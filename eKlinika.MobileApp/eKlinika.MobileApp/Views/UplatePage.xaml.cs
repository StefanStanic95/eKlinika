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
    public partial class UplatePage : ContentPage
    {
        private UplateViewModel model;

        public UplatePage()
        {
            InitializeComponent();
            BindingContext = model = new UplateViewModel();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.LoadUplate();
        }
    }
}