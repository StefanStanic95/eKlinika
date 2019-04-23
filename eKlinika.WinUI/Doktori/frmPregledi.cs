using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eKlinika.WinUI.Doktori
{
    public partial class frmPregledi : Form
    {
        private readonly APIService _apiService = new APIService("pregled");

        public frmPregledi()
        {
            InitializeComponent();

            dgvPregledi.BorderStyle = BorderStyle.None;

            dgvPregledi.EnableHeadersVisualStyles = false;
            dgvPregledi.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvPregledi.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(34, 36, 49);
            dgvPregledi.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(78, 184, 206);

            dgvPregledi.RowsDefaultCellStyle.BackColor = Color.FromArgb(34, 36, 49);
            dgvPregledi.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(34, 36, 49);
            dgvPregledi.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvPregledi.DefaultCellStyle.SelectionBackColor = Color.FromArgb(34, 36, 49);
            dgvPregledi.DefaultCellStyle.SelectionForeColor = Color.FromArgb(78, 184, 206);
            dgvPregledi.BackgroundColor = Color.FromArgb(34, 36, 49);
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            var result = await _apiService.Get<List<Model.Pregled>>();
            dgvPregledi.DataSource = result;
        }

        private void closeForm_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
