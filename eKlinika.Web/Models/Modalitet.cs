using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.Models
{
    public class Modalitet
    {
        [Key]
        public int Id { get; set; }
        public string Opis { get; set; }
        public bool isReferentnaVrijednost { get; set; }

        [ForeignKey("LabPretraga")]
        public int LabPretragaId { get; set; }
        public LabPretraga LabPretraga { get; set; }
    }
}
