using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.ViewModels
{
    public class UplataIndexVM
    {
            public int Id { get; set; }
            public DateTime DatumUplate { get; set; }
            public double Iznos { get; set; }
            public string Namjena { get; set; }
            public string BrojUplatnice { get; set; }
            public string ZiroRacun { get; set; }
            public DateTime DatumPregleda { get; set; }
            public string BrojKnjizice { get; set; }
    }
    public class UplataIndexListVM
    {
        public List<UplataIndexVM> Uplate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Pretraga { get; set; }
    }
}
