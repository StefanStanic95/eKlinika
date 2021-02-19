using eKlinika.MobileApp.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eKlinika.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ApotekaRacuniUplataPage : ContentPage
    {
        private readonly int id;
        private readonly ApotekaRacuniUplataViewModel model;

        public ApotekaRacuniUplataPage(int Id)
        {
            InitializeComponent();
            BindingContext = model = new ApotekaRacuniUplataViewModel(Id);
            id = Id;
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.LoadRacun();

            var str = File.ReadAllText("StripePayment.html");
            str = str.Replace("{APIURL}", APIService.ApiUrl);
            str = str.Replace("{ApotekaRacunId}", id.ToString());

            var source = new HtmlWebViewSource
            {
                BaseUrl = DependencyService.Get<IBaseUrl>().Get(),
                Html = str
            };

            webView.Source = source;
        }

        private async void webView_Navigating(object sender, WebNavigatingEventArgs e)
        {
            if (e.Url.Contains("finished"))
                await Navigation.PopAsync();
        }
    }
}