using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.Models
{
    public class Dijagnoza
    {
        [Key]
        public int Id { get; set; }
        public string StrucniOpis { get; set; }
        public string Opis { get; set; }
    }
}
