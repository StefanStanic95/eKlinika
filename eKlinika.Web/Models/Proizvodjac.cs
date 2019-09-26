﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.Models
{
    public class Proizvodjac
    {
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Kontakt { get; set; }
    }
}
