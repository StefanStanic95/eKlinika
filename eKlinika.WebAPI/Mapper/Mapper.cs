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
            CreateMap<eKlinika.Model.Pacijent, eKlinika.WebAPI.Database.Pacijent>()
                .ForMember(x => x.Korisnik, opt => opt.Ignore());
            CreateMap<eKlinika.Model.Osoblje, eKlinika.WebAPI.Database.Osoblje>();
            CreateMap<eKlinika.Model.Osoblje_Upsert, eKlinika.WebAPI.Database.Osoblje>();
            CreateMap<eKlinika.Model.Doktor, eKlinika.WebAPI.Database.Doktor>();
            CreateMap<eKlinika.Model.Doktor_Upsert, eKlinika.WebAPI.Database.Doktor>();
            CreateMap<eKlinika.Model.Apotekar, eKlinika.WebAPI.Database.Apotekar>();
            CreateMap<eKlinika.Model.Apotekar_Upsert, eKlinika.WebAPI.Database.Apotekar>();
            CreateMap<eKlinika.Model.MedicinskaSestra, eKlinika.WebAPI.Database.MedicinskaSestra>();
            CreateMap<eKlinika.Model.MedicinskaSestra_Upsert, eKlinika.WebAPI.Database.MedicinskaSestra>();


            CreateMap<eKlinika.WebAPI.Database.Korisnici, eKlinika.Model.Requests.KorisniciInsertRequest>().ReverseMap();
            CreateMap<eKlinika.WebAPI.Database.Korisnici, eKlinika.Model.Requests.KorisniciUpdateRequest>().ReverseMap();
            CreateMap<eKlinika.WebAPI.Database.Uputnica, eKlinika.Model.Requests.UputnicaInsertRequest>().ReverseMap();
            CreateMap<eKlinika.WebAPI.Database.Pregled, eKlinika.Model.Requests.PregledInsertRequest>().ReverseMap();
            CreateMap<eKlinika.WebAPI.Database.ApotekaRacun, eKlinika.Model.Requests.ApotekaRacunInsertRequest>().ReverseMap();


            CreateMap<eKlinika.WebAPI.Database.Pregled, eKlinika.Model.Pregled>();
            CreateMap<eKlinika.WebAPI.Database.Uputnica, eKlinika.Model.Uputnica>();
            CreateMap<eKlinika.WebAPI.Database.Uplata, eKlinika.Model.Uplata>();
            CreateMap<eKlinika.WebAPI.Database.ApotekaRacun, eKlinika.Model.ApotekaRacun>();

        }
    }
}
