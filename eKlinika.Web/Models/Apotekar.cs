using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.Models
{
    public class Apotekar
    {
        [ForeignKey("Osoblje")]
        public int Id { get; set; }

        public string OpisPosla { get; set; }

        public virtual Osoblje Osoblje { get; set; }
    }
}
