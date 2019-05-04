using System;
using System.Collections.Generic;
using System.Text;

namespace eKlinika.Model
{
    public class Dobavljac
    {
        public int Id { get; set; }
        public Drzava Drzava { get; set; }
        public string Kontakt { get; set; }
        public string Naziv { get; set; }
    }
}
