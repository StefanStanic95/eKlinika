using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.WebAPI.Database
{
    public class KorisniciUloge
    {
        public string UserId { get; set; }
        public int UlogaId { get; set; }

        public Uloge Uloga { get; set; }
        public Korisnici User { get; set; }
    }
}
