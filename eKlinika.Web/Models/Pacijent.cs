using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.Models
{
    public class Pacijent
    {
        [ForeignKey("Korisnici")]
        public int Id { get; set; }

        public string BrojKnjizice { get; set; }
        public string BrojKartona { get; set; }
        public DateTime DatumRegistracije { get; set; }
        public int Visina { get; set; }
        public double Tezina { get; set; }
        public string Alergije { get; set; }
        public string SpecijalniZahtjevi { get; set; }

        [ForeignKey("KrvnaGrupa")]
        public int KrvnaGrupaId { get; set; }
        public KrvnaGrupa KrvnaGrupa { get; set; }

        public virtual Korisnici Korisnici { get; set; }

    }
}
