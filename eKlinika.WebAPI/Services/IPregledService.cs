using eKlinika.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.WebAPI.Services
{
    public interface IPregledService
    {
        List<Model.Pregled> Get(PregledSearchRequest request);

        Model.Pregled GetById(int id);

        Model.Pregled Insert(Model.Pregled request);

        Model.Pregled Update(int id, Model.Pregled request);
        
    }
}
