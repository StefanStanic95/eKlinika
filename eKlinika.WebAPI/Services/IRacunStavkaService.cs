using eKlinika.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.WebAPI.Services
{
    public interface IRacunStavkaService
    {
        List<Model.RacunStavka> Get(RacunStavkaSearchRequest request);

        Model.RacunStavka GetById(int id);

        Model.RacunStavka Insert(RacunStavkaInsertRequest request);

        Model.RacunStavka Update(int id, RacunStavkaInsertRequest request);
    }
}
