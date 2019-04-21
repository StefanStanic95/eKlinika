namespace eKlinika.WinUI
{
    partial class frmIndex
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.tsmiKorisnici = new System.Windows.Forms.ToolStripMenuItem();
            this.pretragaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noviKorisnikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiDoktor = new System.Windows.Forms.ToolStripMenuItem();
            this.uputniceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preglediToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiMedicinskaSestra = new System.Windows.Forms.ToolStripMenuItem();
            this.uplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uputniceToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.preglediToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiReferent = new System.Windows.Forms.ToolStripMenuItem();
            this.pacijentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noviPacijentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.urediPacijentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiApotekar = new System.Windows.Forms.ToolStripMenuItem();
            this.lijekoviToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.računiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.narudžbeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.receptiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiKorisnici,
            this.tsmiDoktor,
            this.tsmiMedicinskaSestra,
            this.tsmiReferent,
            this.tsmiApotekar});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(632, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // tsmiKorisnici
            // 
            this.tsmiKorisnici.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pretragaToolStripMenuItem,
            this.noviKorisnikToolStripMenuItem});
            this.tsmiKorisnici.Name = "tsmiKorisnici";
            this.tsmiKorisnici.Size = new System.Drawing.Size(61, 20);
            this.tsmiKorisnici.Text = "Korisnik";
            this.tsmiKorisnici.Visible = false;
            // 
            // pretragaToolStripMenuItem
            // 
            this.pretragaToolStripMenuItem.Name = "pretragaToolStripMenuItem";
            this.pretragaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pretragaToolStripMenuItem.Text = "Pretraga";
            this.pretragaToolStripMenuItem.Click += new System.EventHandler(this.pretragaToolStripMenuItem_Click);
            // 
            // noviKorisnikToolStripMenuItem
            // 
            this.noviKorisnikToolStripMenuItem.Name = "noviKorisnikToolStripMenuItem";
            this.noviKorisnikToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.noviKorisnikToolStripMenuItem.Text = "Novi korisnik";
            this.noviKorisnikToolStripMenuItem.Click += new System.EventHandler(this.noviKorisnikToolStripMenuItem_Click);
            // 
            // tsmiDoktor
            // 
            this.tsmiDoktor.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uputniceToolStripMenuItem,
            this.preglediToolStripMenuItem});
            this.tsmiDoktor.Name = "tsmiDoktor";
            this.tsmiDoktor.Size = new System.Drawing.Size(55, 20);
            this.tsmiDoktor.Text = "Doktor";
            this.tsmiDoktor.Visible = false;
            // 
            // uputniceToolStripMenuItem
            // 
            this.uputniceToolStripMenuItem.Name = "uputniceToolStripMenuItem";
            this.uputniceToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.uputniceToolStripMenuItem.Text = "Uputnice";
            // 
            // preglediToolStripMenuItem
            // 
            this.preglediToolStripMenuItem.Name = "preglediToolStripMenuItem";
            this.preglediToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.preglediToolStripMenuItem.Text = "Pregledi";
            // 
            // tsmiMedicinskaSestra
            // 
            this.tsmiMedicinskaSestra.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uplateToolStripMenuItem,
            this.uputniceToolStripMenuItem1,
            this.preglediToolStripMenuItem1});
            this.tsmiMedicinskaSestra.Name = "tsmiMedicinskaSestra";
            this.tsmiMedicinskaSestra.Size = new System.Drawing.Size(112, 20);
            this.tsmiMedicinskaSestra.Text = "Medicinska sestra";
            this.tsmiMedicinskaSestra.Visible = false;
            // 
            // uplateToolStripMenuItem
            // 
            this.uplateToolStripMenuItem.Name = "uplateToolStripMenuItem";
            this.uplateToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.uplateToolStripMenuItem.Text = "Uplate";
            // 
            // uputniceToolStripMenuItem1
            // 
            this.uputniceToolStripMenuItem1.Name = "uputniceToolStripMenuItem1";
            this.uputniceToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.uputniceToolStripMenuItem1.Text = "Uputnice";
            // 
            // preglediToolStripMenuItem1
            // 
            this.preglediToolStripMenuItem1.Name = "preglediToolStripMenuItem1";
            this.preglediToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.preglediToolStripMenuItem1.Text = "Pregledi";
            // 
            // tsmiReferent
            // 
            this.tsmiReferent.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pacijentToolStripMenuItem});
            this.tsmiReferent.Name = "tsmiReferent";
            this.tsmiReferent.Size = new System.Drawing.Size(63, 20);
            this.tsmiReferent.Text = "Referent";
            this.tsmiReferent.Visible = false;
            // 
            // pacijentToolStripMenuItem
            // 
            this.pacijentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.noviPacijentToolStripMenuItem,
            this.urediPacijentaToolStripMenuItem});
            this.pacijentToolStripMenuItem.Name = "pacijentToolStripMenuItem";
            this.pacijentToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.pacijentToolStripMenuItem.Text = "Pacijenti";
            this.pacijentToolStripMenuItem.Click += new System.EventHandler(this.pacijentToolStripMenuItem_Click);
            // 
            // noviPacijentToolStripMenuItem
            // 
            this.noviPacijentToolStripMenuItem.Name = "noviPacijentToolStripMenuItem";
            this.noviPacijentToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.noviPacijentToolStripMenuItem.Text = "Novi pacijent";
            this.noviPacijentToolStripMenuItem.Click += new System.EventHandler(this.noviPacijentToolStripMenuItem_Click);
            // 
            // urediPacijentaToolStripMenuItem
            // 
            this.urediPacijentaToolStripMenuItem.Name = "urediPacijentaToolStripMenuItem";
            this.urediPacijentaToolStripMenuItem.Size = new System.Drawing.Size(165, 22);
            this.urediPacijentaToolStripMenuItem.Text = "Pregled pacijenta";
            this.urediPacijentaToolStripMenuItem.Click += new System.EventHandler(this.urediPacijentaToolStripMenuItem_Click);
            // 
            // tsmiApotekar
            // 
            this.tsmiApotekar.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lijekoviToolStripMenuItem,
            this.računiToolStripMenuItem,
            this.narudžbeToolStripMenuItem,
            this.receptiToolStripMenuItem});
            this.tsmiApotekar.Name = "tsmiApotekar";
            this.tsmiApotekar.Size = new System.Drawing.Size(67, 20);
            this.tsmiApotekar.Text = "Apotekar";
            this.tsmiApotekar.Visible = false;
            // 
            // lijekoviToolStripMenuItem
            // 
            this.lijekoviToolStripMenuItem.Name = "lijekoviToolStripMenuItem";
            this.lijekoviToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.lijekoviToolStripMenuItem.Text = "Lijekovi";
            // 
            // računiToolStripMenuItem
            // 
            this.računiToolStripMenuItem.Name = "računiToolStripMenuItem";
            this.računiToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.računiToolStripMenuItem.Text = "Računi";
            // 
            // narudžbeToolStripMenuItem
            // 
            this.narudžbeToolStripMenuItem.Name = "narudžbeToolStripMenuItem";
            this.narudžbeToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.narudžbeToolStripMenuItem.Text = "Narudžbe";
            // 
            // receptiToolStripMenuItem
            // 
            this.receptiToolStripMenuItem.Name = "receptiToolStripMenuItem";
            this.receptiToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.receptiToolStripMenuItem.Text = "Recepti";
            // 
            // statusStrip
            // 
            this.statusStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 431);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(632, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "StatusStrip";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(39, 17);
            this.toolStripStatusLabel.Text = "Status";
            // 
            // frmIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 453);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "frmIndex";
            this.Text = "frmIndex";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem tsmiKorisnici;
        private System.Windows.Forms.ToolStripMenuItem pretragaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noviKorisnikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiDoktor;
        private System.Windows.Forms.ToolStripMenuItem uputniceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preglediToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiMedicinskaSestra;
        private System.Windows.Forms.ToolStripMenuItem uplateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uputniceToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem preglediToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem tsmiReferent;
        private System.Windows.Forms.ToolStripMenuItem pacijentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmiApotekar;
        private System.Windows.Forms.ToolStripMenuItem lijekoviToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem računiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem narudžbeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem receptiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noviPacijentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem urediPacijentaToolStripMenuItem;
    }
}



