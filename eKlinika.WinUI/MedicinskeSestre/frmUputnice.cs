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

namespace eKlinika.WinUI.MedicinskeSestre
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
            var search = new UputnicaSearchRequest()
            {
                DatumOd = dtFromDate.Value.Date,
                DatumDo = dtToDate.Value.Date
            };

            var list = await _apiService.Get<List<Model.Uputnica>>(search);
            dgvUputnice.AutoGenerateColumns = false;

            dgvUputnice.DataSource = list;
        }

        private void closeForm_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void dgvUputnice_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewColumn column = dgvUputnice.Columns[e.ColumnIndex];
            if (column.DataPropertyName.Contains("."))
            {
                object data = dgvUputnice.Rows[e.RowIndex].DataBoundItem;
                string[] properties = column.DataPropertyName.Split('.');
                for (int i = 0; i < properties.Length && data != null; i++)
                    data = data.GetType().GetProperty(properties[i]).GetValue(data);

                dgvUputnice.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = data;
            }
        }
    }
}
