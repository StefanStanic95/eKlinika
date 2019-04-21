using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using eKlinika.Model.Requests;
using Flurl.Http;

namespace eKlinika.WinUI.Korisnici
{
    public partial class frmKorisnici : Form
    {
        APIService _apiService = new APIService("korisnici");

        public frmKorisnici()
        {
            InitializeComponent();

            dgvKorisnici.BorderStyle = BorderStyle.None;

            dgvKorisnici.EnableHeadersVisualStyles = false;
            dgvKorisnici.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvKorisnici.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(34, 36, 49);
            dgvKorisnici.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(78, 184, 206);
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            var search = new KorisniciSearchRequest()
            {
                ImePrezime = txtPretraga.Text
            };

            var list = await _apiService.Get<List<Model.Korisnici>>(search);
            dgvKorisnici.AutoGenerateColumns = false;

            dgvKorisnici.DataSource = list;
        }

        private void dgvKorisnici_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var korisnikId = int.Parse(dgvKorisnici.SelectedRows[0].Cells[0].Value.ToString());

            frmKorisniciDetails frm = new frmKorisniciDetails(korisnikId);
            frm.Show();
        }

        private void dgvKorisnici_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void minimizeForm_Click_1(object sender, System.EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void maximizeForm_Click_1(object sender, System.EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void closeForm_Click_1(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
