using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Proje_Hastane
{
    public partial class frmgiriş : Form
    {
        public frmgiriş()
        {
            InitializeComponent();
        }

        private void btnhasta_Click(object sender, EventArgs e)
        {
            frmhastagiris fr = new frmhastagiris();
            fr.Show();
            this.Hide();
        }

        private void btndoktor_Click(object sender, EventArgs e)
        {
            frm_doktorgiris fr = new frm_doktorgiris();
            fr.Show();
            this.Hide();
        }

        private void btnsekreter_Click(object sender, EventArgs e)
        {
            frmsekreter_giris fr = new frmsekreter_giris();
            fr.Show();
            this.Hide();
        }

        private void frmgiriş_Load(object sender, EventArgs e)
        {

        }
    }
}
