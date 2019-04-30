using eKlinika.Model;
using eKlinika.Model.Requests;
using eKlinika.WinUI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eKlinika.WinUI.Apotekar
{
    public partial class frmRacuniDetails : Form
    {
        APIService _service = new APIService("ApotekaRacun");
        APIService _serviceKorisnici = new APIService("Korisnici");


        private int? _id = null;
        public frmRacuniDetails(int? id = null)
        {
            InitializeComponent();
            _id = id;

        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {

                Model.ApotekaRacun request = new Model.ApotekaRacun
                {
                    Id = _id ?? 0,
                    DatumIzdavanja = dtpDatumIzdavanja.Value.Date,
                    PacijentId = ((Model.Korisnici)cmbPacijent.SelectedItem).Id,
                    ApotekarId = ((Model.Korisnici)cmbApotekar.SelectedItem).Id
                };

                Model.ApotekaRacun entity = null;
                if (!_id.HasValue)
                {
                    try
                    {
                        entity = await _service.Insert<Model.ApotekaRacun>(request);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Greška");

                    }
                }
                else
                {
                    try
                    {
                        entity = await _service.Update<Model.ApotekaRacun>(_id.Value, request);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Greška");

                    }
                }

                if (entity != null)
                {
                    MessageBox.Show("Uspješno izvršeno");
                }

            }

        }

        private async void frmRacuniDetails_Load(object sender, EventArgs e)
        {
            var search = new KorisniciSearchRequest()
            {
                Uloga = "Pacijent"
            };

            var korisniciList = await _serviceKorisnici.Get<List<Model.Korisnici>>(search);

            cmbPacijent.DataSource = korisniciList;
            cmbPacijent.DisplayMember = "ImePrezime";

            var apotekariList = await _serviceKorisnici.Get<List<Model.Korisnici>>(search);

            cmbApotekar.DataSource = apotekariList;
            cmbApotekar.DisplayMember = "ImePrezime";

            if (_id.HasValue)
            {
                var entity = await _service.GetById<Model.ApotekaRacun>(_id);
                dtpDatumIzdavanja.Value = entity.DatumIzdavanja;

                foreach (Model.Korisnici item in cmbApotekar.Items)
                {
                    if (item.Id == entity.ApotekarId)
                        cmbApotekar.SelectedItem = item;
                }

                foreach (Model.Korisnici item in cmbPacijent.Items)
                {
                    if (item.Id == entity.PacijentId)
                        cmbPacijent.SelectedItem = item;
                }
            }
        }

        private void closeForm_Click(object sender, System.EventArgs e)
        {
            Close();
        }

    }
}
