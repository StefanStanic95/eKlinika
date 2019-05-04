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

namespace eKlinika.WinUI.MedicinskeSestre
{
    public partial class frmUplateDetails : Form
    {
        APIService _service = new APIService("Uplate");
        APIService _servicePregled = new APIService("Pregled");
        APIService _serviceKorisnici = new APIService("Korisnici");



        private int? _id = null;
        public frmUplateDetails(int? id = null)
        {
            InitializeComponent();
            _id = id;

        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {

                Model.Uplata request = new Model.Uplata
                {
                    Id = _id ?? 0,
                    BrojUplatnice = txtBrojUplatnice.Text,
                    DatumUplate = dtpDatumUplate.Value.Date,
                    Iznos = double.Parse(txtIznos.Text),
                    Namjena = txtNamjena.Text,
                    PacijentId = ((Model.Korisnici)cmbPacijent.SelectedItem).Id,
                    ZiroRacun = txtZiroRacun.Text,
                    PregledId = ((Pregled)cmbPregled.SelectedItem).Id,
                };

                Model.Uplata entity = null;
                if (!_id.HasValue)
                {
                    try
                    {
                        entity = await _service.Insert<Model.Uplata>(request);
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
                        entity = await _service.Update<Model.Uplata>(_id.Value, request);
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

        private async void frmKorisniciDetails_Load(object sender, EventArgs e)
        {
            var search = new KorisniciSearchRequest()
            {
                Uloga = "Pacijent"
            };

            var korisniciList = await _serviceKorisnici.Get<List<Model.Korisnici>>(search);

            cmbPacijent.DataSource = korisniciList;
            cmbPacijent.DisplayMember = "ImePrezime";

            var preglediList = await _servicePregled.Get<List<Model.Pregled>>(search);

            cmbPregled.DataSource = preglediList;
            cmbPregled.DisplayMember = "DatumPregleda";

            if (_id.HasValue)
            {
                var entity = await _service.GetById<Model.Uplata>(_id);
                txtBrojUplatnice.Text = entity.BrojUplatnice;
                dtpDatumUplate.Value = entity.DatumUplate;
                txtIznos.Text = entity.Iznos.ToString();
                txtNamjena.Text = entity.Namjena;
                txtZiroRacun.Text = entity.ZiroRacun;

                foreach (Model.Korisnici item in cmbPacijent.Items)
                {
                    if (item.Id == entity.PacijentId)
                        cmbPacijent.SelectedItem = item;
                }

                foreach (Pregled item in cmbPregled.Items)
                {
                    if (item.Id == entity.PregledId)
                        cmbPregled.SelectedItem = item;
                }
            }
        }

        private void minimizeForm_Click(object sender, System.EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void maximizeForm_Click(object sender, System.EventArgs e)
        {
            WindowState = WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
        }

        private void closeForm_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void txtBrojUplatnice_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBrojUplatnice.Text) || txtBrojUplatnice.Text.Length < 5)
            {
                e.Cancel = true;
                errorProvider.SetError(txtBrojUplatnice, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider.SetError(txtBrojUplatnice, null);
            }
        }

        private void txtIznos_Validating(object sender, CancelEventArgs e)
        {
            double val;
            if (string.IsNullOrWhiteSpace(txtIznos.Text) || !double.TryParse(txtIznos.Text, out val) || val < 0.1)
            {
                e.Cancel = true;
                errorProvider.SetError(txtIznos, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider.SetError(txtIznos, null);
            }
        }

        private void txtNamjena_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNamjena.Text) || txtNamjena.Text.Length < 5)
            {
                e.Cancel = true;
                errorProvider.SetError(txtNamjena, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider.SetError(txtNamjena, null);
            }
        }

        private void txtZiroRacun_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtZiroRacun.Text) || txtZiroRacun.Text.Length < 16 || txtZiroRacun.Text.Length > 20)
            {
                e.Cancel = true;
                errorProvider.SetError(txtZiroRacun, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider.SetError(txtZiroRacun, null);
            }
        }

    }
}
