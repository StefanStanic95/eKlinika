using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace eKlinika.MobileApp.ViewModels
{
    public class ApotekaRacuniViewModel : BaseViewModel
    {
        private readonly APIService _serviceUplate = new APIService("ApotekaRacun");

        public ObservableCollection<Model.ApotekaRacun> ListRacuni { get; set; } = new ObservableCollection<Model.ApotekaRacun>();

        public ApotekaRacuniViewModel()
        {
            Title = "Apotekarski računi";
        }

        public async Task LoadRacuni()
        {
            var list = await _serviceUplate.Get<List<Model.ApotekaRacun>>(null);
            ListRacuni.Clear();

            foreach (var racun in list)
            {
                ListRacuni.Add(racun);
            }

        }

    }
}
