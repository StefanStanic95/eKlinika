﻿using eKlinika.MobileApp.ViewModels;
using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eKlinika.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MojProfilPage : ContentPage
    {
        private MojProfilViewModel model;

        public MojProfilPage()
        {
            InitializeComponent();
            BindingContext = model = new MojProfilViewModel(this.Navigation);
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();
            await model.LoadKorisnika();
        }
    }
}