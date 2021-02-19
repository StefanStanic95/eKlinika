using eKlinika.MobileApp.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace eKlinika.MobileApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : MasterDetailPage
    {
        Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();
        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.MojProfil, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.MojProfil:
                        MenuPages.Add(id, new NavigationPage(new MojProfilPage()));
                        break;
                    case (int)MenuItemType.Uplate:
                        MenuPages.Add(id, new NavigationPage(new UplatePage()));
                        break;
                    case (int)MenuItemType.Uputnice:
                        MenuPages.Add(id, new NavigationPage(new UputnicePage()));
                        break;
                    case (int)MenuItemType.Pregledi:
                        MenuPages.Add(id, new NavigationPage(new PreglediPage()));
                        break;
                    case (int)MenuItemType.ApotekaRacuni:
                        MenuPages.Add(id, new NavigationPage(new ApotekaRacuniPage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if (newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}