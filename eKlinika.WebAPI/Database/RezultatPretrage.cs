using System;
using System.Collections.Generic;

namespace eKlinika.WebAPI.Database
{
    public partial class RezultatPretrage
    {
        public int Id { get; set; }
        public int LabPretragaId { get; set; }
        public int? ModalitetId { get; set; }
        public double? NumerickaVrijednost { get; set; }
        public int UputnicaId { get; set; }

        public LabPretraga LabPretraga { get; set; }
        public Modalitet Modalitet { get; set; }
        public Uputnica Uputnica { get; set; }
    }
}
