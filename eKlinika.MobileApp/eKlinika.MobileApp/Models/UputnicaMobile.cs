using eKlinika.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace eKlinika.MobileApp.Models
{
    public class UputnicaMobile
    {

        public int Id { get; set; }
        public DateTime DatumRezultata { get; set; }
        public DateTime DatumUputnice { get; set; }
        public bool IsGotovNalaz { get; set; }
        public int LaboratorijDoktorId { get; set; }
        public int PacijentId { get; set; }
        public int UputioDoktorId { get; set; }
        public int VrstaPretrageId { get; set; }

        public Doktor LaboratorijDoktor { get; set; }
        public Doktor UputioDoktor { get; set; }
        public Pacijent Pacijent { get; set; }
        public VrstaPretrage VrstaPretrage { get; set; }

        public string IsGotovNalazStr { get => IsGotovNalaz ? "DA" : "NE"; }
    }
}
