using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.ViewModels
{
    public class PacijentDetailVM
    {
        public int Id { get; set; }
        public string JMBG { get; set; }
        public byte[] Slika { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Telefon { get; set; }
        public string Spol { get; set; }
        public string Adresa { get; set; }
        public string Grad { get; set; }
        public string BrojKartona { get; set; }
    }
}
