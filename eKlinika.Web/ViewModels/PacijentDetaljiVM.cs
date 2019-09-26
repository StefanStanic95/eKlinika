using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.ViewModels
{
    public class PacijentDetaljiVM
    {
        public int Id { get; set; }
        public string JMBG { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Telefon { get; set; }
        public string Ulica { get; set; }
        public string Broj { get; set; }
        public string Grad { get; set; }
        public string BrojKnjizice { get; set; }
        public string BrojKartona { get; set; }
        public string KrvnaGrupa { get; set; }
        public int Visina { get; set; }
        public double Tezina { get; set; }
        public string Alergije { get; set; }
        public string SpecijalniZahtjevi { get; set; }
    }
}
