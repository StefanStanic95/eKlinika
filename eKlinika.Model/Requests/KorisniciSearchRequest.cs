﻿using System;
using System.Collections.Generic;
using System.Text;

namespace eKlinika.Model.Requests
{
    public class KorisniciSearchRequest
    {
        public string Ime { get; set; }

        public string Prezime { get; set; }

        public string ImePrezime { get; set; }

        public string Uloga { get; set; }
    }
}
