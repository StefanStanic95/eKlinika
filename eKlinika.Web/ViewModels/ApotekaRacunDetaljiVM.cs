using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.ViewModels
{
    public class ApotekaRacunDetaljiVM
    {
        public int Id { get; set; }
        public string Apotekar { get; set; }
        public string Pacijent { get; set; }
        
        [DataType(DataType.Date)]
        [Display(Name = "Datum izdavanja")]
        public DateTime DatumIzdavanja { get; set; }

        [Display(Name = "Ukupan iznos")]
        public double UkupniIznos { get; set; }

        public List<RacunStavkaDetaljiVM> Artikli { get; set; }
    }
}
