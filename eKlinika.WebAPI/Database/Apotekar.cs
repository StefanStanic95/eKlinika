using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace eKlinika.WebAPI.Database
{
    public partial class Apotekar
    {
        public Apotekar()
        {
            ApotekaRacun = new HashSet<ApotekaRacun>();
        }

        [ForeignKey("Osoblje")]
        public int Id { get; set; }
        public string OpisPosla { get; set; }

        public virtual Osoblje Osoblje { get; set; }
        public ICollection<ApotekaRacun> ApotekaRacun { get; set; }
    }
}
