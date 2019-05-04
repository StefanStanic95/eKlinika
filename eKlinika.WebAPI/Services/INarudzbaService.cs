using eKlinika.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.WebAPI.Services
{
    public interface INarudzbaService
    {
        List<Model.Narudzba> Get(NarudzbaSearchRequest request);

        Model.Narudzba GetById(int id);

        Model.Narudzba Insert(NarudzbaInsertRequest request);

        Model.Narudzba Update(int id, NarudzbaInsertRequest request);
    }
}
