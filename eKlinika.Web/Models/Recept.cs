using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.Models
{
    public class Recept
    {
        [Key]
        public int Id { get; set; }
        public DateTime DatumIzdavanja { get; set; }
        public string Uputstvo { get; set; }
        public int Kolicina { get; set; }
        public bool IsObradjen { get; set; }

        [ForeignKey("Pregled")]
        public int PregledId { get; set; }
        public Pregled Pregled { get; set; }

        [ForeignKey("Lijek")]
        public int LijekId { get; set; }
        public Lijek Lijek { get; set; }
    }
}
