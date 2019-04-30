using eKlinika.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.WebAPI.Services
{
    public interface IReceptService
    {
        List<Model.Recept> Get(ReceptSearchRequest request);

        Model.Recept GetById(int id);

        Model.Recept Insert(ReceptInsertRequest request);

        Model.Recept Update(int id, ReceptInsertRequest request);
    }
}
