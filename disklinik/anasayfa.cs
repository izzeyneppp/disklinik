using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace disklinik
{
    public partial class anasayfa : Form
    {
        public anasayfa()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
         
            tedavi frmTedavi = new tedavi();
            frmTedavi.Show();
            this.Hide();
        }

        private void button5_Click(object sender, EventArgs e)
        {
          
            recete frmRecete = new recete();
            frmRecete.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
            randevu frmRandevu = new randevu();
            frmRandevu.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            hastakayit hastaKayit = new hastakayit();
            hastaKayit.Show();


            this.Hide();
        }

        private void anasayfa_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            doktorkayit frmdoktorkayit = new doktorkayit();
            frmdoktorkayit.Show();
            this.Hide();
        }
    }
}
