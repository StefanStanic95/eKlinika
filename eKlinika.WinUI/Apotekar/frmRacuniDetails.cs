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
    public partial class frmRacuniDetails : Form
    {
        APIService _service = new APIService("ApotekaRacun");
        APIService _serviceKorisnici = new APIService("Korisnici");
        APIService _serviceLijek = new APIService("Lijek");
        APIService _serviceRacunStavka = new APIService("RacunStavka");

        private int? _id = null;
        public frmRacuniDetails(int? id = null)
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

                Model.Requests.ApotekaRacunInsertRequest request = new ApotekaRacunInsertRequest
                {
                    DatumIzdavanja = dtpDatumIzdavanja.Value.Date,
                    PacijentId = ((Model.Korisnici)cmbPacijent.SelectedItem).Id,
                    ApotekarId = ((Model.Korisnici)cmbApotekar.SelectedItem).Id
                };

                Model.ApotekaRacun entity = null;
                if (!_id.HasValue)
                {
                    try
                    {
                        entity = await _service.Insert<Model.ApotekaRacun>(request);

                        foreach (DataGridViewRow row in dgvStavke.Rows)
                        {
                            Model.Requests.RacunStavkaInsertRequest request_stavka = new RacunStavkaInsertRequest
                            {
                                ApotekaRacunId = entity.Id,
                                Kolicina = int.Parse(row.Cells["Kolicina"].Value.ToString()),
                                LijekId = int.Parse(row.Cells["LijekId"].Value.ToString())
                            };

                            await _serviceRacunStavka.Insert<Model.RacunStavka>(request_stavka);
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
                        entity = await _service.Update<Model.ApotekaRacun>(_id.Value, request);
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

        private async void frmRacuniDetails_Load(object sender, EventArgs e)
        {
            var search = new KorisniciSearchRequest()
            {
                Uloga = "Pacijent"
            };

            var korisniciList = await _serviceKorisnici.Get<List<Model.Korisnici>>(search);

            cmbPacijent.DataSource = korisniciList;
            cmbPacijent.DisplayMember = "ImePrezime";


            var search1 = new KorisniciSearchRequest()
            {
                Uloga = "Apotekar"
            };

            var apotekariList = await _serviceKorisnici.Get<List<Model.Korisnici>>(search1);

            cmbApotekar.DataSource = apotekariList;
            cmbApotekar.DisplayMember = "ImePrezime";


            var lijekoviList = await _serviceLijek.Get<List<Model.Lijek>>(null);
            cmbLijek.DataSource = lijekoviList;
            cmbLijek.DisplayMember = "Naziv";


            if (_id.HasValue)
            {
                var entity = await _service.GetById<Model.ApotekaRacun>(_id);
                dtpDatumIzdavanja.Value = entity.DatumIzdavanja;

                foreach (Model.Korisnici item in cmbApotekar.Items)
                {
                    if (item.Id == entity.ApotekarId)
                        cmbApotekar.SelectedItem = item;
                }

                foreach (Model.Korisnici item in cmbPacijent.Items)
                {
                    if (item.Id == entity.PacijentId)
                        cmbPacijent.SelectedItem = item;
                }

                btnDodaj.Enabled = txtKolicina.Enabled = cmbLijek.Enabled = false;

                var stavkeList = await _serviceRacunStavka.Get<List<Model.RacunStavka>>(new Model.Requests.RacunStavkaSearchRequest
                {
                    ApotekaRacunId = _id.Value
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
            int val;
            if (txtKolicina.Enabled && (string.IsNullOrWhiteSpace(txtKolicina.Text) || !int.TryParse(txtKolicina.Text, out val) || val < 1))
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
