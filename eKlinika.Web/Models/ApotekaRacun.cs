using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.Models
{
    public class ApotekaRacun
    {
        [Key]
        public int Id { get; set; }
        public DateTime DatumIzdavanja { get; set; }

        [ForeignKey("Apotekar")]
        public int ApotekarId { get; set; }
        public Apotekar Apotekar { get; set; }

        [ForeignKey("Pacijent")]
        public int PacijentId { get; set; }
        public Pacijent Pacijent { get; set; }
    }
}
