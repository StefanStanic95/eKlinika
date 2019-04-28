using eKlinika.Model.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.WebAPI.Services
{
    public interface ILijekService
    {
        List<Model.Lijek> Get(LijekSearchRequest request);

        Model.Lijek GetById(int id);

        Model.Lijek Insert(LijekInsertRequest request);

        Model.Lijek Update(int id, LijekInsertRequest request);
    }
}
