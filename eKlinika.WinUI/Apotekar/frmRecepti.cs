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
    public partial class frmRecepti : Form
    {
        private readonly APIService _apiService = new APIService("Recept");

        public frmRecepti()
        {
            InitializeComponent();

            dgvRecepti.BorderStyle = BorderStyle.None;

            dgvRecepti.EnableHeadersVisualStyles = false;
            dgvRecepti.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvRecepti.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(34, 36, 49);
            dgvRecepti.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(78, 184, 206);

            dgvRecepti.RowsDefaultCellStyle.BackColor = Color.FromArgb(34, 36, 49);
            dgvRecepti.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(34, 36, 49);
            dgvRecepti.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvRecepti.DefaultCellStyle.SelectionBackColor = Color.FromArgb(34, 36, 49);
            dgvRecepti.DefaultCellStyle.SelectionForeColor = Color.FromArgb(78, 184, 206);
            dgvRecepti.BackgroundColor = Color.FromArgb(34, 36, 49);
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            var search = new ReceptSearchRequest()
            {
                DatumIzdavanja = dtpDatumIzdavanja.Value.Date
            };

            var list = await _apiService.Get<List<Model.Recept>>(search);
            dgvRecepti.AutoGenerateColumns = false;

            dgvRecepti.DataSource = list;
        }

        private void closeForm_Click(object sender, System.EventArgs e)
        {
            Close();
        }


        private void dgvRecepti_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewColumn column = dgvRecepti.Columns[e.ColumnIndex];
            if (column.DataPropertyName.Contains("."))
            {
                object data = dgvRecepti.Rows[e.RowIndex].DataBoundItem;
                string[] properties = column.DataPropertyName.Split('.');
                for (int i = 0; i < properties.Length && data != null; i++)
                    data = data.GetType().GetProperty(properties[i]).GetValue(data);

                dgvRecepti.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = data;
            }
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            frmReceptiDetails frm = new frmReceptiDetails();
            frm.Show();
        }

        private void dgvRecepti_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var receptId = int.Parse(dgvRecepti.SelectedRows[0].Cells[0].Value.ToString());

            frmReceptiDetails frm = new frmReceptiDetails(receptId);
            frm.Show();
        }
    }
}
