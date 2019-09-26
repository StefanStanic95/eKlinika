using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.Models
{
    public class UstanovljenaDijagnoza
    {
        [Key]
        public int Id { get; set; }
        public string Detalji { get; set; }
        public string Napomena { get; set; }

        [ForeignKey("Pregled")]
        public int PregledId { get; set; }
        public Pregled Pregled { get; set; }

        [ForeignKey("Dijagnoza")]
        public int DijagnozaId { get; set; }
        public Dijagnoza Dijagnoza { get; set; }
    }
}
