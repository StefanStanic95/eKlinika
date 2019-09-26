using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.ViewModels
{
    public class PacijentListSearchVM
    {
        public IEnumerable<PacijentSearchVM> Pacijenti { get; set; }
    }
}
