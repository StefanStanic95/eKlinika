namespace eKlinika.WinUI.Apotekar
{
    partial class frmRacuni
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRacuni));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.gbxRacuni = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvRacuni = new System.Windows.Forms.DataGridView();
            this.lblRacuni = new System.Windows.Forms.Label();
            this.btnPrikazi = new System.Windows.Forms.Button();
            this.closeForm = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtNaziv = new System.Windows.Forms.TextBox();
            this.lblDatumIzdavanja = new System.Windows.Forms.Label();
            this.dtpDatumIzdavanja = new System.Windows.Forms.DateTimePicker();
            this.btnDodaj = new System.Windows.Forms.Button();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumIzdavanja = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ApotekarId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PacijentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Iznos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbxRacuni.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRacuni)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxRacuni
            // 
            this.gbxRacuni.Controls.Add(this.panel1);
            this.gbxRacuni.Controls.Add(this.dgvRacuni);
            this.gbxRacuni.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.gbxRacuni.Location = new System.Drawing.Point(12, 146);
            this.gbxRacuni.Name = "gbxRacuni";
            this.gbxRacuni.Size = new System.Drawing.Size(1250, 463);
            this.gbxRacuni.TabIndex = 0;
            this.gbxRacuni.TabStop = false;
            this.gbxRacuni.Text = "Računi";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.panel1.Location = new System.Drawing.Point(6, 44);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1164, 1);
            this.panel1.TabIndex = 1;
            // 
            // dgvRacuni
            // 
            this.dgvRacuni.AllowUserToAddRows = false;
            this.dgvRacuni.AllowUserToDeleteRows = false;
            this.dgvRacuni.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.dgvRacuni.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRacuni.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.DatumIzdavanja,
            this.ApotekarId,
            this.PacijentId,
            this.Iznos});
            this.dgvRacuni.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRacuni.Location = new System.Drawing.Point(3, 16);
            this.dgvRacuni.Name = "dgvRacuni";
            this.dgvRacuni.ReadOnly = true;
            this.dgvRacuni.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvRacuni.Size = new System.Drawing.Size(1244, 444);
            this.dgvRacuni.TabIndex = 0;
            this.dgvRacuni.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvRacuni_CellFormatting);
            this.dgvRacuni.CellMouseDoubleClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.dgvRacuni_CellMouseDoubleClick);
            // 
            // lblRacuni
            // 
            this.lblRacuni.AutoSize = true;
            this.lblRacuni.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRacuni.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.lblRacuni.Location = new System.Drawing.Point(536, 35);
            this.lblRacuni.Name = "lblRacuni";
            this.lblRacuni.Size = new System.Drawing.Size(79, 25);
            this.lblRacuni.TabIndex = 1;
            this.lblRacuni.Text = "Računi";
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
            this.lblDatumIzdavanja.Location = new System.Drawing.Point(15, 109);
            this.lblDatumIzdavanja.Name = "lblDatumIzdavanja";
            this.lblDatumIzdavanja.Size = new System.Drawing.Size(89, 13);
            this.lblDatumIzdavanja.TabIndex = 17;
            this.lblDatumIzdavanja.Text = "Datum izdavanja:";
            // 
            // dtpDatumIzdavanja
            // 
            this.dtpDatumIzdavanja.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDatumIzdavanja.Location = new System.Drawing.Point(110, 106);
            this.dtpDatumIzdavanja.Name = "dtpDatumIzdavanja";
            this.dtpDatumIzdavanja.Size = new System.Drawing.Size(89, 20);
            this.dtpDatumIzdavanja.TabIndex = 20;
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
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // DatumIzdavanja
            // 
            this.DatumIzdavanja.DataPropertyName = "DatumIzdavanja";
            this.DatumIzdavanja.HeaderText = "Datum izdavanja";
            this.DatumIzdavanja.Name = "DatumIzdavanja";
            this.DatumIzdavanja.ReadOnly = true;
            // 
            // ApotekarId
            // 
            this.ApotekarId.DataPropertyName = "Apotekar.Osoblje.ImePrezime";
            this.ApotekarId.HeaderText = "Izdao apotekar";
            this.ApotekarId.Name = "ApotekarId";
            this.ApotekarId.ReadOnly = true;
            // 
            // PacijentId
            // 
            this.PacijentId.DataPropertyName = "Pacijent.ImePrezime";
            this.PacijentId.HeaderText = "Pacijent";
            this.PacijentId.Name = "PacijentId";
            this.PacijentId.ReadOnly = true;
            // 
            // Iznos
            // 
            this.Iznos.DataPropertyName = "Iznos";
            dataGridViewCellStyle1.Format = "C2";
            dataGridViewCellStyle1.NullValue = null;
            this.Iznos.DefaultCellStyle = dataGridViewCellStyle1;
            this.Iznos.HeaderText = "Iznos";
            this.Iznos.Name = "Iznos";
            this.Iznos.ReadOnly = true;
            // 
            // frmRacuni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(1274, 651);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.dtpDatumIzdavanja);
            this.Controls.Add(this.lblDatumIzdavanja);
            this.Controls.Add(this.txtNaziv);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.closeForm);
            this.Controls.Add(this.btnPrikazi);
            this.Controls.Add(this.lblRacuni);
            this.Controls.Add(this.gbxRacuni);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRacuni";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.gbxRacuni.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRacuni)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox gbxRacuni;
        private System.Windows.Forms.Label lblRacuni;
        private System.Windows.Forms.Button btnPrikazi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label closeForm;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtNaziv;
        private System.Windows.Forms.Label lblDatumIzdavanja;
        private System.Windows.Forms.DateTimePicker dtpDatumIzdavanja;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.DataGridView dgvRacuni;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumIzdavanja;
        private System.Windows.Forms.DataGridViewTextBoxColumn ApotekarId;
        private System.Windows.Forms.DataGridViewTextBoxColumn PacijentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Iznos;
    }
}