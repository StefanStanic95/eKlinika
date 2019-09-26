using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using eKlinika.Data;
using eKlinika.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace eKlinika.Helper
{
    public static class Autentifikacija
    {
        private const string LogiraniKorisnik = "logirani_korisnik";

        public static void SetLogiraniKorisnik(this HttpContext context, Korisnici korisnik, bool snimiUCookie=false)
        {

            ApplicationDbContext db = context.RequestServices.GetService<ApplicationDbContext>();

            string stariToken = context.Request.GetCookieJson<string>(LogiraniKorisnik);
            if (stariToken != null)
            {
                AutorizacijskiToken obrisati = db.AutorizacijskiToken.FirstOrDefault(x => x.Vrijednost == stariToken);
                if (obrisati != null)
                {
                    db.AutorizacijskiToken.Remove(obrisati);
                    db.SaveChanges();
                }
            }

            if (korisnik != null)
            {

                string token = Guid.NewGuid().ToString();
                db.AutorizacijskiToken.Add(new AutorizacijskiToken
                {
                    Vrijednost = token,
                    KorisniciId = korisnik.Id,
                    VrijemeEvidentiranja = DateTime.Now
                });
                db.SaveChanges();
                context.Response.SetCookieJson(LogiraniKorisnik, token);
            }
        }

        public static string GetTrenutniToken(this HttpContext context)
        {
            return context.Request.GetCookieJson<string>(LogiraniKorisnik);
        }

        public static Korisnici GetLogiraniKorisnik(this HttpContext context)
        {
            ApplicationDbContext db = context.RequestServices.GetService<ApplicationDbContext>();

            string token = context.Request.GetCookieJson<string>(LogiraniKorisnik);
            if (token == null)
                return null;

            return db.AutorizacijskiToken
                .Where(x => x.Vrijednost == token)
                .Select(s => s.Korisnici)
                .SingleOrDefault();

        }


        public static Uloge GetUlogaKorisnika(this HttpContext context)
        {
            ApplicationDbContext db = context.RequestServices.GetService<ApplicationDbContext>();

            Korisnici k = context.GetLogiraniKorisnik();

            if (k == null)
                return null;

            return db.KorisniciUloge
                .Where(x => x.KorisnikId == k.Id)
                .Select(x=>x.Uloga)
                .FirstOrDefault();
        }

    }
}