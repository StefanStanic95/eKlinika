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
    public partial class frmUplate : Form
    {
        private readonly APIService _apiService = new APIService("uplate");

        public frmUplate()
        {
            InitializeComponent();

            dgvUplate.BorderStyle = BorderStyle.None;

            dgvUplate.EnableHeadersVisualStyles = false;
            dgvUplate.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvUplate.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(34, 36, 49);
            dgvUplate.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(78, 184, 206);

            dgvUplate.RowsDefaultCellStyle.BackColor = Color.FromArgb(34, 36, 49);
            dgvUplate.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(34, 36, 49);
            dgvUplate.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvUplate.DefaultCellStyle.SelectionBackColor = Color.FromArgb(34, 36, 49);
            dgvUplate.DefaultCellStyle.SelectionForeColor = Color.FromArgb(78, 184, 206);
            dgvUplate.BackgroundColor = Color.FromArgb(34, 36, 49);
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            var search = new UplateSearchRequest()
            {
                BrojUplatnice = txtUplatnica.Text
            };

            var list = await _apiService.Get<List<Model.Uplata>>(search);
            dgvUplate.AutoGenerateColumns = false;

            dgvUplate.DataSource = list;


        }

        private void closeForm_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void dgvUplate_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewColumn column = dgvUplate.Columns[e.ColumnIndex];
            if (column.DataPropertyName.Contains("."))
            {
                object data = dgvUplate.Rows[e.RowIndex].DataBoundItem;
                string[] properties = column.DataPropertyName.Split('.');
                for (int i = 0; i < properties.Length && data != null; i++)
                    data = data.GetType().GetProperty(properties[i]).GetValue(data);

                dgvUplate.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = data;
            }
        }

        private void dgvUplate_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            var uplataId = int.Parse(dgvUplate.SelectedRows[0].Cells[0].Value.ToString());

            frmUplateDetails frm = new frmUplateDetails(uplataId);
            frm.Show();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmUplateDetails frm = new frmUplateDetails();
            frm.Show();
        }
    }
}
