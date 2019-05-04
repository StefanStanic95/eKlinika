using System;
using System.Collections.Generic;

namespace eKlinika.WebAPI.Database
{
    public partial class Narudzba
    {
        public Narudzba()
        {
            NarudzbaStavka = new HashSet<NarudzbaStavka>();
        }

        public int Id { get; set; }
        public DateTime? DatumIsporuke { get; set; }
        public DateTime DatumNarudzbe { get; set; }
        public int DobavljacId { get; set; }

        public Dobavljac Dobavljac { get; set; }
        public ICollection<NarudzbaStavka> NarudzbaStavka { get; set; }
    }
}
