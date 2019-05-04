using System;
using System.Collections.Generic;
using System.Text;

namespace eKlinika.Model.Requests
{
    public class NarudzbaStavkaInsertRequest
    {
        public int Kolicina { get; set; }
        public int LijekId { get; set; }
        public int NarudzbaId { get; set; }
    }
}
