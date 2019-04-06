using System;
using System.Collections.Generic;

namespace eKlinika.WebAPI.Database
{
    public partial class Grad
    {
        public Grad()
        {
            Korisnici = new HashSet<Korisnici>();
        }

        public int Id { get; set; }
        public int DrzavaId { get; set; }
        public string Naziv { get; set; }
        public string PostanskiBroj { get; set; }

        public Drzava Drzava { get; set; }
        public ICollection<Korisnici> Korisnici { get; set; }
    }
}
