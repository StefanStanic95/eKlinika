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


    }
}