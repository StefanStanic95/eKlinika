using System;
using System.Collections.Generic;
using System.Text;

namespace eKlinika.Model.Requests
{
    public class ApotekaRacunInsertRequest
    {
        public int ApotekarId { get; set; }
        public DateTime DatumIzdavanja { get; set; }
        public int PacijentId { get; set; }
    }
}
