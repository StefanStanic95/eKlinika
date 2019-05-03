namespace eKlinika.WinUI.MedicinskeSestre
{
    partial class frmUplate
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmUplate));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgvUplate = new System.Windows.Forms.DataGridView();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BrojUplatnice = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DatumUplate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Iznos = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Namjena = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PacijentId = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ZiroRacun = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnPrikazi = new System.Windows.Forms.Button();
            this.closeForm = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtUplatnica = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUplate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.panel1);
            this.groupBox1.Controls.Add(this.dgvUplate);
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.groupBox1.Location = new System.Drawing.Point(12, 146);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1189, 341);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Uplate";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.panel1.Location = new System.Drawing.Point(6, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1164, 1);
            this.panel1.TabIndex = 1;
            // 
            // dgvUplate
            // 
            this.dgvUplate.AllowUserToAddRows = false;
            this.dgvUplate.AllowUserToDeleteRows = false;
            this.dgvUplate.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.dgvUplate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUplate.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Id,
            this.BrojUplatnice,
            this.DatumUplate,
            this.Iznos,
            this.Namjena,
            this.PacijentId,
            this.ZiroRacun});
            this.dgvUplate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvUplate.Location = new System.Drawing.Point(3, 16);
            this.dgvUplate.Name = "dgvUplate";
            this.dgvUplate.ReadOnly = true;
            this.dgvUplate.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvUplate.Size = new System.Drawing.Size(1183, 322);
            this.dgvUplate.TabIndex = 0;
            this.dgvUplate.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvUplate_CellDoubleClick);
            this.dgvUplate.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgvUplate_CellFormatting);
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            this.Id.Visible = false;
            // 
            // BrojUplatnice
            // 
            this.BrojUplatnice.DataPropertyName = "BrojUplatnice";
            this.BrojUplatnice.HeaderText = "Broj uplatnice";
            this.BrojUplatnice.Name = "BrojUplatnice";
            this.BrojUplatnice.ReadOnly = true;
            // 
            // DatumUplate
            // 
            this.DatumUplate.DataPropertyName = "DatumUplate";
            this.DatumUplate.HeaderText = "Datum uplate";
            this.DatumUplate.Name = "DatumUplate";
            this.DatumUplate.ReadOnly = true;
            // 
            // Iznos
            // 
            this.Iznos.DataPropertyName = "Iznos";
            this.Iznos.HeaderText = "Iznos";
            this.Iznos.Name = "Iznos";
            this.Iznos.ReadOnly = true;
            // 
            // Namjena
            // 
            this.Namjena.DataPropertyName = "Namjena";
            this.Namjena.HeaderText = "Namjena";
            this.Namjena.Name = "Namjena";
            this.Namjena.ReadOnly = true;
            // 
            // PacijentId
            // 
            this.PacijentId.DataPropertyName = "Pacijent.ImePrezime";
            this.PacijentId.HeaderText = "Pacijent";
            this.PacijentId.Name = "PacijentId";
            this.PacijentId.ReadOnly = true;
            // 
            // ZiroRacun
            // 
            this.ZiroRacun.DataPropertyName = "ZiroRacun";
            this.ZiroRacun.HeaderText = "ZiroRacun";
            this.ZiroRacun.Name = "ZiroRacun";
            this.ZiroRacun.ReadOnly = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.label1.Location = new System.Drawing.Point(536, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Uplate";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.label2.Location = new System.Drawing.Point(14, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Broj uplatnice:";
            // 
            // btnPrikazi
            // 
            this.btnPrikazi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.btnPrikazi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPrikazi.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrikazi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.btnPrikazi.Location = new System.Drawing.Point(1112, 107);
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
            this.closeForm.Location = new System.Drawing.Point(1181, 9);
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
            // txtUplatnica
            // 
            this.txtUplatnica.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.txtUplatnica.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUplatnica.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.txtUplatnica.Location = new System.Drawing.Point(104, 107);
            this.txtUplatnica.Name = "txtUplatnica";
            this.txtUplatnica.Size = new System.Drawing.Size(130, 13);
            this.txtUplatnica.TabIndex = 16;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.panel2.Location = new System.Drawing.Point(89, 123);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 1);
            this.panel2.TabIndex = 17;
            // 
            // btnAdd
            // 
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(78)))), ((int)(((byte)(184)))), ((int)(((byte)(206)))));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.btnAdd.Location = new System.Drawing.Point(1080, 506);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(86, 23);
            this.btnAdd.TabIndex = 18;
            this.btnAdd.Text = "Dodaj";
            this.btnAdd.UseVisualStyleBackColor = false;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // frmUplate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(36)))), ((int)(((byte)(49)))));
            this.ClientSize = new System.Drawing.Size(1213, 562);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.txtUplatnica);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.closeForm);
            this.Controls.Add(this.btnPrikazi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "frmUplate";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmPregledi";
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvUplate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgvUplate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnPrikazi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label closeForm;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtUplatnica;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn BrojUplatnice;
        private System.Windows.Forms.DataGridViewTextBoxColumn DatumUplate;
        private System.Windows.Forms.DataGridViewTextBoxColumn Iznos;
        private System.Windows.Forms.DataGridViewTextBoxColumn Namjena;
        private System.Windows.Forms.DataGridViewTextBoxColumn PacijentId;
        private System.Windows.Forms.DataGridViewTextBoxColumn ZiroRacun;
        private System.Windows.Forms.Button btnAdd;
    }
}