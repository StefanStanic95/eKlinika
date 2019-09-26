using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eKlinika.Models;

namespace eKlinika.Helper
{
    public interface IUserManager
    {
        void AddToRoleAsync(Korisnici user, string role);
        Korisnici CreateAsync(Korisnici user, string password);
        bool RoleExistsAsync(string role);
        void CreateRoleAsync(Uloge uloge);
    }
}
