using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace eKlinika.WebAPI.Database
{
    public partial class Osoblje
    {
        [ForeignKey("Korisnik")]
        public string Id { get; set; }
        public DateTime DatumZaposlenja { get; set; }
        public int GodineStaza { get; set; }
        public string Jezici { get; set; }
        public string TipZaposlenja { get; set; }
        public string TrajanjeUgovora { get; set; }

        public virtual Korisnici Korisnik { get; set; }
        public Apotekar Apotekar { get; set; }
        public Doktor Doktor { get; set; }
        public MedicinskaSestra MedicinskaSestra { get; set; }
    }
}
