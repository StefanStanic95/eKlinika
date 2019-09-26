using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace eKlinika.Models
{
    public class Korisnici
    {
        //osoba je osnovni korisnik aplikacije

        public Korisnici()
        {
            KorisniciUloge = new HashSet<KorisniciUloge>();
        }


        public int Id { get; set; }
        public string UserName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string LozinkaHash { get; set; }
        public string LozinkaSalt { get; set; }

        public DateTime DatumRodjenja { get; set; }
        public int? GradId { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string JMBG { get; set; }
        public byte[] Slika { get; set; }
        public string Spol { get; set; }
        public string Ulica { get; set; }

        public Grad Grad { get; set; }
        public Osoblje Osoblje { get; set; }
        public Pacijent Pacijent { get; set; }

        public ICollection<KorisniciUloge> KorisniciUloge { get; set; }
        public string Telefon { get; internal set; }
        public string Broj { get; internal set; }
    }
}
