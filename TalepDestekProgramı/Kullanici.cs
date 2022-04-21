using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace TalepDestekProgramı
{
    class Kullanici
    {
        private int kullaniciID;
        private string kullaniciAd;
        private string kullaniciSoyad;
        private string telefon;
        private string email;
        private string sifre;
        private string soru;
        private string cevap;
        private DateTime tarih;

        public int KullaniciID { get => kullaniciID; set => kullaniciID = value; }
        public string KullaniciAd { get => kullaniciAd; set => kullaniciAd = value; }
        public string KullaniciSoyad { get => kullaniciSoyad; set => kullaniciSoyad = value; }
        public string Email { get => email; set => email = value; }
        public string Sifre { get => sifre; set => sifre = value; }
        public string Soru { get => soru; set => soru = value; }
        public string Cevap { get => cevap; set => cevap = value; }
        public DateTime Tarih { get => tarih; set => tarih = value; }
        public string Telefon { get => telefon; set => telefon = value; }

        public static bool hal = false;
        public static SqlDataReader KulGrs(string kulad, string sfr)
        {
            Kullanici k = new Kullanici();
            k.kullaniciAd = kulad;
            k.sifre = sfr;
            Veri.baglanti.Open();
            SqlCommand kmt = new SqlCommand("select *from UygulamaGörevlileri where KullanıcıAd='"+k.kullaniciAd+"'" +
                " and Sifre='"+k.sifre+"' ",Veri.baglanti);
            SqlDataReader rd = kmt.ExecuteReader();
            if (rd.Read())
            {
                hal = true;
                k.KullaniciID = int.Parse(rd[0].ToString());
            }
            else
            {
                hal = false;
            }
            rd.Close();
            Veri.baglanti.Close();
            return rd;
        }
        public static DataTable TarihAra(DateTimePicker dttm, DataGridView grd)
        {
            DataTable tb = new DataTable();
            Veri.baglanti.Open();
            SqlDataAdapter adp = new SqlDataAdapter("select k.KullaniciID,k.KullaniciAd,k.KullaniciSoyad,k.Telefon," +
                "k.Email,k.Sifre,k.Soru,k.Cevap,k.Tarih from Kullanicilar k where k.Alanno and Tarih=@T", Veri.baglanti);
            adp.SelectCommand.Parameters.Add("@T",SqlDbType.Date).Value=DateTime.Parse(dttm.Value.ToShortDateString());
            adp.Fill(tb);
            grd.DataSource = tb;
            Veri.baglanti.Close();
            return tb;
        }
        public static SqlDataReader AyniIdKapatma(int kulid)
        {
            Kullanici k = new Kullanici();
            k.kullaniciID = kulid;
            Veri.baglanti.Open();
            SqlCommand kmt = new SqlCommand("select *from UygulamaGörevlileri where KullanıcıId='"+k.kullaniciID+"'",Veri.baglanti);
            SqlDataReader rd = kmt.ExecuteReader();
            if (rd.Read())
            {
                hal = false;
                k.kullaniciAd = (rd[1].ToString());
                k.KullaniciSoyad = (rd[2].ToString());
            }
            else
            {
                hal = true;
            }
            rd.Close();
            Veri.baglanti.Close();
            return rd;
        }
    }
}
