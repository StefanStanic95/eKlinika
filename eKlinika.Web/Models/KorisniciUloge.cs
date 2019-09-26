using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.Models
{
    public class KorisniciUloge
    {
        public int Id { get; set; }

        public int KorisnikId { get; set; }
        public int UlogaId { get; set; }

        public Uloge Uloga { get; set; }
        public Korisnici Korisnik { get; set; }
    }
}
