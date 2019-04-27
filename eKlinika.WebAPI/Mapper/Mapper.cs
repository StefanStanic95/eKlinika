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
            CreateMap<eKlinika.Model.Pacijent, eKlinika.WebAPI.Database.Pacijent>();
            CreateMap<eKlinika.Model.Osoblje, eKlinika.WebAPI.Database.Osoblje>();
            CreateMap<eKlinika.Model.Doktor, eKlinika.WebAPI.Database.Doktor>();
            CreateMap<eKlinika.Model.Apotekar, eKlinika.WebAPI.Database.Apotekar>();
            CreateMap<eKlinika.Model.MedicinskaSestra, eKlinika.WebAPI.Database.MedicinskaSestra>();

            CreateMap<eKlinika.WebAPI.Database.Korisnici, eKlinika.Model.Requests.KorisniciInsertRequest>().ReverseMap();
            CreateMap<eKlinika.WebAPI.Database.Korisnici, eKlinika.Model.Requests.KorisniciUpdateRequest>().ReverseMap();

            CreateMap<eKlinika.WebAPI.Database.Pregled, eKlinika.Model.Pregled>();
            CreateMap<eKlinika.WebAPI.Database.Uputnica, eKlinika.Model.Uputnica>();
        }
    }
}
