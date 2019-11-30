using eKlinika.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.Web.ViewModels
{
    public class MedSestraPretragaVM
    {
        public string Text { get; set; }
        public List<MedicinskaSestra> MedSestre { get; set; }
    }
}
