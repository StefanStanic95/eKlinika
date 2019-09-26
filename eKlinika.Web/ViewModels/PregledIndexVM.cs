using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.ViewModels
{

    public class PregledIndexVM
    {
        public int Id { get; set; }
        public DateTime DatumPregleda { get; set; }
        public string TipPregleda { get; set; }
        public string Napomena { get; set; }
        public string Prioritet { get; set; }
        public DateTime DatumRezervacije { get; set; }
        [Required]
        public string MedSestra { get; set; }
        [Required]
        public string Doktor { get; set; }
        [Required]
        public string Pacijent { get; set; }
    }
    public class PregledIndexListVM
    {
        public List<PregledIndexVM> Pregledi { get; set; }
        public int PacijentId { get; set; }
        public string Pretraga { get; set; }
    }

}
