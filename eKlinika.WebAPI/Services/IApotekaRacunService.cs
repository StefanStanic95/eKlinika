using eKlinika.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.WebAPI.Services
{
    public interface IApotekaRacunService
    {
        List<Model.ApotekaRacun> Get(ApotekaRacunSearchRequest request);

        Model.ApotekaRacun GetById(int id);

        Model.ApotekaRacun Insert(ApotekaRacunInsertRequest request);

        Model.ApotekaRacun Update(int id, ApotekaRacunInsertRequest request);
    }
}
