using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.WebAPI.Services
{
    public interface IRecommenderService
    {
        List<Model.Doktor> Get(int PregledId);
    }
}
