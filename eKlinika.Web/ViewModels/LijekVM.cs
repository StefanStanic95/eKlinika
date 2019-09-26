using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.ViewModels
{
    public class LijekVM
    {
        public int Id { get; set; }

        public string Naziv { get; set; }

        public string Tip { get; set; }

        public string Uputstvo { get; set; }

        [Display(Name = "Po receptu")]
        public bool PoReceptu { get; set; }

        [Display(Name = "Ukupno na stanju")]
        public int UkupnoNaStanju { get; set; }

        [Display(Name = "Cijena po komadu")]
        public double CijenaPoKomadu { get; set; }

        public string Proizvodjac { get; set; }
    }
}
