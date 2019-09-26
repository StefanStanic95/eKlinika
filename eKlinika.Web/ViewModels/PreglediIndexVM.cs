using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.ViewModels
{
    public class PreglediIndexVM
    {
        public int Id { get; set; }
        public DateTime DatumPregleda { get; set; }
        public string Doktor { get; set; }
        public string Pacijent { get; set; }
    }
}
