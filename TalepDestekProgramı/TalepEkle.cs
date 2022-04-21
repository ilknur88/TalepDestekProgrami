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
    public partial class TalepEkle : Form
    {
        public TalepEkle()
        {
            InitializeComponent();
        }

        private void TalepEkle_Load(object sender, EventArgs e)
        {
            FirmaTalepler.KullaniciBilgiGetir(comboBox1);
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
            dateTimePicker1.Value = DateTime.Now;
        }
        private void onay_Click(object sender, EventArgs e)
        {
            FirmaTalepler ft = new FirmaTalepler();
            ft.Id = int.Parse(txtid.Text);
            ft.ReportTo = int.Parse(txtreportto.Text);
            ft.Explanition = txtexplanition.Text;
            ft.Status = int.Parse(txtstatus.Text);
            ft.ParentId = int.Parse(txtparentid.Text);
            ft.File = txtfile.Text;
            ft.AddUserId = int.Parse(txtadduserid.Text);
            ft.UpdateUserId = int.Parse(txtupdateuserid.Text);
            ft.AddDate = dateTimePicker1.Value;
            ft.UpdateDate = dateTimePicker2.Value;
            ft.ObjStatusId = int.Parse(txtobjstatusid.Text);
            ft.Version = int.Parse(txtversion.Text);
            ft.PrevVersionId = int.Parse(txtprevversionid.Text);
            ft.UpdateVersion = int.Parse(txtupdateversion.Text);
            ft.DynamicJsonVal = txtdynamicjsonval.Text;
            ft.OrganizationId = int.Parse(txtorganizationid.Text);
            ft.DataBaseName = txtdatabasename.Text;
            ft.KullanıcıId = int.Parse(comboBox1.Text);

                string data = "insert into GelenTalepler values('" +ft.Id+ "','" + ft.ReportTo + "','" + ft.Explanition + "','" + ft.Status + "'," +
                "'" + ft.ParentId + "','" + ft.File + "','" + ft.AddUserId + "','" + ft.UpdateUserId + "',@AddDate,@UpdateDate," +
                "'" + ft.ObjStatusId + "','" + ft.Version + "','" + ft.PrevVersionId + "','" + ft.UpdateVersion + "','"+ ft.DynamicJsonVal + "'," +
                "'" + ft.OrganizationId + "','" + ft.DataBaseName  + "','"+ ft.KullanıcıId + "')";
                SqlCommand kmt = new SqlCommand();
                kmt.Parameters.Add("@AddDate", SqlDbType.Date).Value = ft.AddDate;
                kmt.Parameters.Add("@UpdateDate", SqlDbType.Date).Value = ft.UpdateDate;
                Veri.EkleSilGüncelle(kmt, data);
                MessageBox.Show("Talep Ekleme Onaylandı.");
                Temizle();            
        }
    }
}
