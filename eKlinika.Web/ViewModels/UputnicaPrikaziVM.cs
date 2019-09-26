using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.ViewModels
{
    public class UputnicaPrikaziVM
    {
        public int PacijentId { get; set; }

        public List<UputniceRow> Uputnice { get; set; }

        public class UputniceRow
        {
            public int UputnicaId { get; set; }
            public DateTime DatumUputnice { get; set; }
            public string UputioLjekar { get; set; }
            public string LabLjekar { get; set; }
            public string Pacijent { get; set; }
            public string VrstaPretrage { get; set; }
            public DateTime? DatumRezultata { get; set; }
            public bool IsGotovNalaz { get; set; }

        }
    }
}
