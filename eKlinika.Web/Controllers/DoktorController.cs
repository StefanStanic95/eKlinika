using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using eKlinika.ViewModels;
using eKlinika.Data;
using eKlinika.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using eKlinika.Util;
using Microsoft.AspNetCore.Http;


using eKlinika.Util.FileManager;
using eKlinika.Helper;

namespace eKlinika.Controllers
{
    [Autorizacija(doktor:true, administrator: true)]
    public class DoktorController : Controller
    {
        private readonly IHostingEnvironment hosting;
        private ApplicationDbContext _db;
        private ImgUploadHelper _imgHelper;
        private UserManagementHelper _userManagementHelper;
        private IUserManager _userManager;


        public DoktorController(ApplicationDbContext db,IHostingEnvironment environment,IFileManager manager, IUserManager userManager)
        {
            _db = db;
            hosting = environment;
            _imgHelper = new ImgUploadHelper(hosting,manager);
            _userManagementHelper = new UserManagementHelper(_db);
            _userManager = userManager;


        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dodaj()
        {
            OsobljeVM model = _userManagementHelper.prepDoktor();
            return View("Dodaj", model);
        }

        [HttpPost]
        public IActionResult Dodaj(OsobljeVM model,IFormFile imgInp)
        {
            bool x = _userManager.RoleExists("Doktor");

            if (!x)
            {
                _userManager.CreateRole(new Uloge
                {
                    Naziv = "Doktor"
                });
            }


            string password = "mostar123";

            Korisnici user = new Korisnici
            {
                JMBG = model.JMBG,
                Ime = model.Ime,
                Prezime = model.Prezime,
                DatumRodjenja = model.DatumRodjenja,
                Telefon = model.Telefon,
                Spol = model.Spol,
                Ulica = model.Ulica,
                Broj = model.Broj,
                Slika = _imgHelper.GetImgLocationAsync(imgInp),
                UserName = model.Ime + '.' + model.Prezime,
                Email = model.Ime + "." + model.Prezime + "@eKlinika.com"//,
            };

            Korisnici chkUser = _userManager.CreateUser(user, password);

            _userManager.AddUserToRole(user, "Doktor");

            Osoblje osoblje = new Osoblje
            {
                Id = user.Id,
                DatumZaposlenja = model.DatumZaposlenja,
                TrajanjeUgovora = model.TipZaposlenja == "Stalno" ? "Neodredjeno" : model.TrajanjeUgovora,
                Jezici = model.Jezici,
                GodineStaza = model.GodineStaza,
                TipZaposlenja = model.TipZaposlenja
            };

            _db.Add(osoblje);
            _db.SaveChanges();

            Doktor doktor = new Doktor
            {
                Id = user.Id,
                Specijalizacija = model.Specijalizcija,
                DatumSpecijalizacije = model.DatumSpecijalizacije,
                Titula = model.Titula
            };

            _db.Add(doktor);
            _db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }


        // *************** UPUTNICE SA ODABIROM PACIJENTA *************** 
        public IActionResult UputnicaIndex()
        {
            UputnicaIndexVM vm = new UputnicaIndexVM()
            {
                Pacijenti = _db.Pacijent
                    .Include(p => p.Korisnici)
                    .Select(p => new SelectListItem
                    {
                        Value = p.Id.ToString(),
                        Text = p.Korisnici.Ime + " " + p.Korisnici.Prezime + " (" + p.Korisnici.JMBG + ")"
                    }).ToList()


            };

            return View(vm);
        }

        public IActionResult UputnicaPrikazPacijenta(int PacijentId)
        {

            UputnicaPrikazPacijentaVM VM = new UputnicaPrikazPacijentaVM()
            {

                Pacijent = _db.Pacijent
                    .Include(p => p.Korisnici)
                    .Include(p => p.Korisnici.Grad)
                    .Include(p => p.KrvnaGrupa)
                    .FirstOrDefault(p => p.Id == PacijentId),

                PacijentId = PacijentId
            };

            return View(VM);

        }

        public IActionResult UputnicaDodaj(int Id)
        {

            List<SelectListItem> doktori = _db.Doktor
                .Include(p => p.Osoblje.Korisnici)
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Titula + " " + p.Osoblje.Korisnici.Ime + " " + p.Osoblje.Korisnici.Prezime
                }).ToList();

