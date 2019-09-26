using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.ViewModels
{
    public class PregledDodajVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Polje je obavezno.")]
        public DateTime DatumPregleda { get; set; }
        [Required(ErrorMessage = "Polje je obavezno.")]
        public string TipPregleda { get; set; }
        [Required(ErrorMessage = "Polje je obavezno.")]
        public string Napomena { get; set; }
        [Required(ErrorMessage = "Polje je obavezno.")]
        public string Prioritet { get; set; }
        [Required(ErrorMessage = "Polje je obavezno.")]
        public DateTime DatumRezervacije { get; set; }
        [Required(ErrorMessage = "Polje je obavezno.")]
        public int MedSestra { get; set; }
        [Required(ErrorMessage = "Polje je obavezno.")]
        public int Doktor { get; set; }
        [Required(ErrorMessage = "Polje je obavezno.")]
        public int Pacijent { get; set; }

        public List<SelectListItem> MedSestre { get; set; }
        public List<SelectListItem> Doktori { get; set; }
        public List<SelectListItem> Pacijenti { get; set; }
    }
}
