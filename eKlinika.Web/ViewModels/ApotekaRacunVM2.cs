using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace eKlinika.ViewModels
{
    public class ApotekaRacunVM2
    {
        [Display(Name = "Datum izdavanja")]
        public string Datum { get; set; }

        public int ApotekarId { get; set; }
        
        [Display(Name = "Apotekar")]
        public string ApotekarIme { get; set; }

        public int PacijentId { get; set; }

        [Display(Name = "Pacijent")]
        public string PacijentIme { get; set; }
        
        public List<string> LijekoviIds { get; set; }
        
        public List<string> LijekoviNazivi { get; set; }
        
        [Remote(controller: "ApotekaValidation", 
                action: "KolicineValidacija",
            ErrorMessage = "Problem")]
        public List<int> Kolicine { get; set; }
    }
}
