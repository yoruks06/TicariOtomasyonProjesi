using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Yorukoglu_Komur_Programı
{
    public partial class FrmSeferler : Form
    {
        public FrmSeferler()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();


        void temizle()
        {
            TxtSeferNo.Text = "";
            MskTarih.Text = "";
            TxtPlaka.Text = "";
            TxtYuk.Text = "";
            TxtFiyat.Text = "";
            CmGidisDonus.Text = "";
        }

        void listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBL_SEFERLER", bgl.baglanti());
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void FrmAnasayfa2_Load(object sender, EventArgs e)
        {
            listele();
            temizle();
        }

        private void BtnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into TBL_SEFERLER(TARIH,PLAKA,YUK,FIYAT,GIDISDONUS) values (@P2,@P3,@P4,@P5,@P6)", bgl.baglanti());
            komut.Parameters.AddWithValue("@P2", MskTarih.Text);
            komut.Parameters.AddWithValue("@P3", TxtPlaka.Text);
            komut.Parameters.AddWithValue("@P4", TxtYuk.Text);
            komut.Parameters.AddWithValue("@P5", decimal.Parse(TxtFiyat.Text));
            komut.Parameters.AddWithValue("@P6", CmGidisDonus.Text);
      
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Sefer Bilgileri Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            listele();
        }

        private void BtnSil_Click(object sender, EventArgs e)
        {
            SqlCommand komutsil = new SqlCommand("delete from TBL_SEFERLER where SEFERNO=@p1", bgl.baglanti());
            komutsil.Parameters.AddWithValue("@p1", TxtSeferNo.Text);
            komutsil.ExecuteNonQuery();
            bgl.baglanti().Close();
            listele();
            MessageBox.Show("Sefer Listeden Silindi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.None);
            temizle();
        }

        private void BtnGuncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update Tbl_SEFERLER set TARIH=@p2,PLAKA=@p3,YUK=@p4,FIYAT=@p5,GIDISDONUS=@p6 WHERE SEFERNO=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p2", MskTarih.Text);
            komut.Parameters.AddWithValue("@p3", TxtPlaka.Text);
            komut.Parameters.AddWithValue("@p4", TxtYuk.Text);
            komut.Parameters.AddWithValue("@p5", decimal.Parse(TxtFiyat.Text));
            komut.Parameters.AddWithValue("@p6", CmGidisDonus.Text);
            komut.Parameters.Add("@p1",TxtSeferNo.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Sefer  Bilgileri Güncellendi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            listele();

        }

        private void BtnTemizle_Click(object sender, EventArgs e)
        {
            temizle();
        }

   
        private void gridView1_FocusedRowChanged_1(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                TxtSeferNo.Text = dr["SEFERNO"].ToString();
                MskTarih .Text = dr["TARIH"].ToString();
                TxtPlaka.Text = dr["PLAKA"].ToString();
                TxtYuk.Text = dr["YUK"].ToString();
                TxtFiyat.Text = dr["FIYAT"].ToString();
                CmGidisDonus.Text = dr["GIDISDONUS"].ToString();
              
            }
        }
    }
}
