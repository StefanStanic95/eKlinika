using System;
using System.Collections.Generic;

namespace eKlinika.WebAPI.Database
{
    public partial class NarudzbaStavka
    {
        public int Id { get; set; }
        public int Kolicina { get; set; }
        public int LijekId { get; set; }
        public int NarudzbaId { get; set; }

        public Lijek Lijek { get; set; }
        public Narudzba Narudzba { get; set; }
    }
}
