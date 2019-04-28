using eKlinika.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.WebAPI.Services
{
    public interface IUputnicaService
    {
        List<Model.Uputnica> Get(UputnicaSearchRequest request);

        Model.Uputnica GetById(int id);

        Model.Uputnica Insert(UputnicaInsertRequest request);

        Model.Uputnica Update(int id, UputnicaInsertRequest request);
        
    }
}
