using eKlinika.MobileApp.Models;
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
        private readonly APIService _serviceRecommender = new APIService("Recommender");

        public ObservableCollection<PregledMobile> ListPregledi { get; set; } = new ObservableCollection<PregledMobile>();

        public PreglediViewModel()
        {
            Title = "Pregledi pacijenta";
        }

        public async Task LoadPregled()
        {
            var list = await _servicePregledi.Get<List<PregledMobile>>(null);
            ListPregledi.Clear();

            foreach (var pregled in list)
            {
                var recommendedDoktori = await _serviceRecommender.GetById<List<Model.Doktor>>(pregled.Id);

                pregled.VisinaListeDijagnoza = pregled.UstanovljenaDijagnoza.Count * 32;
                pregled.VisinaListeDoktora = recommendedDoktori.Count * 84;
                pregled.RecommendedDoktori = recommendedDoktori;
                ListPregledi.Add(pregled);
            }

        }

    }
}
