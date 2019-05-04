namespace eKlinika.WinUI.Apotekar
{
    partial class frmReceptiDetails
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
            this.chbObradjen = new System.Windows.Forms.CheckBox();
            this.panel6 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.txtUputstvo = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.cmbLijek = new System.Windows.Forms.ComboBox();
            this.cmbPregled = new System.Windows.Forms.ComboBox();
            this.panel12 = new System.Windows.Forms.Panel();
            this.dtpDatumIzdavanja = new System.Windows.Forms.DateTimePicker();
            this.label15 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.panel15 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
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
            this.groupBox2.Controls.Add(this.chbObradjen);
            this.groupBox2.Controls.Add(this.panel6);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtUputstvo);
            this.groupBox2.Controls.Add(this.panel1);
            this.groupBox2.Controls.Add(this.cmbLijek);
            this.groupBox2.Controls.Add(this.cmbPregled);
            this.groupBox2.Controls.Add(this.panel12);
            this.groupBox2.Controls.Add(this.dtpDatumIzdavanja);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.groupBox2.Location = new System.Drawing.Point(71, 87);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(389, 297);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Detalji recepta";
            // 
            // chbObradjen
            // 
            this.chbObradjen.AutoSize = true;
            this.chbObradjen.Location = new System.Drawing.Point(26, 252);
            this.chbObradjen.Name = "chbObradjen";
            this.chbObradjen.Size = new System.Drawing.Size(68, 17);
            this.chbObradjen.TabIndex = 38;
            this.chbObradjen.Text = "Obrađen";
            this.chbObradjen.UseVisualStyleBackColor = true;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.panel6.Location = new System.Drawing.Point(26, 237);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(338, 1);
            this.panel6.TabIndex = 37;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.label6.Location = new System.Drawing.Point(21, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 36;
            this.label6.Text = "Uputstvo  *";
            // 
            // txtUputstvo
            // 
            this.txtUputstvo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.txtUputstvo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUputstvo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.txtUputstvo.Location = new System.Drawing.Point(26, 218);
            this.txtUputstvo.Name = "txtUputstvo";
            this.txtUputstvo.Size = new System.Drawing.Size(341, 13);
            this.txtUputstvo.TabIndex = 35;
            this.txtUputstvo.Validating += new System.ComponentModel.CancelEventHandler(this.txtUputstvo_Validating);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.panel1.Location = new System.Drawing.Point(24, 178);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 1);
            this.panel1.TabIndex = 34;
            // 
            // cmbLijek
            // 
            this.cmbLijek.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.cmbLijek.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLijek.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.cmbLijek.FormattingEnabled = true;
            this.cmbLijek.Location = new System.Drawing.Point(23, 97);
            this.cmbLijek.Name = "cmbLijek";
            this.cmbLijek.Size = new System.Drawing.Size(200, 21);
            this.cmbLijek.TabIndex = 33;
            // 
            // cmbPregled
            // 
            this.cmbPregled.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.cmbPregled.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPregled.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.cmbPregled.FormattingEnabled = true;
            this.cmbPregled.Location = new System.Drawing.Point(25, 155);
            this.cmbPregled.Name = "cmbPregled";
            this.cmbPregled.Size = new System.Drawing.Size(199, 21);
            this.cmbPregled.TabIndex = 32;
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
            this.dtpDatumIzdavanja.CustomFormat = "dd-MM-yyyy";
            this.dtpDatumIzdavanja.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
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
            this.label15.Size = new System.Drawing.Size(50, 13);
            this.label15.TabIndex = 22;
            this.label15.Text = "Pregled *";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.label8.Location = new System.Drawing.Point(18, 83);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(36, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Lijek *";
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
            this.btnSave.Location = new System.Drawing.Point(374, 397);
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
            this.label16.Size = new System.Drawing.Size(175, 24);
            this.label16.TabIndex = 0;
            this.label16.Text = "Evidencija recepata";
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
            // frmReceptiDetails
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(532, 439);
            this.Controls.Add(this.panel15);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmReceptiDetails";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registracija pacijenta";
            this.Load += new System.EventHandler(this.frmReceptiDetails_Load);
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
        private System.Windows.Forms.ComboBox cmbPregled;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbLijek;
        private System.Windows.Forms.CheckBox chbObradjen;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUputstvo;
    }
}