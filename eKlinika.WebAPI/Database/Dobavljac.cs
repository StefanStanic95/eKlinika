using System;
using System.Collections.Generic;

namespace eKlinika.WebAPI.Database
{
    public partial class Dobavljac
    {
        public Dobavljac()
        {
            Narudzba = new HashSet<Narudzba>();
        }

        public int Id { get; set; }
        public int DrzavaId { get; set; }
        public string Kontakt { get; set; }
        public string Naziv { get; set; }

        public Drzava Drzava { get; set; }
        public ICollection<Narudzba> Narudzba { get; set; }
    }
}
