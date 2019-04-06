using System;
using System.Collections.Generic;

namespace eKlinika.WebAPI.Database
{
    public partial class VrstaPretrage
    {
        public VrstaPretrage()
        {
            LabPretraga = new HashSet<LabPretraga>();
            Uputnica = new HashSet<Uputnica>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }

        public ICollection<LabPretraga> LabPretraga { get; set; }
        public ICollection<Uputnica> Uputnica { get; set; }
    }
}
