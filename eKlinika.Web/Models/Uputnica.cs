using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.Models
{
    public class Uputnica
    {
        [Key]
        public int Id { get; set; }
        public DateTime DatumUputnice { get; set; }
        public DateTime DatumRezultata { get; set; }
        public bool IsGotovNalaz { get; set; }

        [ForeignKey("Pacijent")]
        public int PacijentId { get; set; }
        public Pacijent Pacijent { get; set; }

        [ForeignKey("Doktor")]
        public string UputioDoktorId { get; set; }
        public Doktor UputioDoktor { get; set; }

        [ForeignKey("Doktor")]
        public string LaboratorijDoktorId { get; set; }
        public Doktor LaboratorijDoktor { get; set; }

        [ForeignKey("VrstaPretrage")]
        public int VrstaPretrageId { get; set; }
        public VrstaPretrage VrstaPretrage { get; set; }
    }
}
