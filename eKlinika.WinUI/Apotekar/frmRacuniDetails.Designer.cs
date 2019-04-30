//namespace eKlinika.WinUI.Apotekar
//{
//    partial class frmRacuniDetails
//    {
//        /// <summary>
//        /// Required designer variable.
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary>
//        /// Clean up any resources being used.
//        /// </summary>
//        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Windows Form Designer generated code

//        /// <summary>
//        /// Required method for Designer support - do not modify
//        /// the contents of this method with the code editor.
//        /// </summary>
//        private void InitializeComponent()
//        {
//            this.components = new System.ComponentModel.Container();
//            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
//            this.groupBox2 = new System.Windows.Forms.GroupBox();
//            this.cmbPacijent = new System.Windows.Forms.ComboBox();
//            this.label2 = new System.Windows.Forms.Label();
//            this.cmbApotekar = new System.Windows.Forms.ComboBox();
//            this.dtpDatumIzdavanja = new System.Windows.Forms.DateTimePicker();
//            this.label9 = new System.Windows.Forms.Label();
//            this.label12 = new System.Windows.Forms.Label();
//            this.btnSave = new System.Windows.Forms.Button();
//            this.panel15 = new System.Windows.Forms.Panel();
//            this.closeForm = new System.Windows.Forms.Label();
//            this.lblTitle = new System.Windows.Forms.Label();
//            this.maximizeForm = new System.Windows.Forms.Label();
//            this.minimizeForm = new System.Windows.Forms.Label();
//            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
//            this.groupBox2.SuspendLayout();
//            this.panel15.SuspendLayout();
//            this.SuspendLayout();
//            // 
//            // errorProvider
//            // 
//            this.errorProvider.ContainerControl = this;
//            // 
//            // groupBox2
//            // 
//            this.groupBox2.Controls.Add(this.cmbPacijent);
//            this.groupBox2.Controls.Add(this.label2);
//            this.groupBox2.Controls.Add(this.cmbApotekar);
//            this.groupBox2.Controls.Add(this.dtpDatumIzdavanja);
//            this.groupBox2.Controls.Add(this.label9);
//            this.groupBox2.Controls.Add(this.label12);
//            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
//            this.groupBox2.Location = new System.Drawing.Point(28, 102);
//            this.groupBox2.Name = "groupBox2";
//            this.groupBox2.Size = new System.Drawing.Size(407, 179);
//            this.groupBox2.TabIndex = 2;
//            this.groupBox2.TabStop = false;
//            this.groupBox2.Text = "Detalji računa";
//            // 
//            // cmbPacijent
//            // 
//            this.cmbPacijent.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
//            this.cmbPacijent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
//            this.cmbPacijent.FormattingEnabled = true;
//            this.cmbPacijent.Location = new System.Drawing.Point(227, 99);
//            this.cmbPacijent.Name = "cmbPacijent";
//            this.cmbPacijent.Size = new System.Drawing.Size(142, 21);
//            this.cmbPacijent.TabIndex = 28;
//            // 
//            // label2
//            // 
//            this.label2.AutoSize = true;
//            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
//            this.label2.Location = new System.Drawing.Point(225, 80);
//            this.label2.Name = "label2";
//            this.label2.Size = new System.Drawing.Size(52, 13);
//            this.label2.TabIndex = 27;
//            this.label2.Text = "Pacijent *";
//            // 
//            // cmbApotekar
//            // 
//            this.cmbApotekar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
//            this.cmbApotekar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
//            this.cmbApotekar.FormattingEnabled = true;
//            this.cmbApotekar.Location = new System.Drawing.Point(33, 99);
//            this.cmbApotekar.Name = "cmbApotekar";
//            this.cmbApotekar.Size = new System.Drawing.Size(142, 21);
//            this.cmbApotekar.TabIndex = 24;
//            // 
//            // dtpDatumIzdavanja
//            // 
//            this.dtpDatumIzdavanja.Format = System.Windows.Forms.DateTimePickerFormat.Short;
//            this.dtpDatumIzdavanja.Location = new System.Drawing.Point(32, 43);
//            this.dtpDatumIzdavanja.Name = "dtpDatumIzdavanja";
//            this.dtpDatumIzdavanja.Size = new System.Drawing.Size(141, 20);
//            this.dtpDatumIzdavanja.TabIndex = 23;
//            // 
//            // label9
//            // 
//            this.label9.AutoSize = true;
//            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
//            this.label9.Location = new System.Drawing.Point(31, 80);
//            this.label9.Name = "label9";
//            this.label9.Size = new System.Drawing.Size(85, 13);
//            this.label9.TabIndex = 21;
//            this.label9.Text = "Izdao apotekar *";
//            // 
//            // label12
//            // 
//            this.label12.AutoSize = true;
//            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
//            this.label12.Location = new System.Drawing.Point(28, 24);
//            this.label12.Name = "label12";
//            this.label12.Size = new System.Drawing.Size(93, 13);
//            this.label12.TabIndex = 5;
//            this.label12.Text = "Datum izdavanja *";
//            // 
//            // btnSave
//            // 
//            this.btnSave.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
//            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
//            this.btnSave.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.btnSave.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
//            this.btnSave.Location = new System.Drawing.Point(338, 297);
//            this.btnSave.Name = "btnSave";
//            this.btnSave.Size = new System.Drawing.Size(86, 30);
//            this.btnSave.TabIndex = 5;
//            this.btnSave.Text = "Sačuvaj";
//            this.btnSave.UseVisualStyleBackColor = false;
//            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
//            // 
//            // panel15
//            // 
//            this.panel15.Controls.Add(this.closeForm);
//            this.panel15.Controls.Add(this.lblTitle);
//            this.panel15.Controls.Add(this.maximizeForm);
//            this.panel15.Controls.Add(this.minimizeForm);
//            this.panel15.Dock = System.Windows.Forms.DockStyle.Top;
//            this.panel15.Location = new System.Drawing.Point(0, 0);
//            this.panel15.Name = "panel15";
//            this.panel15.Size = new System.Drawing.Size(460, 47);
//            this.panel15.TabIndex = 6;
//            // 
//            // closeForm
//            // 
//            this.closeForm.AutoSize = true;
//            this.closeForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.closeForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
//            this.closeForm.Location = new System.Drawing.Point(412, 11);
//            this.closeForm.Name = "closeForm";
//            this.closeForm.Size = new System.Drawing.Size(21, 20);
//            this.closeForm.TabIndex = 9;
//            this.closeForm.Text = "X";
//            this.closeForm.Click += new System.EventHandler(this.closeForm_Click);
//            // 
//            // lblTitle
//            // 
//            this.lblTitle.AutoSize = true;
//            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.lblTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
//            this.lblTitle.Location = new System.Drawing.Point(148, 11);
//            this.lblTitle.Name = "lblTitle";
//            this.lblTitle.Size = new System.Drawing.Size(160, 24);
//            this.lblTitle.TabIndex = 0;
//            this.lblTitle.Text = "Evidencija računa";
//            this.lblTitle.Click += new System.EventHandler(this.label16_Click);
//            // 
//            // maximizeForm
//            // 
//            this.maximizeForm.AutoSize = true;
//            this.maximizeForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.maximizeForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
//            this.maximizeForm.Location = new System.Drawing.Point(387, 10);
//            this.maximizeForm.Name = "maximizeForm";
//            this.maximizeForm.Size = new System.Drawing.Size(19, 20);
//            this.maximizeForm.TabIndex = 8;
//            this.maximizeForm.Text = "➚";
//            this.maximizeForm.Click += new System.EventHandler(this.maximizeForm_Click);
//            // 
//            // minimizeForm
//            // 
//            this.minimizeForm.AutoSize = true;
//            this.minimizeForm.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.minimizeForm.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(120)))), ((int)(((byte)(138)))));
//            this.minimizeForm.Location = new System.Drawing.Point(363, 10);
//            this.minimizeForm.Name = "minimizeForm";
//            this.minimizeForm.Size = new System.Drawing.Size(19, 20);
//            this.minimizeForm.TabIndex = 7;
//            this.minimizeForm.Text = "_";
//            this.minimizeForm.Click += new System.EventHandler(this.minimizeForm_Click);
//            // 
//            // frmRacuniDetails
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
//            this.ClientSize = new System.Drawing.Size(460, 366);
//            this.Controls.Add(this.panel15);
//            this.Controls.Add(this.btnSave);
//            this.Controls.Add(this.groupBox2);
//            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
//            this.Name = "frmRacuniDetails";
//            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
//            this.Text = "Registracija pacijenta";
//            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
//            this.groupBox2.ResumeLayout(false);
//            this.groupBox2.PerformLayout();
//            this.panel15.ResumeLayout(false);
//            this.panel15.PerformLayout();
//            this.ResumeLayout(false);

//        }

//        #endregion
//        private System.Windows.Forms.ErrorProvider errorProvider;
//        private System.Windows.Forms.GroupBox groupBox2;
//        private System.Windows.Forms.Label label12;
//        private System.Windows.Forms.Label label9;
//        private System.Windows.Forms.ComboBox cmbApotekar;
//        private System.Windows.Forms.DateTimePicker dtpDatumIzdavanja;
//        private System.Windows.Forms.Button btnSave;
//        private System.Windows.Forms.Panel panel15;
//        private System.Windows.Forms.Label lblTitle;
//        private System.Windows.Forms.Label closeForm;
//        private System.Windows.Forms.Label maximizeForm;
//        private System.Windows.Forms.Label minimizeForm;
//        private System.Windows.Forms.ComboBox cmbPacijent;
//        private System.Windows.Forms.Label label2;
//    }
//}