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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;


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

            // Şifre kontrolü
            if (password.Length != 11)
            {
                MessageBox.Show("Şifre 11 haneli olmalıdır!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Veritabanı bağlantısı ve doğrulama
            try
            {
                ConnectionString connStr = new ConnectionString();
                SqlConnection conn = connStr.GetCon();
                conn.Open();

                // Kullanıcı adı ve şifreyi sorgulama
                string query = "SELECT COUNT(*) FROM giris WHERE kullnici_adi = @username AND sifre = @password";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@password", password);

                int result = (int)cmd.ExecuteScalar(); // Sadece 1 ya da 0 döndürür.

                if (result > 0)
                {
                    // Giriş başarılı
                    MessageBox.Show("Hoşgeldiniz!", "Başarılı Giriş", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    anasayfa anaSayfaFormu = new anasayfa();
                    anaSayfaFormu.Show();
                    this.Hide();
                }
                else
                {
                    // Hatalı kullanıcı adı veya şifre
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
            catch (Exception ex)
            {
                MessageBox.Show("Veritabanı bağlantısı sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }
    }
}
