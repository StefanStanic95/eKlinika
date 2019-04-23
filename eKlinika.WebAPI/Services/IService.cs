using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.WebAPI.Services
{
    public interface IService<T, TSearch>
    {
        List<T> Get(TSearch search);

        List<T> Get();

        T GetById(int id);
    }
}
