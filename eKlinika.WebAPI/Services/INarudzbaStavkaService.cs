using eKlinika.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.WebAPI.Services
{
    public interface INarudzbaStavkaService
    {
        List<Model.NarudzbaStavka> Get(NarudzbaStavkaSearchRequest request);

        Model.NarudzbaStavka GetById(int id);

        Model.NarudzbaStavka Insert(NarudzbaStavkaInsertRequest request);

        Model.NarudzbaStavka Update(int id, NarudzbaStavkaInsertRequest request);
    }
}
