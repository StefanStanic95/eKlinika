using System;
using System.Collections.Generic;

namespace eKlinika.WebAPI.Database
{
    public partial class Proizvodjac
    {
        public Proizvodjac()
        {
            Lijek = new HashSet<Lijek>();
        }

        public int Id { get; set; }
        public string Kontakt { get; set; }
        public string Naziv { get; set; }

        public ICollection<Lijek> Lijek { get; set; }
    }
}
