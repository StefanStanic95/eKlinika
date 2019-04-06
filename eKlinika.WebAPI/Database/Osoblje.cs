using System;
using System.Collections.Generic;

namespace eKlinika.WebAPI.Database
{
    public partial class Osoblje
    {
        public int Id { get; set; }
        public DateTime DatumZaposlenja { get; set; }
        public int GodineStaza { get; set; }
        public string Jezici { get; set; }
        public string TipZaposlenja { get; set; }
        public string TrajanjeUgovora { get; set; }

        public Korisnici IdNavigation { get; set; }
        public Apotekar Apotekar { get; set; }
        public Doktor Doktor { get; set; }
        public MedicinskaSestra MedicinskaSestra { get; set; }
    }
}
