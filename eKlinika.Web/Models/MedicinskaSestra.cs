using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.Models
{
    public class MedicinskaSestra
    {
        [ForeignKey("Osoblje")]
        public int Id { get; set; }

        public string Kursevi { get; set; }
        public string Certifikati { get; set; }

        public virtual Osoblje Osoblje { get; set; }
    }
}
