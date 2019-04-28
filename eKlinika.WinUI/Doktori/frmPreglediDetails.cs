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

namespace eKlinika.WinUI.Doktori
{
    public partial class frmPreglediDetails : Form
    {
        APIService _service = new APIService("Pregled");
        APIService _serviceKorisnici = new APIService("Korisnici");


        private int? _id = null;
        public frmPreglediDetails(int? id = null)
        {
            InitializeComponent();
            _id = id;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                PregledInsertRequest request = new PregledInsertRequest
                {
                    DatumPregleda = dtpDatumPregleda.Value.Date,
                    DatumRezervacije = dtpDatumRezervacije.Value.Date,
                    DoktorId = ((Model.Korisnici)cmbDoktor.SelectedItem).Id,
                    MedicinskaSestraId = ((Model.Korisnici)cmbMedSestra.SelectedItem).Id,
                    PacijentId = ((Model.Korisnici)cmbPacijent.SelectedItem).Id,
                    Napomena = txtNapomena.Text,
                    Prioritet = txtPrioritet.Text,
                    TipPregleda = txtTipPregleda.Text,
                    IsOdrzan = chbOdrzan.Checked
                };

                Model.Pregled entity = null;
                if (!_id.HasValue)
                {
                    try
                    {
                        entity = await _service.Insert<Model.Pregled>(request);
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
                        entity = await _service.Update<Model.Pregled>(_id.Value, request);
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

        private async void frmPreglediDetails_Load(object sender, EventArgs e)
        {

            var searchDoktori = new KorisniciSearchRequest()
            {
                Uloga = "Doktor"
            };
            var searchPacijenti = new KorisniciSearchRequest()
            {
                Uloga = "Pacijent"
            };
            var searchMedSestre = new KorisniciSearchRequest()
            {
                Uloga = "MedicinskaSestra"
            };

            var doktoriList = await _serviceKorisnici.Get<List<Model.Korisnici>>(searchDoktori);
            var pacijentiList = await _serviceKorisnici.Get<List<Model.Korisnici>>(searchPacijenti);
            var medSestreList = await _serviceKorisnici.Get<List<Model.Korisnici>>(searchMedSestre);

            cmbMedSestra.DataSource = medSestreList;
            cmbMedSestra.DisplayMember = "ImePrezime";

            cmbDoktor.DataSource = doktoriList;
            cmbDoktor.DisplayMember = "ImePrezime";

            cmbPacijent.DataSource = pacijentiList;
            cmbPacijent.DisplayMember = "ImePrezime";

            if (_id.HasValue)
            {
                var entity = await _service.GetById<Model.Pregled>(_id);

                dtpDatumPregleda.Value = entity.DatumPregleda;
                dtpDatumRezervacije.Value = entity.DatumRezervacije;

                foreach (Model.Korisnici item in cmbDoktor.Items)
                {
                    if (item.Id == entity.DoktorId)
                        cmbDoktor.SelectedItem = item;
                }

                foreach (Model.Korisnici item in cmbMedSestra.Items)
                {
                    if (item.Id == entity.MedicinskaSestraId)
                        cmbMedSestra.SelectedItem = item;
                }

                foreach (Model.Korisnici item in cmbPacijent.Items)
                {
                    if (item.Id == entity.PacijentId)
                        cmbPacijent.SelectedItem = item;
                }

                chbOdrzan.Checked = entity.IsOdrzan;

                txtTipPregleda.Text = entity.TipPregleda;
                txtPrioritet.Text = entity.Prioritet;
                txtNapomena.Text = entity.Napomena;

            }
        }

        //private void txtIme_Validating(object sender, CancelEventArgs e)
        //{
        //    if (string.IsNullOrWhiteSpace(txtIme.Text))
        //    {
        //        e.Cancel = true;
        //        errorProvider.SetError(txtIme, Resources.Validation_RequiredField);
        //    }
        //    else
        //    {
        //        errorProvider.SetError(txtIme, null);
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

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        //void frmPacijentiDetails_Paint(object sender, PaintEventArgs e)
        //{
        //    ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        //}
    }
}
