using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.ViewModels
{
    public class UplataUrediVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Polje je obavezno.")]
        public DateTime DatumUplate { get; set; }
        [Required(ErrorMessage = "Polje je obavezno.")]
        [Range(minimum:0, maximum:10000000, ErrorMessage = "Neispravan iznos.")]
        public double Iznos { get; set; }
        [Required(ErrorMessage = "Polje je obavezno.")]
        public string Namjena { get; set; }
        [Required(ErrorMessage = "Polje je obavezno.")]
        [RegularExpression("\\d{1,}", ErrorMessage = "Neispravan format.")]
        public string BrojUplatnice { get; set; }
        [Required(ErrorMessage = "Polje je obavezno.")]
        [RegularExpression("\\d{1,}", ErrorMessage = "Neispravan format.")]
        public string ZiroRacun { get; set; }
        public int PregledId { get; set; }
        public int PacijentId { get; set; }
    }
}
