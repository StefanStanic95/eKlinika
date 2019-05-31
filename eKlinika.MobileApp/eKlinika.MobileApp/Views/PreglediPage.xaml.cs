using eKlinika.MobileApp.ViewModels;
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
	public partial class PreglediPage : ContentPage
	{
        private PreglediViewModel model;

        public PreglediPage()
        {
            InitializeComponent();
            BindingContext = model = new PreglediViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.LoadPregled();
        }
    }
}