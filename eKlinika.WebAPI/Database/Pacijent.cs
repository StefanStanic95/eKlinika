using System;
using System.Collections.Generic;

namespace eKlinika.WebAPI.Database
{
    public partial class Pacijent
    {
        public Pacijent()
        {
            ApotekaRacun = new HashSet<ApotekaRacun>();
            Pregled = new HashSet<Pregled>();
            Uplata = new HashSet<Uplata>();
            Uputnica = new HashSet<Uputnica>();
        }

        public string Id { get; set; }
        public string Alergije { get; set; }
        public string BrojKartona { get; set; }
        public string BrojKnjizice { get; set; }
        public DateTime DatumRegistracije { get; set; }
        public int KrvnaGrupaId { get; set; }
        public string SpecijalniZahtjevi { get; set; }
        public double Tezina { get; set; }
        public int Visina { get; set; }

        public Korisnici Korisnik { get; set; }
        public KrvnaGrupa KrvnaGrupa { get; set; }
        public ICollection<ApotekaRacun> ApotekaRacun { get; set; }
        public ICollection<Pregled> Pregled { get; set; }
        public ICollection<Uplata> Uplata { get; set; }
        public ICollection<Uputnica> Uputnica { get; set; }
    }
}
