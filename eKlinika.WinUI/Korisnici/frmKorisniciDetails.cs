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

namespace eKlinika.WinUI.Korisnici
{
    public partial class frmKorisniciDetails : Form
    {
        APIService _service = new APIService("Korisnici");
        APIService _ulogeService = new APIService("Uloge");

        KorisniciInsertRequest request = new KorisniciInsertRequest();

        private int? _id = null;
        public frmKorisniciDetails(int? id = null)
        {
            InitializeComponent();
            _id = id;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {
                var roleList = clbRole.CheckedItems.Cast<Model.Uloge>().Select(x => x.Id).ToList();
                var roleListStr = clbRole.CheckedItems.Cast<Model.Uloge>().Select(x => x.Naziv).ToList();

                Model.Korisnici entity = null;
                request.Email = txtEmail.Text;
                request.Ime = txtIme.Text;
                request.UserName = txtKorisnickoIme.Text;
                request.Password = txtPassword.Text;
                request.PasswordPotvrda = txtPasswordPotvrda.Text;
                request.Prezime = txtPrezime.Text;
                request.PhoneNumber = txtTelefon.Text;
                request.Uloge = roleList;

                if (!_id.HasValue)
                {
                    if (roleListStr.Contains("Apotekar"))
                    {
                        request.Osoblje = new Osoblje_Upsert
                        {
                            Apotekar = new Apotekar_Upsert()
                        };
                    }
                    if (roleListStr.Contains("Doktor"))
                    {
                        request.Osoblje = new Osoblje_Upsert
                        {
                            Doktor = new Doktor_Upsert
                            {
                                DatumSpecijalizacije = DateTime.Now
                            }
                        };
                    }
                    if (roleListStr.Contains("MedicinskaSestra"))
                    {
                        request.Osoblje = new Osoblje_Upsert
                        {
                            MedicinskaSestra = new MedicinskaSestra_Upsert()
                        };
                    }

                    entity = await _service.Insert<Model.Korisnici>(request);
                }
                else
                {
                    entity = await _service.Update<Model.Korisnici>(_id.Value, request);

                    if (_id.Value == APIService.Korisnik.Id)
                    {
                        APIService.Username = request.UserName;
                        if (!string.IsNullOrWhiteSpace(request.Password))
                            APIService.Password = request.Password;
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
            var ulogeList = await _ulogeService.Get<List<Model.Uloge>>(null);

            clbRole.DataSource = ulogeList;
            clbRole.DisplayMember = "Naziv";

            if (_id.HasValue)
            {
                var entity = await _service.GetById<Model.Korisnici>(_id);
                txtEmail.Text = entity.Email;
                txtIme.Text = entity.Ime;
                txtKorisnickoIme.Text = entity.UserName;
                txtPrezime.Text = entity.Prezime;
                txtTelefon.Text = entity.PhoneNumber;
                if (entity.Slika.Length > 0)
                {
                    var stream = new MemoryStream(entity.Slika);
                    pbSlika.Image = Image.FromStream(stream);

                    request.Slika = entity.Slika;
                }

                foreach (var uloga in entity.KorisniciUloge)
                {
                    for (int i = 0; i < clbRole.Items.Count; i++)
                    {
                        if (((Uloge)clbRole.Items[i]).Naziv == uloga.Uloga.Naziv)
                            clbRole.SetItemChecked(i, true);
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
            else if (!pass_empty && !confirm_empty && txtPassword.Text != txtPasswordPotvrda.Text)
            {
                e.Cancel = true;
                errorProvider.SetError(txtPassword, Resources.Validation_PasswordNotMatch);
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

        private void button1_Click(object sender, EventArgs e)
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
