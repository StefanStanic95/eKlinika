using eKlinika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.ViewModels
{
    public class PreglediPretragaVM
    {
        public string Doktor { get; set; }
        public string Datum { get; set; }
        public string Pacijent { get; set; }
        public List<Pregled> Pregledi { get; set; }
    }
}
