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
    public partial class KullaniciEkle : Form
    {
        public KullaniciEkle()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        void Temizle()
        {
            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
            combsoru.Text = "";
            dateTimePicker1.Value = DateTime.Now;           
        }
        private void onay_Click(object sender, EventArgs e)
        {
            Kullanici.AyniIdKapatma(int.Parse(txtkulid.Text));
            if (Kullanici.hal)
            {
               Kullanici k = new Kullanici();
            k.KullaniciID = int.Parse(txtkulid.Text);
            k.KullaniciAd = txtad.Text;
            k.KullaniciSoyad = txtsoyad.Text;
            k.Telefon = txttel.Text;
            k.Email = txtmail.Text;
            k.Sifre = txtsfr.Text;
            k.Soru = combsoru.Text;
            k.Cevap = txtcvp.Text;
            k.Tarih = dateTimePicker1.Value;
            if (txtsfr.Text!="")
            {
                string data = "insert into UygulamaGörevlileri values('"+k.KullaniciID+"','"+k.KullaniciAd+"','"+k.KullaniciSoyad+"','"+k.Telefon+"','"+k.Email+"','"+k.Sifre+"','"+k.Soru+"','"+k.Cevap+"',@Tarih)";
                SqlCommand kmt = new SqlCommand();
                kmt.Parameters.Add("@Tarih", SqlDbType.Date).Value = k.Tarih;
                Veri.EkleSilGüncelle(kmt, data);
                MessageBox.Show("Kullanıcı Ekleme Onaylandı.");
                Temizle();
            }
            else
            {
                MessageBox.Show("Lütfen Şifre Giriniz!");
            } }
            else
            {
                MessageBox.Show("Girilen KullanıcıId Mevcut!Bilgi Değişikliği Yapınız!");

            }

        }

        private void KullaniciEkle_Load(object sender, EventArgs e)
        {
            
        }

        private void blgdzn_Click(object sender, EventArgs e)
        {
            KullaniciBilgiDüzenle KBD = new KullaniciBilgiDüzenle();
            KBD.Show();
        }
    }
}
