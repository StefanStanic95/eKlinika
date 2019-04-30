using System;
using System.Collections.Generic;
using System.Text;

namespace eKlinika.Model.Requests
{
    public class ReceptInsertRequest
    {
        public DateTime DatumIzdavanja { get; set; }
        public int Kolicina { get; set; }
        public int LijekId { get; set; }
        public int PregledId { get; set; }
        public string Uputstvo { get; set; }
        public bool IsObradjen { get; set; }
    }
}
