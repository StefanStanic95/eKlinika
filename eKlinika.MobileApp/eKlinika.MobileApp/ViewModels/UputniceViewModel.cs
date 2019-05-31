using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace eKlinika.MobileApp.ViewModels
{
    public class UputniceViewModel : BaseViewModel
    {
        private readonly APIService _serviceUputnice = new APIService("Uputnica");

        public ObservableCollection<Models.UputnicaMobile> ListUputnice { get; set; } = new ObservableCollection<Models.UputnicaMobile>();

        public UputniceViewModel()
        {
            Title = "Uputnice pacijenta";
        }

        public async Task LoadUputnice()
        {
            var list = await _serviceUputnice.Get<List<Models.UputnicaMobile>>(null);
            ListUputnice.Clear();

            foreach (var uputnica in list)
            {
                ListUputnice.Add(uputnica);
            }

        }

    }
}
