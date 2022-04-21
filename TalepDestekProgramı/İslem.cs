using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace TalepDestekProgramı
{
    class İslem
    {
        private int islemId;
        private string islem;
        private int talepId;
        private int kullaniciId;
        private DateTime tarih;

        public int IslemId { get => islemId; set => islemId = value; }
        public string Islem { get => islem; set => islem = value; }
        public int KullaniciId { get => kullaniciId; set => kullaniciId = value; }
        public DateTime Tarih { get => tarih; set => tarih = value; }
        public int TalepId { get => talepId; set => talepId = value; }

        public static SqlDataReader CalisanBilgiAta(TextBox txtkulID, TextBox txtadsoyad)
        {
            Veri.baglanti.Open();
            SqlCommand kmt = new SqlCommand("select *from UygulamaGörevlileri where " +
                "KullanıcıID='" + txtkulID.Text + "'", Veri.baglanti);
            SqlDataReader rd = kmt.ExecuteReader();
            while (rd.Read())
            {
                txtadsoyad.Text = rd[1] + " " + rd[2];
            }
            Veri.baglanti.Close();
            return rd;

        }
    }
}
