using System;
using System.Collections.Generic;
using System.Text;

namespace eKlinika.Model
{
    public class Apotekar
    {
        public int Id { get; set; }
        public string OpisPosla { get; set; }

        public Osoblje Osoblje { get; set; }
    }
}
