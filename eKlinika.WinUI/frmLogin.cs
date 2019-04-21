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

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void frmLogin_Load_1(object sender, EventArgs e)
        {

        }
    }
}
