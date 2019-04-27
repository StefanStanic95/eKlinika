using System;
using System.Collections.Generic;
using System.Text;

namespace eKlinika.Model
{
    public class Doktor
    {
        public int Id { get; set; }
        public DateTime DatumSpecijalizacije { get; set; }
        public string Specijalizacija { get; set; }
        public string Titula { get; set; }

        public Osoblje Osoblje { get; set; }

        public string ImePrezime { get => (Titula.Length != 0 ? Titula + " " : "") + Osoblje?.ImePrezime; }
    }
}
