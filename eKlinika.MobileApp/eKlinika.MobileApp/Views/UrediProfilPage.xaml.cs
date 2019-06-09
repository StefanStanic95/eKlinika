using eKlinika.MobileApp.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eKlinika.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UrediProfilPage : ContentPage
    {
        private UrediProfilViewModel model;

        public UrediProfilPage()
        {
            InitializeComponent();
            BindingContext = model = new UrediProfilViewModel(this.Navigation);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.LoadKorisnika();
        }
    }
}