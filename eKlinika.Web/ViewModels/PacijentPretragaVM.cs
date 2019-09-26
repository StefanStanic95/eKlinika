using eKlinika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.ViewModels
{
    public class PacijentPretragaVM
    {
        public string Text { get; set; }
        public List<Pacijent> Pacijenti { get; set; }
    }
}
