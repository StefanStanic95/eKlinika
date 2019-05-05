using eKlinika.WinUI.Doktori;
using eKlinika.WinUI.Korisnici;
using eKlinika.WinUI.Pacijenti;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eKlinika.WinUI
{
    public partial class frmIndex : Form
    {

        public frmIndex()
        {
            InitializeComponent();

            List<string> roles = APIService.Korisnik.KorisniciUloge.Select(x => x.Uloga.Naziv).ToList();
            bool IsAdmin = roles.Contains("Administrator");
            if (IsAdmin)
                tsmiKorisnici.Visible = true;

            if (IsAdmin || roles.Contains("Doktor"))
                tsmiDoktor.Visible = true;

            if (IsAdmin || roles.Contains("Apotekar"))
                tsmiApotekar.Visible = true;

            if (IsAdmin || roles.Contains("MedicinskaSestra"))
                tsmiMedicinskaSestra.Visible = true;

            if (IsAdmin || roles.Contains("Referent"))
                tsmiReferent.Visible = true;

            FormBorderStyle = FormBorderStyle.None;
        }

        private void pretragaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmKorisnici();
            frm.Show();
        }

        private void noviKorisnikToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmKorisniciDetails();
            frm.Show();
        }

        private void noviPacijentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmPacijentiDetails();
            frm.Show();

        }

        private void urediPacijentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmPacijenti();
            frm.Show();
        }

        private void minimizeForm_Click(object sender, System.EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void maximizeForm_Click(object sender, System.EventArgs e)
        {
            WindowState = WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;
        }

        private void closeForm_Click(object sender, System.EventArgs e)
        {
            Close();
        }

        private void preglediToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmPregledi();
            frm.Show();
        }

        private void uputniceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new frmUputnice();
            frm.Show();
        }

        private void uputniceToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frm = new MedicinskeSestre.frmUputnice();
            frm.Show();
        }

        private void preglediToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var frm = new MedicinskeSestre.frmPregledi();
            frm.Show();
        }

        private void uplateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new MedicinskeSestre.frmUplate();
            frm.Show();
        }

        private void lijekoviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new Apotekar.frmLijekovi();
            frm.Show();
        }

        private void dodavanjeLijekaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new Apotekar.frmLijekoviDetails();
            frm.Show();
        }

        private void računiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new Apotekar.frmRacuni();
            frm.Show();
        }

        private void receptiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new Apotekar.frmRecepti();
            frm.Show();
        }

        private void narudžbeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var frm = new Apotekar.frmNarudzbe();
            frm.Show();
        }

        private void pregledPacijentaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var frm = new frmPacijenti();
            frm.Show();
        }

        private void noviPacijentToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            var frm = new frmPacijentiDetails();
            frm.Show();
        }
    }
}
