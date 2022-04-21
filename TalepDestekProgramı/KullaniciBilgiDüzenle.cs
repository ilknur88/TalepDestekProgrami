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
    public partial class KullaniciBilgiDüzenle : Form
    {
        public KullaniciBilgiDüzenle()
        {
            InitializeComponent();
        }

        private void KullaniciBilgiDüzenle_Load(object sender, EventArgs e)
        {
            ListGünc();
        }
        private void ListGünc()
        {
            Veri.ListeleAra(dataGridView1,"select KullanıcıID,KullanıcıAd,KullanıcıSoyad,Telefon," +
                "Email,Sifre,SifreKurtarmaSoru,SifreKurtarmaCevap,Tarih from UygulamaGörevlileri");
            label10.Text = "" + (dataGridView1.Rows.Count - 1) + "";
        }
        void sil()
        {
            dateTimePicker1.Value = DateTime.Now;
            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }    
        }
        private void güncelle_Click(object sender, EventArgs e)
        {
            Kullanici k = new Kullanici();
            k.KullaniciID = int.Parse(txtkulıd.Text);
            k.KullaniciAd = txtad.Text;
            k.KullaniciSoyad = txtsoyad.Text;
            k.Telefon = txttel.Text;
            k.Email = txtmail.Text;
            k.Sifre = txtsfr.Text;
            k.Soru = combsoru.Text;
            k.Cevap = txtcvp.Text;
            k.Tarih = dateTimePicker1.Value;
            string ara = "update UygulamaGörevlileri set KullanıcıAd='"+k.KullaniciAd+"',KullanıcıSoyad='"+k.KullaniciSoyad+"',Telefon='"+k.Telefon+"',Email='"+k.Email+"',Sifre='"+k.Sifre+"',SifreKurtarmaSoru='"+k.Soru+"',SifreKurtarmaCevap='"+k.Cevap+"',Tarih=@Tarih where KullanıcıID='"+k.KullaniciID+"' ";
            SqlCommand kmt = new SqlCommand();
            kmt.Parameters.Add("@Tarih", SqlDbType.Date).Value = k.Tarih;
            Veri.EkleSilGüncelle(kmt, ara);
            sil();
            MessageBox.Show("Bilgi Güncelleme Onaylandı.");
            ListGünc();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txtkulıd.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtad.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtsoyad.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txttel.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtmail.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtsfr.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            combsoru.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtcvp.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            dateTimePicker1.Value = DateTime.Parse(dataGridView1.CurrentRow.Cells[8].Value.ToString());
        }
       
        private void bilgisil_Click(object sender, EventArgs e)
        {
            Kullanici k = new Kullanici();
            k.KullaniciID = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());          
            string ara2 = "delete from UygulamaGörevlileri where KullanıcıID='" + k.KullaniciID + "'";
            SqlCommand kmt2 = new SqlCommand();
            Veri.EkleSilGüncelle(kmt2, ara2);
            MessageBox.Show("Silme İşlemi Onaylandı.");
            sil(); ListGünc();
        }
    }
}
