using System;
using System.Collections.Generic;
using System.Text;

namespace eKlinika.Model
{
    public class NarudzbaStavka
    {
        public int Id { get; set; }
        public int Kolicina { get; set; }
        public int LijekId { get; set; }
        public int NarudzbaId { get; set; }

        public Lijek Lijek { get; set; }
    }
}
