using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.ViewModels
{
    public class NarudzbaIndexVM
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Datum narudzbe")]
        public DateTime DatumNarudzbe { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Datum isporuke")]
        public DateTime? DatumIsporuke { get; set; }

        public string Dobavljac { get; set; }

        public string Lijek { get; set; }
        
        [Display(Name = "Cijena po komadu")]
        public double CijenaPoKomadu { get; set; }

        public int Kolicina { get; set; }

        [Display(Name = "Iznos narudzbe")]
        public double IznosNarudzbe { get; set; }
        public List<NarudzbaStavkaIndexVM> Stavke { get; set; }
    }

    public class NarudzbaStavkaIndexVM
    {
        public string Lijek { get; set; }
        public int Kolicina { get; set; }
        public double CijenaPoKomadu { get; set; }
    }
}
