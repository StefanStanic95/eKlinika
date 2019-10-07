using eKlinika.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.ViewModels
{
    public class UputnicaDodajVM
    {
        public int Id { get; set; }

        public int DoktorId { get; set; }
        public int LabDoktorId { get; set; }
        public List<SelectListItem> Doktori { get; set; }
        public int PacijentId { get; set; }
        public int VrstePretrageId { get; set; }
        public List<SelectListItem> VrstePretrage { get; set; }
        public DateTime DatumUputnice { get; set; }
        public DateTime DatumRezultata { get; set; }
        public bool IsGotovNalaz { get; set; }
    }
}
