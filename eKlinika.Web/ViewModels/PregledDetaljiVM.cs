using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.ViewModels
{
    public class PregledDetaljiVM
    {
        public int Id { get; set; }
        public DateTime DatumPregleda { get; set; }
        public string TipPregleda { get; set; }
        public string Napomena { get; set; }
        public string Prioritet { get; set; }
        public DateTime DatumRezervacije { get; set; }
        public string MedSestra { get; set; }
        public string Doktor { get; set; }
        public string Pacijent { get; set; }
    }
}
