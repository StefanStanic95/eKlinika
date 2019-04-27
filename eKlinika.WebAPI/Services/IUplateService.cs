using eKlinika.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.WebAPI.Services
{
    public interface IUplateService
    {
        List<Model.Uplata> Get(UplateSearchRequest request);

        Model.Uplata GetById(int id);

        Model.Uplata Insert(Model.Uplata request);

        Model.Uplata Update(int id, Model.Uplata request);

    }
}
