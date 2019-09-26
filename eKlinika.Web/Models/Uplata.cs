using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.Models
{
    public class Uplata
    {
        [Key]
        public int Id { get; set; }
        public DateTime DatumUplate { get; set; }
        public double Iznos { get; set; }
        public string Namjena { get; set; }
        public string BrojUplatnice { get; set; }
        public string ZiroRacun { get; set; }

        [ForeignKey("Pacijent")]
        public int PacijentId { get; set; }
        public virtual Pacijent Pacijent { get; set; }

        [ForeignKey("Pregled")]
        public int? PregledId { get; set; }
        public virtual Pregled Pregled { get; set; }


    }
}
