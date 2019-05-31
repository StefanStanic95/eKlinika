using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using eKlinika.MobileApp.Models;
using eKlinika.MobileApp.Views;

namespace eKlinika.MobileApp.ViewModels
{
    public class MojProfilViewModel : BaseViewModel
    {
        private readonly APIService _service = new APIService("Korisnici");

        Model.Korisnici korisnik = null;
        public Model.Korisnici Korisnik
        {
            get { return korisnik; }
            set { SetProperty(ref korisnik, value); }
        }

        public MojProfilViewModel()
        {
            Title = "Moj profil";
        }

        public async Task LoadKorisnika()
        {
            Korisnik = await _service.Get<Model.Korisnici>(null, "me");
        }



    }
}