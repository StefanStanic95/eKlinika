namespace eKlinika.WinUI.Apotekar
{
    partial class frmNarudzbe
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmNarudzbe));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbxNarudzbe = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvNarudzbe = new System.Windows.Forms.DataGridView();
            this.lblNarudzbe = new System.Windows.Forms.Label();
            this.btnPrikazi = new System.Windows.Forms.Button();
            this.closeForm = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.lblDatumIzdavanja = new System.Windows.Forms.Label();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.cmbDobavljaci = new System.Windows.Forms.ComboBox();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumNarudzbe = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumIsporuke = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Dobavljac = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Iznos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbxNarudzbe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNarudzbe)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxNarudzbe
            // 
            this.gbxNarudzbe.Controls.Add(this.panel1);
            this.gbxNarudzbe.Controls.Add(this.dgvNarudzbe);
            this.gbxNarudzbe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.gbxNarudzbe.Location = new System.Drawing.Point(12, 146);
            this.gbxNarudzbe.Name = "gbxNarudzbe";
            this.gbxNarudzbe.Size = new System.Drawing.Size(1250, 463);
            this.gbxNarudzbe.TabIndex = 0;
            this.gbxNarudzbe.TabStop = false;
            this.gbxNarudzbe.Text = "Narudžbe";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.panel1.Location = new System.Drawing.Point(6, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1164, 1);
            this.panel1.TabIndex = 1;
            // 
            // dgvNarudzbe
            // 
            this.dgvNarudzbe.AllowUserToAddRows = false;
            this.dgvNarudzbe.AllowUserToDeleteRows = false;
            this.dgvNarudzbe.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.dgvNarudzbe.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNarudzbe.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.DatumNarudzbe,
            this.DatumIsporuke,
            this.Dobavljac,
            this.Iznos});
            this.dgvNarudzbe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvNarudzbe.Location = new System.Drawing.Point(3, 16);
            this.dgvNarudzbe.Name = "dgvNarudzbe";
            this.dgvNarudzbe.ReadOnly = true;
            this.dgvNarudzbe.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNarudzbe.Size = new System.Drawing.Size(1244, 444);
            this.dgvNarudzbe.TabIndex = 0;
            this.dgvNarudzbe.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvNarudzbe_CellFormatting);
            this.dgvNarudzbe.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvNarudzbe_CellMouseDoubleClick);
            // 
            // lblNarudzbe
            // 
            this.lblNarudzbe.AutoSize = true;
            this.lblNarudzbe.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNarudzbe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.lblNarudzbe.Location = new System.Drawing.Point(536, 35);
            this.lblNarudzbe.Name = "lblNarudzbe";
            this.lblNarudzbe.Size = new System.Drawing.Size(105, 25);
            this.lblNarudzbe.TabIndex = 1;
            this.lblNarudzbe.Text = "Narudžbe";
            // 
            // btnPrikazi
            // 
            this.btnPrikazi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.btnPrikazi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrikazi.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrikazi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.btnPrikazi.Location = new System.Drawing.Point(1158, 74);
            this.btnPrikazi.Name = "btnPrikazi";
            this.btnPrikazi.Size = new System.Drawing.Size(86, 23);
            this.btnPrikazi.TabIndex = 5;
            this.btnPrikazi.Text = "Prikaži";
            this.btnPrikazi.UseVisualStyleBackColor = false;
            this.btnPrikazi.Click += new System.EventHandler(this.btnPrikazi_Click);
            // 
            // closeForm
            // 
            this.closeForm.AutoSize = true;
            this.closeForm.Font = new System.Drawing.Font("Century Gothic", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.closeForm.Location = new System.Drawing.Point(1244, 9);
            this.closeForm.Name = "closeForm";
            this.closeForm.Size = new System.Drawing.Size(17, 16);
            this.closeForm.TabIndex = 9;
            this.closeForm.Text = "X";
            this.closeForm.Click += new System.EventHandler(this.closeForm_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(15, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 64);
            this.pictureBox1.TabIndex = 15;
            this.pictureBox1.TabStop = false;
            // 
            // txtNaziv
            // 
            this.txtNaziv.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.txtNaziv.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNaziv.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.txtNaziv.Location = new System.Drawing.Point(94, 106);
            this.txtNaziv.Name = "txtNaziv";
            this.txtNaziv.Size = new System.Drawing.Size(147, 13);
            this.txtNaziv.TabIndex = 16;
            // 
            // lblDatumIzdavanja
            // 
            this.lblDatumIzdavanja.AutoSize = true;
            this.lblDatumIzdavanja.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.lblDatumIzdavanja.Location = new System.Drawing.Point(30, 112);
            this.lblDatumIzdavanja.Name = "lblDatumIzdavanja";
            this.lblDatumIzdavanja.Size = new System.Drawing.Size(58, 13);
            this.lblDatumIzdavanja.TabIndex = 17;
            this.lblDatumIzdavanja.Text = "Dobavljač:";
            // 
            // btnDodaj
            // 
            this.btnDodaj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.btnDodaj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDodaj.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDodaj.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.btnDodaj.Location = new System.Drawing.Point(1158, 616);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(86, 23);
            this.btnDodaj.TabIndex = 21;
            this.btnDodaj.Text = "Dodaj";
            this.btnDodaj.UseVisualStyleBackColor = false;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // cmbDobavljaci
            // 
            this.cmbDobavljaci.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDobavljaci.FormattingEnabled = true;
            this.cmbDobavljaci.Location = new System.Drawing.Point(94, 109);
            this.cmbDobavljaci.Name = "cmbDobavljaci";
            this.cmbDobavljaci.Size = new System.Drawing.Size(121, 21);
            this.cmbDobavljaci.TabIndex = 22;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // DatumNarudzbe
            // 
            this.DatumNarudzbe.DataPropertyName = "DatumNarudzbe";
            this.DatumNarudzbe.HeaderText = "Datum narudžbe";
            this.DatumNarudzbe.Name = "DatumNarudzbe";
            this.DatumNarudzbe.ReadOnly = true;
            this.DatumNarudzbe.Width = 120;
            // 
            // DatumIsporuke
            // 
            this.DatumIsporuke.DataPropertyName = "DatumIsporuke";
            this.DatumIsporuke.HeaderText = "Datum isporuke";
            this.DatumIsporuke.Name = "DatumIsporuke";
            this.DatumIsporuke.ReadOnly = true;
            this.DatumIsporuke.Width = 120;
            // 
            // Dobavljac
            // 
            this.Dobavljac.DataPropertyName = "Dobavljac.Naziv";
            this.Dobavljac.HeaderText = "Dobavljač";
            this.Dobavljac.Name = "Dobavljac";
            this.Dobavljac.ReadOnly = true;
            // 
            // Iznos
            // 
            this.Iznos.DataPropertyName = "Iznos";
            dataGridViewCellStyle3.Format = "C2";
            dataGridViewCellStyle3.NullValue = null;
            this.Iznos.DefaultCellStyle = dataGridViewCellStyle3;
            this.Iznos.HeaderText = "Iznos";
            this.Iznos.Name = "Iznos";
            this.Iznos.ReadOnly = true;
            // 
            // frmNarudzbe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(1274, 651);
            this.Controls.Add(this.cmbDobavljaci);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.lblDatumIzdavanja);
            this.Controls.Add(this.txtNaziv);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.closeForm);
            this.Controls.Add(this.btnPrikazi);
            this.Controls.Add(this.lblNarudzbe);
            this.Controls.Add(this.gbxNarudzbe);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmNarudzbe";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.frmNarudzbe_Load);
            this.gbxNarudzbe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvNarudzbe)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxNarudzbe;
        private System.Windows.Forms.Label lblNarudzbe;
        private System.Windows.Forms.Button btnPrikazi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label closeForm;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtNaziv;
        private System.Windows.Forms.Label lblDatumIzdavanja;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.DataGridView dgvNarudzbe;
        private System.Windows.Forms.ComboBox cmbDobavljaci;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumNarudzbe;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumIsporuke;
        private System.Windows.Forms.DataGridViewTextBoxColumn Dobavljac;
        private System.Windows.Forms.DataGridViewTextBoxColumn Iznos;
    }
}