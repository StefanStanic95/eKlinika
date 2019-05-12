using eKlinika.MobileApp.Views;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eKlinika.MobileApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly APIService _service = new APIService("Korisnici");

        public LoginViewModel()
        {
            LoginCommand = new Command(async () => await Login());

        }
        string _username = string.Empty;
        public string Username
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }

        string _password = string.Empty;
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }

        public ICommand LoginCommand { get; set; }

        async Task Login()
        {
            IsBusy = true;
            APIService.Username = Username;
            APIService.Password = Password;

            try
            {
                APIService.Korisnik = await _service.Get<Model.Korisnici>(null, "me");

                bool IsPacijent = false;
                foreach (Model.KorisniciUloge item in APIService.Korisnik.KorisniciUloge)
                {
                    if (item.Uloga.Naziv == "Pacijent")
                        IsPacijent = true;
                }
                if (APIService.Korisnik.Pacijent is null)
                    IsPacijent = false;

                if (!IsPacijent)
                {
                    await Application.Current.MainPage.DisplayAlert("Greška", "Niste autorizovani", "OK");
                }
                else
                    Application.Current.MainPage = new MainPage();
            }
            catch (Exception ex)
            {

            }
        }
    }
}
