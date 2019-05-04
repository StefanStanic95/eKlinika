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
                var roleListStr = clbRole.CheckedItems.Cast<Model.Uloge>().Select(x => x.Naziv).ToList();


                Model.Korisnici entity = null;
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
                if (!_id.HasValue)
                {
                    if(roleListStr.Contains("Apotekar"))
                    {
                        request.Osoblje = new Osoblje_Upsert {
                            Apotekar = new Apotekar_Upsert()
                        };
                    }
                    if(roleListStr.Contains("Doktor"))
                    {
                        request.Osoblje = new Osoblje_Upsert {
                            Doktor = new Doktor_Upsert()
                        };
                    }
                    if(roleListStr.Contains("Doktor"))
                    {
                        request.Osoblje = new Osoblje_Upsert {
                            MedicinskaSestra = new MedicinskaSestra_Upsert()
                        };
                    }

                    entity = await _service.Insert<Model.Korisnici>(request);
                }
                else
                {
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
            else if(!pass_empty && !confirm_empty && txtPassword.Text != txtPasswordPotvrda.Text)
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
    }
}
