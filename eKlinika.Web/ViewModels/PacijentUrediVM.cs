using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.ViewModels
{
    public class PacijentUrediVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Polje je obavezno.")]
        [RegularExpression("[A-Za-z\\sšđčćžŠĐČĆŽ]{2,50}", ErrorMessage = "Nepravilan format.")]
        public string Ime { get; set; }
        [Required(ErrorMessage = "Polje je obavezno.")]
        [RegularExpression("[A-Za-z\\sšđčćžŠĐČĆŽ]{2,50}", ErrorMessage = "Nepravilan format.")]
        public string Prezime { get; set; }

        [Required(ErrorMessage = "Polje je obavezno.")]
        [RegularExpression("[0-9]{1,25}", ErrorMessage = "Nepravilan format.")]
        public string BrojKnjizice { get; set; }

        [Required(ErrorMessage = "Polje je obavezno.")]
        [RegularExpression("[0-9]{1,25}", ErrorMessage = "Nepravilan format.")]
        public string BrojKartona { get; set; }

        [Required(ErrorMessage = "Polje je obavezno.")]
        public DateTime DatumRegistracije { get; set; }

        [Required(ErrorMessage = "Polje je obavezno.")]
        [Range(minimum: 1, maximum: 250, ErrorMessage = "Nepravilan format.")]
        public int Visina { get; set; }

        [Required(ErrorMessage = "Polje je obavezno.")]
        [Range(minimum: 1, maximum: 999, ErrorMessage = "Nepravilan format.")]
        public double Tezina { get; set; }

        public string Alergije { get; set; }
        public string SpecijalniZahtjevi { get; set; }
        [Required(ErrorMessage = "Polje je obavezno.")]
        [RegularExpression("\\+?\\d{9,15}", ErrorMessage = "Nepravilan format.")]
        public string Telefon { get; set; }
        [Required(ErrorMessage = "Polje je obavezno.")]
        public string Grad { get; set; }
        public string KrvnaGrupa { get; set; }
        public string Slika { get; set; }

        public List<SelectListItem> Gradovi { get; set; }
        public List<SelectListItem> KrvneGrupe { get; set; }
        public List<SelectListItem> Spolovi { get; set; }

        [Required(ErrorMessage = "Polje je obavezno.")]
        [RegularExpression("\\d{13}", ErrorMessage = "Nepravilan format.")]
        public string JMBG { get; set; }
        [Required(ErrorMessage = "Polje je obavezno.")]
        public string Ulica { get; set; }
        [Required(ErrorMessage = "Polje je obavezno.")]
        public DateTime DatumRodjenja { get; set; }
        [Required(ErrorMessage = "Polje je obavezno.")]
        [RegularExpression("[A-Za-z\\s0-9]{1,50}", ErrorMessage = "Nepravilan format.")]
        public string Broj { get; set; }
        [Required(ErrorMessage = "Polje je obavezno.")]
        public string Spol { get; set; }
    }
}
