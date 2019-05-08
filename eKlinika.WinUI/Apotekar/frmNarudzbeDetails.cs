using eKlinika.Model;
using eKlinika.Model.Requests;
using eKlinika.WinUI.Properties;
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
    public partial class frmNarudzbeDetails : Form
    {
        APIService _service = new APIService("Narudzba");
        APIService _serviceDobavljaci = new APIService("Dobavljac");
        APIService _serviceLijek = new APIService("Lijek");
        APIService _serviceNarudzbaStavka = new APIService("NarudzbaStavka");

        private int? _id = null;
        public frmNarudzbeDetails(int? id = null)
        {
            InitializeComponent();
            _id = id;

            dgvStavke.BorderStyle = BorderStyle.None;

            dgvStavke.EnableHeadersVisualStyles = false;
            dgvStavke.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvStavke.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(34, 36, 49);
            dgvStavke.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(78, 184, 206);

            dgvStavke.RowsDefaultCellStyle.BackColor = Color.FromArgb(34, 36, 49);
            dgvStavke.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(34, 36, 49);
            dgvStavke.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvStavke.DefaultCellStyle.SelectionBackColor = Color.FromArgb(34, 36, 49);
            dgvStavke.DefaultCellStyle.SelectionForeColor = Color.FromArgb(78, 184, 206);
            dgvStavke.BackgroundColor = Color.FromArgb(34, 36, 49);

        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {

                Model.Requests.NarudzbaInsertRequest request = new NarudzbaInsertRequest
                {
                    DatumIsporuke = dtpDatumIsporuke.Value,
                    DatumNarudzbe = dtpDatumNarudzbe.Value,
                    DobavljacId = ((Model.Dobavljac)cmbDobavljaci.SelectedItem).Id,
                };

                Model.Narudzba entity = null;
                if (!_id.HasValue)
                {
                    try
                    {
                        entity = await _service.Insert<Model.Narudzba>(request);

                        foreach (DataGridViewRow row in dgvStavke.Rows)
                        {
                            Model.Requests.NarudzbaStavkaInsertRequest request_stavka = new NarudzbaStavkaInsertRequest
                            {
                                NarudzbaId = entity.Id,
                                Kolicina = int.Parse(row.Cells["Kolicina"].Value.ToString()),
                                LijekId = int.Parse(row.Cells["LijekId"].Value.ToString())
                            };

                            await _serviceNarudzbaStavka.Insert<Model.NarudzbaStavka>(request_stavka);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Greška");

                    }
                }
                else
                {
                    try
                    {
                        entity = await _service.Update<Model.Narudzba>(_id.Value, request);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Greška");

                    }
                }

                if (entity != null)
                {
                    MessageBox.Show("Uspješno izvršeno");
                }

            }

        }

        private async void frmNarudzbeDetails_Load(object sender, EventArgs e)
        {
            var dobavljaciList = await _serviceDobavljaci.Get<List<Model.Dobavljac>>(null);
            cmbDobavljaci.DataSource = dobavljaciList;
            cmbDobavljaci.DisplayMember = "Naziv";

            var lijekoviList = await _serviceLijek.Get<List<Model.Lijek>>(null);
            cmbLijek.DataSource = lijekoviList;
            cmbLijek.DisplayMember = "Naziv";


            if (_id.HasValue)
            {
                var entity = await _service.GetById<Model.Narudzba>(_id);
                dtpDatumNarudzbe.Value = entity.DatumNarudzbe;
                if(entity.DatumIsporuke.HasValue)
                    dtpDatumIsporuke.Value = entity.DatumIsporuke.Value;

                foreach (Model.Dobavljac item in cmbDobavljaci.Items)
                {
                    if (item.Id == entity.Dobavljac.Id)
                        cmbDobavljaci.SelectedItem = item;
                }

                btnDodaj.Enabled = txtKolicina.Enabled = cmbLijek.Enabled = false;

                var stavkeList = await _serviceNarudzbaStavka.Get<List<Model.NarudzbaStavka>>(new Model.Requests.NarudzbaStavkaSearchRequest
                {
                    NarudzbaId = _id.Value
                });
                dgvStavke.AutoGenerateColumns = false;
                dgvStavke.DataSource = stavkeList;
            }
        }

        private void closeForm_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btnDodaj_Click(object sender, EventArgs e)
        {
            if (!ValidateChildren())
                return;

            Lijek lijek = (Lijek)cmbLijek.SelectedItem;
            string kolicina = txtKolicina.Text;

            var index = dgvStavke.Rows.Add();
            dgvStavke.Rows[index].Cells["LijekId"].Value = lijek.Id.ToString();
            dgvStavke.Rows[index].Cells["Lijek"].Value = lijek.Naziv;
            dgvStavke.Rows[index].Cells["Kolicina"].Value = kolicina;
        }

        private void dgvStavke_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (!_id.HasValue)
                return;

            DataGridViewColumn column = dgvStavke.Columns[e.ColumnIndex];
            if (column.DataPropertyName.Contains("."))
            {
                object data = dgvStavke.Rows[e.RowIndex].DataBoundItem;
                string[] properties = column.DataPropertyName.Split('.');
                for (int i = 0; i < properties.Length && data != null; i++)
                    data = data.GetType().GetProperty(properties[i]).GetValue(data);

                dgvStavke.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = data;
            }
        }

        private void txtKolicina_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtKolicina.Text) || !int.TryParse(txtKolicina.Text, out int val) || val < 1)
            {
                e.Cancel = true;
                errorProvider.SetError(txtKolicina, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider.SetError(txtKolicina, null);
            }
        }
    }
}
