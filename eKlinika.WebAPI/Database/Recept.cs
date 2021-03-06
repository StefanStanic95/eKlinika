﻿using System;
using System.Collections.Generic;

namespace eKlinika.WebAPI.Database
{
    public partial class Recept
    {
        public int Id { get; set; }
        public DateTime DatumIzdavanja { get; set; }
        public int LijekId { get; set; }
        public int PregledId { get; set; }
        public string Uputstvo { get; set; }
        public bool IsObradjen { get; set; }

        public Lijek Lijek { get; set; }
        public Pregled Pregled { get; set; }
    }
}
