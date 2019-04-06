using System;
using System.Collections.Generic;

namespace eKlinika.WebAPI.Database
{
    public partial class Drzava
    {
        public Drzava()
        {
            Dobavljac = new HashSet<Dobavljac>();
            Grad = new HashSet<Grad>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Oznaka { get; set; }

        public ICollection<Dobavljac> Dobavljac { get; set; }
        public ICollection<Grad> Grad { get; set; }
    }
}
