using System;
using System.Collections.Generic;

namespace eKlinika.WebAPI.Database
{
    public partial class Uloge
    {
        public Uloge()
        {
            KorisniciUloge = new HashSet<KorisniciUloge>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<KorisniciUloge> KorisniciUloge { get; set; }
    }
}
