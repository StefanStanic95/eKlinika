using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.Models
{
    public class Narudzba
    {
        [Key]
        public int Id { get; set; }
        public DateTime DatumNarudzbe { get; set; }
        public DateTime? DatumIsporuke { get; set; }
        public double Iznos { get; set; }

        [ForeignKey("Dobavljac")]
        public int DobavljacId { get; set; }
        public Dobavljac Dobavljac { get; set; }
    }
}
