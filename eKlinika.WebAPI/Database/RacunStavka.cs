using System;
using System.Collections.Generic;

namespace eKlinika.WebAPI.Database
{
    public partial class RacunStavka
    {
        public int Id { get; set; }
        public int ApotekaRacunId { get; set; }
        public int Kolicina { get; set; }
        public int LijekId { get; set; }

        public ApotekaRacun ApotekaRacun { get; set; }
        public Lijek Lijek { get; set; }
    }
}
