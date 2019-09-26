using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.ViewModels
{
    public class PacijentUplataVM
    {
        public List<Row> rows { get; set; }

        public class Row
        {

            public int Id { get; set; }
            public DateTime DatumUplate { get; set; }
            public double Iznos { get; set; }
            public string Namjena { get; set; }
            public string BrojUplatnice { get; set; }
            public string ZiroRacun { get; set; }
        }
    }
}
