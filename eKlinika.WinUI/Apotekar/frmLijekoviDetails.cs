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
                    ProizvodjacId = int.Parse(txtProizvodjac.Text),
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
    }
}
