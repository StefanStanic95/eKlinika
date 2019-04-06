using System;
using System.Collections.Generic;

namespace eKlinika.WebAPI.Database
{
    public partial class Doktor
    {
        public Doktor()
        {
            Pregled = new HashSet<Pregled>();
            UputnicaLaboratorijDoktor = new HashSet<Uputnica>();
            UputnicaUputioDoktor = new HashSet<Uputnica>();
        }

        public int Id { get; set; }
        public DateTime DatumSpecijalizacije { get; set; }
        public string Specijalizacija { get; set; }
        public string Titula { get; set; }

        public Osoblje IdNavigation { get; set; }
        public ICollection<Pregled> Pregled { get; set; }
        public ICollection<Uputnica> UputnicaLaboratorijDoktor { get; set; }
        public ICollection<Uputnica> UputnicaUputioDoktor { get; set; }
    }
}
