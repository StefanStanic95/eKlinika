using System;
using System.Collections.Generic;
using System.Text;

namespace eKlinika.Model
{
    public partial class Pacijent
    {
        //public int Id { get; set; }
        public string Alergije { get; set; }
        public string BrojKartona { get; set; }
        public string BrojKnjizice { get; set; }
        public DateTime DatumRegistracije { get; set; }
        public int KrvnaGrupaId { get; set; }
        public string SpecijalniZahtjevi { get; set; }
        public double Tezina { get; set; }
        public int Visina { get; set; }

        public Korisnici_Base Korisnik { get; set; }

        public string ImePrezime { get => Korisnik?.Ime + " " + Korisnik?.Prezime; }

        public KrvnaGrupa KrvnaGrupa { get; set; }
        //public ICollection<ApotekaRacun> ApotekaRacun { get; set; }
        //public ICollection<Pregled> Pregled { get; set; }
        //public ICollection<Uplata> Uplata { get; set; }
        //public ICollection<Uputnica> Uputnica { get; set; }
    }
}
