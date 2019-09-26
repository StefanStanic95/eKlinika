using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.ViewModels
{
    public class TerminEvidencijaVM
    {
        public int TerminId { get; set; }
        public string Doktor { get; set; }
        public PacijentShortVM Pacijent { get; set; }
        public string DatumRezervacije { get; set; }
        public string DatumPregleda { get; set; }
        public string VrijemePregleda { get; set; }
        public string Napomena { get; set; }
    }
}
