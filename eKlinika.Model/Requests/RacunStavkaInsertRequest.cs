using System;
using System.Collections.Generic;
using System.Text;

namespace eKlinika.Model.Requests
{
    public class RacunStavkaInsertRequest
    {
        public int ApotekaRacunId { get; set; }
        public int Kolicina { get; set; }
        public int LijekId { get; set; }
    }
}
