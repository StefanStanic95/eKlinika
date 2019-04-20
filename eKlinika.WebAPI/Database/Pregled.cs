using System;
using System.Collections.Generic;

namespace eKlinika.WebAPI.Database
{
    public partial class Pregled
    {
        public Pregled()
        {
            Recept = new HashSet<Recept>();
            UstanovljenaDijagnoza = new HashSet<UstanovljenaDijagnoza>();
        }

        public int Id { get; set; }
        public DateTime DatumPregleda { get; set; }
        public DateTime DatumRezervacije { get; set; }
        public int DoktorId { get; set; }
        public int MedicinskaSestraId { get; set; }
        public string Napomena { get; set; }
        public string Prioritet { get; set; }
        public string TipPregleda { get; set; }
        public int? UplataId { get; set; }
        public bool IsOdrzan { get; set; }
        public int PacijentId { get; set; }

        public Doktor Doktor { get; set; }
        public MedicinskaSestra MedicinskaSestra { get; set; }
        public Pacijent Pacijent { get; set; }
        public Uplata Uplata { get; set; }
        public ICollection<Recept> Recept { get; set; }
        public ICollection<UstanovljenaDijagnoza> UstanovljenaDijagnoza { get; set; }
    }
}
