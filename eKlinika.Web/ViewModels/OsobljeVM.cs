using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eKlinika.ViewModels
{
    public class OsobljeVM
    {
        //Application user
        public int Id { get; set; }
        public string JMBG { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public DateTime DatumRodjenja { get; set; }
        public string Telefon { get; set; }
        public string Ulica { get; set; }
        public string Broj { get; set; }
        public byte[] Slika { get; set; }

        public List<SelectListItem> Gradovi { get; set; }
        public int GradId { get; set; }

        public List<SelectListItem> Spolovi { get; set; }
        public string Spol { get; set; }

        //Osoblje

        public DateTime DatumZaposlenja { get; set; }        
        public string TrajanjeUgovora { get; set; }
        public string Jezici { get; set; }
        public int GodineStaza { get; set; }


        public List<SelectListItem> TipoviZaposlenja { get; set; }
        public string TipZaposlenja { get; set; }


        //Doktor
        public string Specijalizcija { get; set; }
        public DateTime DatumSpecijalizacije { get; set; }
        public string Titula { get; set; }

        //Medicinska Sestra

        public string Kursevi { get; set; }
        public string Certifikati { get; set; }

        //Apotekar

        public string OpisPosla { get; set; }


    }
}
