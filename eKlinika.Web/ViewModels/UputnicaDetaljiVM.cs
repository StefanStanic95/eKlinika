using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.ViewModels
{
    public class UputnicaDetaljiVM
    {
        public Detalj Uputnica { get; set; }

        public class Detalj
        {
            public int UputnicaId { get; set; }
            public DateTime DatumUputnice { get; set; }
            public string Doktor { get; set; }
            public string Pacijent { get; set; }
            public string VrstaPretrage { get; set; }
            public DateTime? DatumRezultata { get; set; }
            public bool IsGotovNalaz { get; set; }
        }
    }
}
