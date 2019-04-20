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
                        Uloge = roleList,
                        Pacijent = new Pacijent
                        {
                            BrojKartona = txtBrojKartona.Text,
                            Alergije = txtAlergije.Text,
                            BrojKnjizice = txtBrojKnjizice.Text,
                            DatumRegistracije = DateTime.Now,
                            KrvnaGrupaId = ((KrvnaGrupa)cmbKrvnaGrupa.SelectedValue).Id,
                            SpecijalniZahtjevi = txtSpecZahtjevi.Text,
                            Tezina = double.Parse(txtTezina.Text),
                            Visina = int.Parse(txtVisina.Text)
                        }
                    };

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
                    var request = new KorisniciUpdateRequest
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
                            Tezina = double.Parse(txtTezina.Text),
                            Visina = int.Parse(txtVisina.Text)
                        }
                    };



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
                cmbKrvnaGrupa.SelectedIndex = entity.Pacijent.KrvnaGrupaId;
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

            if (dodavanje && (string.IsNullOrWhiteSpace(txtPassword.Text) || string.IsNullOrWhiteSpace(txtPasswordPotvrda.Text)))
            {
                e.Cancel = true;
                errorProvider.SetError(txtPassword, Resources.Validation_RequiredField);
            }
            else if (!dodavanje && !string.IsNullOrWhiteSpace(txtPassword.Text) && !string.IsNullOrWhiteSpace(txtPasswordPotvrda.Text) && (txtPassword.Text.Length < 3 || txtPasswordPotvrda.Text.Length < 3))
            {
                e.Cancel = true;
                errorProvider.SetError(txtPassword, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider.SetError(txtPassword, null);
            }
        }
    }
}
