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

namespace eKlinika.WinUI
{
    public partial class frmLogin : Form
    {
        APIService _service = new APIService("Korisnici");

        public frmLogin()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;
            APIService.Username = txtUsername.Text;
            APIService.Password = txtPassword.Text;
            try
            {
                APIService.Korisnik = await _service.Get<Model.Korisnici>(null, "me");
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
               
            }

        }

        private void close_Click_1(object sender, System.EventArgs e)
        {
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "Emina.Custovic";
            txtPassword.Text = "123";
            btnLogin.PerformClick();
        }

        private void txtUsername_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || txtUsername.Text.Length < 3)
            {
                e.Cancel = true;
                errorProvider.SetError(txtUsername, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider.SetError(txtUsername, null);
            }
        }

        private void txtPassword_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPassword.Text) || txtPassword.Text.Length < 3)
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
