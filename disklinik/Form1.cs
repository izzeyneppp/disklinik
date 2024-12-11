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
    public partial class Form1 : Form
    {
        private const string CorrectUsername = "admin";
        private const string CorrectPassword = "12345678901";
        private int attemptCount = 0; 
        private const int MaxAttempts = 3; 

        public Form1()
        {
            InitializeComponent();
        }
       
        
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {


            
                string username = kullanici_id.Text;
                string password = sifre_giris.Text; 

              
                if (password.Length != 11)
                {
                    MessageBox.Show("Şifre 11 haneli olmalıdır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

               
                if (username == CorrectUsername && password == CorrectPassword)
                {
                    MessageBox.Show("Hoşgeldiniz!", "Başarılı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Information);
                anasayfa anaSayfaFormu = new anasayfa();


                anaSayfaFormu.Show();
                this.Hide(); 
                }
                else
                {
                    attemptCount++; // Deneme sayısını artır
                    if (attemptCount >= MaxAttempts)
                    {
                        MessageBox.Show("Maksimum giriş hakkını doldurdunuz! Uygulama kapatılıyor.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Application.Exit(); // Uygulamayı kapat
                    }
                    else
                    {
                        MessageBox.Show($"Kullanıcı adı veya şifre hatalı! Kalan hakkınız: {MaxAttempts - attemptCount}", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
               

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();

        }

        public void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
