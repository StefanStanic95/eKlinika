using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.ViewModels
{
    public class ApotekaReceptDodajVM
    {
        public int Id { get; set; }
        public int Kolicina { get; set; }
        public int PregledId { get; set; }
        public string Uputstvo { get; set; }
        public int LijekId { get; set; }
        public List<SelectListItem> Lijekovi { get; set; }
    }
}
