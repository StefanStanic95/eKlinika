using System;
using System.Collections.Generic;

namespace eKlinika.WebAPI.Database
{
    public partial class Modalitet
    {
        public Modalitet()
        {
            RezultatPretrage = new HashSet<RezultatPretrage>();
        }

        public int Id { get; set; }
        public int LabPretragaId { get; set; }
        public string Opis { get; set; }
        public bool IsReferentnaVrijednost { get; set; }

        public LabPretraga LabPretraga { get; set; }
        public ICollection<RezultatPretrage> RezultatPretrage { get; set; }
    }
}
