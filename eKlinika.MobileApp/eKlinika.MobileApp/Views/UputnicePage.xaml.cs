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
	public partial class UputnicePage : ContentPage
	{

        private UputniceViewModel model;

        public UputnicePage()
        {
            InitializeComponent();
            BindingContext = model = new UputniceViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.LoadUputnice();
        }

        private async void Picker_SelectedIndexChanged(object sender, EventArgs e)
        {
            await model.LoadUputnice();
        }
    }
}