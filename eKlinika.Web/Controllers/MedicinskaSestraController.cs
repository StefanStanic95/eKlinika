using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using eKlinika.Data;
using eKlinika.Models;
using eKlinika.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Hosting;
using eKlinika.Util;
using Microsoft.AspNetCore.Http;

using eKlinika.Util.FileManager;
using eKlinika.Helper;

namespace eKlinika.Controllers
{
    [Autorizacija(medicinskasestra: true, administrator: true)]
    public class MedicinskaSestraController : Controller
    {
        private ApplicationDbContext _db;
        private ImgUploadHelper _imgHelper;
        private UserManagementHelper _userManagementHelper;
        private IUserManager _userManager;




        // *************** MEDICINSKA SESTRA *************** 

        public MedicinskaSestraController(ApplicationDbContext db, IUserManager userManager)
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
            OsobljeVM model = _userManagementHelper.prepMedSestra();

            return View("Dodaj", model);
        }

        [HttpPost]
        public IActionResult Dodaj(OsobljeVM model, IFormFile imgInp)
        {
            bool x = _userManager.RoleExists("MedicinskaSestra");

            if (!x)
            {
                _userManager.CreateRole(new Uloge
                {
                    Naziv = "MedicinskaSestra"
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

            _userManager.AddUserToRole(user, "MedicinskaSestra");


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

            MedicinskaSestra sestra = new MedicinskaSestra
            {
                Id = user.Id,
                Kursevi = model.Kursevi,
                Certifikati = model.Certifikati
            };
            _db.Add(sestra);
            _db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }

        public IActionResult MedicinskaSestraIndex()
        {
            return View();
        }

        // *************** PACIJENT *************** 

        public IActionResult IndexPacijenta()
        {
            var pacijenti = _db.Pacijent.Include(p => p.Korisnici);
            var modelList = pacijenti
                .OrderBy(x => x.Korisnici.Ime)
                .Select(p => new PacijentIndexVM
            {
                Id = p.Id,
                Ime = p.Korisnici.Ime,
                Prezime = p.Korisnici.Prezime,
                Grad = p.Korisnici.Grad.Naziv
            })
            .ToList();

            var model = new PacijentIndexListVM
            {
                Pacijenti = modelList
            };

            return View(model);
        }

        public IActionResult PacijentDodaj()
        {
            PacijentVM model = _userManagementHelper.prepPacijent();

            return View("PacijentDodaj", model);
        }
        [HttpPost]
        public IActionResult PacijentDodaj(PacijentVM model, IFormFile imgInp)
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
                GradId = 2,
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
                KrvnaGrupaId = 2
            };

            _db.Add(pacijent);
            _db.SaveChanges();

            return RedirectToAction("IndexPacijenta");
        }

        public IActionResult PacijentDetalji(int id)
        {
            var pacijent = _db.Pacijent
                .Include(p => p.Korisnici)
                .Include(p => p.Korisnici.Grad)
                .Include(p => p.KrvnaGrupa)
                .FirstOrDefault(p => p.Id == id);

            var model = new PacijentDetaljiVM
            {
                Id = pacijent.Id,
                JMBG = pacijent.Korisnici.JMBG,
                Ime = pacijent.Korisnici.Ime,
                Prezime = pacijent.Korisnici.Prezime,
                DatumRodjenja = pacijent.Korisnici.DatumRodjenja,
                Telefon = pacijent.Korisnici.Telefon,
                Ulica = pacijent.Korisnici.Ulica,
                Broj = pacijent.Korisnici.Broj,
                BrojKnjizice = pacijent.BrojKnjizice,
                BrojKartona = pacijent.BrojKartona,
                Visina = pacijent.Visina,
                Tezina = pacijent.Tezina,
                Alergije = pacijent.Alergije,
                SpecijalniZahtjevi = pacijent.SpecijalniZahtjevi,
                Grad = pacijent.Korisnici.Grad?.Naziv,
                KrvnaGrupa = pacijent.KrvnaGrupa.Naziv
            };
            return View(model);
        }


        public IActionResult PacijentUredi(int id)
        {
            var pacijent = _db.Pacijent
                .Include(p => p.Korisnici)
                .Include(p => p.Korisnici.Grad)
                .Include(p => p.KrvnaGrupa)
                .FirstOrDefault(p => p.Id == id);

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
                Gradovi = gradovi,
                KrvneGrupe = krvnegrupe,
                BrojKnjizice = pacijent.BrojKnjizice,
                BrojKartona = pacijent.BrojKartona,
                Visina = pacijent.Visina,
                Tezina = pacijent.Tezina,
                Alergije = pacijent.Alergije,
                SpecijalniZahtjevi = pacijent.SpecijalniZahtjevi
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult PacijentUredi(PacijentUrediVM model)
        {
            var pacijent = _db.Pacijent
              .Include(p => p.Korisnici)
              .Include(p => p.Korisnici.Grad)
              .Include(p => p.KrvnaGrupa)
              .FirstOrDefault(p => p.Id == model.Id);

            pacijent.Korisnici.Ime = model.Ime;
            pacijent.Korisnici.Prezime = model.Prezime;
            pacijent.KrvnaGrupaId = Convert.ToInt32(model.KrvnaGrupa);
            pacijent.Korisnici.GradId = Convert.ToInt32(model.Grad);
            pacijent.BrojKnjizice = model.BrojKnjizice;
            pacijent.BrojKartona = model.BrojKartona;
            pacijent.Visina = model.Visina;
            pacijent.Tezina = model.Tezina;
            pacijent.Alergije = model.Alergije;
            pacijent.SpecijalniZahtjevi = model.SpecijalniZahtjevi;

            _db.SaveChanges();
            return RedirectToAction("IndexPacijenta");
        }

        public IActionResult PacijentObrisi(int id)
        {

            Pacijent pacijent = _db.Pacijent.FirstOrDefault(l => l.Id == id);
            var pregledi = _db.Pregled.Where(p => p.Pacijent.Id == id);
            var uplate = _db.Uplata.Where(p => p.Pacijent.Id == id);
            var uputnice = _db.Uputnica.Where(p => p.Pacijent.Id == id);
            
            _db.SaveChanges();

            if (pacijent != null)
            {
                _db.Pacijent.Remove(pacijent);
                _db.SaveChanges();
            }

            return RedirectToAction("IndexPacijenta");

        }


        // PACIJENT SEARCH
        public IActionResult PacijentSearch(string search)
        {

            string searchTxt = search.ToLower();

            var listaPacijenata = _db.Pacijent
                            .Include(l => l.Korisnici)
                            .Include(l => l.Korisnici.Grad)
                            .Where(l => (l.Korisnici.Ime + " " + l.Korisnici.Prezime).ToLower().Contains(searchTxt));


            var pacijenti = listaPacijenata.Select(l => new PacijentIndexVM
            {
                Id = l.Id,
                Ime = l.Korisnici.Ime,
                Prezime = l.Korisnici.Prezime,
                Grad = l.Korisnici.Grad.Naziv
            }).ToList();

            var model = new PacijentIndexListVM
            {
                Pacijenti = pacijenti
            };


            return View("IndexPacijenta", model);
        }

        // *************** UPLATE *************** 

        public IActionResult IndexUplate(DateTime? Pretraga)
        {
            var uplate = _db.Uplata
                               .Include(u => u.Pacijent)
                               .Include(u => u.Pregled)
                               .Where(u => Pretraga == null || u.DatumUplate.ToShortDateString() == Pretraga.Value.ToShortDateString());

            var modelList = uplate.Select(u => new UplataIndexVM
            {
                Id = u.Id,
                DatumUplate = u.DatumUplate,
                Iznos = u.Iznos,
                Namjena = u.Namjena
            }).ToList();

            var model = new UplataIndexListVM
            {
                Uplate = modelList
            };

            return View(model);
        }

        public IActionResult UplataDodaj()
        {
            List<SelectListItem> pacijenti = _db.Pacijent
                .Include(p => p.Korisnici)
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Korisnici.Ime + " " + p.Korisnici.Prezime
                }).ToList();

            List<SelectListItem> pregledi = _db.Pregled.Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.DatumPregleda.ToShortDateString() + "/" + p.TipPregleda
            }).ToList();
            var viewModel = new UplataDodajVM
            {
                Pacijenti = pacijenti,
                Pregledi = pregledi,
                DatumUplate = DateTime.Now
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult UplataDodaj(UplataDodajVM model)
        {

            var novaUplata = new Uplata
            {
                DatumUplate = model.DatumUplate,
                Iznos = model.Iznos,
                Namjena = model.Namjena,
                BrojUplatnice = model.BrojUplatnice,
                ZiroRacun = model.ZiroRacun,
                PregledId = Convert.ToInt32(model.PregledId),
                PacijentId = model.PacijentId
            };
            _db.Add(novaUplata);
            _db.SaveChanges();

            return RedirectToAction("IndexUplate");
        }

        public IActionResult UplataDetalji(int id)
        {
            var uplata = _db.Uplata
                    .Include(u => u.Pregled)
                    .Include(u => u.Pacijent)
                    .FirstOrDefault(u => u.Id == id);

            var model = new UplataDetaljiVM
            {
                Id = uplata.Id,
                DatumUplate = uplata.DatumUplate,
                Iznos = uplata.Iznos,
                Namjena = uplata.Namjena,
                BrojUplatnice = uplata.BrojUplatnice,
                ZiroRacun = uplata.ZiroRacun,
                DatumPregleda = uplata.Pregled.DatumPregleda,
                BrojKnjizice = uplata.Pacijent.BrojKnjizice

            };

            if (uplata.PacijentId != null)
                model.BrojKnjizice = uplata.Pacijent.BrojKnjizice;
            else
                model.BrojKnjizice = "Pacijent nije dodijeljen";


            if (!uplata.PregledId.HasValue)
                model.DatumPregleda = uplata.Pregled.DatumPregleda;
            else
                model.DatumPregleda = DateTime.Now;


            return View(model);
        }

        public IActionResult UplataUredi(int id)
        {
            var uplata = _db.Uplata
                .Include(u => u.Pregled)
                .Include(u => u.Pacijent)
                .Where(u => u.PacijentId != null && u.PregledId.HasValue)
                .FirstOrDefault(u => u.Id == id);

            var model = new UplataUrediVM
            {
                Id = uplata.Id,
                DatumUplate = uplata.DatumUplate,
                Iznos = uplata.Iznos,
                Namjena = uplata.Namjena,
                BrojUplatnice = uplata.BrojUplatnice,
                ZiroRacun = uplata.ZiroRacun,
                PregledId = uplata.PregledId.Value,
                PacijentId = uplata.PacijentId
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult UplataUredi(UplataUrediVM model)
        {
            var uplata = _db.Uplata
              .Include(p => p.Pacijent)
              .Include(p => p.Pregled)
                .Where(u => u.PacijentId != null && u.PregledId.HasValue)
              .FirstOrDefault(p => p.Id == model.Id);

            uplata.DatumUplate = model.DatumUplate;
            uplata.Iznos = model.Iznos;
            uplata.Namjena = model.Namjena;
            uplata.BrojUplatnice = model.BrojUplatnice;
            uplata.ZiroRacun = model.ZiroRacun;

            _db.SaveChanges();
            return RedirectToAction("IndexUplate");
        }

        public IActionResult UplataObrisi(int id)
        {
            Uplata uplata = _db.Uplata.FirstOrDefault(o => o.Id == id);

            if (uplata != null)
            {
                _db.Uplata.Remove(uplata);
                _db.SaveChanges();
            }


            return RedirectToAction("IndexUplate");

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
        
        // *************** NALAZI / PREGLEDI *************** 

        public IActionResult PregledIndex(string Pretraga)
        {
            var pregledi = _db.Pregled.Include(p => p.Pacijent)
                .Include(p => p.Doktor)
                .Include(p => p.MedicinskaSestra)
                .Where(p => p.PacijentId != null && p.MedicinskaSestraId != null && p.DoktorId != null)
                .Where(p => Pretraga == null || p.TipPregleda == Pretraga);

            var modelList = pregledi.Select(p => new PregledIndexVM
            {
                Id = p.Id,
                DatumPregleda = p.DatumPregleda,
                TipPregleda = p.TipPregleda,
                Napomena = p.Napomena,
                Prioritet = p.Prioritet,
                DatumRezervacije = p.DatumRezervacije,
                MedSestra = p.MedicinskaSestra.Osoblje.Korisnici.Ime,
                Doktor = p.Doktor.Osoblje.Korisnici.Ime,
                Pacijent = p.Pacijent.Korisnici.Ime + " " + p.Pacijent.Korisnici.Prezime
            }).ToList();

            var model = new PregledIndexListVM
            {
                Pregledi = modelList
            };

            return View(model);
        }

        public IActionResult PregledDetalji(int id)
        {
            var pregled = _db.Pregled
                .Include(p => p.MedicinskaSestra)
                .Include(p => p.Doktor)
                .Include(p => p.Pacijent)
                                .Where(p => p.PacijentId != null && p.MedicinskaSestraId != null && p.DoktorId != null)
                .FirstOrDefault(p => p.Id == id);


            var model = new PregledDetaljiVM
            {
                Id = pregled.Id,
                DatumPregleda = pregled.DatumPregleda,
                TipPregleda = pregled.TipPregleda,
                Napomena = pregled.Napomena,
                Prioritet = pregled.Prioritet,
                DatumRezervacije = pregled.DatumRezervacije,
                MedSestra = _db.Korisnici.FirstOrDefault(u => u.Id == pregled.MedicinskaSestraId).Ime + " " + _db.Korisnici.FirstOrDefault(u => u.Id == pregled.MedicinskaSestraId).Prezime,
                Doktor = _db.Korisnici.FirstOrDefault(u => u.Id == pregled.DoktorId).Ime + " " + _db.Korisnici.FirstOrDefault(u => u.Id == pregled.DoktorId).Prezime,
                Pacijent = _db.Korisnici.FirstOrDefault(u => u.Id == pregled.PacijentId).Ime + " " + _db.Korisnici.FirstOrDefault(u => u.Id == pregled.PacijentId).Prezime
            };
            return View(model);
        }

        public IActionResult PregledDodaj()
        {
            List<SelectListItem> pacijenti = _db.Pacijent
                           .Include(p => p.Korisnici)
                           .Select(p => new SelectListItem
                           {
                               Value = p.Id.ToString(),
                               Text = p.Korisnici.Ime + " " + p.Korisnici.Prezime
                           }).ToList();
            List<SelectListItem> sestre = _db.MedicinskaSestra
                .Include(p => p.Osoblje)
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Osoblje.Korisnici.Ime + " " + p.Osoblje.Korisnici.Prezime
                }).ToList();
            List<SelectListItem> doktori = _db.Doktor
                .Include(p => p.Osoblje)
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Osoblje.Korisnici.Ime + " " + p.Osoblje.Korisnici.Prezime
                }).ToList();


            var viewModel = new PregledDodajVM
            {
                Pacijenti = pacijenti,
                Doktori = doktori,
                MedSestre = sestre,
                DatumRezervacije = DateTime.Now,
                DatumPregleda = DateTime.Now,
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult PregledDodaj(PregledDodajVM model)
        {
            var noviPregled = new Pregled
            {
                DatumPregleda = model.DatumPregleda,
                TipPregleda = model.TipPregleda,
                Napomena = model.Napomena,
                Prioritet = model.Prioritet,
                DatumRezervacije = model.DatumRezervacije,
                MedicinskaSestraId = model.MedSestra,
                DoktorId = model.Doktor,
                PacijentId = model.Pacijent
                //Doktor = model.Doktor
                //Pacijent = model.Pacijent

            };
            _db.Add(noviPregled);
            _db.SaveChanges();

            return RedirectToAction("PregledIndex");
        }

        public IActionResult PregledObrisi(int id)
        {
            var pregled = _db.Pregled.FirstOrDefault(o => o.Id == id);

            _db.Remove(pregled);
            _db.SaveChanges();

            return RedirectToAction("PregledIndex");

        }

        public IActionResult PregledUredi(int id)
        {
            var pregled = _db.Pregled
                .Include(u => u.Pacijent)
                .Include(u => u.Doktor)
                .Include(u => u.MedicinskaSestra)
                .Where(u => u.PacijentId != null)
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

            var medsestre = _db.MedicinskaSestra.Include(p => p.Osoblje.Korisnici).Select(p => new SelectListItem
            {
                Value = p.Id.ToString(),
                Text = p.Osoblje.Korisnici.Ime + " " + p.Osoblje.Korisnici.Prezime

            }).ToList();

            var model = new PregledUrediVM
            {
                Id = pregled.Id,
                DatumPregleda = pregled.DatumPregleda,
                TipPregleda = pregled.TipPregleda,
                Napomena = pregled.Napomena,
                Prioritet = pregled.Prioritet,
                DatumRezervacije = pregled.DatumRezervacije,
                MedicinskaSestras = medsestre,
                Pacijenti = pacijenti,
                Doktori = doktori
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult PregledUredi(PregledUrediVM model)
        {
            var pregled = _db.Pregled
                .Include(u => u.Pacijent)
                .Include(u => u.Doktor)
                .Include(u => u.MedicinskaSestra)
                .Where(u => u.PacijentId != null)
              .FirstOrDefault(p => p.Id == model.Id);

            pregled.DatumPregleda = model.DatumPregleda;
            pregled.TipPregleda = model.TipPregleda;
            pregled.Napomena = model.Napomena;
            pregled.Prioritet = model.Prioritet;
            pregled.DatumRezervacije = model.DatumRezervacije;
            pregled.MedicinskaSestraId = model.MedicinskaSestraId;
            pregled.DoktorId = model.DoktorId;

            _db.SaveChanges();
            return RedirectToAction("PregledIndex");
        }

        /******* NALAZI *******/

        public IActionResult NalaziIndex(int Id)
        {
            var pregledi = _db.Pregled.Include(p => p.Pacijent)
                .Where(p => p.PacijentId == Id)
                .Select(p => new PregledIndexVM
            {
                Id = p.Id,
                DatumPregleda = p.DatumPregleda,
                TipPregleda = p.TipPregleda,
                Napomena = p.Napomena,
                Prioritet = p.Prioritet,
                DatumRezervacije = p.DatumRezervacije,
                MedSestra = p.MedicinskaSestra.Osoblje.Korisnici.Ime,
                Doktor = p.Doktor.Osoblje.Korisnici.Ime,
                Pacijent = p.Pacijent.Korisnici.Ime + " " + p.Pacijent.Korisnici.Prezime
            }).ToList();

            var model = new PregledIndexListVM
            {
                Pregledi = pregledi,
                PacijentId = Id
            };

            return PartialView(model);
        }


        public IActionResult NalaziDodaj(int Id)
        {
            List<SelectListItem> sestre = _db.MedicinskaSestra
                .Include(p => p.Osoblje)
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Osoblje.Korisnici.Ime + " " + p.Osoblje.Korisnici.Prezime
                }).ToList();
            List<SelectListItem> doktori = _db.Doktor
                .Include(p => p.Osoblje)
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Osoblje.Korisnici.Ime + " " + p.Osoblje.Korisnici.Prezime
                }).ToList();


            var viewModel = new PregledDodajVM
            {
                Pacijent = Id,
                Doktori = doktori,
                MedSestre = sestre,
                DatumRezervacije = DateTime.Now,
                DatumPregleda = DateTime.Now
            };

            return PartialView(viewModel);
        }

        [HttpPost]
        public IActionResult NalaziDodaj(PregledDodajVM model)
        {
            var noviPregled = new Pregled
            {
                DatumPregleda = model.DatumPregleda,
                TipPregleda = model.TipPregleda,
                Napomena = model.Napomena,
                Prioritet = model.Prioritet,
                DatumRezervacije = model.DatumRezervacije,
                MedicinskaSestraId = model.MedSestra,
                DoktorId = model.Doktor,
                PacijentId = model.Pacijent

            };
            _db.Add(noviPregled);
            _db.SaveChanges();

            return RedirectToAction("NalaziIndex", new { Id = model.Pacijent });
        }

    }
}

