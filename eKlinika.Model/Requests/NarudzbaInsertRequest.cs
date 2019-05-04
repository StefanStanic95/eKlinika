using System;
using System.Collections.Generic;
using System.Text;

namespace eKlinika.Model.Requests
{
    public class NarudzbaInsertRequest
    {
        public DateTime? DatumIsporuke { get; set; }
        public DateTime DatumNarudzbe { get; set; }
        public int DobavljacId { get; set; }
    }
}
