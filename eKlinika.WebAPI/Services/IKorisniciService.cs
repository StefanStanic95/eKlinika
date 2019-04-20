using eKlinika.Model.Requests;
using eKlinika.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.WebAPI.Services
{
    public interface IKorisniciService
    {
        List<Model.Korisnici> Get(KorisniciSearchRequest request);

        Model.Korisnici GetById(int id);

        Model.Korisnici GetByEmail(string email);

        Model.Korisnici Insert(KorisniciInsertRequest request);

        Model.Korisnici Update(int id, KorisniciInsertRequest request);

        Model.Korisnici Authenticiraj(string username, string pass);
    }
}
