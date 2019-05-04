namespace eKlinika.WinUI.Apotekar
{
    partial class frmRacuniDetails
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
            this.components = new System.ComponentModel.Container();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbPacijent = new System.Windows.Forms.ComboBox();
            this.cmbApotekar = new System.Windows.Forms.ComboBox();
            this.panel12 = new System.Windows.Forms.Panel();
            this.dtpDatumIzdavanja = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtVisina = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel15 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.closeForm = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.maximizeForm = new System.Windows.Forms.Label();
            this.minimizeForm = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgvStavke = new System.Windows.Forms.DataGridView();
            this.LijekId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lijek = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Kolicina = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cmbLijek = new System.Windows.Forms.ComboBox();
            this.txtKolicina = new System.Windows.Forms.TextBox();
            this.btnDodaj = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel15.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStavke)).BeginInit();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.cmbPacijent);
            this.groupBox2.Controls.Add(this.cmbApotekar);
            this.groupBox2.Controls.Add(this.panel12);
            this.groupBox2.Controls.Add(this.dtpDatumIzdavanja);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtVisina);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.groupBox2.Location = new System.Drawing.Point(71, 87);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(389, 233);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detalji računa";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.panel1.Location = new System.Drawing.Point(24, 178);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 1);
            this.panel1.TabIndex = 34;
            // 
            // cmbPacijent
            // 
            this.cmbPacijent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.cmbPacijent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPacijent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.cmbPacijent.FormattingEnabled = true;
            this.cmbPacijent.Location = new System.Drawing.Point(23, 97);
            this.cmbPacijent.Name = "cmbPacijent";
            this.cmbPacijent.Size = new System.Drawing.Size(200, 21);
            this.cmbPacijent.TabIndex = 33;
            // 
            // cmbApotekar
            // 
            this.cmbApotekar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.cmbApotekar.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbApotekar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.cmbApotekar.FormattingEnabled = true;
            this.cmbApotekar.Location = new System.Drawing.Point(24, 155);
            this.cmbApotekar.Name = "cmbApotekar";
            this.cmbApotekar.Size = new System.Drawing.Size(199, 21);
            this.cmbApotekar.TabIndex = 32;
            // 
            // panel12
            // 
            this.panel12.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.panel12.Location = new System.Drawing.Point(23, 120);
            this.panel12.Name = "panel12";
            this.panel12.Size = new System.Drawing.Size(200, 1);
            this.panel12.TabIndex = 27;
            // 
            // dtpDatumIzdavanja
            // 
            this.dtpDatumIzdavanja.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDatumIzdavanja.Location = new System.Drawing.Point(21, 44);
            this.dtpDatumIzdavanja.Name = "dtpDatumIzdavanja";
            this.dtpDatumIzdavanja.Size = new System.Drawing.Size(202, 20);
            this.dtpDatumIzdavanja.TabIndex = 23;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.label15.Location = new System.Drawing.Point(21, 140);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(57, 13);
            this.label15.TabIndex = 22;
            this.label15.Text = "Apotekar *";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.label8.Location = new System.Drawing.Point(18, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Pacijent *";
            // 
            // txtVisina
            // 
            this.txtVisina.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.txtVisina.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtVisina.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.txtVisina.Location = new System.Drawing.Point(23, 159);
            this.txtVisina.Name = "txtVisina";
            this.txtVisina.Size = new System.Drawing.Size(141, 13);
            this.txtVisina.TabIndex = 16;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.label12.Location = new System.Drawing.Point(18, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(96, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "Datum izdavanja  *";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.btnSave.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.btnSave.Location = new System.Drawing.Point(361, 514);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 30);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Sačuvaj";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.label1);
            this.panel15.Controls.Add(this.closeForm);
            this.panel15.Controls.Add(this.label16);
            this.panel15.Controls.Add(this.maximizeForm);
            this.panel15.Controls.Add(this.minimizeForm);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel15.Location = new System.Drawing.Point(0, 0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(532, 47);
            this.panel15.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Century Gothic", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.label1.Location = new System.Drawing.Point(503, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "X";
            this.label1.Click += new System.EventHandler(this.closeForm_Click);
            // 
            // closeForm
            // 
            this.closeForm.AutoSize = true;
            this.closeForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.closeForm.Location = new System.Drawing.Point(877, 9);
            this.closeForm.Name = "closeForm";
            this.closeForm.Size = new System.Drawing.Size(21, 20);
            this.closeForm.TabIndex = 9;
            this.closeForm.Text = "X";
            this.closeForm.Click += new System.EventHandler(this.closeForm_Click);
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.label16.Location = new System.Drawing.Point(169, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(160, 24);
            this.label16.TabIndex = 0;
            this.label16.Text = "Evidencija računa";
            // 
            // maximizeForm
            // 
            this.maximizeForm.Location = new System.Drawing.Point(0, 0);
            this.maximizeForm.Name = "maximizeForm";
            this.maximizeForm.Size = new System.Drawing.Size(100, 23);
            this.maximizeForm.TabIndex = 11;
            // 
            // minimizeForm
            // 
            this.minimizeForm.Location = new System.Drawing.Point(0, 0);
            this.minimizeForm.Name = "minimizeForm";
            this.minimizeForm.Size = new System.Drawing.Size(100, 23);
            this.minimizeForm.TabIndex = 12;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgvStavke);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.groupBox1.Location = new System.Drawing.Point(71, 326);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(389, 144);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lijekovi";
            // 
            // dgvStavke
            // 
            this.dgvStavke.AllowUserToAddRows = false;
            this.dgvStavke.AllowUserToDeleteRows = false;
            this.dgvStavke.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStavke.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.LijekId,
            this.Lijek,
            this.Kolicina});
            this.dgvStavke.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStavke.Location = new System.Drawing.Point(3, 16);
            this.dgvStavke.Name = "dgvStavke";
            this.dgvStavke.ReadOnly = true;
            this.dgvStavke.Size = new System.Drawing.Size(383, 125);
            this.dgvStavke.TabIndex = 0;
            this.dgvStavke.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvStavke_CellFormatting);
            // 
            // LijekId
            // 
            this.LijekId.DataPropertyName = "LijekId";
            this.LijekId.HeaderText = "LijekId";
            this.LijekId.Name = "LijekId";
            this.LijekId.ReadOnly = true;
            this.LijekId.Visible = false;
            // 
            // Lijek
            // 
            this.Lijek.DataPropertyName = "Lijek.Naziv";
            this.Lijek.HeaderText = "Lijek";
            this.Lijek.Name = "Lijek";
            this.Lijek.ReadOnly = true;
            // 
            // Kolicina
            // 
            this.Kolicina.DataPropertyName = "Kolicina";
            this.Kolicina.HeaderText = "Kolicina";
            this.Kolicina.Name = "Kolicina";
            this.Kolicina.ReadOnly = true;
            // 
            // cmbLijek
            // 
            this.cmbLijek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLijek.FormattingEnabled = true;
            this.cmbLijek.Location = new System.Drawing.Point(92, 484);
            this.cmbLijek.Name = "cmbLijek";
            this.cmbLijek.Size = new System.Drawing.Size(121, 21);
            this.cmbLijek.TabIndex = 9;
            // 
            // txtKolicina
            // 
            this.txtKolicina.Location = new System.Drawing.Point(229, 485);
            this.txtKolicina.Name = "txtKolicina";
            this.txtKolicina.Size = new System.Drawing.Size(100, 20);
            this.txtKolicina.TabIndex = 10;
            this.txtKolicina.Validating += new System.ComponentModel.CancelEventHandler(this.txtKolicina_Validating);
            // 
            // btnDodaj
            // 
            this.btnDodaj.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.btnDodaj.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDodaj.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDodaj.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDodaj.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.btnDodaj.Location = new System.Drawing.Point(361, 478);
            this.btnDodaj.Name = "btnDodaj";
            this.btnDodaj.Size = new System.Drawing.Size(86, 30);
            this.btnDodaj.TabIndex = 11;
            this.btnDodaj.Text = "Dodaj";
            this.btnDodaj.UseVisualStyleBackColor = false;
            this.btnDodaj.Click += new System.EventHandler(this.btnDodaj_Click);
            // 
            // frmRacuniDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(532, 573);
            this.Controls.Add(this.btnDodaj);
            this.Controls.Add(this.txtKolicina);
            this.Controls.Add(this.cmbLijek);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.panel15);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmRacuniDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registracija pacijenta";
            this.Load += new System.EventHandler(this.frmRacuniDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStavke)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtVisina;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtpDatumIzdavanja;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel12;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label closeForm;
        private System.Windows.Forms.Label maximizeForm;
        private System.Windows.Forms.Label minimizeForm;
        private System.Windows.Forms.ComboBox cmbApotekar;
        private System.Windows.Forms.ComboBox cmbPacijent;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnDodaj;
        private System.Windows.Forms.TextBox txtKolicina;
        private System.Windows.Forms.ComboBox cmbLijek;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvStavke;
        private System.Windows.Forms.DataGridViewTextBoxColumn LijekId;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lijek;
        private System.Windows.Forms.DataGridViewTextBoxColumn Kolicina;
    }
}