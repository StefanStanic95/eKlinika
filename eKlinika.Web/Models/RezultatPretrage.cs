using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.Models
{
    public class RezultatPretrage
    {
        [Key]
        public int Id { get; set; }
        public double? NumerickaVrijednost { get; set; }

        [ForeignKey("Uputnica")]
        public int UputnicaId { get; set; }
        public Uputnica Uputnica { get; set; }
        
        [ForeignKey("Modalitet")]
        public int? ModalitetId { get; set; }
        public Modalitet Modalitet { get; set; }

        [ForeignKey("LabPretraga")]
        public int LabPretragaId { get; set; }
        public LabPretraga LabPretraga { get; set; }
    }
}
