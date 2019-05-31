using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace eKlinika.MobileApp.ViewModels
{
    public class PreglediViewModel : BaseViewModel
    {
        private readonly APIService _servicePregledi = new APIService("Pregled");

        public ObservableCollection<Model.Pregled> ListPregledi { get; set; } = new ObservableCollection<Model.Pregled>();

        public PreglediViewModel()
        {
            Title = "Pregledi pacijenta";
        }

        public async Task LoadPregled()
        {
            var list = await _servicePregledi.Get<List<Model.Pregled>>(null);
            ListPregledi.Clear();

            foreach (var pregled in list)
            {
                ListPregledi.Add(pregled);
            }

        }

    }
}
