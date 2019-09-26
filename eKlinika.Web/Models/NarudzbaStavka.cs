using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.Models
{
    public class NarudzbaStavka
    {
        [Key]
        public int Id { get; set; }
        public int Kolicina { get; set; }

        [ForeignKey("Narudzba")]
        public int NarudzbaId { get; set; }
        public Narudzba Narudzba { get; set; }

        [ForeignKey("Lijek")]
        public int LijekId { get; set; }
        public Lijek Lijek { get; set; }
    }
}
