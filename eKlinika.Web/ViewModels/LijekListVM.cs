using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.ViewModels
{
    public class LijekListVM
    {
        public IEnumerable<LijekVM> Lijekovi { get; set; }
    }
}
