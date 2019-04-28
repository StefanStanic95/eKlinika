using System;
using System.Collections.Generic;
using System.Text;

namespace eKlinika.Model.Requests
{
    public class PregledInsertRequest
    {
        public DateTime DatumPregleda { get; set; }
        public DateTime DatumRezervacije { get; set; }
        public int DoktorId { get; set; }
        public int MedicinskaSestraId { get; set; }
        public int PacijentId { get; set; }
        public string Napomena { get; set; }
        public string Prioritet { get; set; }
        public string TipPregleda { get; set; }
        public bool IsOdrzan { get; set; }
    }
}
