using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using eKlinika.Data;
using eKlinika.Helper;
using eKlinika.Models;
using eKlinika.ViewModels;


using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eKlinika.Controllers
{
    [Autorizacija(apotekar: true, administrator: true)]
    public class ApotekaController : Controller
    {
        private ApplicationDbContext _context;




        public ApotekaController(ApplicationDbContext context)
        {
            _context = context;


        }

        //LIJEKOVI
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult LijekLibrary()
        {
            var lijekovi = _context.Lijek.Select(l => new LijekVM
            {
                Id = l.Id,
                Naziv = l.Naziv,
                UkupnoNaStanju = l.UkupnoNaStanju,
                Uputstvo = l.Uputstvo,
                Tip = l.Tip,
                CijenaPoKomadu = l.CijenaPoKomadu,
                PoReceptu = l.PoReceptu,
                Proizvodjac = l.Proizvodjac.Naziv
            }).ToList();

            LijekListVM model = new LijekListVM
            {
                Lijekovi = lijekovi
            };
            return View(model);
        }

        public IActionResult Dodaj()
        {
            List<SelectListItem> proizvodjaci = _context.Proizvodjac.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Naziv
            }).ToList();


            LijekDodajVM model = new LijekDodajVM
            {
                Proizvodjaci = proizvodjaci
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Dodaj(LijekDodajVM model)
        {
            if (ModelState.IsValid)
            {
                int id = Convert.ToInt32(model.Proizvodjac);

                Lijek noviLijek = new Lijek
                {
                    Naziv = model.Naziv,
                    CijenaPoKomadu = model.CijenaPoKomadu,
                    Tip = model.Tip,
                    PoReceptu = model.PoReceptu,
                    UkupnoNaStanju = model.UkupnoNaStanju,
                    Uputstvo = model.Uputstvo,
                    ProizvodjacId = id
                };

                _context.Add(noviLijek);
                _context.SaveChanges();
            }


            return RedirectToAction("LijekLibrary");
        }

        public IActionResult Detalji(int Id)
        {
            Lijek lijek = _context.Lijek.Include(l => l.Proizvodjac).FirstOrDefault(l => l.Id == Id);

            LijekVM model = new LijekVM
            {
                Id = lijek.Id,
                Naziv = lijek.Naziv,
                UkupnoNaStanju = lijek.UkupnoNaStanju,
                CijenaPoKomadu = lijek.CijenaPoKomadu,
                PoReceptu = lijek.PoReceptu,
                Proizvodjac = lijek.Proizvodjac.Naziv,
                Tip = lijek.Tip,
                Uputstvo = lijek.Uputstvo
            };

            return View(model);
        }

        public IActionResult UrediLijek(int Id)
        {
            Lijek lijek = _context.Lijek
                .Include(l => l.Proizvodjac)
                .FirstOrDefault(l => l.Id == Id);

            List<SelectListItem> proizvodjaci = _context.Proizvodjac.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Naziv
            }).ToList();

            //greska se javlja ovdje

            LijekDodajVM model = new LijekDodajVM
            {
                Id = lijek.Id,
                Naziv = lijek.Naziv,
                Tip = lijek.Tip,
                UkupnoNaStanju = lijek.UkupnoNaStanju,
                PoReceptu = lijek.PoReceptu,
                Uputstvo = lijek.Uputstvo,
                CijenaPoKomadu = lijek.CijenaPoKomadu,
                Proizvodjac = lijek.Proizvodjac.Naziv.ToString(),
                Proizvodjaci = proizvodjaci
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult UrediLijekSave(LijekDodajVM model)
        {
            if (ModelState.IsValid)
            {
                var lijek = _context.Lijek.FirstOrDefault(l => l.Id == model.Id);

                //_context.Update(lijek);

                lijek.Naziv = model.Naziv;
                lijek.PoReceptu = model.PoReceptu;
                lijek.CijenaPoKomadu = model.CijenaPoKomadu;
                lijek.Tip = model.Tip;
                lijek.ProizvodjacId = Convert.ToInt32(model.Proizvodjac);
                lijek.UkupnoNaStanju = model.UkupnoNaStanju;
                lijek.Uputstvo = model.Uputstvo;
                _context.SaveChanges();

            }
            return RedirectToAction("LijekLibrary");
        }

        public IActionResult IzbrisiLijek(int Id)
        {
            Lijek lijek = _context.Lijek.FirstOrDefault(l => l.Id == Id);

            if (lijek != null)
            {
                _context.Lijek.Remove(lijek);
                _context.SaveChanges();
            }
            return RedirectToAction("LijekLibrary");
        }


        public IActionResult LijekSearch(string search)
        {
            string searchTxt = search.ToLower();


            var listaLijekova = _context.Lijek.Where(l => l.Naziv.ToLower().Contains(searchTxt));


            var lijekovi = listaLijekova.Select(l => new LijekVM
            {
                Id = l.Id,
                Naziv = l.Naziv,
                UkupnoNaStanju = l.UkupnoNaStanju,
                Uputstvo = l.Uputstvo,
                Tip = l.Tip,
                CijenaPoKomadu = l.CijenaPoKomadu,
                PoReceptu = l.PoReceptu,
                Proizvodjac = l.Proizvodjac.Naziv
            }).ToList();

            LijekListVM model = new LijekListVM
            {
                Lijekovi = lijekovi
            };


            return View("LijekLibrary", model);

        }

        //APOTEKARACUNI

        public IActionResult RacuniRecepti()
        {
            return View();
        }

        public IActionResult IzdavanjeRacuna()
        {
            List<SelectListItem> lijekovi = _context.Lijek.Select(p => new SelectListItem
            {
                Text = p.Naziv,
                Value = p.Id.ToString()
            }).ToList();

            List<SelectListItem> pacijenti = _context.Pacijent.Select(p => new SelectListItem
            {
                Text = p.Korisnici.Ime + ' ' + p.Korisnici.Prezime,
                Value = p.Id.ToString()
            }).ToList();

            List<SelectListItem> apotekari = _context.Apotekar.Select(a => new SelectListItem
            {
                Text = a.Osoblje.Korisnici.Ime + ' ' + a.Osoblje.Korisnici.Prezime,
                Value = a.Id.ToString()
            }).ToList();

            var model = new ApotekaRacunVM
            {
                Pacijenti = pacijenti,
                Lijekovi = lijekovi,
                Apotekari = apotekari,
                Datum = DateTime.Now
            };


            return View(model);
        }

        [HttpPost]
        public IActionResult IzdavanjeRacuna2(ApotekaRacunVM2 model, List<string> LijekId)
        {

            Korisnici apotekar = _context.Korisnici.FirstOrDefault(u => u.Id == model.ApotekarId);
            string apotekarIme = apotekar.Ime + ' ' + apotekar.Prezime;

            Korisnici pacijent = _context.Korisnici.FirstOrDefault(u => u.Id == model.PacijentId);
            string pacijentIme = pacijent.Ime + ' ' + pacijent.Prezime;

            ApotekaRacunVM2 model2 = new ApotekaRacunVM2
            {
                ApotekarId = model.ApotekarId,
                ApotekarIme = apotekarIme,
                PacijentId = model.PacijentId,
                PacijentIme = pacijentIme,
                Datum = model.Datum,
                LijekoviIds = LijekId,
                LijekoviNazivi = new List<string>(),
                Kolicine = new List<int>()
            };

            int id = 0;
            foreach (var lijek in model2.LijekoviIds)
            {
                id = Convert.ToInt32(lijek);
                model2.LijekoviNazivi.Add(_context.Lijek.FirstOrDefault(l => l.Id == id).Naziv);
                model2.Kolicine.Add(0);
            }




            return View(model2);
        }

        [HttpPost]
        public IActionResult IzdavanjeRacunaSave(ApotekaRacunVM2 model)
        {

            ApotekaRacun noviRacun = new ApotekaRacun
            {
                DatumIzdavanja = Convert.ToDateTime(model.Datum),
                ApotekarId = HttpContext.GetLogiraniKorisnik().Id, //...
                PacijentId = model.PacijentId
            };
            _context.Add(noviRacun);
            _context.SaveChanges();

            var racunId = _context.ApotekaRacun.Last().Id;
            var id = 0;

            Lijek lijek = null;
            for (int i = 0; i < model.LijekoviIds.Count; i++)
            {
                id = Convert.ToInt32(model.LijekoviIds[i]);

                lijek = _context.Lijek.FirstOrDefault(l => l.Id == id);

                if (lijek.UkupnoNaStanju - model.Kolicine[i] <= 0)
                {
                    lijek.UkupnoNaStanju = 0;
                }
                else
                {
                    lijek.UkupnoNaStanju -= model.Kolicine[i];
                }

                _context.Add(new RacunStavka
                {
                    ApotekaRacunId = racunId,
                    LijekId = id,
                    Kolicina = model.Kolicine[i]
                });
            }

            _context.SaveChanges();

            return RedirectToAction("IzdatiRacuniIndex");
        }

        public IActionResult IspisiArtikle(int racunId)
        {
            var artikli = _context.RacunStavka.Where(rs => rs.ApotekaRacunId == racunId)
                .Select(a => new DodaniArtikalVM
                {
                    ApotekaRacunId = a.ApotekaRacunId,
                    LijekId = a.LijekId,
                    Kolicina = a.Kolicina,
                    RacunStavkaId = a.Id
                }).ToList();

            DodaniArtikalListVM model = new DodaniArtikalListVM
            {
                Artikli = artikli
            };

            return View(model);
        }


        //RECEPTI

        public IActionResult ReceptiIndex()
        {
            var recepti = _context.Recept.Select(r => new ApotekaReceptVM
            {
                ReceptId = r.Id,
                PregledId = r.PregledId,
                DatumIzdavanja = r.DatumIzdavanja,
                DoktorId = r.Pregled.DoktorId,
                PacijentId = r.Pregled.PacijentId,
                Obradjen = r.IsObradjen,
                Kolicina = r.Kolicina,
                LijekId = r.LijekId,
                NazivLijeka = r.Lijek.Naziv
            }).ToList();

            Korisnici pacijent = new Korisnici();
            Korisnici doktor = new Korisnici();

            foreach (var item in recepti)
            {
                pacijent = _context.Korisnici.FirstOrDefault(u => u.Id == item.PacijentId);
                doktor = _context.Korisnici.FirstOrDefault(u => u.Id == item.DoktorId);

                item.PacijentIme = pacijent.Ime + ' ' + pacijent.Prezime;
                item.DoktorIme = doktor.Ime + ' ' + doktor.Prezime;
            }

            ApotekaReceptIndexVM model = new ApotekaReceptIndexVM
            {
                Recepti = recepti
            };

            return View(model);
        }

        public IActionResult ObradiRecept(int Id)
        {
            Recept recept = _context.Recept.Include(r => r.Pregled).FirstOrDefault(r => r.Id == Id);

            var UserId = 0;
            if (HttpContext.GetUlogaKorisnika(0).Naziv == "Apotekar")
                UserId = HttpContext.GetLogiraniKorisnik().Id;
            else
            {
                var apotekar = _context.Apotekar.FirstOrDefault();
                if (apotekar != null)
                    UserId = apotekar.Id;
            }

            if (UserId != 0)
            {

                ApotekaRacun racun = new ApotekaRacun
                {
                    DatumIzdavanja = DateTime.Now,
                    ApotekarId = UserId,
                    PacijentId = recept.Pregled.PacijentId
                };

                _context.Add(racun);
                _context.SaveChanges();

                _context.Add(new RacunStavka
                {
                    ApotekaRacunId = racun.Id,
                    Kolicina = recept.Kolicina,
                    LijekId = recept.LijekId
                });

                recept.IsObradjen = true;

                Lijek lijek = _context.Lijek.FirstOrDefault(l => l.Id == recept.LijekId);
                lijek.UkupnoNaStanju -= recept.Kolicina;


                _context.SaveChanges();

                return RedirectToAction("RacunDetalji", new { Id = racun.Id } );
            }

            return RedirectToAction("IzdatiRacuniIndex");
        }

        public IActionResult FilterRecepti(string value)
        {
            bool obradjen = false;

            switch (value)
            {
                case "0":
                    return RedirectToAction("ReceptiIndex");
                case "1":
                    obradjen = true;
                    break;
                case "2":
                    obradjen = false;
                    break;
            }
            var sviRecepti = _context.Recept.Where(r => r.IsObradjen == obradjen);

            var recepti = sviRecepti.Select(r => new ApotekaReceptVM
            {
                ReceptId = r.Id,
                PregledId = r.PregledId,
                DatumIzdavanja = r.DatumIzdavanja,
                DoktorId = r.Pregled.DoktorId,
                PacijentId = r.Pregled.PacijentId,
                Obradjen = r.IsObradjen,
                Kolicina = r.Kolicina,
                LijekId = r.LijekId,
                NazivLijeka = r.Lijek.Naziv
            }).ToList();

            Korisnici pacijent = new Korisnici();
            Korisnici doktor = new Korisnici();

            foreach (var item in recepti)
            {
                pacijent = _context.Korisnici.FirstOrDefault(u => u.Id == item.PacijentId);
                doktor = _context.Korisnici.FirstOrDefault(u => u.Id == item.DoktorId);

                item.PacijentIme = pacijent.Ime + ' ' + pacijent.Prezime;
                item.DoktorIme = doktor.Ime + ' ' + doktor.Prezime;
            }

            ApotekaReceptIndexVM model = new ApotekaReceptIndexVM
            {
                Recepti = recepti
            };

            return View("ReceptiIndex", model);
        }

        public IActionResult IzdatiRacuniIndex()
        {
            var racuni = _context.ApotekaRacun.Select(r => new ApotekaRacunDetaljiVM
            {
                Id = r.Id,
                Apotekar = r.Apotekar.Osoblje.Korisnici.Ime + ' ' + r.Apotekar.Osoblje.Korisnici.Prezime,
                Pacijent = r.Pacijent.Korisnici.Ime + ' ' + r.Pacijent.Korisnici.Prezime,
                DatumIzdavanja = r.DatumIzdavanja
            }).ToList();

            //ostali detalji se mogu pogledati u DetaljiView
            /*
            var racunStavke = _context.RacunStavka.ToList();

            foreach(var racun in racuni)
            {
                foreach(var stavka in racunStavke)
                {
                    if(racun.Id == stavka.ApotekaRacunId)
                    {
                        racun.Lijek = stavka.Lijek.Naziv;
                    }
                }
            }
            */
            var model = new ApotekaRacunIndexVM
            {
                Racuni = racuni
            };

            return View(model);
        }

        public IActionResult RacunDetalji(int Id)
        {

            var racun = _context.ApotekaRacun.FirstOrDefault(r => r.Id == Id);

            Korisnici apotekar = _context.Korisnici.FirstOrDefault(u => u.Id == racun.ApotekarId);
            Korisnici pacijent = _context.Korisnici.FirstOrDefault(u => u.Id == racun.PacijentId);

            var model = new ApotekaRacunDetaljiVM
            {
                DatumIzdavanja = racun.DatumIzdavanja,
                Apotekar = apotekar.Ime + ' ' + apotekar.Prezime,
                Pacijent = pacijent.Ime + ' ' + pacijent.Prezime,
                UkupniIznos = 0
            };

            List<RacunStavkaDetaljiVM> artikli = _context.RacunStavka.Where(rs => rs.ApotekaRacunId == racun.Id).Select(r => new RacunStavkaDetaljiVM
            {
                Naziv = r.Lijek.Naziv,
                Kolicina = r.Kolicina,
                Cijena = r.Lijek.CijenaPoKomadu * r.Kolicina
            }).ToList();

            model.Artikli = artikli;

            foreach (var artikal in artikli)
            {
                model.UkupniIznos += artikal.Cijena * artikal.Kolicina;
            }

            return View(model);
        }

        public IActionResult RacunStavkaDodaj()
        {
            List<SelectListItem> lijekovi = _context.Lijek.Select(l => new SelectListItem
            {
                Value = l.Id.ToString(),
                Text = l.Naziv
            }).ToList();

            var model = new RacunStavkaDodajVM
            {
                Lijekovi = lijekovi
            };

            return PartialView("RacunStavkaDodaj", model);
        }

        //NARUDZBE
        public IActionResult IndexNarudzbi()
        {
            var narudzbe = _context.Narudzba.Select(n => new NarudzbaIndexVM
            {
                Id = n.Id,
                DatumIsporuke = n.DatumIsporuke,
                DatumNarudzbe = n.DatumNarudzbe,
                Dobavljac = n.Dobavljac.Naziv
            });

            var model = new NarudzbaIndexListVM
            {
                Narudzbe = narudzbe
            };

            return View(model);
        }

        public IActionResult DodajNarudzbu()
        {

            List<SelectListItem> dobavljaci = _context.Dobavljac.Select(d => new SelectListItem
            {
                Value = d.Id.ToString(),
                Text = d.Naziv
            }).ToList();

            List<SelectListItem> lijekovi = _context.Lijek.Select(l => new SelectListItem
            {
                Value = l.Id.ToString(),
                Text = l.Naziv
            }).ToList();

            NarudzbaDodajVM model = new NarudzbaDodajVM
            {
                Dobavljaci = dobavljaci,
                Lijekovi = lijekovi,
                DatumNarudzbe = DateTime.Now,
                DatumIsporuke = null
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult DodajNarudzbu(NarudzbaDodajVM model)
        {
            if (ModelState.IsValid)
            {
                Narudzba novaNarudzba = new Narudzba
                {
                    DatumIsporuke = null,
                    DatumNarudzbe = model.DatumNarudzbe,
                    DobavljacId = Convert.ToInt32(model.DobavljacId),
                    Iznos = 0
                };

                _context.Add(novaNarudzba);
                _context.SaveChanges();

                int id = _context.Narudzba.Last().Id;

                NarudzbaStavka novaStavka = new NarudzbaStavka
                {
                    Kolicina = model.Kolicina,
                    LijekId = Convert.ToInt32(model.LijekId),
                    NarudzbaId = id
                };
                _context.Add(novaStavka);
                _context.SaveChanges();

                return RedirectToAction("IndexNarudzbi");
            }
            return RedirectToAction("IndexNarudzbi");
        }

        public IActionResult DetaljiNarudzbe(int id)
        {
            var narudzba = _context.Narudzba.Include(n => n.Dobavljac)
                .FirstOrDefault(n => n.Id == id);

            NarudzbaIndexVM model = new NarudzbaIndexVM
            {
                Id = narudzba.Id,
                DatumNarudzbe = narudzba.DatumNarudzbe,
                Dobavljac = narudzba.Dobavljac.Naziv,
                IznosNarudzbe = _context.NarudzbaStavka.Where(n => n.NarudzbaId == id).Sum(x => x.Lijek.CijenaPoKomadu * x.Kolicina),
                Stavke = _context.NarudzbaStavka.Include(n => n.Lijek)
                .Where(n => n.NarudzbaId == id)
                .Select(x => new NarudzbaStavkaIndexVM
                {
                    Lijek = x.Lijek.Naziv,
                    Kolicina = x.Kolicina,
                    CijenaPoKomadu = x.Lijek.CijenaPoKomadu,
                }).ToList()
            };

            if (narudzba.DatumIsporuke.HasValue)
                model.DatumIsporuke = narudzba.DatumIsporuke;

            return View(model);
        }

        public IActionResult NarudzbaFinaliziraj(NarudzbaIndexVM model)
        {

            Narudzba narudzba = _context.Narudzba.FirstOrDefault(n => n.Id == model.Id);
            narudzba.DatumIsporuke = DateTime.Now;
            _context.SaveChanges();

            NarudzbaStavka stavka = _context.NarudzbaStavka.FirstOrDefault(ns => ns.NarudzbaId == narudzba.Id);

            int LijekId = stavka.LijekId;

            Lijek lijek = _context.Lijek.FirstOrDefault(l => l.Id == LijekId);
            lijek.UkupnoNaStanju += model.Kolicina;
            _context.SaveChanges();

            return RedirectToAction("IndexNarudzbi");
        }

        public IActionResult UrediNarudzbu(NarudzbaIndexVM model)
        {
            return RedirectToAction("IndexNarudzbi");
        }

        public IActionResult IzbrisiNarudzbu(int Id)
        {
            Narudzba narudzba = _context.Narudzba.FirstOrDefault(n => n.Id == Id);

            if (narudzba != null)
            {
                _context.Narudzba.Remove(narudzba);
                _context.SaveChanges();
            }

            return RedirectToAction("IndexNarudzbi");
        }
    }
}