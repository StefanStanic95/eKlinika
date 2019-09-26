using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eKlinika.Models;

namespace eKlinika.Helper
{
    public class UserManager : IUserManager
    {
        public void AddToRoleAsync(Korisnici user, string role)
        {
            throw new NotImplementedException();
        }

        public Korisnici CreateAsync(Korisnici user, string password)
        {
            throw new NotImplementedException();
        }

        public void CreateRoleAsync(Uloge uloge)
        {
            throw new NotImplementedException();
        }

        public bool RoleExistsAsync(string role)
        {
            throw new NotImplementedException();
        }
    }
}
