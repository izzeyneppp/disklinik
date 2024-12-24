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

            tedavi form2 = new tedavi();
            form2.TopLevel = false;
            form2.FormBorderStyle = FormBorderStyle.None;
            form2.Dock = DockStyle.Fill;
            panel3.Controls.Clear();
            panel3.Controls.Add(form2);
            form2.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {

            recete form2 = new recete();
            form2.TopLevel = false;
            form2.FormBorderStyle = FormBorderStyle.None;
            form2.Dock = DockStyle.Fill;
            panel3.Controls.Clear();
            panel3.Controls.Add(form2);
            form2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            randevu form2 = new randevu();
            form2.TopLevel = false;
            form2.FormBorderStyle = FormBorderStyle.None;
            form2.Dock = DockStyle.Fill;
            panel3.Controls.Clear();
            panel3.Controls.Add(form2);
            form2.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            hastakayit form2 = new hastakayit();
            form2.TopLevel = false; 
            form2.FormBorderStyle = FormBorderStyle.None; 
            form2.Dock = DockStyle.Fill; 
            panel3.Controls.Clear(); 
            panel3.Controls.Add(form2); 
            form2.Show(); 
        }

        private void anasayfa_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            doktorkayit form2 = new doktorkayit();
            form2.TopLevel = false;
            form2.FormBorderStyle = FormBorderStyle.None;
            form2.Dock = DockStyle.Fill;
            panel3.Controls.Clear();
            panel3.Controls.Add(form2);
            form2.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Şifreyi sor
            string enteredPassword = Microsoft.VisualBasic.Interaction.InputBox("Lütfen şifreyi girin:", "Şifre Girişi", "");

            // Şifreyi kontrol et
            if (enteredPassword == "12375861")
            {
                // Doğru şifre girildiyse AdminLogin formunu panel3'e ekle
                AdminLogin form2 = new AdminLogin();
                form2.TopLevel = false;
                form2.FormBorderStyle = FormBorderStyle.None;
                form2.Dock = DockStyle.Fill;
                panel3.Controls.Clear();
                panel3.Controls.Add(form2);
                form2.Show();
            }
            else
            {
                // Yanlış şifre girildiyse hata mesajı göster
                MessageBox.Show("Yanlış şifre girdiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
  
            panel3.Controls.Clear();
  
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

            resimForm form2 = new resimForm();
            form2.TopLevel = false;
            form2.FormBorderStyle = FormBorderStyle.None;
            form2.Dock = DockStyle.Fill;
            panel3.Controls.Add(form2);
            form2.Show();

        }
    }
}
