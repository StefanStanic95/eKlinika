using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using eKlinika.Data;
using eKlinika.Helper;
using eKlinika.Models;
using eKlinika.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace eKlinika.Controllers
{
    public class AccountController : Controller
    {
        private ApplicationDbContext _context;
        public AccountController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Login()
        {
            LoginVM model = new LoginVM();

            return View(model);
        }

        [HttpPost]
        public IActionResult Login(LoginVM model)
        {
            if (ModelState.IsValid)
            {
                Korisnici user = _context.Korisnici.FirstOrDefault(u => u.UserName == model.Username);
                if (user != null)
                {

                    var newHash = Hashing.GenerateHash(user.LozinkaSalt, model.Password);

                    if (newHash == user.LozinkaHash)
                    {
                        HttpContext.SetLogiraniKorisnik(user);

                        var userRole = HttpContext.GetUlogaKorisnika(user.Id)?.Naziv;

                        if (userRole == "Apotekar")
                            return RedirectToAction("Index", "Apoteka");
                        else if (userRole == "Doktor")
                            return RedirectToAction("Index", "Pregledi");
                        else if (userRole == "Pacijent")
                            return RedirectToAction("Index", "Pacijent");
                        else if (userRole == "MedicinskaSestra")
                            return RedirectToAction("Index", "MedicinskaSestra");
                        else if (userRole == "Referent")
                            return RedirectToAction("Index", "Referent");
                        else
                            return RedirectToAction("Index", "Home");
                    }
                }
            }

            TempData["login_error"] = "Korisničko ime ili lozinka nisu tačni.";
            return RedirectToAction("Login");
        }

        public IActionResult Logout()
        {
            HttpContext.SetLogiraniKorisnik(null);
            return RedirectToAction("Index", "Home");
        }

        #region Helpers

        //private void AddErrors(IdentityResult result)
        //{
        //    foreach (var error in result.Errors)
        //    {
        //        ModelState.AddModelError(string.Empty, error.Description);
        //    }
        //}

        //public IActionResult AccessDenied()
        //{
        //    return View();
        //}
        //private IActionResult RedirectToLocal(string returnUrl)
        //{
        //    if (Url.IsLocalUrl(returnUrl))
        //    {
        //        return Redirect(returnUrl);
        //    }
        //    else
        //    {
        //        return RedirectToAction(nameof(HomeController.Index), "Home");
        //    }
        //}

        #endregion
    }
}
