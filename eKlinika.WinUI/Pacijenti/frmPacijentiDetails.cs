using eKlinika.Model;
using eKlinika.Model.Requests;
using eKlinika.WinUI.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eKlinika.WinUI.Pacijenti
{
    public partial class frmPacijentiDetails : Form
    {
        APIService _service = new APIService("Korisnici");
        APIService _ulogeService = new APIService("Uloge");
        APIService _krvneGrupeService = new APIService("KrvnaGrupa");
        KorisniciInsertRequest request = new KorisniciInsertRequest();

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

                request.Email = txtEmail.Text;
                request.Ime = txtIme.Text;
                request.UserName = txtKorisnickoIme.Text;
                request.Password = txtPassword.Text;
                request.PasswordPotvrda = txtPasswordPotvrda.Text;
                request.Prezime = txtPrezime.Text;
                request.PhoneNumber = txtTelefon.Text;
                request.Uloge = roleList;
                request.Pacijent = new Pacijent();
                request.Pacijent.BrojKartona = txtBrojKartona.Text;
                request.Pacijent.Alergije = txtAlergije.Text;
                request.Pacijent.BrojKnjizice = txtBrojKnjizice.Text;
                request.Pacijent.DatumRegistracije = DateTime.Now;
                request.Pacijent.KrvnaGrupaId = ((KrvnaGrupa)cmbKrvnaGrupa.SelectedValue).Id;
                request.Pacijent.SpecijalniZahtjevi = txtSpecZahtjevi.Text;
                request.Pacijent.Tezina = double.TryParse(txtTezina.Text, out var tezina) ? tezina : 0.0;
                request.Pacijent.Visina = int.TryParse(txtVisina.Text, out var visina) ? visina : 0;

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

                if(entity.Slika.Length > 0)
                {
                    using (MemoryStream ms = new MemoryStream(entity.Slika))
                    {
                        pbSlika.Image = Image.FromStream(ms);
                    }
                }
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
            Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtEmail, Resources.Validation_RequiredField);
            }
            else if (!regex.IsMatch(txtEmail.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtEmail, Resources.Validation_InvalidFormat);
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
                errorProvider.SetError(txtKorisnickoIme, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider.SetError(txtKorisnickoIme, null);
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

        private void txtTelefon_Validating(object sender, CancelEventArgs e)
        {
            var regex = new Regex(@"\+?([0-9]{9,15}|[0-9 ]{9,18})");
            if (string.IsNullOrWhiteSpace(txtTelefon.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtTelefon, Resources.Validation_RequiredField);
            }
            else if (txtTelefon.Text.Length < 9 || txtTelefon.Text.Length > 15
                || !regex.IsMatch(txtTelefon.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtTelefon, Resources.Validation_InvalidFormat);
            }
            else
            {
                errorProvider.SetError(txtTelefon, null);
            }
        }

        private void txtBrojKartona_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBrojKartona.Text) || txtBrojKartona.Text.Length > 10)
            {
                e.Cancel = true;
                errorProvider.SetError(txtBrojKartona, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider.SetError(txtBrojKartona, null);
            }
        }

        private void txtBrojKnjizice_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtBrojKnjizice.Text) || txtBrojKnjizice.Text.Length > 10)
            {
                e.Cancel = true;
                errorProvider.SetError(txtBrojKnjizice, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider.SetError(txtBrojKnjizice, null);
            }
        }

        private void txtTezina_Validating(object sender, CancelEventArgs e)
        {
            double val;
            if (string.IsNullOrWhiteSpace(txtTezina.Text) || !double.TryParse(txtTezina.Text, out val) || val < 0.1)
            {
                e.Cancel = true;
                errorProvider.SetError(txtTezina, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider.SetError(txtTezina, null);
            }
        }

        private void txtVisina_Validating(object sender, CancelEventArgs e)
        {
            int val;
            if (string.IsNullOrWhiteSpace(txtVisina.Text) || !int.TryParse(txtVisina.Text, out val) || val < 1)
            {
                e.Cancel = true;
                errorProvider.SetError(txtVisina, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider.SetError(txtVisina, null);
            }
        }

        private void btnOdaberiSliku_Click(object sender, EventArgs e)
        {
            var result = openFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;

                var file = File.ReadAllBytes(fileName);

                request.Slika = file;

                Image image = Image.FromFile(fileName);
                pbSlika.Image = image;
            }
        }
    }
}
