using eKlinika.Data;
using eKlinika.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using eKlinika.Models;

namespace eKlinika.Util
{
    public class UserManagementHelper
    {
        private ApplicationDbContext _db;

        public UserManagementHelper(ApplicationDbContext db)
        {
            _db = db;
        }

        public PacijentVM prepPacijent()
        {

            PacijentVM model = new PacijentVM();

            model.DatumRegistracije = DateTime.Now;
            model.DatumRodjenja = DateTime.Now;
            model.Spolovi = new List<SelectListItem>();
            model.Spolovi.Add(new SelectListItem()
            {
                Value = "Musko",
                Text = "Musko"
            });
            model.Spolovi.Add(new SelectListItem()
            {
                Value = "Zensko",
                Text = "Zensko"
            });

            model.Gradovi = _db.Grad.Include(x => x.Drzava).Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Naziv + ", " + x.Drzava.Oznaka
            }).ToList();

            model.KrvneGrupe = _db.KrvnaGrupa.Select(x => new SelectListItem()
            {
                Value = x.Id.ToString(),
                Text = x.Naziv
            }).ToList();

            return model;
        }
        public OsobljeVM prepMedSestra()
        {
            OsobljeVM model = new OsobljeVM();

            model.DatumRodjenja = DateTime.Now;
            model.DatumZaposlenja = DateTime.Now;

            model.Gradovi = _db.Grad.Include(x => x.Drzava).Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Naziv + ", " + x.Drzava.Naziv

            }).ToList();

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

            model.TipoviZaposlenja = new List<SelectListItem>();
            model.TipoviZaposlenja.Add(new SelectListItem
            {
                Value = "Stalno",
                Text = "Stalno"
            });

            model.TipoviZaposlenja.Add(new SelectListItem
            {
                Value = "Na odredjeno vrijeme",
                Text = "Na odredjeno vrijeme"
            });

            return model;
        }
        public OsobljeVM prepDoktor()
        {
            OsobljeVM model = new OsobljeVM();

            model.DatumRodjenja = DateTime.Now;
            model.DatumZaposlenja = DateTime.Now;
            model.DatumSpecijalizacije = DateTime.Now;

            model.Gradovi = _db.Grad.Include(x => x.Drzava).Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Naziv + ", " + x.Drzava.Naziv

            }).ToList();

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

            model.TipoviZaposlenja = new List<SelectListItem>();
            model.TipoviZaposlenja.Add(new SelectListItem
            {
                Value = "Stalno",
                Text = "Stalno"
            });

            model.TipoviZaposlenja.Add(new SelectListItem
            {
                Value = "Na odredjeno vrijeme",
                Text = "Na odredjeno vrijeme"
            });

            return model;
        }
        public OsobljeVM prepApotekar()
        {
            OsobljeVM model = new OsobljeVM();

            model.DatumRodjenja = DateTime.Now;
            model.DatumZaposlenja = DateTime.Now;

            model.Gradovi = _db.Grad.Include(x => x.Drzava).Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Naziv + ", " + x.Drzava.Naziv

            }).ToList();

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

            model.TipoviZaposlenja = new List<SelectListItem>();
            model.TipoviZaposlenja.Add(new SelectListItem
            {
                Value = "Stalno",
                Text = "Stalno"
            });

            model.TipoviZaposlenja.Add(new SelectListItem
            {
                Value = "Na odredjeno vrijeme",
                Text = "Na odredjeno vrijeme"
            });

            return model;
        }
        public TerminRezervacijaVM prepRezervaciju()
        {
            TerminRezervacijaVM model = new TerminRezervacijaVM();
            model.DatumRezervacije = DateTime.Now;
            model.TipoviPregleda = new List<SelectListItem>();
            model.TipoviPregleda.Add(new SelectListItem
            {
                Text = "Redovni",
                Value = "Redovni"
            });
            model.TipoviPregleda.Add(new SelectListItem
            {
                Text = "Prezervacijski",
                Value = "Prezervacijski"
            });

            model.Doktori = _db.Doktor.Select(x => new SelectListItem {
                Text = x.Titula + " " + x.Osoblje.Korisnici.Ime + " " + x.Osoblje.Korisnici.Prezime,
                Value = x.Id.ToString()
            }).ToList();

            model.MedSestre = _db.MedicinskaSestra.Select(x => new SelectListItem {
                Text=x.Osoblje.Korisnici.Ime+" "+x.Osoblje.Korisnici.Prezime,
                Value=x.Id.ToString()
            }).ToList();

            model.Pacijenti = _db.Pacijent.Select(x => new SelectListItem {
                Text=x.Korisnici.Ime+" "+x.Korisnici.Prezime,
                Value=x.Id.ToString()
            }).ToList();
            model.DatumTermina = DateTime.Now.Date.ToShortDateString();
            return model;
        }
        public TerminEvidencijaVM prepPregledEvidencija(int PregledId)
        {
            TerminEvidencijaVM model = _db.Pregled.Where(x => x.Id == PregledId).Select(x => new TerminEvidencijaVM
            {
                TerminId = x.Id,
                Doktor = x.Doktor.Titula + " " + x.Doktor.Osoblje.Korisnici.Ime + " "
                + x.Doktor.Osoblje.Korisnici.Prezime,
                PacijentId = x.PacijentId,
                DatumPregleda = x.DatumPregleda.Date.ToShortDateString(),
                DatumRezervacije = x.DatumRezervacije.Date.ToShortDateString(),
                VrijemePregleda = x.DatumPregleda.Hour.ToString() + ":" + x.DatumPregleda.Minute.ToString()
            }).FirstOrDefault();

            model.Pacijent = prepPacijentShort(model.PacijentId);

            return model;
        }

        public PacijentShortVM prepPacijentShort(int PacijentId)
        {
            PacijentShortVM model = _db.Pacijent.Where(x => x.Id == PacijentId).Select(x => new PacijentShortVM
            {
                PacijentId = x.Id,
                ImePrezime = x.Korisnici.Ime + " " + x.Korisnici.Prezime,
                Spol = x.Korisnici.Spol,
                Starost = (DateTime.Now.Year-x.Korisnici.DatumRodjenja.Year).ToString(),
                BrojKartona=x.BrojKartona,
                BrojKnjizice=x.BrojKnjizice,
                Image= x.Korisnici.Slika != null ? Convert.ToBase64String(x.Korisnici.Slika) : null
            }).FirstOrDefault();
            return model;
        }
        public string SerializeObject(string datum, int DoktorId)
        {
            List<int> sati = _db.Pregled.Where(x=>x.DatumPregleda.Date.ToString()==datum && x.DoktorId==DoktorId).Select(x=>x.DatumPregleda.Hour).Distinct().ToList();

            List<DateTime> datumi = _db.Pregled.Where(x=>x.DatumPregleda.Date.ToString()==datum && x.DoktorId == DoktorId).Select(x => x.DatumPregleda).ToList();
            Dictionary<int, List<int>> zauzetaVremena= new Dictionary<int, List<int>>();

            foreach (var item in sati) {
                zauzetaVremena.Add(item, datumi.Where(x => x.Hour == item).Distinct().Select(x => x.Minute).ToList());
            }
            var res = JsonConvert.SerializeObject(zauzetaVremena);
            return res;
        }
    }
}
