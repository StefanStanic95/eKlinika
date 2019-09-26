using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.ViewModels
{
    public class ApotekaRacunIndexVM
    {
        public IEnumerable<ApotekaRacunDetaljiVM> Racuni { get; set; }
    }
}
