using System;
using System.Collections.Generic;

namespace eKlinika.WebAPI.Database
{
    public partial class Lijek
    {
        public Lijek()
        {
            NarudzbaStavka = new HashSet<NarudzbaStavka>();
            RacunStavka = new HashSet<RacunStavka>();
            Recept = new HashSet<Recept>();
        }

        public int Id { get; set; }
        public double CijenaPoKomadu { get; set; }
        public string Naziv { get; set; }
        public bool PoReceptu { get; set; }
        public int ProizvodjacId { get; set; }
        public string Tip { get; set; }
        public int UkupnoNaStanju { get; set; }
        public string Uputstvo { get; set; }

        public Proizvodjac Proizvodjac { get; set; }
        public ICollection<NarudzbaStavka> NarudzbaStavka { get; set; }
        public ICollection<RacunStavka> RacunStavka { get; set; }
        public ICollection<Recept> Recept { get; set; }
    }
}
