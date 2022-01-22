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
    public partial class _7__frm_doktordetay : Form
    {
        public _7__frm_doktordetay()
        {
            InitializeComponent();
        }
        sqlbaglantisi bgl = new sqlbaglantisi();
        public string tcno;
        private void _7__frm_doktordetay_Load(object sender, EventArgs e)
        {
            //Ad Soyad Ve Tc Çekme
            lbltc.Text = tcno;
            SqlCommand komut = new SqlCommand("select doktorad,doktorsoyad from tbl_doktorlar where doktortc=" + tcno,bgl.baglanti());
            SqlDataReader dr = komut.ExecuteReader();
            while(dr.Read())
            {
                lbladsoyad.Text = dr[0] + " " + dr[1];
            }
            bgl.baglanti().Close();
            string adsoyad = lbladsoyad.Text;
            //Data Gride Randevuları çekme

            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("select  * from tblrandevular where randevudoktor='" + adsoyad +"'", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }

        private void brtnduyurular_Click(object sender, EventArgs e)
        {
            frmduyurular fr = new frmduyurular();
            fr.Show();
        }

        private void btnbilgiduzenle_Click(object sender, EventArgs e)
        {
            _8__doktor_bilgiduzenle frm = new _8__doktor_bilgiduzenle();
            frm.tc = lbltc.Text;
            frm.Show();
        }
        private void btncikis_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int secilen = dataGridView1.SelectedCells[0].RowIndex;
            rchsikayet.Text = dataGridView1.Rows[secilen].Cells[7].Value.ToString();
        }
    }
}
