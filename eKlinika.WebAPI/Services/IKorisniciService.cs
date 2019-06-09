using eKlinika.Model;
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

        Model.Korisnici GetMe();

        Model.Korisnici GetById(int id);

        Model.Korisnici GetByEmail(string email);

        Model.Korisnici Insert(KorisniciInsertRequest request);

        Model.Korisnici Update(int id, KorisniciUpdateRequest request);

        Model.Korisnici Authenticiraj(string username, string pass);
        Korisnici UpdatePacijent(int id, PacijentUpdateRequest request);
    }
}
