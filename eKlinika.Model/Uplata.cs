using System;
using System.Collections.Generic;
using System.Text;

namespace eKlinika.Model
{
    public class Uplata
    {
        public int Id { get; set; }
        public string BrojUplatnice { get; set; }
        public DateTime DatumUplate { get; set; }
        public double Iznos { get; set; }
        public string Namjena { get; set; }
        public int PacijentId { get; set; }
        public string ZiroRacun { get; set; }
        public Pacijent Pacijent { get; set; }
        public int? PregledId { get; set; }
        public Pregled Pregled { get; set; }

    }
}
