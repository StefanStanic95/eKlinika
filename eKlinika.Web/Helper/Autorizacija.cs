using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eKlinika.Data;
using eKlinika.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;


namespace eKlinika.Helper
{

    public class AutorizacijaAttribute : TypeFilterAttribute
    {
        public AutorizacijaAttribute(bool doktor = false, bool medicinskasestra = false, bool pacijent = false, bool apotekar = false, bool administrator = false, bool referent = false)
            : base(typeof(MyAuthorizeImpl))
        {
            Arguments = new object[] { doktor, medicinskasestra, pacijent, apotekar, administrator, referent };
        }
    }


    public class MyAuthorizeImpl : IAsyncActionFilter
    {
        public MyAuthorizeImpl(bool doktor = false, bool medicinskasestra = false, bool pacijent = false, bool apotekar = false, bool administrator = false, bool referent = false)
        {
            _doktor = doktor;
            _medicinskasestra = medicinskasestra;
            _pacijent = pacijent;
            _apotekar = apotekar;
            _administrator = administrator;
            _referent = referent;
        }
        private readonly bool _doktor;
        private readonly bool _medicinskasestra;
        private readonly bool _pacijent;
        private readonly bool _apotekar;
        private readonly bool _administrator;
        private readonly bool _referent;
        public async Task OnActionExecutionAsync(ActionExecutingContext filterContext, ActionExecutionDelegate next)
        {
            Korisnici k = filterContext.HttpContext.GetLogiraniKorisnik();

            if (k == null)
            {
                if (filterContext.Controller is Controller controller)
                {
                    controller.TempData["login_error"] = "Niste logirani";
                }

                filterContext.Result = new RedirectToActionResult("Login", "Account", new { @area = "" });
                return;
            }

            Uloge uloga = filterContext.HttpContext.GetUlogaKorisnika();
            if (uloga != null)
            {
                if (_doktor && uloga.Naziv == "Doktor")
                {
                    await next(); //ok - ima pravo pristupa
                    return;
                }
                if (_medicinskasestra && uloga.Naziv == "MedicinskaSestra")
                {
                    await next(); //ok - ima pravo pristupa
                    return;
                }
                if (_pacijent && uloga.Naziv == "Pacijent")
                {
                    await next(); //ok - ima pravo pristupa
                    return;
                }
                if (_apotekar && uloga.Naziv == "Apotekar")
                {
                    await next(); //ok - ima pravo pristupa
                    return;
                }
                if (_administrator && uloga.Naziv == "Administrator")
                {
                    await next(); //ok - ima pravo pristupa
                    return;
                }
                if (_referent && uloga.Naziv == "Referent")
                {
                    await next(); //ok - ima pravo pristupa
                    return;
                }

            }


            if (filterContext.Controller is Controller c1)
            {
                c1.TempData["login_error"] = "Nemate pravo pristupa";
            }
            filterContext.Result = new RedirectToActionResult("Login", "Account", new { @area = "" });
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            // throw new NotImplementedException();
        }
    }
}

