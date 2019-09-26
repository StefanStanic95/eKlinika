using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eKlinika.ViewModels
{
    public class ApotekaRacunVM
    {
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd MMM yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Datum { get; set; }

        [Required]
        [Display(Name = "Apotekar")]
        public int ApotekarId { get; set; }
        public List<SelectListItem> Apotekari { get; set; }

        [Required]
        public int PacijentId { get; set; }
        public List<SelectListItem> Pacijenti { get; set; }

        [Required]
        public List<string> LijekId { get; set; }
        public List<SelectListItem> Lijekovi { get; set; }
    }
}
