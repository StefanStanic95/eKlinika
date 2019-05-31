using System;
using System.Collections.Generic;
using System.Text;

namespace eKlinika.Model
{
    public class MedicinskaSestra
    {
        public int Id { get; set; }
        public string Certifikati { get; set; }
        public string Kursevi { get; set; }

        public Osoblje Osoblje { get; set; }

        public string ImePrezime { get => Osoblje?.Korisnik?.Ime + " " + Osoblje?.Korisnik?.Prezime; }

    }
}
