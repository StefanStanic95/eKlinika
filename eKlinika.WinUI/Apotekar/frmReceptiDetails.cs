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
    public partial class frmReceptiDetails : Form
    {
        APIService _service = new APIService("Recept");
        APIService _serviceLijek = new APIService("Lijek");
        APIService _servicePregled = new APIService("Pregled");

        private int? _id = null;
        public frmReceptiDetails(int? id = null)
        {
            InitializeComponent();
            _id = id;

        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {

                Model.Recept request = new Model.Recept
                {
                    Id = _id ?? 0,
                    DatumIzdavanja = dtpDatumIzdavanja.Value.Date,
                    IsObradjen = chbObradjen.Checked,
                    LijekId = ((Model.Lijek)cmbLijek.SelectedItem).Id,
                    PregledId = ((Model.Pregled)cmbPregled.SelectedItem).Id,
                    Uputstvo = txtUputstvo.Text
                };

                Model.Recept entity = null;
                if (!_id.HasValue)
                {
                    try
                    {
                        entity = await _service.Insert<Model.Recept>(request);
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
                        entity = await _service.Update<Model.Recept>(_id.Value, request);
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

        private async void frmReceptiDetails_Load(object sender, EventArgs e)
        {
            var lijekoviList = await _serviceLijek.Get<List<Model.Lijek>>(null);
            cmbLijek.DataSource = lijekoviList;
            cmbLijek.DisplayMember = "Naziv";

            var preglediList = await _servicePregled.Get<List<Model.Pregled>>(null);
            cmbPregled.DataSource = preglediList;
            cmbPregled.DisplayMember = "DatumPregleda";

            if (_id.HasValue)
            {
                var entity = await _service.GetById<Model.Recept>(_id);
                dtpDatumIzdavanja.Value = entity.DatumIzdavanja;
                txtUputstvo.Text = entity.Uputstvo;
                chbObradjen.Checked = entity.IsObradjen;

                foreach (Model.Lijek item in cmbLijek.Items)
                {
                    if (item.Id == entity.LijekId)
                        cmbLijek.SelectedItem = item;
                }

                foreach (Model.Pregled item in cmbPregled.Items)
                {
                    if (item.Id == entity.PregledId)
                        cmbPregled.SelectedItem = item;
                }

            }
        }

        private void closeForm_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void txtUputstvo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUputstvo.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtUputstvo, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider.SetError(txtUputstvo, null);
            }
        }
    }
}
