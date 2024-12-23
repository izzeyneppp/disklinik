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
using System.Net;
using System.Net.Mail;

namespace disklinik
{
    public partial class randevu : Form
    {
        ConnectionString mycon= new ConnectionString();
        private void filldoktor()
        {
            SqlConnection baglanti = mycon.GetCon();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select doktorad from doktorkayit", baglanti);
            SqlDataReader rdr;
            rdr = komut.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("doktorad", typeof(string));
            dt.Load(rdr);
            randevudr.ValueMember = "doktorad";
            randevudr.DataSource = dt;
            baglanti.Close();
        }
        private void fillhasta()
        {
            SqlConnection baglanti = mycon.GetCon();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select hasta_adi from hastakayit", baglanti);
            SqlDataReader rdr;
            rdr = komut.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("hasta_adi", typeof(string));
            dt.Load(rdr);
            adrandevu.ValueMember = "hasta_adi";
            adrandevu.DataSource = dt;
            baglanti.Close();

        }
        private void filltedavi()
        {
            SqlConnection baglanti = mycon.GetCon();
            baglanti.Open();
            SqlCommand komut = new SqlCommand("select tedavi_ad from Tedavi", baglanti);
            SqlDataReader rdr;
            rdr = komut.ExecuteReader();
            DataTable dt = new DataTable();
            dt.Columns.Add("tedavi_ad", typeof(string));
            dt.Load(rdr);
            tedavirandevu.ValueMember = "tedavi_ad";
            tedavirandevu.DataSource = dt;
            baglanti.Close();


        }
        public randevu()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();

        }
        void filter()
        {
            randevular ran = new randevular();
            string query = "select * from randevu where ad_soyad like'%" + randevuarama.Text + "%'";
            DataSet ds = ran.Showrandevu(query);
            randevudata.DataSource = ds.Tables[0];
        }
        private void randevu_Load(object sender, EventArgs e)
        {
            uyeler();
            yenile();
            fillhasta();
            filltedavi();
            filldoktor();
            
        }

