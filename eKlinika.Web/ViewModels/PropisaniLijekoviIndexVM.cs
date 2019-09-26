using eKlinika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.ViewModels
{
    public class PropisaniLijekoviIndexVM
    {
        public int PregledId { get; set; }
        public List<Recept> Recepti { get; set; }
    }
}
