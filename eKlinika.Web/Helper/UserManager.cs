using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eKlinika.Data;
using eKlinika.Models;

namespace eKlinika.Helper
{
    public class UserManager : IUserManager
    {
        private readonly ApplicationDbContext db;

        public UserManager(ApplicationDbContext db)
        {
            this.db = db;
        }

        public void AddUserToRole(Korisnici user, string role)
        {
            Uloge uloga = db.Uloge.Where(x => x.Naziv == role).FirstOrDefault();
            if (uloga == null)
                throw new Exception("Role " + role + " not found.");

            Korisnici korisnik = db.Korisnici.Find(user.Id);
            if (korisnik == null)
                throw new Exception("User " + user.Id + " not found.");

            korisnik.KorisniciUloge.Add(new KorisniciUloge
            {
                KorisnikId = user.Id,
                UlogaId = uloga.Id
            });
            db.SaveChanges();
        }

        public Korisnici CreateUser(Korisnici user, string password)
        {
            user.LozinkaSalt = Hashing.GenerateSalt();
            user.LozinkaHash = Hashing.GenerateHash(user.LozinkaSalt, password);

            db.Korisnici.Add(user);
            db.SaveChanges();

            return user;
        }

        public void CreateRole(Uloge uloge)
        {
            db.Uloge.Add(uloge);
            db.SaveChanges();
        }

        public bool RoleExists(string role)
        {
            return db.Uloge.Any(x => x.Naziv == role);
        }
    }
}
