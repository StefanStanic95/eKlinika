﻿using eKlinika.Model.Requests;
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
    public partial class frmLijekovi : Form
    {
        private readonly APIService _apiService = new APIService("Lijek");

        public frmLijekovi()
        {
            InitializeComponent();

            dgvLijekovi.BorderStyle = BorderStyle.None;

            dgvLijekovi.EnableHeadersVisualStyles = false;
            dgvLijekovi.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvLijekovi.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(34, 36, 49);
            dgvLijekovi.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(78, 184, 206);

            dgvLijekovi.RowsDefaultCellStyle.BackColor = Color.FromArgb(34, 36, 49);
            dgvLijekovi.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(34, 36, 49);
            dgvLijekovi.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvLijekovi.DefaultCellStyle.SelectionBackColor = Color.FromArgb(34, 36, 49);
            dgvLijekovi.DefaultCellStyle.SelectionForeColor = Color.FromArgb(78, 184, 206);
            dgvLijekovi.BackgroundColor = Color.FromArgb(34, 36, 49);
        }

        private async void btnPrikazi_Click(object sender, EventArgs e)
        {
            var search = new LijekSearchRequest()
            {
                Naziv = txtNaziv.Text
            };

            var list = await _apiService.Get<List<Model.Lijek>>(search);
            dgvLijekovi.AutoGenerateColumns = false;

            dgvLijekovi.DataSource = list;
        }

        private void closeForm_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            frmLijekoviDetails frm = new frmLijekoviDetails();
            frm.Show();
        }

        //private void dgvPregledi_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    DataGridViewColumn column = dgvLijekovi.Columns[e.ColumnIndex];
        //    if (column.DataPropertyName.Contains("."))
        //    {
        //        object data = dgvLijekovi.Rows[e.RowIndex].DataBoundItem;
        //        string[] properties = column.DataPropertyName.Split('.');
        //        for (int i = 0; i < properties.Length && data != null; i++)
        //            data = data.GetType().GetProperty(properties[i]).GetValue(data);

        //        dgvLijekovi.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = data;
        //    }
        //}
    }
}
