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
    public partial class OrtalamaCevaplamaSüresi : Form
    {
        public OrtalamaCevaplamaSüresi()
        {
            InitializeComponent();
        }
        public static SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-98NKA0M\\SQLEXPRESS;Initial Catalog=TalepDestekDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void OrtalamaCevaplamaSüresi_Load(object sender, EventArgs e)
        {
            SqlDataAdapter listele = new SqlDataAdapter("DECLARE @TarihFark DATETIME; SELECT DATEDIFF(day, AddDate, UpdateDate) AS Gün, DATEDIFF(hour, AddDate, UpdateDate) AS Saat, DATEDIFF(minute, AddDate, UpdateDate) AS Dakika, DATEDIFF(second, AddDate, UpdateDate) AS Saniye FROM GelenTalepler ; ", baglanti);
            DataTable tablo = new DataTable();
            listele.Fill(tablo);
            bindingSource1.DataSource = tablo;
            dataGridView1.DataSource = bindingSource1;

            SqlDataAdapter listele2 = new SqlDataAdapter("SELECT AVG(DATEDIFF(day, AddDate, UpdateDate))AS Gün, (SELECT AVG(DATEDIFF(hour, AddDate, UpdateDate))) AS Saat, (SELECT AVG(DATEDIFF(minute, AddDate, UpdateDate)))AS Dakika, (SELECT AVG(DATEDIFF(second, AddDate, UpdateDate)))AS Saniye FROM GelenTalepler; ", baglanti);
            DataTable tablo2 = new DataTable();
            listele2.Fill(tablo2);
            bindingSource2.DataSource = tablo2;
            dataGridView2.DataSource = bindingSource2;
        }
    }
}
