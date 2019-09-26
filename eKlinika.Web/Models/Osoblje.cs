using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.Models
{
    public class Osoblje
    {
        [ForeignKey("Korisnici")]
        public int Id { get; set; }

        public DateTime DatumZaposlenja { get; set; }
        public string TipZaposlenja { get; set; }
        public string TrajanjeUgovora { get; set; }
        public string Jezici { get; set; }
        public int GodineStaza { get; set; }

        public virtual Korisnici Korisnici { get; set; }
    }
}
