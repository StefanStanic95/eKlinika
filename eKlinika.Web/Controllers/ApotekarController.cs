using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

using eKlinika.Data;
using eKlinika.Models;
using eKlinika.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Hosting;
using eKlinika.Util;
using Microsoft.AspNetCore.Http;

using System.Security.Cryptography;
using System.Text;
using eKlinika.Util.FileManager;
using eKlinika.Helper;

namespace eKlinika.Controllers
{
    public class ApotekarController : Controller
    {
        private readonly IHostingEnvironment hosting;
        private ApplicationDbContext _db;
        private ImgUploadHelper _imgHelper;
        private UserManagementHelper _userManagementHelper;
        private IUserManager _userManager;

        public ApotekarController(ApplicationDbContext db,
                                  IUserManager userManager,
                                  IFileManager manager)
        {
            _db = db;
            _imgHelper = new ImgUploadHelper(hosting,manager);
            _userManagementHelper = new UserManagementHelper(_db);
            _userManager = userManager;

        }
        public IActionResult Index()
        {
            return View();
        }

        public static byte[] GetHash(string inputString)
        {
            HashAlgorithm algorithm = MD5.Create();  //or use SHA256.Create();
            return algorithm.ComputeHash(Encoding.UTF8.GetBytes(inputString));
        }

        public static string GetHashString(string inputString)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in GetHash(inputString))
                sb.Append(b.ToString("X2"));

            return sb.ToString();
        }
        public IActionResult Dodaj()
        {
            OsobljeVM model = _userManagementHelper.prepApotekar();

            return View("Dodaj",model);
        }

        [HttpPost]
        public IActionResult Dodaj(OsobljeVM model,IFormFile imgInp)
        {
            
            bool x = _userManager.RoleExists("Apotekar");

            if (!x) { 
                _userManager.CreateRole(new Uloge {
                Naziv = "Apotekar"
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
                Slika= _imgHelper.GetImgLocationAsync(imgInp),
                UserName = model.Ime + '.' + model.Prezime,
                Email = model.Ime + "." + model.Prezime + "@eKlinika.com"//,
            };

            
            Korisnici chkUser = _userManager.CreateUser(user, password);

            _userManager.AddUserToRole(user, "Apotekar");

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

             Apotekar apotekar = new Apotekar
             {
                 Id = user.Id,
                 OpisPosla = model.OpisPosla
             };

             _db.Add(apotekar);
             _db.SaveChanges();
            
            return RedirectToAction("Index", "Home");
        }



    }
}