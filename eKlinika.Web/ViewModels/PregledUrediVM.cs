using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.ViewModels
{
    public class PregledUrediVM
    {
        public int Id { get; set; }
        public DateTime DatumPregleda { get; set; }
        public string TipPregleda { get; set; }
        public string Napomena { get; set; }
        public string Prioritet { get; set; }
        public DateTime DatumRezervacije { get; set; }

        public List<SelectListItem> MedicinskaSestras { get; set; }
        public List<SelectListItem> Doktori { get; set; }
        public List<SelectListItem> Pacijenti { get; set; }

        public int MedicinskaSestraId { get; set; }
        public int DoktorId { get; set; }
        public int PacijentId { get; set; }

       
    }
}
