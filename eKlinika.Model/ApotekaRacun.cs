using System;
using System.Collections.Generic;
using System.Text;

namespace eKlinika.Model
{
    public class ApotekaRacun
    {
        public int Id { get; set; }
        public int ApotekarId { get; set; }
        public DateTime DatumIzdavanja { get; set; }
        public int PacijentId { get; set; }

        public Apotekar Apotekar { get; set; }
        public Pacijent Pacijent { get; set; }
    }
}
