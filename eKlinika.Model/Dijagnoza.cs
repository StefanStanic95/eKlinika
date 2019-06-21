using System;
using System.Collections.Generic;

namespace eKlinika.Model
{
    public partial class Dijagnoza
    {
        public int Id { get; set; }
        public string Opis { get; set; }
        public string StrucniOpis { get; set; }
        public string DoktorSpecijalizacija { get; set; }
    }
}
