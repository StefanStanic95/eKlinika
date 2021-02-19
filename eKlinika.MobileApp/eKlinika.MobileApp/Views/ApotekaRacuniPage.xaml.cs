using eKlinika.MobileApp.ViewModels;
using eKlinika.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eKlinika.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ApotekaRacuniPage : ContentPage
    {
        private ApotekaRacuniViewModel model;

        public ApotekaRacuniPage()
        {
            InitializeComponent();
            BindingContext = model = new ApotekaRacuniViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.LoadRacuni();
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var btn = sender as Button;
            var racun = btn.BindingContext as ApotekaRacun;

            Navigation.PushAsync(new ApotekaRacuniUplataPage(racun.Id));
        }
    }
}