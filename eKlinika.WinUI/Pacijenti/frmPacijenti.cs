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

namespace eKlinika.WinUI.Pacijenti
{
    public partial class frmPacijenti : Form
    {
        APIService _apiService = new APIService("korisnici");

        public frmPacijenti()
        {
            InitializeComponent();

            dgvKorisnici.BorderStyle = BorderStyle.None;

            dgvKorisnici.EnableHeadersVisualStyles = false;
            dgvKorisnici.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvKorisnici.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(34, 36, 49);
            dgvKorisnici.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(78, 184, 206);

            dgvKorisnici.RowsDefaultCellStyle.BackColor = Color.FromArgb(34, 36, 49);
            dgvKorisnici.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(34, 36, 49);
            dgvKorisnici.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvKorisnici.DefaultCellStyle.SelectionBackColor = Color.FromArgb(34, 36, 49);
            dgvKorisnici.DefaultCellStyle.SelectionForeColor = Color.FromArgb(78, 184, 206);
            dgvKorisnici.BackgroundColor = Color.FromArgb(34, 36, 49);
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            var search = new KorisniciSearchRequest()
            {
                ImePrezime = txtPretraga.Text,
                Uloga = "Pacijent"
            };

            var list = await _apiService.Get<List<Model.Korisnici>>(search);
            dgvKorisnici.AutoGenerateColumns = false;

            dgvKorisnici.DataSource = list;
        }

        private void dgvKorisnici_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var korisnikId = int.Parse(dgvKorisnici.SelectedRows[0].Cells[0].Value.ToString());

            frmPacijentiDetails frm = new frmPacijentiDetails(korisnikId);
            frm.Show();
        }

        private void dgvKorisnici_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewColumn column = dgvKorisnici.Columns[e.ColumnIndex];
            if (column.DataPropertyName.Contains("."))
            {
                object data = dgvKorisnici.Rows[e.RowIndex].DataBoundItem;
                string[] properties = column.DataPropertyName.Split('.');
                for (int i = 0; i < properties.Length && data != null; i++)
                    data = data.GetType().GetProperty(properties[i]).GetValue(data);

                if(data is DateTime)
                {
                    dgvKorisnici.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = ((DateTime)data).ToShortDateString();
                }
                else
                {
                    dgvKorisnici.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = data;
                }
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

        private void dgvKorisnici_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
