using System;
using System.Collections.Generic;
using System.Text;

namespace eKlinika.Model.Requests
{
    public class UputnicaInsertRequest
    {
        public DateTime DatumRezultata { get; set; }
        public DateTime DatumUputnice { get; set; }
        public bool IsGotovNalaz { get; set; }
        public int LaboratorijDoktorId { get; set; }
        public int PacijentId { get; set; }
        public int UputioDoktorId { get; set; }
        public int VrstaPretrageId { get; set; }
    }
}
