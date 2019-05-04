
using System;
using System.Collections.Generic;
using System.Text;

namespace eKlinika.Model
{
    public class Osoblje_Upsert
    {
        public DateTime DatumZaposlenja { get; set; }
        public int GodineStaza { get; set; }
        public string Jezici { get; set; }
        public string TipZaposlenja { get; set; }
        public string TrajanjeUgovora { get; set; }        

        public Apotekar_Upsert Apotekar { get; set; }
        public Doktor_Upsert Doktor { get; set; }
        public MedicinskaSestra_Upsert MedicinskaSestra { get; set; }

    }
}
