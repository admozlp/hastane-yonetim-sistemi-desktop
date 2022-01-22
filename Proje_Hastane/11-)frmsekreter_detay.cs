using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Proje_Hastane
{
    public partial class frmsekreter_detay : Form
    {
        public frmsekreter_detay()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        public string sektc;
        private void frmsekreter_detay_Load(object sender, EventArgs e)
        {
            // tc çekme

            lbltc.Text = sektc;

            // sekreter ad soyad çekme

            SqlCommand komut = new SqlCommand("select sekreteradsoyad from tbl_sekreterler  where sekretertc=" + sektc, bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            if(dr.Read())
            {
                lbadsoyad.Text = dr[0].ToString();
            }
            bgl.baglanti().Close();


            //branşları ddatagride çekme

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select * from tbl_branşlar", bgl.baglanti());
            da.Fill(dt);
            datagridbranslar.DataSource = dt;

            //data gride doktorları çekme

            DataTable dt1 = new DataTable();
            SqlDataAdapter da1 = new SqlDataAdapter("select (doktorad + ' ' +doktorsoyad) as 'Doktorlar' ,doktorbranş from tbl_doktorlar", bgl.baglanti());
            da1.Fill(dt1);
            datagriddoktorlar.DataSource = dt1;

            //branşı combobaxa aktarma

            SqlCommand komutcek = new SqlCommand("select branşad from tbl_branşlar", bgl.baglanti());
            SqlDataReader drcek = komutcek.ExecuteReader();
            while(drcek.Read())
            {
                cmbbrans.Items.Add(drcek[0]);
            }
            bgl.baglanti().Close();
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            
            SqlCommand komutkaydet = new SqlCommand("insert into tblrandevular (randevutarih,randevusaat,randevubranş,randevudoktor) values (@p1,@p2,@p3,@p4)",bgl.baglanti());
            komutkaydet.Parameters.AddWithValue("@p1", msktarih.Text);
            komutkaydet.Parameters.AddWithValue("@p2", msksaat.Text);
            komutkaydet.Parameters.AddWithValue("@p3", cmbbrans.Text);
            komutkaydet.Parameters.AddWithValue("@p4", cmbdoktor.Text);
            komutkaydet.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Kaydı Yapıldı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void cmbbrans_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbdoktor.Items.Clear();
            SqlCommand komutdok = new SqlCommand("select doktorad,doktorsoyad from tbl_doktorlar where doktorbranş=@p1", bgl.baglanti());
            komutdok.Parameters.AddWithValue("@p1", cmbbrans.Text);
            SqlDataReader drdok = komutdok.ExecuteReader();
            while(drdok.Read())
            {
                cmbdoktor.Items.Add(drdok[0] +" " +drdok[1]);
            }
            bgl.baglanti().Close();
        }

        private void btnolustur_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("insert into tbl_duyurular (duyuru) values (@p1)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", rcbduyuru.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Duyuru Oluşturuldu");
        }

        private void btndoktorpaneli_Click(object sender, EventArgs e)
        {
            _12__frmdoktorpaneli fr = new _12__frmdoktorpaneli();
            fr.Show();
        }

        private void btnbranspaneli_Click(object sender, EventArgs e)
        {
            _13__frmbranspaneli fr = new _13__frmbranspaneli();
            fr.Show();
        }

        private void btnrandevuliste_Click(object sender, EventArgs e)
        {
            _14__frmrandevulistesi fr = new _14__frmrandevulistesi();
            fr.Show();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update tblrandevular set randevutarih=@p1, randevusaat=@p2,randevubranş=@p3,randevudoktor=@p4 where randevuid=@p5",bgl.baglanti());
            komut.Parameters.AddWithValue("@p5", txtid.Text);
            komut.Parameters.AddWithValue("@p1", msktarih.Text);
            komut.Parameters.AddWithValue("@p2", msksaat.Text);
            komut.Parameters.AddWithValue("@p3", cmbbrans.Text);
            komut.Parameters.AddWithValue("@p4", cmbdoktor.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Güncellendi");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("delete from tblrandevular where randevuid=@p1", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtid.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Randevu Silindi");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmduyurular fr = new frmduyurular();
            fr.Show();
        }
    }
}
