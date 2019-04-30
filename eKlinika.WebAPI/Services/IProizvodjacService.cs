using eKlinika.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.WebAPI.Services
{
    public interface IProizvodjacService
    {
        List<Model.Proizvodjac> Get(ProizvodjacSearchRequest request);

        Model.Proizvodjac GetById(int id);

        Model.Proizvodjac Insert(Model.Proizvodjac request);

        Model.Proizvodjac Update(int id, Model.Proizvodjac request);
    }
}
