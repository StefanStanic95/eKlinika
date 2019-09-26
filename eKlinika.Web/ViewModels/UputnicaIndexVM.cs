using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.ViewModels
{
    public class UputnicaIndexVM
    {
        public List<SelectListItem> Pacijenti { get; set; }
        public int PacijentId { get; set; }
    }
}
