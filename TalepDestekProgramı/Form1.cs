using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TalepDestekProgramı
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void onay_Click(object sender, EventArgs e)
        {
            Kullanici.KulGrs(txtad.Text, txtsfr.Text);
            if (Kullanici.hal)
            {
                KullanıcıGiris KG = new KullanıcıGiris();
                KG.Show();
            }
            else
            {
                MessageBox.Show("Eksik Bilgi Girişi!");
            }
        }

        private void sifrenimiunuttun_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            SifreUnutma SU = new SifreUnutma();
            SU.Show();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            {
                if (checkBox1.Checked)
                {
                    txtsfr.PasswordChar = '\0';
                }
                else
                {
                    txtsfr.PasswordChar = '*';
                }
            }
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {

        }
    }
}
