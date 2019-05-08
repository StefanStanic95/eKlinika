using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.WebAPI.Mapper
{
    public class Mapper : Profile
    {
        public Mapper()
        {
            CreateMap<Database.Korisnici, Model.Korisnici>();
            CreateMap<Model.Pacijent, Database.Pacijent>()
                .ForMember(x => x.Korisnik, opt => opt.Ignore());
            CreateMap<Model.Osoblje, Database.Osoblje>();
            CreateMap<Model.Osoblje_Upsert, Database.Osoblje>();
            CreateMap<Model.Doktor, Database.Doktor>();
            CreateMap<Model.Doktor_Upsert, Database.Doktor>();
            CreateMap<Model.Apotekar, Database.Apotekar>();
            CreateMap<Model.Apotekar_Upsert, Database.Apotekar>();
            CreateMap<Model.MedicinskaSestra, Database.MedicinskaSestra>();
            CreateMap<Model.MedicinskaSestra_Upsert, Database.MedicinskaSestra>();


            CreateMap<Database.Korisnici, Model.Requests.KorisniciInsertRequest>().ReverseMap();
            CreateMap<Database.Korisnici, Model.Requests.KorisniciUpdateRequest>().ReverseMap();
            CreateMap<Database.Uputnica, Model.Requests.UputnicaInsertRequest>().ReverseMap();
            CreateMap<Database.Pregled, Model.Requests.PregledInsertRequest>().ReverseMap();
            CreateMap<Database.ApotekaRacun, Model.Requests.ApotekaRacunInsertRequest>().ReverseMap();
            CreateMap<Database.Lijek, Model.Requests.LijekInsertRequest>().ReverseMap();
            CreateMap<Database.RacunStavka, Model.Requests.RacunStavkaInsertRequest>().ReverseMap();
            CreateMap<Database.Recept, Model.Requests.ReceptInsertRequest>().ReverseMap();
            CreateMap<Database.Narudzba, Model.Requests.NarudzbaInsertRequest>().ReverseMap();
            CreateMap<Database.NarudzbaStavka, Model.Requests.NarudzbaStavkaInsertRequest>().ReverseMap();


            CreateMap<Database.Pregled, Model.Pregled>();
            CreateMap<Database.Uputnica, Model.Uputnica>();
            CreateMap<Database.Uplata, Model.Uplata>();
            CreateMap<Database.ApotekaRacun, Model.ApotekaRacun>();
            CreateMap<Database.Lijek, Model.Lijek>();
            CreateMap<Database.RacunStavka, Model.RacunStavka>();
            CreateMap<Database.Recept, Model.Recept>();
            CreateMap<Database.Narudzba, Model.Narudzba>();
            CreateMap<Database.NarudzbaStavka, Model.NarudzbaStavka>();

        }
    }
}
