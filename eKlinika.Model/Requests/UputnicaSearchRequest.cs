using System;
using System.Collections.Generic;
using System.Text;

namespace eKlinika.Model.Requests
{
    public class UputnicaSearchRequest
    {
        public int? VrstaId { get; set; }
        public DateTime? DatumOd { get; set; }
        public DateTime? DatumDo { get; set; }
    }
}
