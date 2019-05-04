namespace eKlinika.WinUI.Doktori
{
    partial class frmPreglediDetails
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
            this.txtTipPregleda = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPrioritet = new System.Windows.Forms.TextBox();
            this.txtNapomena = new System.Windows.Forms.TextBox();
            this.chbOdrzan = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbPacijent = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbMedSestra = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDatumRezervacije = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbDoktor = new System.Windows.Forms.ComboBox();
            this.dtpDatumPregleda = new System.Windows.Forms.DateTimePicker();
            this.label9 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel15 = new System.Windows.Forms.Panel();
            this.closeForm = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.maximizeForm = new System.Windows.Forms.Label();
            this.minimizeForm = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.panel15.SuspendLayout();
            this.SuspendLayout();
            // 
            // errorProvider
            // 
            this.errorProvider.ContainerControl = this;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txtTipPregleda);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtPrioritet);
            this.groupBox2.Controls.Add(this.txtNapomena);
            this.groupBox2.Controls.Add(this.chbOdrzan);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cmbPacijent);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.cmbMedSestra);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.dtpDatumRezervacije);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cmbDoktor);
            this.groupBox2.Controls.Add(this.dtpDatumPregleda);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.groupBox2.Location = new System.Drawing.Point(28, 102);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(407, 357);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detalji pregleda";
            // 
            // txtTipPregleda
            // 
            this.txtTipPregleda.Location = new System.Drawing.Point(226, 240);
            this.txtTipPregleda.Name = "txtTipPregleda";
            this.txtTipPregleda.Size = new System.Drawing.Size(142, 20);
            this.txtTipPregleda.TabIndex = 39;
            this.txtTipPregleda.Validating += new System.ComponentModel.CancelEventHandler(this.txtTipPregleda_Validating);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.label5.Location = new System.Drawing.Point(224, 80);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "Prioritet *";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.label6.Location = new System.Drawing.Point(30, 80);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 13);
            this.label6.TabIndex = 37;
            this.label6.Text = "Napomena *";
            // 
            // txtPrioritet
            // 
            this.txtPrioritet.Location = new System.Drawing.Point(226, 105);
            this.txtPrioritet.Name = "txtPrioritet";
            this.txtPrioritet.Size = new System.Drawing.Size(142, 20);
            this.txtPrioritet.TabIndex = 36;
            this.txtPrioritet.Validating += new System.ComponentModel.CancelEventHandler(this.txtPrioritet_Validating);
            // 
            // txtNapomena
            // 
            this.txtNapomena.Location = new System.Drawing.Point(32, 105);
            this.txtNapomena.Name = "txtNapomena";
            this.txtNapomena.Size = new System.Drawing.Size(141, 20);
            this.txtNapomena.TabIndex = 35;
            this.txtNapomena.Validating += new System.ComponentModel.CancelEventHandler(this.txtNapomena_Validating);
            // 
            // chbOdrzan
            // 
            this.chbOdrzan.AutoSize = true;
            this.chbOdrzan.Location = new System.Drawing.Point(32, 295);
            this.chbOdrzan.Name = "chbOdrzan";
            this.chbOdrzan.Size = new System.Drawing.Size(111, 17);
            this.chbOdrzan.TabIndex = 34;
            this.chbOdrzan.Text = "Održan (DA/NE) *";
            this.chbOdrzan.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.label3.Location = new System.Drawing.Point(225, 220);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Tip pregleda *";
            // 
            // cmbPacijent
            // 
            this.cmbPacijent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.cmbPacijent.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPacijent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.cmbPacijent.FormattingEnabled = true;
            this.cmbPacijent.Location = new System.Drawing.Point(33, 239);
            this.cmbPacijent.Name = "cmbPacijent";
            this.cmbPacijent.Size = new System.Drawing.Size(142, 21);
            this.cmbPacijent.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.label4.Location = new System.Drawing.Point(31, 220);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 13);
            this.label4.TabIndex = 29;
            this.label4.Text = "Pacijent *";
            // 
            // cmbMedSestra
            // 
            this.cmbMedSestra.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.cmbMedSestra.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMedSestra.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.cmbMedSestra.FormattingEnabled = true;
            this.cmbMedSestra.Location = new System.Drawing.Point(227, 170);
            this.cmbMedSestra.Name = "cmbMedSestra";
            this.cmbMedSestra.Size = new System.Drawing.Size(142, 21);
            this.cmbMedSestra.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.label2.Location = new System.Drawing.Point(225, 151);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 27;
            this.label2.Text = "Med. sestra *";
            // 
            // dtpDatumRezervacije
            // 
            this.dtpDatumRezervacije.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDatumRezervacije.Location = new System.Drawing.Point(227, 43);
            this.dtpDatumRezervacije.Name = "dtpDatumRezervacije";
            this.dtpDatumRezervacije.Size = new System.Drawing.Size(141, 20);
            this.dtpDatumRezervacije.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.label1.Location = new System.Drawing.Point(223, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 13);
            this.label1.TabIndex = 25;
            this.label1.Text = "Datum rezervacije *";
            // 
            // cmbDoktor
            // 
            this.cmbDoktor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.cmbDoktor.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDoktor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.cmbDoktor.FormattingEnabled = true;
            this.cmbDoktor.Location = new System.Drawing.Point(33, 170);
            this.cmbDoktor.Name = "cmbDoktor";
            this.cmbDoktor.Size = new System.Drawing.Size(142, 21);
            this.cmbDoktor.TabIndex = 24;
            // 
            // dtpDatumPregleda
            // 
            this.dtpDatumPregleda.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDatumPregleda.Location = new System.Drawing.Point(32, 43);
            this.dtpDatumPregleda.Name = "dtpDatumPregleda";
            this.dtpDatumPregleda.Size = new System.Drawing.Size(141, 20);
            this.dtpDatumPregleda.TabIndex = 23;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.label9.Location = new System.Drawing.Point(31, 151);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 21;
            this.label9.Text = "Doktor *";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.label12.Location = new System.Drawing.Point(28, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(89, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "Datum pregleda *";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.btnSave.Location = new System.Drawing.Point(347, 485);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 30);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "Sačuvaj";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.closeForm);
            this.panel15.Controls.Add(this.label16);
            this.panel15.Controls.Add(this.maximizeForm);
            this.panel15.Controls.Add(this.minimizeForm);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel15.Location = new System.Drawing.Point(0, 0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(460, 47);
            this.panel15.TabIndex = 6;
            // 
            // closeForm
            // 
            this.closeForm.AutoSize = true;
            this.closeForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.closeForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.closeForm.Location = new System.Drawing.Point(412, 11);
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
            this.label16.Location = new System.Drawing.Point(148, 11);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(177, 24);
            this.label16.TabIndex = 0;
            this.label16.Text = "Evidencija pregleda";
            // 
            // maximizeForm
            // 
            this.maximizeForm.AutoSize = true;
            this.maximizeForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maximizeForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.maximizeForm.Location = new System.Drawing.Point(387, 10);
            this.maximizeForm.Name = "maximizeForm";
            this.maximizeForm.Size = new System.Drawing.Size(19, 20);
            this.maximizeForm.TabIndex = 8;
            this.maximizeForm.Text = "➚";
            this.maximizeForm.Click += new System.EventHandler(this.maximizeForm_Click);
            // 
            // minimizeForm
            // 
            this.minimizeForm.AutoSize = true;
            this.minimizeForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minimizeForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
            this.minimizeForm.Location = new System.Drawing.Point(363, 10);
            this.minimizeForm.Name = "minimizeForm";
            this.minimizeForm.Size = new System.Drawing.Size(19, 20);
            this.minimizeForm.TabIndex = 7;
            this.minimizeForm.Text = "_";
            this.minimizeForm.Click += new System.EventHandler(this.minimizeForm_Click);
            // 
            // frmPreglediDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(460, 538);
            this.Controls.Add(this.panel15);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmPreglediDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registracija pacijenta";
            this.Load += new System.EventHandler(this.frmPreglediDetails_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ErrorProvider errorProvider;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cmbDoktor;
        private System.Windows.Forms.DateTimePicker dtpDatumPregleda;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label closeForm;
        private System.Windows.Forms.Label maximizeForm;
        private System.Windows.Forms.Label minimizeForm;
        private System.Windows.Forms.DateTimePicker dtpDatumRezervacije;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbPacijent;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbMedSestra;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chbOdrzan;
        private System.Windows.Forms.TextBox txtPrioritet;
        private System.Windows.Forms.TextBox txtNapomena;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtTipPregleda;
    }
}