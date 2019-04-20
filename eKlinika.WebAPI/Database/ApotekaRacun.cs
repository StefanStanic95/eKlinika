using System;
using System.Collections.Generic;

namespace eKlinika.WebAPI.Database
{
    public partial class ApotekaRacun
    {
        public ApotekaRacun()
        {
            RacunStavka = new HashSet<RacunStavka>();
        }

        public int Id { get; set; }
        public int ApotekarId { get; set; }
        public DateTime DatumIzdavanja { get; set; }
        public int PacijentId { get; set; }

        public Apotekar Apotekar { get; set; }
        public Pacijent Pacijent { get; set; }
        public ICollection<RacunStavka> RacunStavka { get; set; }
    }
}
