using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.Models
{
    public class RacunStavka
    {
        public int Id { get; set; }

        public int Kolicina { get; set;}
        
        [ForeignKey("Lijek")]
        public int LijekId { get; set; }
        public Lijek Lijek { get; set; }

        [ForeignKey("ApotekaRacun")]
        public int ApotekaRacunId { get; set; }
        public ApotekaRacun ApotekaRacun { get; set; }


    }
}
