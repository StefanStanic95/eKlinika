using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace eKlinika.WebAPI.Database
{
    public partial class MedicinskaSestra
    {
        public MedicinskaSestra()
        {
            Pregled = new HashSet<Pregled>();
        }
        [ForeignKey("Osoblje")]
        public int Id { get; set; }
        public string Certifikati { get; set; }
        public string Kursevi { get; set; }

        public Osoblje Osoblje { get; set; }
        public ICollection<Pregled> Pregled { get; set; }
    }
}
