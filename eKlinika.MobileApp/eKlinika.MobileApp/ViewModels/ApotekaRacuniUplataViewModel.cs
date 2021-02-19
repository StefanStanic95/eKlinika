using eKlinika.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Threading.Tasks;

namespace eKlinika.MobileApp.ViewModels
{
    public class ApotekaRacuniUplataViewModel : BaseViewModel
    {
        private readonly APIService _serviceUplate = new APIService("ApotekaRacun");
        private readonly int id;
        private ApotekaRacun _racun;

        public ApotekaRacun Racun
        {
            get { return _racun; }
            set { _racun = value; }
        }


        public ApotekaRacuniUplataViewModel(int Id)
        {
            Title = "Uplata apotekarskog računa";
            id = Id;
        }

        public async Task LoadRacun()
        {
            Racun = await _serviceUplate.GetById<Model.ApotekaRacun>(id);
        }

    }
}
