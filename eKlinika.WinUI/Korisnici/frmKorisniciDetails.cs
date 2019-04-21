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

namespace eKlinika.WinUI.Korisnici
{
    public partial class frmKorisniciDetails : Form
    {
        APIService _service = new APIService("Korisnici");
        APIService _ulogeService = new APIService("Uloge");

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


                Model.Korisnici entity = null;
                if (!_id.HasValue)
                {
                    var request = new KorisniciInsertRequest
                    {
                        Email = txtEmail.Text,
                        Ime = txtIme.Text,
                        UserName = txtKorisnickoIme.Text,
                        Password = txtPassword.Text,
                        PasswordPotvrda = txtPasswordPotvrda.Text,
                        Prezime = txtPrezime.Text,
                        PhoneNumber = txtTelefon.Text,
                        Uloge = roleList
                    };

                    entity = await _service.Insert<Model.Korisnici>(request);
                }
                else
                {
                    var request = new KorisniciUpdateRequest
                    {
                        Email = txtEmail.Text,
                        Ime = txtIme.Text,
                        UserName = txtKorisnickoIme.Text,
                        Password = txtPassword.Text,
                        PasswordPotvrda = txtPasswordPotvrda.Text,
                        Prezime = txtPrezime.Text,
                        PhoneNumber = txtTelefon.Text,
                        Uloge = roleList
                    };

                    entity = await _service.Update<Model.Korisnici>(_id.Value, request);
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

            if (dodavanje && string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtPassword, Resources.Validation_RequiredField);
            }
            else if (!dodavanje && !string.IsNullOrWhiteSpace(txtPassword.Text) && !string.IsNullOrWhiteSpace(txtPasswordPotvrda.Text) && txtPassword.Text.Length < 3)
            {
                e.Cancel = true;
                errorProvider.SetError(txtPassword, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider.SetError(txtPassword, null);
            }
        }

        private void txtPasswordPotvrda_Validating(object sender, CancelEventArgs e)
        {
            bool dodavanje = !_id.HasValue;

            if (dodavanje && string.IsNullOrWhiteSpace(txtPasswordPotvrda.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtPasswordPotvrda, Resources.Validation_RequiredField);
            }
            else if (!dodavanje && !string.IsNullOrWhiteSpace(txtPassword.Text) && !string.IsNullOrWhiteSpace(txtPasswordPotvrda.Text) && txtPasswordPotvrda.Text.Length < 3)
            {
                e.Cancel = true;
                errorProvider.SetError(txtPasswordPotvrda, Resources.Validation_RequiredField);
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
            WindowState = FormWindowState.Maximized;

        }

        private void closeForm_Click(object sender, System.EventArgs e)
        {
            Close();

        }
    }
}
