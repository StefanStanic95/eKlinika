using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eKlinika.ViewModels
{
    public class NarudzbaDodajVM
    {
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Datum narudzbe")]
        public DateTime DatumNarudzbe { get; set; }

        [Display(Name = "Datum isporuke")]
        public DateTime? DatumIsporuke { get; set; }

        [Required]
        public double Iznos { get; set; }

        [Required]
        [Display(Name = "Dobavljac")]
        public int DobavljacId { get; set; }
        public List<SelectListItem> Dobavljaci { get; set; }

        [Required]
        [Display(Name = "Lijek")]
        public int LijekId { get; set; }
        public List<SelectListItem> Lijekovi { get; set; }

        [Required]
        public int Kolicina { get; set; }
    }
}
