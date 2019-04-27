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

namespace eKlinika.WinUI.Pacijenti
{
    public partial class frmPacijentiDetails : Form
    {
        APIService _service = new APIService("Korisnici");
        APIService _ulogeService = new APIService("Uloge");
        APIService _krvneGrupeService = new APIService("KrvnaGrupa");


        private int? _id = null;
        public frmPacijentiDetails(int? id = null)
        {
            InitializeComponent();
            _id = id;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                var roleList = new List<int>();
                var ulogeList = await _ulogeService.Get<List<Model.Uloge>>(null);
                foreach (var item in ulogeList)
                {
                    if (item.Naziv == "Pacijent")
                    {
                        roleList.Add(item.Id);
                    }
                }

                KorisniciInsertRequest request = new KorisniciInsertRequest
                {
                    Email = txtEmail.Text,
                    Ime = txtIme.Text,
                    UserName = txtKorisnickoIme.Text,
                    Password = txtPassword.Text,
                    PasswordPotvrda = txtPasswordPotvrda.Text,
                    Prezime = txtPrezime.Text,
                    PhoneNumber = txtTelefon.Text,
                    Uloge = roleList,
                    
                    Pacijent = new Pacijent
                    {
                        BrojKartona = txtBrojKartona.Text,
                        Alergije = txtAlergije.Text,
                        BrojKnjizice = txtBrojKnjizice.Text,
                        DatumRegistracije = DateTime.Now,
                        KrvnaGrupaId = ((KrvnaGrupa)cmbKrvnaGrupa.SelectedValue).Id,
                        SpecijalniZahtjevi = txtSpecZahtjevi.Text,
                        Tezina = double.TryParse(txtTezina.Text, out var tezina) ? tezina : 0.0,
                        Visina = int.TryParse(txtVisina.Text, out var visina) ? visina : 0
                    }
                };

                Model.Korisnici entity = null;
                if (!_id.HasValue)
                {
                    try
                    {
                        entity = await _service.Insert<Model.Korisnici>(request);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Greška");

                    }
                }
                else
                {
                    request.Pacijent.Id = _id.Value;
                    try
                    {
                        entity = await _service.Update<Model.Korisnici>(_id.Value, request);
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
            var krvneGrupeList = await _krvneGrupeService.Get<List<Model.KrvnaGrupa>>(null);

            cmbKrvnaGrupa.DataSource = krvneGrupeList;
            cmbKrvnaGrupa.DisplayMember = "Naziv";

            if (_id.HasValue)
            {
                var entity = await _service.GetById<Model.Korisnici>(_id);
                txtEmail.Text = entity.Email;
                txtIme.Text = entity.Ime;
                txtKorisnickoIme.Text = entity.UserName;
                txtPrezime.Text = entity.Prezime;
                txtTelefon.Text = entity.PhoneNumber;
                txtBrojKartona.Text = entity.Pacijent.BrojKartona.ToString();
                txtAlergije.Text = entity.Pacijent.Alergije;
                txtBrojKnjizice.Text = entity.Pacijent.BrojKnjizice.ToString();
                dtpDatumRegistarcije.Value = entity.Pacijent.DatumRegistracije;
                foreach (KrvnaGrupa item in cmbKrvnaGrupa.Items)
                {
                    if (item.Id == entity.Pacijent.KrvnaGrupaId)
                        cmbKrvnaGrupa.SelectedItem = item;
                }
                txtSpecZahtjevi.Text = entity.Pacijent.SpecijalniZahtjevi;
                txtTezina.Text = entity.Pacijent.Tezina.ToString();
                txtVisina.Text = entity.Pacijent.Visina.ToString();
            }
        }

        private void txtIme_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtIme.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtIme, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider.SetError(txtIme, null);
            }
        }

        private void txtPrezime_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPrezime.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtPrezime, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider.SetError(txtPrezime, null);
            }
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtEmail, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider.SetError(txtEmail, null);
            }
        }

        private void txtKorisnickoIme_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKorisnickoIme.Text) || txtKorisnickoIme.Text.Length < 3)
            {
                e.Cancel = true;
                errorProvider.SetError(txtEmail, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider.SetError(txtEmail, null);
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            bool dodavanje = !_id.HasValue;

            bool pass_empty = string.IsNullOrWhiteSpace(txtPassword.Text),
                confirm_empty = string.IsNullOrWhiteSpace(txtPasswordPotvrda.Text);

            if ((dodavanje || !confirm_empty) && pass_empty)
            {
                e.Cancel = true;
                errorProvider.SetError(txtPassword, Resources.Validation_RequiredField);
            }
            else if (!pass_empty && txtPassword.Text.Length < 3)
            {
                e.Cancel = true;
                errorProvider.SetError(txtPassword, Resources.Validation_PasswordLength);
            }
            else
            {
                errorProvider.SetError(txtPassword, null);
            }
        }

        private void txtPasswordPotvrda_Validating(object sender, CancelEventArgs e)
        {
            bool dodavanje = !_id.HasValue;

            bool pass_empty = string.IsNullOrWhiteSpace(txtPassword.Text),
                confirm_empty = string.IsNullOrWhiteSpace(txtPasswordPotvrda.Text);

            if ((dodavanje || !pass_empty) && confirm_empty)
            {
                e.Cancel = true;
                errorProvider.SetError(txtPasswordPotvrda, Resources.Validation_RequiredField);
            }
            else if (!pass_empty && !confirm_empty && txtPassword.Text != txtPasswordPotvrda.Text)
            {
                e.Cancel = true;
                errorProvider.SetError(txtPasswordPotvrda, Resources.Validation_PasswordNotMatch);
            }
            else
            {
                errorProvider.SetError(txtPasswordPotvrda, null);
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

        //void frmPacijentiDetails_Paint(object sender, PaintEventArgs e)
        //{
        //    ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.Black, ButtonBorderStyle.Solid);
        //}
    }
}
