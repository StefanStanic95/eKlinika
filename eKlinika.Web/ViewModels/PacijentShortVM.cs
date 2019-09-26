using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.ViewModels
{
    public class PacijentShortVM
    {
        public int PacijentId { get; set; }
        public string ImePrezime { get; set; }
        public string Spol { get; set; }
        public string Starost { get; set; }
        public string BrojKnjizice { get; set; }
        public string BrojKartona { get; set; }
        public string Image { get; set; }
    }
}
