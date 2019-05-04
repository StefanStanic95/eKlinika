using System;
using System.Collections.Generic;
using System.Text;

namespace eKlinika.Model
{
    public class RacunStavka
    {
        public int Id { get; set; }
        public int ApotekaRacunId { get; set; }
        public int Kolicina { get; set; }
        public int LijekId { get; set; }

        public Lijek Lijek { get; set; }
    }
}
