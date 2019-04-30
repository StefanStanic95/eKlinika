using eKlinika.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eKlinika.WinUI.Apotekar
{
    public partial class frmRacuni : Form
    {
        private readonly APIService _apiService = new APIService("ApotekaRacun");

        public frmRacuni()
        {
            InitializeComponent();

            dgvRacuni.BorderStyle = BorderStyle.None;

            dgvRacuni.EnableHeadersVisualStyles = false;
            dgvRacuni.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvRacuni.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(34, 36, 49);
            dgvRacuni.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(78, 184, 206);

            dgvRacuni.RowsDefaultCellStyle.BackColor = Color.FromArgb(34, 36, 49);
            dgvRacuni.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(34, 36, 49);
            dgvRacuni.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvRacuni.DefaultCellStyle.SelectionBackColor = Color.FromArgb(34, 36, 49);
            dgvRacuni.DefaultCellStyle.SelectionForeColor = Color.FromArgb(78, 184, 206);
            dgvRacuni.BackgroundColor = Color.FromArgb(34, 36, 49);
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            var search = new ApotekaRacunSearchRequest()
            {
                DatumIzdavanja = dtpDatumIzdavanja.Value.Date
            };

            var list = await _apiService.Get<List<Model.ApotekaRacun>>(search);
            dgvRacuni.AutoGenerateColumns = false;

            dgvRacuni.DataSource = list;
        }

        private void closeForm_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            //frmRacuniDetails frm = new frmRacuniDetails();
            //frm.Show();
        }

    }
}
