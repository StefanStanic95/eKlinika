using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace eKlinika.ViewModels
{
    public class UstanovljenaDijagnozaVM
    {
        public int Id { get; set; }
        public int PregledId { get; set; }
        public string Detalji { get; set; }
        public string Napomena { get; set; }
        public List<SelectListItem> DijagnozeList;
        public int DijagnozaId { get; set; }

    }
}
