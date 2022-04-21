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
    public partial class TaleplerAylaraGöreGelmeSayisi : Form
    {
        public TaleplerAylaraGöreGelmeSayisi()
        {
            InitializeComponent();
        }
        public static SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-98NKA0M\\SQLEXPRESS;Initial Catalog=TalepDestekDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void TaleplerAylaraGöreGelmeSayisi_Load(object sender, EventArgs e)
        {
            SqlDataAdapter listele = new SqlDataAdapter("SELECT COUNT(*) AS AylaraGöreToplamTalep, MONTH(AddDate) AS AYLAR FROM GelenTalepler GROUP BY MONTH(AddDate) ", baglanti);
            DataTable tablo = new DataTable();
            listele.Fill(tablo);
            bindingSource1.DataSource = tablo;
            dataGridView1.DataSource = bindingSource1;
        }
    }
}
