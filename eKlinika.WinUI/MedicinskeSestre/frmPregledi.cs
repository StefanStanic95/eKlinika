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
            var search = new PregledSearchRequest()
            {
                DatumPregleda = dtpDatumPregleda.Value.Date
            };

            var list = await _apiService.Get<List<Model.Pregled>>(search);
            dgvPregledi.AutoGenerateColumns = false;

            dgvPregledi.DataSource = list;


        }

        private void closeForm_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void dgvPregledi_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewColumn column = dgvPregledi.Columns[e.ColumnIndex];
            if (column.DataPropertyName.Contains("."))
            {
                object data = dgvPregledi.Rows[e.RowIndex].DataBoundItem;
                string[] properties = column.DataPropertyName.Split('.');
                for (int i = 0; i < properties.Length && data != null; i++)
                    data = data.GetType().GetProperty(properties[i]).GetValue(data);

                dgvPregledi.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = data;
            }
        }
    }
}
