using eKlinika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.ViewModels
{
    public class UstanovljenaDijagnozaIndexVM
    {
        public int PregledId { get; set; }
        public List<UstanovljenaDijagnoza> ustanovljeneDijagnoze { get; set; }
    }
}