            List<SelectListItem> pretrage = _db.VrstaPretrage
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Naziv.ToString()
                }).ToList();

            var viewModel = new UputnicaDodajVM
            {
                PacijentId = Id,
                Doktori = doktori,
                VrstePretrage = pretrage,
                DatumUputnice = DateTime.Now,
                DatumRezultata = DateTime.Now
            };

            return PartialView(viewModel);
        }

        [HttpPost]
        public IActionResult UputnicaDodaj(UputnicaDodajVM model)
        {
            var novaUputnica = new Uputnica
            {
                UputioDoktorId = model.DoktorId,
                LaboratorijDoktorId = model.LabDoktorId,
                PacijentId = model.PacijentId,
                VrstaPretrageId = model.VrstePretrageId,
                DatumUputnice = model.DatumUputnice,
                DatumRezultata = model.DatumRezultata,
                IsGotovNalaz = model.IsGotovNalaz
            };
            _db.Add(novaUputnica);
            _db.SaveChanges();

            return RedirectToAction("UputnicaPrikazi", new { Id = model.PacijentId });
        }

        public IActionResult UputnicaPrikazi(int Id)
        {
            UputnicaPrikaziVM VM = new UputnicaPrikaziVM()
            {
                PacijentId = Id,

                Uputnice =
                    _db.Uputnica.Include(x => x.Pacijent)
                    .Where(x => x.PacijentId == Id)
                    .Include(x => x.UputioDoktor)
                    .Select(x => new UputnicaPrikaziVM.UputniceRow()
                    {
                        UputnicaId = x.Id,
                        DatumRezultata = x.DatumRezultata,
                        DatumUputnice = x.DatumUputnice,
                        Pacijent = x.Pacijent.Korisnici.Ime + " " + x.Pacijent.Korisnici.Prezime,
                        UputioLjekar = x.UputioDoktor.Titula + " " + x.UputioDoktor.Osoblje.Korisnici.Ime + " " + x.UputioDoktor.Osoblje.Korisnici.Prezime,
                        LabLjekar = x.LaboratorijDoktor.Titula + " " + x.LaboratorijDoktor.Osoblje.Korisnici.Ime + " " + x.LaboratorijDoktor.Osoblje.Korisnici.Prezime,
                        VrstaPretrage = x.VrstaPretrage.Naziv,
                        IsGotovNalaz = x.IsGotovNalaz
                    }).ToList()
            };
            return PartialView(VM);
        }

        public IActionResult UputnicaDetalji(int uputnicaId)
        {
            UputnicaDetaljiVM vm = new UputnicaDetaljiVM()
            {
                Uputnica = _db.Uputnica.Include(x => x.UputioDoktor).Include(x => x.VrstaPretrage).Where(x => x.Id == uputnicaId).Select(x => new UputnicaDetaljiVM.Detalj()
                {
                    UputnicaId = uputnicaId,
                    DatumRezultata = x.DatumRezultata,
                    DatumUputnice = x.DatumUputnice,
                    Pacijent = x.Pacijent.Korisnici.Ime + " " + x.Pacijent.Korisnici.Prezime,
                    Doktor = x.UputioDoktor.Titula + " " + x.UputioDoktor.Osoblje.Korisnici.Ime + " " + x.UputioDoktor.Osoblje.Korisnici.Prezime,
                    VrstaPretrage = x.VrstaPretrage.Naziv,
                    IsGotovNalaz = x.IsGotovNalaz
                }).FirstOrDefault()
            };

            return View(vm);
        }

        public IActionResult UputnicaUredi(int id)
        {
            var uputnica = _db.Uputnica
                .Include(u => u.Pacijent)
                .Include(u => u.UputioDoktor)
                .Include(u => u.VrstaPretrage)
                .FirstOrDefault(u => u.Id == id);


            var pacijenti = _db.Pacijent.Include(p => p.Korisnici).Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Korisnici.Ime + " " + p.Korisnici.Prezime

            }).ToList();

            var doktori = _db.Doktor.Include(p => p.Osoblje.Korisnici).Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Titula + " " + p.Osoblje.Korisnici.Ime + " " + p.Osoblje.Korisnici.Prezime

            }).ToList();

            var vrPretrage = _db.VrstaPretrage.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Naziv

            }).ToList();

            var model = new UputnicaUrediVM
            {
                Id = uputnica.Id,
                Pacijenti = pacijenti,
                Doktori = doktori,
                VrstePretraga = vrPretrage
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult UputnicaUredi(UputnicaUrediVM model)
        {
            var uputnica = _db.Uputnica
                .Include(u => u.Pacijent)
                .Include(u => u.UputioDoktor)
                .Include(u => u.VrstaPretrage)
              .FirstOrDefault(p => p.Id == model.Id);

            uputnica.UputioDoktorId = model.UputioDoktorId;
            uputnica.VrstaPretrageId = model.VrstaPretrageId;

            _db.SaveChanges();
            return RedirectToAction("UputnicaIndex");
        }

    }
}