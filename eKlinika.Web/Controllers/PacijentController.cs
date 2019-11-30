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
    [Autorizacija(pacijent: true, administrator:true)]
    public class PacijentController : Controller
    {
        private ApplicationDbContext _db;
        private ImgUploadHelper _imgHelper;

        public PacijentController(ApplicationDbContext db)
        {
            _db = db;
            _imgHelper = new ImgUploadHelper();
        }
        public IActionResult Index()
        {
            Korisnici user = HttpContext.GetLogiraniKorisnik();

            return View(user);
        }

        public IActionResult Profil()
        {
            Korisnici user = HttpContext.GetLogiraniKorisnik();

            Pacijent model = _db.Pacijent
                .Include(x => x.Korisnici)
                   .ThenInclude(x => x.Grad)
                .Include(x => x.KrvnaGrupa)
                .Where(x => x.Id == user.Id)
                .FirstOrDefault();

            return View(model);
        }

        public IActionResult Uredi()
        {
            Korisnici user = HttpContext.GetLogiraniKorisnik();

            Pacijent pacijent = _db.Pacijent
                .Include(p => p.Korisnici)
                   .ThenInclude(x => x.Grad)
                .FirstOrDefault(p => p.Id == user.Id);

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
                Spol = pacijent.Korisnici.Spol
            };
            model.Spolovi = new List<SelectListItem>();
            model.Spolovi.Add(new SelectListItem
            {
                Text = "Musko",
                Value = "Musko"
            });
            model.Spolovi.Add(new SelectListItem
            {
                Text = "Zensko",
                Value = "Zensko"
            });

            return View(model);
        }

        [HttpPost]
        public IActionResult Uredi(PacijentUrediVM model, IFormFile imgInp)
        {
            Korisnici user = HttpContext.GetLogiraniKorisnik();

            var pacijent = _db.Pacijent
          .Include(p => p.Korisnici)
          .Include(p => p.Korisnici.Grad)
          .Include(p => p.KrvnaGrupa)
          .FirstOrDefault(p => p.Id == user.Id);

            pacijent.Korisnici.Telefon = model.Telefon;
            pacijent.Korisnici.Ulica = model.Ulica;
            pacijent.Korisnici.Broj = model.Broj;
            pacijent.Korisnici.GradId = Convert.ToInt32(model.Grad);
            pacijent.Korisnici.Spol = model.Spol;
            pacijent.Visina = model.Visina;
            pacijent.Tezina = model.Tezina;
            pacijent.Alergije = model.Alergije;
            pacijent.SpecijalniZahtjevi = model.SpecijalniZahtjevi;
            if (imgInp != null)
                pacijent.Korisnici.Slika = _imgHelper.GetImgLocationAsync(imgInp);


            _db.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Uplata()
        {
            Korisnici user = HttpContext.GetLogiraniKorisnik();

            PacijentUplataVM VM = new PacijentUplataVM
            {
                rows = _db.Uplata
                .Where(x => x.PacijentId == user.Id)
                .Select(x => new PacijentUplataVM.Row
                {
                    Id = x.Id,
                    BrojUplatnice = x.BrojUplatnice,
                    DatumUplate = x.DatumUplate,
                    Iznos = x.Iznos,
                    Namjena = x.Namjena,
                    ZiroRacun = x.ZiroRacun
                })
                .ToList()
            };

            return View(VM);
        }

        public IActionResult Uputnica()
        {
            Korisnici user = HttpContext.GetLogiraniKorisnik();

            UputnicaPrikaziVM VM = new UputnicaPrikaziVM()
            {
                Uputnice =
                    _db.Uputnica.Include(x => x.Pacijent)
                    .Where(x => x.PacijentId == user.Id)
                    .Select(x => new UputnicaPrikaziVM.UputniceRow()
                    {
                        UputnicaId = x.Id,
                        DatumRezultata = x.DatumRezultata,
                        DatumUputnice = x.DatumUputnice,
                        Pacijent = x.Pacijent.Korisnici.Ime + " " + x.Pacijent.Korisnici.Prezime,
                        UputioLjekar = x.UputioDoktor.Titula + " " + x.UputioDoktor.Osoblje.Korisnici.Ime + " " + x.UputioDoktor.Osoblje.Korisnici.Prezime,
                        LabLjekar = (x.LaboratorijDoktor != null ?
                            x.LaboratorijDoktor.Titula + " " + x.LaboratorijDoktor.Osoblje.Korisnici.Ime + " " + x.LaboratorijDoktor.Osoblje.Korisnici.Prezime : "(nema rezultata)"),
                        VrstaPretrage = x.VrstaPretrage.Naziv,
                        IsGotovNalaz = x.IsGotovNalaz
                    }).ToList()
            };

            return View(VM);
        }


        public IActionResult Pregled()
        {
            Korisnici user = HttpContext.GetLogiraniKorisnik();

            var pregledi = _db.Pregled
                .Where(p => p.PacijentId == user.Id && p.PacijentId != null && p.MedicinskaSestraId != null && p.DoktorId != null)
                .Select(p => new PregledIndexVM
                {
                    Id = p.Id,
                    DatumPregleda = p.DatumPregleda,
                    TipPregleda = p.TipPregleda,
                    Napomena = p.Napomena,
                    Prioritet = p.Prioritet,
                    DatumRezervacije = p.DatumRezervacije,
                    MedSestra = p.MedicinskaSestra.Osoblje.Korisnici.Ime + " " + p.MedicinskaSestra.Osoblje.Korisnici.Prezime,
                    Doktor = p.Doktor.Titula + " " + p.Doktor.Osoblje.Korisnici.Ime + " " + p.Doktor.Osoblje.Korisnici.Prezime,
                }).ToList();

            var model = new PregledIndexListVM
            {
                Pregledi = pregledi
            };

            return View(model);
        }


    }
}