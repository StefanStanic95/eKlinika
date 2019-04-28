using System;
using System.Collections.Generic;

namespace eKlinika.WebAPI.Database
{
    public partial class Uputnica
    {
        //public Uputnica()
        //{
        //    RezultatPretrage = new HashSet<RezultatPretrage>();
        //}

        public int Id { get; set; }
        public DateTime DatumRezultata { get; set; }
        public DateTime DatumUputnice { get; set; }
        public bool IsGotovNalaz { get; set; }
        public int LaboratorijDoktorId { get; set; }
        public int PacijentId { get; set; }
        public int UputioDoktorId { get; set; }
        public int VrstaPretrageId { get; set; }

        public Doktor LaboratorijDoktor { get; set; }
        public Pacijent Pacijent { get; set; }
        public Doktor UputioDoktor { get; set; }
        public VrstaPretrage VrstaPretrage { get; set; }
        //public ICollection<RezultatPretrage> RezultatPretrage { get; set; }
    }
}
