using System;
using System.Collections.Generic;

namespace eKlinika.WebAPI.Database
{
    public partial class MedicinskaSestra
    {
        public MedicinskaSestra()
        {
            Pregled = new HashSet<Pregled>();
        }

        public int Id { get; set; }
        public string Certifikati { get; set; }
        public string Kursevi { get; set; }

        public Osoblje IdNavigation { get; set; }
        public ICollection<Pregled> Pregled { get; set; }
    }
}
