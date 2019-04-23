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
    public partial class frmUputnice : Form
    {
        private readonly APIService _apiService = new APIService("uputnica");

        public frmUputnice()
        {
            InitializeComponent();

            dgvUputnice.BorderStyle = BorderStyle.None;

            dgvUputnice.EnableHeadersVisualStyles = false;
            dgvUputnice.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvUputnice.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(34, 36, 49);
            dgvUputnice.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(78, 184, 206);

            dgvUputnice.RowsDefaultCellStyle.BackColor = Color.FromArgb(34, 36, 49);
            dgvUputnice.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(34, 36, 49);
            dgvUputnice.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvUputnice.DefaultCellStyle.SelectionBackColor = Color.FromArgb(34, 36, 49);
            dgvUputnice.DefaultCellStyle.SelectionForeColor = Color.FromArgb(78, 184, 206);
            dgvUputnice.BackgroundColor = Color.FromArgb(34, 36, 49);
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            var result = await _apiService.Get<List<Model.Uputnica>>();
            dgvUputnice.DataSource = result;

            //string query = "SELECT Id, DatumRezultata, DatumUputnice, IsGotovNalaz, LaboratorijDoktorId, PacijentId, UputioDoktorId, VrstaPretrageId" +
            //               "FROM Uputnica" +
            //               $"WHERE DatumUputnice BETWEEN { dtFromDate.Value} AND { dtToDate.Value}";
        }

        private void closeForm_Click(object sender, System.EventArgs e)
        {
            Close();
        }
    }
}
