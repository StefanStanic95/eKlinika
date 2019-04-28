using System;
using System.Collections.Generic;
using System.Text;

namespace eKlinika.Model
{
    public class Lijek
    {
        public int Id { get; set; }
        public double CijenaPoKomadu { get; set; }
        public string Naziv { get; set; }
        public bool PoReceptu { get; set; }
        public int ProizvodjacId { get; set; }
        public string Tip { get; set; }
        public int UkupnoNaStanju { get; set; }
        public string Uputstvo { get; set; }

        public Proizvodjac Proizvodjac { get; set; }
    }
}
