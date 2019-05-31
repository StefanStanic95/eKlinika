using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace eKlinika.MobileApp.ViewModels
{
    public class UplateViewModel: BaseViewModel
    {
        private readonly APIService _serviceUplate = new APIService("Uplate");

        public ObservableCollection<Model.Uplata> ListUplate { get; set; } = new ObservableCollection<Model.Uplata>();

        public UplateViewModel()
        {
            Title = "Uplate pacijenta";
        }

        public async Task LoadUplate()
        {
            var list = await _serviceUplate.Get<List<Model.Uplata>>(null);
            ListUplate.Clear();

            foreach (var uplata in list)
            {
                ListUplate.Add(uplata);
            }

        }

    }
}
