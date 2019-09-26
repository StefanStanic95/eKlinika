using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eKlinika.ViewModels
{
    public class LijekDodajVM
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Naziv je obavezan.")]
        [StringLength(maximumLength: 50, MinimumLength = 5)]
        public string Naziv { get; set; }

        [Required(ErrorMessage ="Tip je obavezan")]
        public string Tip { get; set; }

        [Required(ErrorMessage ="Uputstvo je obavezno unijeti.")]
        public string Uputstvo { get; set; }
        
        [Display(Name = "Po receptu")]
        public bool PoReceptu { get; set; }

        [Required]
        [Display(Name = "Ukupno na stanju")]
        public int UkupnoNaStanju { get; set; }

        [Required]
        [Display(Name = "Cijena po komadu")]
        public double CijenaPoKomadu { get; set; }

        [Required]
        public string Proizvodjac { get; set; }
        public List<SelectListItem> Proizvodjaci { get; set; }
    }
}
