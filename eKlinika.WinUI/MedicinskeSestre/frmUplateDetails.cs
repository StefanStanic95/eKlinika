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

        //private void txtIme_Validating(object sender, CancelEventArgs e)
        //{
        //    if (string.IsNullOrWhiteSpace(txtBrojUplatnice.Text))
        //    {
        //        e.Cancel = true;
        //        errorProvider.SetError(txtBrojUplatnice, Resources.Validation_RequiredField);
        //    }
        //    else
        //    {
        //        errorProvider.SetError(txtBrojUplatnice, null);
        //    }
        //}

        //private void txtPrezime_Validating(object sender, CancelEventArgs e)
        //{
        //    if (string.IsNullOrWhiteSpace(txtPrezime.Text))
        //    {
        //        e.Cancel = true;
        //        errorProvider.SetError(txtPrezime, Resources.Validation_RequiredField);
        //    }
        //    else
        //    {
        //        errorProvider.SetError(txtPrezime, null);
        //    }
        //}

        //private void txtEmail_Validating(object sender, CancelEventArgs e)
        //{
        //    if (string.IsNullOrWhiteSpace(txtEmail.Text))
        //    {
        //        e.Cancel = true;
        //        errorProvider.SetError(txtEmail, Resources.Validation_RequiredField);
        //    }
        //    else
        //    {
        //        errorProvider.SetError(txtEmail, null);
        //    }
        //}

        //private void txtKorisnickoIme_Validating(object sender, CancelEventArgs e)
        //{
        //    if (string.IsNullOrWhiteSpace(txtKorisnickoIme.Text) || txtKorisnickoIme.Text.Length < 3)
        //    {
        //        e.Cancel = true;
        //        errorProvider.SetError(txtEmail, Resources.Validation_RequiredField);
        //    }
        //    else
        //    {
        //        errorProvider.SetError(txtEmail, null);
        //    }
        //}

        //private void txtPassword_Validating(object sender, CancelEventArgs e)
        //{
        //    bool dodavanje = !_id.HasValue;

        //    bool pass_empty = string.IsNullOrWhiteSpace(txtPassword.Text),
        //        confirm_empty = string.IsNullOrWhiteSpace(txtPasswordPotvrda.Text);

        //    if ((dodavanje || !confirm_empty) && pass_empty)
        //    {
        //        e.Cancel = true;
        //        errorProvider.SetError(txtPassword, Resources.Validation_RequiredField);
        //    }
        //    else if (!pass_empty && txtPassword.Text.Length < 3)
        //    {
        //        e.Cancel = true;
        //        errorProvider.SetError(txtPassword, Resources.Validation_PasswordLength);
        //    }
        //    else
        //    {
        //        errorProvider.SetError(txtPassword, null);
        //    }
        //}

        //private void txtPasswordPotvrda_Validating(object sender, CancelEventArgs e)
        //{
        //    bool dodavanje = !_id.HasValue;

        //    bool pass_empty = string.IsNullOrWhiteSpace(txtPassword.Text),
        //        confirm_empty = string.IsNullOrWhiteSpace(txtPasswordPotvrda.Text);

        //    if ((dodavanje || !pass_empty) && confirm_empty)
        //    {
        //        e.Cancel = true;
        //        errorProvider.SetError(txtPasswordPotvrda, Resources.Validation_RequiredField);
        //    }
        //    else if (!pass_empty && !confirm_empty && txtPassword.Text != txtPasswordPotvrda.Text)
        //    {
        //        e.Cancel = true;
        //        errorProvider.SetError(txtPasswordPotvrda, Resources.Validation_PasswordNotMatch);
        //    }
        //    else
        //    {
        //        errorProvider.SetError(txtPasswordPotvrda, null);
        //    }
        //}

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

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        //void frmPacijentiDetails_Paint(object sender, PaintEventArgs e)
        //{
        //    ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        //}
    }
}
