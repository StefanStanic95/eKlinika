using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using eKlinika.Models;

namespace eKlinika.Helper
{
    public interface IUserManager
    {
        void AddUserToRole(Korisnici user, string role);
        Korisnici CreateUser(Korisnici user, string password);
        bool RoleExists(string role);
        void CreateRole(Uloge uloge);
    }
}
