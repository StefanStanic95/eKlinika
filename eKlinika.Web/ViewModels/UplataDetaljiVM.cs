using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.ViewModels
{
    public class UplataDetaljiVM
    {
        public int Id { get; set; }
        public DateTime DatumUplate { get; set; }
        public double Iznos { get; set; }
        public string Namjena { get; set; }
        public string BrojUplatnice { get; set; }
        public string ZiroRacun { get; set; }
        public DateTime DatumPregleda { get; set; }
        public string BrojKnjizice { get; set; }
    }
}
