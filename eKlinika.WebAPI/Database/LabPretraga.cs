using System;
using System.Collections.Generic;

namespace eKlinika.WebAPI.Database
{
    public partial class LabPretraga
    {
        public LabPretraga()
        {
            Modalitet = new HashSet<Modalitet>();
            RezultatPretrage = new HashSet<RezultatPretrage>();
        }

        public int Id { get; set; }
        public string MjernaJedinica { get; set; }
        public string Naziv { get; set; }
        public double ReferentnaVrijednostDonja { get; set; }
        public double ReferentnaVrijednostGornja { get; set; }
        public int VrstaPretrageId { get; set; }
        public int VrstaVr { get; set; }

        public VrstaPretrage VrstaPretrage { get; set; }
        public ICollection<Modalitet> Modalitet { get; set; }
        public ICollection<RezultatPretrage> RezultatPretrage { get; set; }
    }
}
