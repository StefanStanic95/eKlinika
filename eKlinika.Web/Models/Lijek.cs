using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.Models
{
    public class Lijek
    {
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Tip { get; set; }
        public string Uputstvo { get; set; }
        public bool PoReceptu { get; set; }
        public int UkupnoNaStanju { get; set; }
        public double CijenaPoKomadu { get; set; }

        [ForeignKey("Proizvodjac")]
        public int ProizvodjacId { get; set; }
        public Proizvodjac Proizvodjac { get; set; }
    }
}
