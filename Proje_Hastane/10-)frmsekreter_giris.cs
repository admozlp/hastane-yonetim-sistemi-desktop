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
    public partial class frmsekreter_giris : Form
    {
        public frmsekreter_giris()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
       
        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("select * from tbl_sekreterler where sekretertc=@p1 and sekreterşifre=@p2", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", msktc.Text);
            komut.Parameters.AddWithValue("@p2", textsifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read())
            {
                frmsekreter_detay fr = new frmsekreter_detay();
                fr.sektc = msktc.Text;
                fr.Show();
                this.Hide();
            }
            else
                MessageBox.Show("Tc veya Şifre hatalı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            bgl.baglanti().Close();
        }

        private void textsifre_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
