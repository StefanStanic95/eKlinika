using System;
using System.Collections.Generic;

namespace eKlinika.WebAPI.Database
{
    public partial class Dijagnoza
    {
        public Dijagnoza()
        {
            UstanovljenaDijagnoza = new HashSet<UstanovljenaDijagnoza>();
        }

        public int Id { get; set; }
        public string Opis { get; set; }
        public string StrucniOpis { get; set; }

        public ICollection<UstanovljenaDijagnoza> UstanovljenaDijagnoza { get; set; }
    }
}
