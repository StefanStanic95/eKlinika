using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.ViewModels
{
    public class UputnicaUrediVM
    {
        public int Id { get; set; }
        public DateTime DatumUputnice { get; set; }
        public DateTime DatumRezultata { get; set; }
        public bool IsGotovNalaz { get; set; }

        public List<SelectListItem> Pacijenti { get; set; }
        public List<SelectListItem> Doktori { get; set; }
        public List<SelectListItem> VrstePretraga { get; set; }

        public int PacijentId { get; set; }
        public string UputioDoktorId { get; set; }
        public int VrstaPretrageId { get; set; }
    }
}
