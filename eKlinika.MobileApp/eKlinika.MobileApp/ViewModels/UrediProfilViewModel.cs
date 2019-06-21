using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Threading.Tasks;

using Xamarin.Forms;

using eKlinika.MobileApp.Models;
using eKlinika.MobileApp.Views;
using System.Windows.Input;
using System.Collections.Generic;

namespace eKlinika.MobileApp.ViewModels
{
    public class UrediProfilViewModel : BaseViewModel
    {
        private readonly APIService _service = new APIService("Korisnici");

        Model.Korisnici korisnik = null;
        private INavigation Navigation;

        public Model.Korisnici Korisnik
        {
            get { return korisnik; }
            set { SetProperty(ref korisnik, value); }
        }

        public UrediProfilViewModel(INavigation navigation)
        {
            Title = "Uredi profil";
            SacuvajIzmjeneCommand = new Command(async () => await SacuvajIzmjene());
            Navigation = navigation;
        }

        private async Task SacuvajIzmjene()
        {
            if (!string.IsNullOrEmpty(Lozinka))
            {
                if(Lozinka != LozinkaPotvrda)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Passwordi se ne podudaraju!", "OK");
                    return;
                }
            }

            var request = new Model.Requests.PacijentUpdateRequest
            {
                Email = korisnik.Email,
                Password = Lozinka,
                PasswordPotvrda = LozinkaPotvrda,
                PhoneNumber = korisnik.PhoneNumber,
                UserName = korisnik.UserName,
                Slika = korisnik.Slika,
                Pacijent1 = new Model.Pacijent
                {
                    Alergije = korisnik.Pacijent.Alergije,
                    Tezina = korisnik.Pacijent.Tezina,
                    Visina = korisnik.Pacijent.Visina
                }
            };

            var entity = await _service.Update<Model.Korisnici>(APIService.Korisnik.Id, request, "UpdatePacijent");
            if (entity != null)
            {
                APIService.Username = korisnik.UserName;
                if (!string.IsNullOrEmpty(Lozinka))
                {
                    APIService.Password = Lozinka;
                }

                await Application.Current.MainPage.DisplayAlert("Uspjeh", "Profil je uspješno izmijenjen.", "OK");
                await Navigation.PushAsync(new MojProfilPage());
            }
        }

        public async Task LoadKorisnika()
        {
            Korisnik = await _service.Get<Model.Korisnici>(null, "me");
        }

        public ICommand SacuvajIzmjeneCommand { get; set; }

        private string _lozinka = string.Empty;

        public string Lozinka
        {
            get { return _lozinka; }
            set { SetProperty(ref _lozinka, value); }
        }

        private string _lozinkaPotvrda = string.Empty;

        public string LozinkaPotvrda
        {
            get { return _lozinkaPotvrda; }
            set { SetProperty(ref _lozinkaPotvrda, value); }
        }

    }
}