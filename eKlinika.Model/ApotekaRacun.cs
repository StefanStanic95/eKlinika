﻿using System;
using System.Collections.Generic;
using System.Text;

namespace eKlinika.Model
{
    public class ApotekaRacun
    {
        public int Id { get; set; }
        public int ApotekarId { get; set; }
        public DateTime DatumIzdavanja { get; set; }
        public DateTime? DatumUplate { get; set; }
        public int PacijentId { get; set; }

        public Apotekar Apotekar { get; set; }
        public Pacijent Pacijent { get; set; }
        public ICollection<RacunStavka> RacunStavka { get; set; }
        public double Iznos { get; set; }

        public string DatumIzdavanjaStr => DatumIzdavanja.ToShortDateString();
        public string DatumUplateStr => DatumUplate == null ? "-" : DatumUplate.Value.ToShortDateString();
        public bool RacunNeplacen => DatumUplate is null;
    }
}
