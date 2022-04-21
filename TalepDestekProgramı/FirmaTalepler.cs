using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows.Forms;

namespace TalepDestekProgramı
{
    class FirmaTalepler
    {
        private int talepNo;
        private int id;
        private int reportTo;
        private string explanition;
        private int status;
        private int parentId;
        private string file;
        private int addUserId;
        private int updateUserId;
        private DateTime addDate;
        private DateTime updateDate;
        private int objStatusId;
        private int version;
        private int prevVersionId;
        private int updateVersion;
        private string dynamicJsonVal;
        private int organizationId;
        private string dataBaseName;
        private int kullanıcıId;

        public int TalepNo { get => talepNo; set => talepNo = value; }
        public int Id { get => id; set => id = value; }
        public int ReportTo { get => reportTo; set => reportTo = value; }
        public string Explanition { get => explanition; set => explanition = value; }
        public int Status { get => status; set => status = value; }
        public int ParentId { get => parentId; set => parentId = value; }
        public string File { get => file; set => file = value; }
        public int UpdateUserId { get => updateUserId; set => updateUserId = value; }
        public DateTime UpdateDate { get => updateDate; set => updateDate = value; }
        public int ObjStatusId { get => objStatusId; set => objStatusId = value; }
        public int Version { get => version; set => version = value; }
        public int PrevVersionId { get => prevVersionId; set => prevVersionId = value; }
        public int UpdateVersion { get => updateVersion; set => updateVersion = value; }
        public string DynamicJsonVal { get => dynamicJsonVal; set => dynamicJsonVal = value; }
        public int OrganizationId { get => organizationId; set => organizationId = value; }
        public string DataBaseName { get => dataBaseName; set => dataBaseName = value; }
        public int KullanıcıId { get => kullanıcıId; set => kullanıcıId = value; }
        public DateTime AddDate { get => addDate; set => addDate = value; }
        public int AddUserId { get => addUserId; set => addUserId = value; }

        public static string data = "select *from UygulamaGörevlileri";
        public static string value = "KullanıcıId";
        public static string text = "KullanıcıAd" + "KullanıcıSoyad";

        public static DataTable KullaniciBilgiGetir(ComboBox cmb)
        {
            DataTable tb = new DataTable();
            Veri.baglanti.Open();
            SqlDataAdapter adp = new SqlDataAdapter(data, Veri.baglanti);
            adp.Fill(tb);
            cmb.DataSource = tb;
            cmb.ValueMember = value;
            cmb.DisplayMember = text;
            Veri.baglanti.Close();
            return tb;
        }      
    }
}
