using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TalepDestekProgramı
{
    public partial class KullanıcıGiris : Form
    {
        public KullanıcıGiris()
        {
            InitializeComponent();
        }
        private void pictureBox5_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void talepislmleri_Click(object sender, EventArgs e)
        {
            TalepEkle TE = new TalepEkle();
            TE.Show();
        }
        private void islemdurum_Click(object sender, EventArgs e)
        {
            TalepİslemDurumlari TİD = new TalepİslemDurumlari();
            TİD.Show();
        }
        private void uygkulislm_Click(object sender, EventArgs e)
        {
            KullaniciEkle KE = new KullaniciEkle();
            KE.Show();
        }
        private void sorguA_Click(object sender, EventArgs e)
        {
            Encoktalepgelenfirma ectgf = new Encoktalepgelenfirma();
            ectgf.Show();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            TaleplerKelimeBulma tkb = new TaleplerKelimeBulma();
            tkb.Show();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            OrtalamaCevaplamaSüresi ocs = new OrtalamaCevaplamaSüresi();
            ocs.Show();
        }
        private void button3_Click(object sender, EventArgs e)
        {
            TaleplerAylaraGöreGelmeSayisi tap = new TaleplerAylaraGöreGelmeSayisi();
            tap.Show();
        }
    }
}
