using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.Models
{
    public class Doktor
    {
        [ForeignKey("Osoblje")]
        public int Id { get; set; }

        public string Specijalizacija { get; set; }
        public DateTime DatumSpecijalizacije { get; set; }
        public string Titula { get; set; }

        public virtual Osoblje Osoblje { get; set; }
    }
}
