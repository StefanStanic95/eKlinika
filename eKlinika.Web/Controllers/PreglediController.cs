using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eKlinika.Data;
using eKlinika.Helper;
using eKlinika.Models;
using eKlinika.Util;
using eKlinika.ViewModels;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eKlinika.Controllers
{
    [Autorizacija(doktor: true, administrator: true)]
    public class PreglediController : Controller
    {
        private ApplicationDbContext _db;
        private UserManagementHelper _userManagementHelper;
        private IUserManager _userManager;



        public PreglediController(ApplicationDbContext db, IUserManager userManager)
        {
            _db = db;
            _userManagementHelper = new UserManagementHelper(_db);
            _userManager = userManager;


        }
        public IActionResult Index()
        {
            var currentUser = HttpContext.GetLogiraniKorisnik().Id;
            List<PreglediIndexVM> model = _db.Pregled
                .Include(x => x.Pacijent)
                .Include(x => x.Doktor)
                .Include(x => x.MedicinskaSestra)
                .Where(x => !x.isOdrzan && (currentUser == x.DoktorId || HttpContext.GetUlogaKorisnika(0).Naziv == "Administrator"))
                .Select(
                x => new PreglediIndexVM
                {
                    Id = x.Id,
                    DatumPregleda = x.DatumPregleda,
                    Doktor = x.Doktor.Titula + ". " + x.Doktor.Osoblje.Korisnici.Ime + " " + x.Doktor.Osoblje.Korisnici.Prezime,
                    Pacijent = x.Pacijent.Korisnici.Ime + " " + x.Pacijent.Korisnici.Prezime

                }
                ).ToList();

            return View(model);
        }

        public IActionResult LandingPage()
        {
            return View();
        }

        public IActionResult RezervacijaTermina()
        {
            TerminRezervacijaVM model = _userManagementHelper.prepRezervaciju();
            return View(model);
        }

        [HttpPost]
        public IActionResult RezervacijaTermina(TerminRezervacijaVM model)
        {
            Pregled pregled = new Pregled
            {
                DatumPregleda = DateTime.Parse(model.DatumTermina + " " + model.VrijemeTermina),
                TipPregleda = model.TipPregleda,
                Napomena = model.Napomena,
                DatumRezervacije = DateTime.Now,
                isOdrzan = false,
                MedicinskaSestraId = model.MedicinskaSestraId,
                DoktorId = model.DoktorId,
                PacijentId = model.PacijentId
            };

            _db.Add(pregled);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Otkazi(int Id)
        {
            Pregled pregledDel = _db.Pregled.Where(x => x.Id == Id).FirstOrDefault();

            _db.Remove(pregledDel);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult EvidencijaPregleda(int Id)
        {
            TerminEvidencijaVM model = _userManagementHelper.prepPregledEvidencija(Id);
            return View(model);
        }

        [HttpPost]
        public IActionResult EvidencijaPregleda(TerminEvidencijaVM model)
        {
            Pregled evidentiraniPregled = _db.Pregled.Where(x => x.Id == model.TerminId).FirstOrDefault();
            evidentiraniPregled.Napomena = string.IsNullOrEmpty(model.Napomena) ? string.Empty : model.Napomena;
            evidentiraniPregled.isOdrzan = true;
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult ReceptiIndex(int Id)
        {
            PropisaniLijekoviIndexVM model = new PropisaniLijekoviIndexVM
            {
                PregledId = Id,
                Recepti = _db.Recept.Include(x => x.Lijek).Where(x => x.PregledId == Id).ToList()
            };
            return PartialView(model);
        }
        public IActionResult DetailsReceptIndex(int Id)
        {
            PropisaniLijekoviIndexVM model = new PropisaniLijekoviIndexVM
            {
                PregledId = Id,
                Recepti = _db.Recept.Include(x => x.Lijek).Where(x => x.PregledId == Id).ToList()
            };
            return PartialView(model);
        }
        public IActionResult IzdavanjeRecepta(int Id)
        {
            PropisaniLijekoviVM model = new PropisaniLijekoviVM
            {
                PregledId = Id,
                Lijekovi = _db.Lijek.Select(x => new SelectListItem
                {
                    Text = x.Naziv + " ( " + x.Tip + " )",
                    Value = x.Id.ToString()
                }).ToList()
            };

            return PartialView(model);
        }
        [HttpPost]
        public IActionResult IzdavanjeRecepta(PropisaniLijekoviVM model)
        {
            Recept newRecept = new Recept
            {
                PregledId = model.PregledId,
                LijekId = model.LijekId,
                Uputstvo = model.Uputstvo,
                Kolicina = model.Kolicina,
                IsObradjen = false
            };

            _db.Add(newRecept);
            _db.SaveChanges();

            return RedirectToAction("EvidencijaPregleda", new { Id = model.PregledId });
        }

        public IActionResult UkloniRecept(int Id)
        {
            Recept model = _db.Recept.Where(x => x.Id == Id).FirstOrDefault();
            int pregledId = model.PregledId;
            _db.Remove(model);
            _db.SaveChanges();
            return RedirectToAction("EvidencijaPregleda", "Pregledi", new { Id = pregledId });
        }

        public IActionResult ReceptDetails(int Id)
        {
            Recept model = _db.Recept.Include(x => x.Lijek).Where(x => x.Id == Id).FirstOrDefault();
            return PartialView(model);
        }

        public IActionResult Details(int Id)
        {
            Pregled pregled = _db.Pregled.Include(x => x.Doktor).ThenInclude(x => x.Osoblje).ThenInclude(x => x.Korisnici).
                Include(x => x.Pacijent).ThenInclude(x => x.Korisnici).FirstOrDefault(x => x.Id == Id);
            return View(pregled);
        }

        public IActionResult Pretraga(string doktor = "", string pacijent = "", string datum = "")
        {
            string tempDoktor = string.IsNullOrEmpty(doktor) ? string.Empty : doktor.ToLower();
            string tempPacijent = string.IsNullOrEmpty(pacijent) ? string.Empty : pacijent.ToLower();
            string tempDatum = string.IsNullOrEmpty(datum) ? string.Empty : datum;
            PreglediPretragaVM model = new PreglediPretragaVM
            {
                Doktor = tempDoktor,
                Pacijent = tempPacijent,
                Datum = tempDatum,
                Pregledi = _db.Pregled.Include(x => x.Doktor).ThenInclude(x => x.Osoblje).ThenInclude(x => x.Korisnici).
                Include(x => x.Pacijent).ThenInclude(x => x.Korisnici).
                Where(x => (x.Doktor.Osoblje.Korisnici.Ime + " " + x.Doktor.Osoblje.Korisnici.Prezime).ToLower().Contains(tempDoktor) &&
                (x.Pacijent.Korisnici.Ime + " " + x.Pacijent.Korisnici.Prezime).ToLower().Contains(tempPacijent) &&
                x.DatumPregleda.Date.ToString().Contains(tempDatum)).ToList()
            };
            return View(model);
        }

        public string getJsonResponse(string date, int DoktorId)
        {
            return _userManagementHelper.SerializeObject(date, DoktorId);
        }
    }
}