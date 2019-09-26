using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.Models
{
    public class Pregled
    {
        [Key]
        public int Id { get; set; }

        public DateTime DatumPregleda { get; set; }
        public string TipPregleda { get; set; }
        public string Napomena { get; set; }
        public string Prioritet { get; set; }
        public DateTime DatumRezervacije { get; set; }
        public bool isOdrzan { get; set; }

        [ForeignKey("MedicinskaSestra")]
        public int MedicinskaSestraId { get; set; }
        public MedicinskaSestra MedicinskaSestra { get; set; }
        
        [ForeignKey("Uplata")]
        public int? UplataId { get; set; }
        public Uplata Uplata { get; set; }

        [ForeignKey("Doktor")]
        public int DoktorId { get; set; }
        public Doktor Doktor { get; set; }

        [ForeignKey("Pacijent")]
        public int PacijentId { get; set; }
        public Pacijent Pacijent { get; set; }
    }
}
