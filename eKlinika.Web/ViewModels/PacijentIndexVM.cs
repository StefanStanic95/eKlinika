﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.ViewModels
{
    public class PacijentIndexVM
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Grad { get; set; }
    }
    public class PacijentIndexListVM
    {
        public List<PacijentIndexVM> Pacijenti { get; set; }
    }
}
