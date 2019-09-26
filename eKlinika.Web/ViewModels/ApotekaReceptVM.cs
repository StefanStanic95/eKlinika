using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.ViewModels
{
    public class ApotekaReceptVM
    {
        public int ReceptId { get; set; }
        public int DoktorId { get; set; }
        public string DoktorIme { get; set; }
        public int PacijentId { get; set; }
        public string PacijentIme { get; set; }
        public int PregledId { get; set; }
        public DateTime DatumIzdavanja { get; set; }
        public int LijekId { get; set; }
        public string NazivLijeka { get; set; }
        public int Kolicina { get; set; }
        public bool Obradjen { get; set; }
    }
}
