using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.ViewModels
{
    public class TerminRezervacijaVM
    {
        public int Id { get; set; }
        public DateTime DatumRezervacije { get; set; }
        public string DatumTermina { get; set; }
        public string VrijemeTermina { get; set; }
        public string Napomena { get; set; }

        public List<SelectListItem> TipoviPregleda { get; set; }
        public string TipPregleda { get; set; }

        public List<SelectListItem>  Doktori { get; set; }
        public int DoktorId { get; set; }

        public List<SelectListItem> MedSestre { get; set; }
        public int MedicinskaSestraId { get; set; }

        public List<SelectListItem>  Pacijenti{ get; set; }
        public int PacijentId { get; set; }

    }
}
