using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using eKlinika.MobileApp.Models;
using eKlinika.MobileApp.Views;
using System.Windows.Input;

namespace eKlinika.MobileApp.ViewModels
{
    public class MojProfilViewModel : BaseViewModel
    {
        private readonly APIService _service = new APIService("Korisnici");

        Model.Korisnici korisnik = null;
        private INavigation Navigation;

        public Model.Korisnici Korisnik
        {
            get { return korisnik; }
            set { SetProperty(ref korisnik, value); }
        }

        public MojProfilViewModel(INavigation navigation)
        {
            Title = "Moj profil";
            Navigation = navigation;
            NavigateToUrediCommand = new Command(async () => await NavigateToUredi());
        }

        private async Task NavigateToUredi()
        {
            await Navigation.PushAsync(new UrediProfilPage());
        }

        public async Task LoadKorisnika()
        {
            Korisnik = await _service.Get<Model.Korisnici>(null, "me");
        }

        public ICommand NavigateToUrediCommand { get; set; }


    }
}