using System;
using System.Collections.Generic;

namespace eKlinika.WebAPI.Database
{
    public partial class Apotekar
    {
        public Apotekar()
        {
            ApotekaRacun = new HashSet<ApotekaRacun>();
        }

        public int Id { get; set; }
        public string OpisPosla { get; set; }

        public Osoblje IdNavigation { get; set; }
        public ICollection<ApotekaRacun> ApotekaRacun { get; set; }
    }
}
