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
    public partial class TalepİslemDurumlari : Form
    {
        public TalepİslemDurumlari()
        {
            InitializeComponent();
        }
        private void TalepİslemDurumlari_Load(object sender, EventArgs e)
        {
            ListGünc();
        }
        private void ListGünc()
        {
            Veri.ListeleAra(dataGridView1, "select TalepNo,Id,ReportTo,Explanition,Status,ParentId,[File],AddUserId,UpdateUserId," +
                "AddDate,UpdateDate,ObjStatusId,Version,PrevVersionId,UpdateVersion,DynamicJsonVal,OrganizationId,DataBaseName,KullanıcıID from GelenTalepler");
            label16.Text = "" + (dataGridView1.Rows.Count - 1) + "";
        }
        void sil()
        {
            //dateTimePicker1.Value = DateTime.Now;
            foreach (Control item in Controls)
            {
                if (item is TextBox)
                {
                    item.Text = "";
                }
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void güncelle_Click(object sender, EventArgs e)
        {
            FirmaTalepler f = new FirmaTalepler();
            f.TalepNo = int.Parse(txttalepno.Text);
            f.Id = int.Parse(txtid.Text);
            f.ReportTo = int.Parse(txtreportto.Text);
            f.Explanition = txtexplanition.Text;
            f.Status = int.Parse(txtstatus.Text);
            f.ParentId = int.Parse(txtparentid.Text);
            f.File = txtfile.Text;
            f.AddUserId = int.Parse(txtadduserid.Text);
            f.UpdateUserId = int.Parse(txtupdateuserid.Text);
            f.AddDate = dateTimePicker1.Value;
            f.UpdateDate = dateTimePicker2.Value;
            f.ObjStatusId = int.Parse(txtobjstatusid.Text);
            f.Version = int.Parse(txtversion.Text);
            f.PrevVersionId = int.Parse(txtprevversionid.Text);
            f.UpdateVersion = int.Parse(txtupdateversion.Text);
            f.DynamicJsonVal = txtdynamicjsonval.Text;
            f.OrganizationId = int.Parse(txtorganizationid.Text); 
            f.DataBaseName = txtdatabasename.Text;
            f.KullanıcıId = int.Parse(comboBox1.Text);
           
            string ara = "update GelenTalepler set Id='"+f.Id+"', ReportTo='"+f.ReportTo+"', Explanition='"+f.Explanition+"', Status='"+f.Status+"', ParentId='"+f.ParentId+"', [File]='"+f.File+"', AddUserId='"+f.AddUserId+"', UpdateUserId='"+f.UpdateUserId+"'," +
                "AddDate=@AddDate, UpdateDate=@UpdateDate, ObjStatusId='"+f.ObjStatusId+"', Version='"+f.Version+"', PrevVersionId='"+f.PrevVersionId+"', UpdateVersion='"+f.UpdateVersion+"', DynamicJsonVal='"+f.DynamicJsonVal+"', OrganizationId='"+f.OrganizationId+"'," +
                " DataBaseName='"+f.DataBaseName+"', KullanıcıId='"+f.KullanıcıId+"' where TalepNo='" + f.TalepNo + "' ";
            SqlCommand kmt = new SqlCommand();
            kmt.Parameters.Add("@AddDate", SqlDbType.Date).Value = f.AddDate;
            kmt.Parameters.Add("@UpdateDate", SqlDbType.Date).Value = f.UpdateDate;
            Veri.EkleSilGüncelle(kmt, ara);
            sil();
            MessageBox.Show("Bilgi Güncelleme Onaylandı.");
            ListGünc();
        }

        private void bilgisil_Click(object sender, EventArgs e)
        {
            FirmaTalepler f = new FirmaTalepler();
            f.TalepNo = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
            string ara2 = "delete from GelenTalepler where TalepNo='" + f.TalepNo + "'";
            SqlCommand kmt2 = new SqlCommand();
            Veri.EkleSilGüncelle(kmt2, ara2);
            MessageBox.Show("Silme İşlemi Onaylandı.");
            sil(); ListGünc();
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            txttalepno.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtid.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtreportto.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtexplanition.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            txtstatus.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            txtparentid.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            txtfile.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            txtadduserid.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            txtupdateuserid.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            dateTimePicker1.Value = DateTime.Parse(dataGridView1.CurrentRow.Cells[9].Value.ToString());
            dateTimePicker2.Value = DateTime.Parse(dataGridView1.CurrentRow.Cells[10].Value.ToString());
            txtobjstatusid.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();
            txtversion.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
            txtprevversionid.Text = dataGridView1.CurrentRow.Cells[13].Value.ToString();
            txtupdateversion.Text = dataGridView1.CurrentRow.Cells[14].Value.ToString();
            txtdynamicjsonval.Text = dataGridView1.CurrentRow.Cells[15].Value.ToString();
            txtorganizationid.Text = dataGridView1.CurrentRow.Cells[16].Value.ToString();
            txtdatabasename.Text = dataGridView1.CurrentRow.Cells[17].Value.ToString();
            comboBox1.Text = dataGridView1.CurrentRow.Cells[18].Value.ToString();
        }
    }
}
