using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eProdaja.WebAPI.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<eKlinika.WebAPI.Database.Korisnici, eKlinika.Model.Korisnici>();
            CreateMap<eKlinika.WebAPI.Database.Korisnici, eKlinika.Model.Requests.KorisniciInsertRequest>().ReverseMap();
        }
    }
}
