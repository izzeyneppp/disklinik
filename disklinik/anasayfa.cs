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

        private void panel2_Paint(object sender, PaintEventArgs e)
        {
            altpanel.Width = button3.Width; 
            altpanel.Top = button3.Top;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            altpanel.Width = button4.Width;
            altpanel.Top = button4.Top;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            altpanel.Width = button5.Width;
            altpanel.Top = button5.Top;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            altpanel.Width = button1.Width;
            altpanel.Top = button1.Top;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();

        }
    }
}
