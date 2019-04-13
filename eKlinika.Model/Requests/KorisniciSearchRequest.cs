using System;
using System.Collections.Generic;
using System.Text;

namespace eKlinika.Model.Requests
{
    public class KorisniciSearchRequest
    {
        public string ImePrezime { get; set; }

        public bool IsUlogeLoadingEnabled { get; set; }
    }
}
