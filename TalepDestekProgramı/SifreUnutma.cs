using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace TalepDestekProgramı
{
    public partial class SifreUnutma : Form
    {
        public SifreUnutma()
        {
            InitializeComponent();
        }
        private void onay_Click(object sender, EventArgs e)
        {
            Kullanici k = new Kullanici();
            k.KullaniciAd = txtkulad.Text;
            k.Sifre = txtsfr.Text;
            k.Soru = combsoru.Text;
            k.Cevap = txtcvp.Text;
            if (txtsfr.Text==txtsfr.Text)
            {
                string data= "update UygulamaGörevlileri set KullanıcıAd='"+k.KullaniciAd+"',Sifre='"+k.Sifre+"'," +
                    "SifreKurtarmaSoru='"+k.Soru+"',SifreKurtarmaCevap='"+k.Cevap+"' " +
                    "where KullanıcıAd='"+k.KullaniciAd+"'";
                SqlCommand kmt = new SqlCommand();
                Veri.EkleSilGüncelle(kmt, data);
                MessageBox.Show("Yeni Şifre Onaylandı.");
                this.Close();
            }
            else{  MessageBox.Show("Lütfen Yeni Şifre Giriniz!");}
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void SifreUnutma_Load(object sender, EventArgs e)
        {

        }
    }
}
