using System;
using System.Collections.Generic;

namespace eKlinika.WebAPI.Database
{
    public partial class KrvnaGrupa
    {
        public KrvnaGrupa()
        {
            Pacijent = new HashSet<Pacijent>();
        }

        public int Id { get; set; }
        public string Naziv { get; set; }

        public ICollection<Pacijent> Pacijent { get; set; }
    }
}
