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
    public partial class frmNarudzbe : Form
    {
        private readonly APIService _apiService = new APIService("Narudzba");
        private readonly APIService _serviceDobavljac = new APIService("Dobavljac");

        public frmNarudzbe()
        {
            InitializeComponent();

            dgvNarudzbe.BorderStyle = BorderStyle.None;

            dgvNarudzbe.EnableHeadersVisualStyles = false;
            dgvNarudzbe.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvNarudzbe.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(34, 36, 49);
            dgvNarudzbe.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(78, 184, 206);

            dgvNarudzbe.RowsDefaultCellStyle.BackColor = Color.FromArgb(34, 36, 49);
            dgvNarudzbe.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(34, 36, 49);
            dgvNarudzbe.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvNarudzbe.DefaultCellStyle.SelectionBackColor = Color.FromArgb(34, 36, 49);
            dgvNarudzbe.DefaultCellStyle.SelectionForeColor = Color.FromArgb(78, 184, 206);
            dgvNarudzbe.BackgroundColor = Color.FromArgb(34, 36, 49);
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            var search = new NarudzbaSearchRequest()
            {
                DobavljacId = ((Model.Dobavljac)cmbDobavljaci.SelectedItem).Id
            };

            var list = await _apiService.Get<List<Model.Narudzba>>(search);
            dgvNarudzbe.AutoGenerateColumns = false;

            dgvNarudzbe.DataSource = list;
        }

        private void closeForm_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            frmNarudzbeDetails frm = new frmNarudzbeDetails();
            frm.Show();
        }

        private void dgvNarudzbe_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            DataGridViewColumn column = dgvNarudzbe.Columns[e.ColumnIndex];
            if (column.DataPropertyName.Contains("."))
            {
                object data = dgvNarudzbe.Rows[e.RowIndex].DataBoundItem;
                string[] properties = column.DataPropertyName.Split('.');
                for (int i = 0; i < properties.Length && data != null; i++)
                    data = data.GetType().GetProperty(properties[i]).GetValue(data);

                dgvNarudzbe.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = data;
            }
        }

        private void dgvNarudzbe_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var Narudzbed = int.Parse(dgvNarudzbe.SelectedRows[0].Cells[0].Value.ToString());

            frmNarudzbeDetails frm = new frmNarudzbeDetails(Narudzbed);
            frm.Show();
        }

        private async void frmNarudzbe_Load(object sender, EventArgs e)
        {
            var dobavljaciList = await _serviceDobavljac.Get<List<Model.Dobavljac>>();
            cmbDobavljaci.DataSource = dobavljaciList;
            cmbDobavljaci.DisplayMember = "Naziv";
        }
    }
}
