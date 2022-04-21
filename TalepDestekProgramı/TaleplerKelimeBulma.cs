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
    public partial class TaleplerKelimeBulma : Form
    {
        public TaleplerKelimeBulma()
        {
            InitializeComponent();
        }
        public static SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-98NKA0M\\SQLEXPRESS;Initial Catalog=TalepDestekDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void TaleplerKelimeBulma_Load(object sender, EventArgs e)
        {
            SqlDataAdapter listele = new SqlDataAdapter("SELECT SUM(CASE WHEN Explanition LIKE '%hata%' then 1 end) AS ToplamSözcük FROM GelenTalepler", baglanti);
            DataTable tablo = new DataTable();
            listele.Fill(tablo);
            bindingSource1.DataSource = tablo;
            dataGridView1.DataSource = bindingSource1;

            SqlDataAdapter listele2 = new SqlDataAdapter("SELECT COUNT (*) AS HataKelimesiIcerenTalepler FROM GelenTalepler WHERE Explanition LIKE '%hata%' GROUP BY[Explanition]  ", baglanti);
            DataTable tablo2 = new DataTable();
            listele2.Fill(tablo2);
            bindingSource2.DataSource = tablo2;
            dataGridView2.DataSource = bindingSource2;

            SqlDataAdapter listele3 = new SqlDataAdapter("SELECT TalepNo,DataBaseName FROM GelenTalepler WHERE Explanition LIKE '%hata%' ", baglanti);
            DataTable tablo3 = new DataTable();
            listele3.Fill(tablo3);
            bindingSource3.DataSource = tablo3;
            dataGridView3.DataSource = bindingSource3;

        }
    }
}
