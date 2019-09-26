using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.Models
{
    public enum VrstaVrijednosti
    {
        NumerickaVrijednost, Modalitet
    }

    public class LabPretraga
    {
        [Key]
        public int Id { get; set; }

        public string Naziv { get; set; }
        public string MjernaJedinica { get; set; }
        public double ReferentnaVrijednostDonja { get; set; }
        public double ReferentnaVrijednostGornja { get; set; }
        public VrstaVrijednosti VrstaVr { get; set; }

        [ForeignKey("VrstaPretrage")]
        public int VrstaPretrageId { get; set; }
        public VrstaPretrage VrstaPretrage { get; set; }
    }
}