        private void homeRandevu_Click(object sender, EventArgs e)
        {
            anasayfa frmAnaSayfa = new anasayfa();
            frmAnaSayfa.Show();
            this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            anasayfa frmAnaSayfa = new anasayfa();
            frmAnaSayfa.Show();
            this.Hide();
        }
        public void yenile()
        {

            adrandevu.SelectedItem = "";
            tedavirandevu.SelectedItem = "";
            tarihrandevu.Text = "";
            saatrandevu.SelectedItem = "";
            randevuarama.Text = "";
            randevudr.SelectedItem = "";


        }
        void uyeler()
        {
            randevular ran = new randevular();
            string query = "select * from randevu ";
            DataSet ds = ran.Showrandevu(query);
            randevudata.DataSource = ds.Tables[0];
        }
        private void button4_Click(object sender, EventArgs e)
        {

            // Adres Bilgisi Kontrolü
            if (string.IsNullOrWhiteSpace(adrandevu.Text))
            {
                MessageBox.Show("Adres bilgisi boş bırakılamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                adrandevu.Focus();
                return;
            }

            // Tedavi Bilgisi Kontrolü
            if (string.IsNullOrWhiteSpace(tedavirandevu.Text))
            {
                MessageBox.Show("Tedavi bilgisi boş bırakılamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tedavirandevu.Focus();
                return;
            }

            // Randevu Tarihi Seçimi Kontrolü
            if (tarihrandevu.Value == DateTimePicker.MinimumDateTime)
            {
                MessageBox.Show("Randevu Tarihi seçilmelidir!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                tarihrandevu.Focus();
                return;
            }

            // Randevu Saati Kontrolü
            if (string.IsNullOrWhiteSpace(saatrandevu.Text))
            {
                MessageBox.Show("Randevu saati boş bırakılamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                saatrandevu.Focus();
                return;
            }

            // Randevu Doktoru Seçimi Kontrolü
            if (string.IsNullOrWhiteSpace(randevudr.Text))
            {
                MessageBox.Show("Randevu doktoru seçilmelidir!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                randevudr.Focus();
                return;
            }


             string query = "INSERT INTO randevu (ad_soyad, randevu_tedavi,randevu_tarih,randevu_saat,randevu_doktor) " +
                      "VALUES ('" + adrandevu.SelectedValue.ToString() + "', '" + tedavirandevu.SelectedValue.ToString() + "', '" + tarihrandevu.Text + "', '" +
                      saatrandevu.SelectedItem.ToString() + "','"+randevudr.SelectedValue.ToString( )+"')";
            randevular ran = new randevular();
            
            try
            {
                ran.randevu_ekle(query);
                MessageBox.Show("RANDEVU BAŞARIYLA EKLENDİ");
                yenile();
                uyeler();

            }
            catch (Exception)
            {
                ran.randevu_ekle(query);
                MessageBox.Show("Randevu Başarıyla Eklendi.");
                uyeler();
                yenile();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            yenile();
            uyeler();
        }
        int key = 0;
        private void button5_Click(object sender, EventArgs e)
        {

            randevular ran = new randevular();
            if (key == 0)
            {
                MessageBox.Show("Düzenlenecek Randevuyu Seçiniz");
            }
            else
            {
                try
                {

                    string query = "update randevu set ad_soyad='" + adrandevu.SelectedItem + "', randevu_tedavi='" + tedavirandevu.SelectedItem + "',randevu_tarih='" + tarihrandevu.Text + "',randevu_saat='" + saatrandevu.SelectedItem + "',randevu_doktor='"+randevudr.SelectedItem+"'  where randevu_id=" + key + "";
                    ran.randevuguncelle(query);
                    MessageBox.Show("Randevu Başarıyla güncellendi");
                    uyeler();
                    yenile();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            randevular ran= new randevular();
            if (key == 0)
            {
                MessageBox.Show("Silinecek randevuyu Seçiniz");
            }
            else
            {
                try
                {

                    string query = "delete from randevu where randevu_id=" + key + "";
                    ran.randevusil(query);
                    MessageBox.Show("Randevu Başarıyla Silindi");
                    uyeler();
                    yenile();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void randevudata_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            adrandevu.SelectedItem = randevudata.Rows[e.RowIndex].Cells[1].Value.ToString();
            tedavirandevu.SelectedItem = randevudata.Rows[e.RowIndex].Cells[2].Value.ToString();
            tarihrandevu.Text = randevudata.Rows[e.RowIndex].Cells[3].Value.ToString();
            saatrandevu.SelectedItem = randevudata.Rows[e.RowIndex].Cells[4].Value.ToString();
            randevudr.SelectedItem = randevudata.Rows[e.RowIndex].Cells[5].Value.ToString();
            if (adrandevu.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(randevudata.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }

        private void randevudata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            adrandevu.SelectedItem = randevudata.Rows[e.RowIndex].Cells[1].Value.ToString();
            tedavirandevu.SelectedItem = randevudata.Rows[e.RowIndex].Cells[2].Value.ToString();
            tarihrandevu.Text = randevudata.Rows[e.RowIndex].Cells[3].Value.ToString();
            saatrandevu.SelectedItem = randevudata.Rows[e.RowIndex].Cells[4].Value.ToString();
            randevudr.SelectedItem = randevudata.Rows[e.RowIndex].Cells[5].Value.ToString();
            if (adrandevu.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(randevudata.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }

        private void randevuarama_TextChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            // Ana sayfa formunu yeniden açıyoruz.
            anasayfa anasayfaForm = new anasayfa();
            anasayfaForm.Show();

            // Recete formunu kapatıyoruz.
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Yandex SMTP bilgileri
            string smtpServer = "smtp.yandex.com"; // Yandex SMTP sunucusu
            int port = 587; // TLS portu (SSL yerine TLS kullanıyoruz)
            string fromEmail = "hastanemail@yandex.com"; // Yandex e-posta adresiniz
            string password = "rebeddewsigbhzeq"; // Yandex şifreniz
            string toEmail = textBox1.Text; // Alıcı e-posta adresi
            string subject = "Randevü Hatırlatma"; // E-posta konusu
            string body = tarihrandevu.Text +" "+ saatrandevu.Text + "  Bu bir randevu hatırlatma e-postasıdır.   "+" "+ randevudr.Text +"   Doktorunuzun adıdır."; // E-posta içeriği

            try
            {
                // SmtpClient ile mail gönderimi için ayarları yapıyoruz
                using (SmtpClient smtp = new SmtpClient(smtpServer))
                {
                    smtp.Port = port;
                    smtp.Credentials = new NetworkCredential(fromEmail, password); // Kullanıcı adı ve şifre
                    smtp.EnableSsl = true; // SSL/TLS güvenliği aktif

                    // MailMessage nesnesi oluşturuluyor
                    MailMessage mail = new MailMessage(fromEmail, toEmail, subject, body);

                    // Mail gönderimi
                    smtp.Send(mail);

                    // Mail gönderildikten sonra MessageBox ile başarı mesajı gösteriliyor
                    MessageBox.Show("Mail başarıyla gönderildi!", "Başarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                // Hata durumunda MessageBox ile hata mesajı gösteriliyor
                MessageBox.Show("Mail gönderimi sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
