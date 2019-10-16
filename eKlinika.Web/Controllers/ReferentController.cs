using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eKlinika.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using eKlinika.Data;
using eKlinika.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using eKlinika.Util;

using Microsoft.AspNetCore.Hosting.Server;
using eKlinika.Util.FileManager;
using eKlinika.Helper;

namespace eKlinika.Controllers
{
    [Autorizacija(referent: true, administrator: true)]
    public class ReferentController : Controller
    {
        private ApplicationDbContext _db;
        private ImgUploadHelper _imgHelper;
        private UserManagementHelper _userManagementHelper;
        private IUserManager _userManager;

        


        public ReferentController(ApplicationDbContext db, IUserManager userManager)
        {
            _db = db;
            _imgHelper = new ImgUploadHelper();
            _userManagementHelper = new UserManagementHelper(_db);
            _userManager = userManager;


        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dodaj()
        {
            PacijentVM model = _userManagementHelper.prepPacijent();

            return View("Dodaj", model);
        }
        [HttpPost]
        public IActionResult Dodaj(PacijentVM model, IFormFile imgInp)
        {


            bool x = _userManager.RoleExists("Pacijent");

            if (!x)
            {
                _userManager.CreateRole(new Uloge
                {
                    Naziv = "Pacijent"
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
                GradId= model.GradId,
                Slika = _imgHelper.GetImgLocationAsync(imgInp),
                Email = model.Ime + "." + model.Prezime + "eKlinika.com",
                UserName = model.Ime + "." + model.Prezime

            };

            /*Korisnici chkUser = */
            _userManager.CreateUser(user, password);

            _userManager.AddUserToRole(user, "Pacijent");




            Pacijent pacijent = new Pacijent
            {
                Id = user.Id,
                BrojKnjizice = model.BrojKnjizice,
                BrojKartona = model.BrojKartona,
                DatumRegistracije = model.DatumRegistracije,
                Visina = model.Visina,
                Tezina = model.Tezina,
                Alergije = model.Alergije,
                SpecijalniZahtjevi = model.SpecijalniZahtjevi,
                KrvnaGrupaId = model.KrvnaGrupaId
            };

            _db.Add(pacijent);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Pretraga(string Text=" ")
        {
            PacijentPretragaVM rezultat = new PacijentPretragaVM
            {

                Pacijenti =  !string.IsNullOrEmpty(Text)?_db.Pacijent.Include(x => x.Korisnici).Where(x => x.Korisnici.Ime.ToLower().Contains(Text.ToLower())
                                  || x.Korisnici.Prezime.ToLower().Contains(Text.ToLower())
                                  || (x.Korisnici.Ime + " " + x.Korisnici.Prezime).ToLower().Contains(Text.ToLower())).OrderBy(x => x.Korisnici.Ime).ToList(): _db.Pacijent.Include(x => x.Korisnici).OrderBy(x => x.Korisnici.Ime).ToList(),
                Text = Text
            };
            return View(rezultat);

    }

    public IActionResult Detalji(int PacijentId)
    {
        Pacijent model = _db.Pacijent
                .Include(x => x.Korisnici)
                    .ThenInclude(x => x.Grad)
                .Include(x=>x.KrvnaGrupa)
                .Where(x => x.Id == PacijentId)
                .FirstOrDefault();
        return View(model);
    }

        public IActionResult Uredi(int Id)
        {
            Pacijent pacijent = _db.Pacijent
                .Include(p=>p.Korisnici)
                    .ThenInclude(x => x.Grad)
                .FirstOrDefault(p => p.Id == Id);

            var krvnegrupe = _db.KrvnaGrupa.Select(k => new SelectListItem
            {
                Value = k.Id.ToString(),
                Text = k.Naziv

            }).ToList();

            var gradovi = _db.Grad.Select(k => new SelectListItem
            {
                Value = k.Id.ToString(),
                Text = k.Naziv

            }).ToList();


            List<SelectListItem> spolovi = new List<SelectListItem>();
            spolovi.Add(new SelectListItem()
            {
                Value = "Musko",
                Text = "Musko"
            });
            spolovi.Add(new SelectListItem()
            {
                Value = "Zensko",
                Text = "Zensko"
            });

            var model = new PacijentUrediVM
            {
                Id = pacijent.Id,
                Ime = pacijent.Korisnici.Ime,
                Prezime = pacijent.Korisnici.Prezime,
                BrojKnjizice = pacijent.BrojKnjizice,
                BrojKartona = pacijent.BrojKartona,
                DatumRegistracije = pacijent.DatumRegistracije,
                Visina = pacijent.Visina,
                Tezina = pacijent.Tezina,
                Alergije = pacijent.Alergije,
                SpecijalniZahtjevi = pacijent.SpecijalniZahtjevi,
                Gradovi = gradovi,
                KrvneGrupe = krvnegrupe,
                Ulica = pacijent.Korisnici.Ulica,
                DatumRodjenja = pacijent.Korisnici.DatumRodjenja,
                Broj = pacijent.Korisnici.Broj,
                JMBG = pacijent.Korisnici.JMBG,
                Telefon = pacijent.Korisnici.Telefon,
                Grad = _db.Grad.FirstOrDefault(g => g.Id == pacijent.Korisnici.GradId).Naziv,
                Slika = pacijent.Korisnici.Slika != null ? Convert.ToBase64String(pacijent.Korisnici.Slika) : null,
                Spol = pacijent.Korisnici.Spol,
                Spolovi = spolovi
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Uredi(PacijentUrediVM model, IFormFile imgInp)
        {
            var pacijent = _db.Pacijent
              .Include(p => p.Korisnici)
              .Include(p => p.Korisnici.Grad)
              .Include(p => p.KrvnaGrupa)
              .Where(p => p.Id != null)
              .FirstOrDefault(p => p.Id == model.Id);

            pacijent.Korisnici.Ime = model.Ime;
            pacijent.Korisnici.Prezime = model.Prezime;
            pacijent.Korisnici.Spol = model.Spol;
            pacijent.Korisnici.JMBG = model.JMBG;
            pacijent.Korisnici.DatumRodjenja = model.DatumRodjenja;
            pacijent.Korisnici.GradId = Convert.ToInt32(model.Grad);
            pacijent.Korisnici.Ulica = model.Ulica;
            pacijent.Korisnici.Broj = model.Broj;
            pacijent.BrojKnjizice = model.BrojKnjizice;
            pacijent.BrojKartona = model.BrojKartona;
            pacijent.DatumRegistracije = model.DatumRegistracije;
            pacijent.Korisnici.Telefon = model.Telefon;
            pacijent.Visina = model.Visina;
            pacijent.Tezina = model.Tezina;
            pacijent.Alergije = model.Alergije;
            pacijent.SpecijalniZahtjevi = model.SpecijalniZahtjevi;
            pacijent.KrvnaGrupaId = Convert.ToInt32(model.KrvnaGrupa);
            if (imgInp != null)
                pacijent.Korisnici.Slika = _imgHelper.GetImgLocationAsync(imgInp);

            _db.SaveChanges();
            return RedirectToAction("Pretraga");
        }

        public IActionResult Izbrisi(int Id)
        {
            Pacijent pacijent = _db.Pacijent.FirstOrDefault(l => l.Id == Id);
            var pregledi = _db.Pregled.Where(p => p.Pacijent.Id == Id);
            var uplate = _db.Uplata.Where(p => p.Pacijent.Id == Id);
            var uputnice = _db.Uputnica.Where(p => p.Pacijent.Id == Id);

            _db.SaveChanges();

            if (pacijent != null)
            {
                _db.Pacijent.Remove(pacijent);
                _db.SaveChanges();
            }

            return RedirectToAction("Pretraga");
        }
    }
}