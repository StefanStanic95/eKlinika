using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace eKlinika.ViewModels
{
    public class RacunStavkaDodajVM
    {
        public int ApotekaRacunId { get; set; }
        public int LijekId { get; set; }
        public List<SelectListItem> Lijekovi { get; set; }
        public int Kolicina { get; set; }
    }
}
