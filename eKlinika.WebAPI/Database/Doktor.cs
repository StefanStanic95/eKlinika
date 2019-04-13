using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace eKlinika.WebAPI.Database
{
    public partial class Doktor
    {
        public Doktor()
        {
            Pregled = new HashSet<Pregled>();
        }
        [ForeignKey("Osoblje")]
        public string Id { get; set; }
        public DateTime DatumSpecijalizacije { get; set; }
        public string Specijalizacija { get; set; }
        public string Titula { get; set; }

        public virtual Osoblje Osoblje { get; set; }
        public ICollection<Pregled> Pregled { get; set; }
    }
}
