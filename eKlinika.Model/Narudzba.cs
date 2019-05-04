using System;
using System.Collections.Generic;
using System.Text;

namespace eKlinika.Model
{
    public class Narudzba
    {
        public Narudzba()
        {
            NarudzbaStavka = new HashSet<NarudzbaStavka>();
        }
        public int Id { get; set; }
        public DateTime? DatumIsporuke { get; set; }
        public DateTime DatumNarudzbe { get; set; }
        public Dobavljac Dobavljac { get; set; }
        public double Iznos { get; set; }
        public ICollection<NarudzbaStavka> NarudzbaStavka { get; set; }
    }
}
