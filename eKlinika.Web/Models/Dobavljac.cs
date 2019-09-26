using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.Models
{
    public class Dobavljac
    {
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Kontakt { get; set; }

        [ForeignKey("Drzava")]
        public int DrzavaId { get; set; }
        public Drzava Drzava { get; set; }
    }
}
