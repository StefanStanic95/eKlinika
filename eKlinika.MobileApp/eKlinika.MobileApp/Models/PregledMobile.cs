using eKlinika.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace eKlinika.MobileApp.Models
{
    public class PregledMobile
    {
        public int Id { get; set; }
        public DateTime DatumPregleda { get; set; }
        public DateTime DatumRezervacije { get; set; }
        public string Napomena { get; set; }
        public string Prioritet { get; set; }
        public string TipPregleda { get; set; }
        public bool IsOdrzan { get; set; }

        public int DoktorId { get; set; }
        public int MedicinskaSestraId { get; set; }
        public int PacijentId { get; set; }

        public Doktor Doktor { get; set; }
        public MedicinskaSestra MedicinskaSestra { get; set; }
        public Pacijent Pacijent { get; set; }
        public ICollection<UstanovljenaDijagnoza> UstanovljenaDijagnoza { get; set; }

        public List<Doktor> RecommendedDoktori { get; set; }
        public int VisinaListeDijagnoza { get; set; }
        public int VisinaListeDoktora { get; set; }
    }
}
