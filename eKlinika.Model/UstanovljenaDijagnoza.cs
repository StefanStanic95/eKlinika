using System;
using System.Collections.Generic;

namespace eKlinika.Model
{
    public partial class UstanovljenaDijagnoza
    {
        public int Id { get; set; }
        public string Detalji { get; set; }
        public int DijagnozaId { get; set; }
        public string Napomena { get; set; }
        public int PregledId { get; set; }

        public Dijagnoza Dijagnoza { get; set; }
    }
}
