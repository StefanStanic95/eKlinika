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
    public partial class frmLijekoviDetails : Form
    {
        APIService _service = new APIService("Lijek");
        APIService _serviceProizvodjac = new APIService("Proizvodjac");

        private int? _id = null;

        public frmLijekoviDetails(int? id = null)
        {
            InitializeComponent();
            _id = id;
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateChildren())
            {

                LijekInsertRequest request = new LijekInsertRequest
                {
                    CijenaPoKomadu = double.Parse(txtCijena.Text),
                    Naziv = txtNaziv.Text,
                    PoReceptu = chbPoReceptu.Checked,
                    ProizvodjacId = ((Model.Proizvodjac)cmbProizvodjac.SelectedItem).Id,
                    Tip = txtTipLijeka.Text,
                    UkupnoNaStanju = int.Parse(txtUkupnoNaStanju.Text),
                    Uputstvo = txtUputstvo.Text
                 };

                Model.Lijek entity = null;
                if (!_id.HasValue)
                {
                    try
                    {
                        entity = await _service.Insert<Model.Lijek>(request);
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
                        entity = await _service.Update<Model.Lijek>(_id.Value, request);
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

        private async void frmLijekoviDetails_Load(object sender, EventArgs e)
        {

            var proizvodjaciList = await _serviceProizvodjac.Get<List<Model.Proizvodjac>>(null);

            cmbProizvodjac.DisplayMember = "Naziv";
            cmbProizvodjac.DataSource = proizvodjaciList;


            if (_id.HasValue)
            {
                var entity = await _service.GetById<Model.Lijek>(_id);

                txtCijena.Text = entity.CijenaPoKomadu.ToString();
                txtNaziv.Text = entity.Naziv;
                chbPoReceptu.Checked = entity.PoReceptu;
                txtTipLijeka.Text = entity.Tip;
                txtUkupnoNaStanju.Text = entity.UkupnoNaStanju.ToString();
                txtUputstvo.Text = entity.Uputstvo;

                foreach (Model.Proizvodjac item in cmbProizvodjac.Items)
                {
                    if (item.Id == entity.ProizvodjacId)
                        cmbProizvodjac.SelectedItem = item;
                }
            }
        }

        private void minimizeForm_Click(object sender, System.EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void maximizeForm_Click(object sender, System.EventArgs e)
        {
            WindowState = WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
        }

        private void closeForm_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void txtNaziv_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNaziv.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtNaziv, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider.SetError(txtNaziv, null);
            }
        }

        private void txtCijena_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtCijena.Text) || !double.TryParse(txtCijena.Text, out double val) || val < 0.1)
            {
                e.Cancel = true;
                errorProvider.SetError(txtCijena, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider.SetError(txtCijena, null);
            }
        }

        private void txtTipLijeka_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTipLijeka.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtTipLijeka, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider.SetError(txtTipLijeka, null);
            }
        }

        private void txtUkupnoNaStanju_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUkupnoNaStanju.Text) || !int.TryParse(txtUkupnoNaStanju.Text, out int val) || val < 1)
            {
                e.Cancel = true;
                errorProvider.SetError(txtUkupnoNaStanju, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider.SetError(txtUkupnoNaStanju, null);
            }
        }

        private void txtUputstvo_Validating(object sender, CancelEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUputstvo.Text))
            {
                e.Cancel = true;
                errorProvider.SetError(txtUputstvo, Resources.Validation_RequiredField);
            }
            else
            {
                errorProvider.SetError(txtUputstvo, null);
            }
        }
    }
}
