using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace TalepDestekProgramı
{
    class Veri
    {
        public static SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-98NKA0M\\SQLEXPRESS;Initial" +
            " Catalog=TalepDestekDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;" +
            "TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        public static void EkleSilGüncelle(SqlCommand com, string data)
        {
            baglanti.Open();
            com.Connection = baglanti;
            com.CommandText = data;
            com.ExecuteNonQuery();
            baglanti.Close();
        }
        public static DataTable ListeleAra(DataGridView grd, string data)
        {
            DataTable tb = new DataTable();
            baglanti.Open();
            SqlDataAdapter adp = new SqlDataAdapter(data, baglanti);
            adp.Fill(tb);
            grd.DataSource = tb;
            baglanti.Close();
            return tb;
        }
    }
}
