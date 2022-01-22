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
    public partial class _8__doktor_bilgiduzenle : Form
    {
        public _8__doktor_bilgiduzenle()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        public string tc;
        private void _8__doktor_bilgiduzenle_Load(object sender, EventArgs e)
        {
            //Doktor Bilgilerini Çekme
            msktc.Text = tc;
            SqlCommand komut = new SqlCommand("select doktorad,doktorsoyad,doktorbranş,doktorşifre from tbl_doktorlar where doktortc=" + tc, bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                txtad.Text = dr[0].ToString();
                txtsoyad.Text = dr[1].ToString();
                cmbbrans.Text = dr[2].ToString();
                txtsifre.Text = dr[3].ToString();
            }
            bgl.baglanti().Close();

            //Branşları comboboxa Çekme
            SqlCommand komut1 = new SqlCommand("select branşad from tbl_branşlar", bgl.baglanti());
            SqlDataReader dr1 = komut1.ExecuteReader();
            while (dr1.Read())
            {
                cmbbrans.Items.Add(dr1[0].ToString());
            }
            bgl.baglanti().Close();
        }

        private void btnguncelle_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("update tbl_doktorlar set doktorad=@p1,doktorsoyad=@p2,doktorbranş=@p3,doktorşifre=@p4 where doktortc="+tc,bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtad.Text);
            komut.Parameters.AddWithValue("@p2", txtsoyad.Text);
            komut.Parameters.AddWithValue("@p3", cmbbrans.Text);
            komut.Parameters.AddWithValue("@p4", txtsifre.Text);
            komut.ExecuteNonQuery();
            bgl.baglanti().Close();
            MessageBox.Show("Bilgiler Güncellendi");
        }
    }
}
