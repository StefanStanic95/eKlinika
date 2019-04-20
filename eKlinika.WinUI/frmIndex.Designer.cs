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
            this.korisniciToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pretragaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noviKorisnikToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.doktorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uputniceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.preglediToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.medicinskaSestraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uplateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.uputniceToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.preglediToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.referentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pacijentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.noviPacijentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.urediPacijentaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.apotekarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.korisniciToolStripMenuItem,
            this.doktorToolStripMenuItem,
            this.medicinskaSestraToolStripMenuItem,
            this.referentToolStripMenuItem,
            this.apotekarToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(632, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // korisniciToolStripMenuItem
            // 
            this.korisniciToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pretragaToolStripMenuItem,
            this.noviKorisnikToolStripMenuItem});
            this.korisniciToolStripMenuItem.Name = "korisniciToolStripMenuItem";
            this.korisniciToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.korisniciToolStripMenuItem.Text = "Korisnik";
            // 
            // pretragaToolStripMenuItem
            // 
            this.pretragaToolStripMenuItem.Name = "pretragaToolStripMenuItem";
            this.pretragaToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.pretragaToolStripMenuItem.Text = "Pretraga";
            this.pretragaToolStripMenuItem.Click += new System.EventHandler(this.pretragaToolStripMenuItem_Click);
            // 
            // noviKorisnikToolStripMenuItem
            // 
            this.noviKorisnikToolStripMenuItem.Name = "noviKorisnikToolStripMenuItem";
            this.noviKorisnikToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.noviKorisnikToolStripMenuItem.Text = "Novi korisnik";
            this.noviKorisnikToolStripMenuItem.Click += new System.EventHandler(this.noviKorisnikToolStripMenuItem_Click);
            // 
            // doktorToolStripMenuItem
            // 
            this.doktorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uputniceToolStripMenuItem,
            this.preglediToolStripMenuItem});
            this.doktorToolStripMenuItem.Name = "doktorToolStripMenuItem";
            this.doktorToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.doktorToolStripMenuItem.Text = "Doktor";
            // 
            // uputniceToolStripMenuItem
            // 
            this.uputniceToolStripMenuItem.Name = "uputniceToolStripMenuItem";
            this.uputniceToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.uputniceToolStripMenuItem.Text = "Uputnice";
            // 
            // preglediToolStripMenuItem
            // 
            this.preglediToolStripMenuItem.Name = "preglediToolStripMenuItem";
            this.preglediToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.preglediToolStripMenuItem.Text = "Pregledi";
            // 
            // medicinskaSestraToolStripMenuItem
            // 
            this.medicinskaSestraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.uplateToolStripMenuItem,
            this.uputniceToolStripMenuItem1,
            this.preglediToolStripMenuItem1});
            this.medicinskaSestraToolStripMenuItem.Name = "medicinskaSestraToolStripMenuItem";
            this.medicinskaSestraToolStripMenuItem.Size = new System.Drawing.Size(112, 20);
            this.medicinskaSestraToolStripMenuItem.Text = "Medicinska sestra";
            // 
            // uplateToolStripMenuItem
            // 
            this.uplateToolStripMenuItem.Name = "uplateToolStripMenuItem";
            this.uplateToolStripMenuItem.Size = new System.Drawing.Size(122, 22);
            this.uplateToolStripMenuItem.Text = "Uplate";
            // 
            // uputniceToolStripMenuItem1
            // 
            this.uputniceToolStripMenuItem1.Name = "uputniceToolStripMenuItem1";
            this.uputniceToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.uputniceToolStripMenuItem1.Text = "Uputnice";
            // 
            // preglediToolStripMenuItem1
            // 
            this.preglediToolStripMenuItem1.Name = "preglediToolStripMenuItem1";
            this.preglediToolStripMenuItem1.Size = new System.Drawing.Size(122, 22);
            this.preglediToolStripMenuItem1.Text = "Pregledi";
            // 
            // referentToolStripMenuItem
            // 
            this.referentToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pacijentToolStripMenuItem});
            this.referentToolStripMenuItem.Name = "referentToolStripMenuItem";
            this.referentToolStripMenuItem.Size = new System.Drawing.Size(63, 20);
            this.referentToolStripMenuItem.Text = "Referent";
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
            this.noviPacijentToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.noviPacijentToolStripMenuItem.Text = "Novi pacijent";
            this.noviPacijentToolStripMenuItem.Click += new System.EventHandler(this.noviPacijentToolStripMenuItem_Click);
            // 
            // urediPacijentaToolStripMenuItem
            // 
            this.urediPacijentaToolStripMenuItem.Name = "urediPacijentaToolStripMenuItem";
            this.urediPacijentaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.urediPacijentaToolStripMenuItem.Text = "Pregled pacijenta";
            this.urediPacijentaToolStripMenuItem.Click += new System.EventHandler(this.urediPacijentaToolStripMenuItem_Click);
            // 
            // apotekarToolStripMenuItem
            // 
            this.apotekarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lijekoviToolStripMenuItem,
            this.računiToolStripMenuItem,
            this.narudžbeToolStripMenuItem,
            this.receptiToolStripMenuItem});
            this.apotekarToolStripMenuItem.Name = "apotekarToolStripMenuItem";
            this.apotekarToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.apotekarToolStripMenuItem.Text = "Apotekar";
            // 
            // lijekoviToolStripMenuItem
            // 
            this.lijekoviToolStripMenuItem.Name = "lijekoviToolStripMenuItem";
            this.lijekoviToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.lijekoviToolStripMenuItem.Text = "Lijekovi";
            // 
            // računiToolStripMenuItem
            // 
            this.računiToolStripMenuItem.Name = "računiToolStripMenuItem";
            this.računiToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.računiToolStripMenuItem.Text = "Računi";
            // 
            // narudžbeToolStripMenuItem
            // 
            this.narudžbeToolStripMenuItem.Name = "narudžbeToolStripMenuItem";
            this.narudžbeToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.narudžbeToolStripMenuItem.Text = "Narudžbe";
            // 
            // receptiToolStripMenuItem
            // 
            this.receptiToolStripMenuItem.Name = "receptiToolStripMenuItem";
            this.receptiToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
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
        private System.Windows.Forms.ToolStripMenuItem korisniciToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pretragaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noviKorisnikToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem doktorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uputniceToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem preglediToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem medicinskaSestraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uplateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem uputniceToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem preglediToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem referentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pacijentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem apotekarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem lijekoviToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem računiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem narudžbeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem receptiToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem noviPacijentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem urediPacijentaToolStripMenuItem;
    }
}



