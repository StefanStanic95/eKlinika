using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.ViewModels
{
    public class PropisaniLijekoviVM
    {
        public int PregledId { get; set; }
        public int LijekId { get; set; }
        public string Uputstvo { get; set; }
        public int Kolicina { get; set; }

        public List<SelectListItem> Lijekovi { get; set; }
    }
}
