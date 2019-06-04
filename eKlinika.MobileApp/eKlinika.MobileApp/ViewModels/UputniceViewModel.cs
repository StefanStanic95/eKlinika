using eKlinika.Model;
using eKlinika.Model.Requests;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace eKlinika.MobileApp.ViewModels
{
    public class UputniceViewModel : BaseViewModel
    {
        private readonly APIService _serviceUputnice = new APIService("Uputnica");
        private readonly APIService _serviceVrstaPretrage = new APIService("VrstaPretrage");

        public UputniceViewModel()
        {
            Title = "Uputnice pacijenta";
            InitCommand = new Command(async () => await LoadUputnice());
        }

        public ObservableCollection<Models.UputnicaMobile> ListUputnice { get; set; } = new ObservableCollection<Models.UputnicaMobile>();
        public ObservableCollection<Model.VrstaPretrage> ListVrstaPretrage { get; set; } = new ObservableCollection<Model.VrstaPretrage>();

        VrstaPretrage _selectedVrstaPretrage = null;
        public VrstaPretrage SelectedVrstaPretrage
        {
            get { return _selectedVrstaPretrage; }
            set
            {
                SetProperty(ref _selectedVrstaPretrage, value);
                if (value != null)
                {
                    InitCommand.Execute(null);
                }
            }
        }

        public ICommand InitCommand { get; set; }

        public async Task LoadUputnice()
        {

            if (ListVrstaPretrage.Count == 0)
            {
                var vrstaPretrageList = await _serviceVrstaPretrage.Get<List<VrstaPretrage>>(null);

                foreach (var vrstaPretrage in vrstaPretrageList)
                {
                    ListVrstaPretrage.Add(vrstaPretrage);
                }
            }

            UputnicaSearchRequest search = null;
            if (SelectedVrstaPretrage != null) {
                search = new UputnicaSearchRequest
                {
                    VrstaId = SelectedVrstaPretrage.Id
                };
            }

            var list = await _serviceUputnice.Get<List<Models.UputnicaMobile>>(search);

            ListUputnice.Clear();
            foreach (var uputnica in list)
            {
                ListUputnice.Add(uputnica);
            }

        }

    }
}
