using System;
using System.Collections.Generic;

namespace eKlinika.WebAPI.Database
{
    public partial class KorisniciUloge
    {
        public int UserId { get; set; }
        public int UlogaId { get; set; }

        public Uloge Uloga { get; set; }
        public Korisnici User { get; set; }
    }
}
