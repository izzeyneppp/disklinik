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

namespace disklinik
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }
        private void GetData()
        {
            try
            {
                // Veritabanı bağlantısını başlat
                ConnectionString connStr = new ConnectionString();
                SqlConnection conn = connStr.GetCon();
                conn.Open();

                // Verileri çekmek için SQL sorgusu
                string query = "SELECT * FROM giris"; // 'giris' tablosundaki tüm veriler
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();

                // Sorguyu çalıştır ve sonuçları DataTable'a aktar
                da.Fill(dt);

                // DataGridView'e verileri bağla
                AdminDataGrid.DataSource = dt;

                // Bağlantıyı kapat
                conn.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri çekme sırasında bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void AdminLogin_Load(object sender, EventArgs e)
        {
            GetData();
        }
   



        private void button4_Click(object sender, EventArgs e)
        {



            if (string.IsNullOrWhiteSpace(Kadi.Text))
            {
                MessageBox.Show("Kullanıcı adı boş geçilemez!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Kadi.Focus(); // Kullanıcıyı Kadi alanına yönlendir
                return;
            }

            if (string.IsNullOrWhiteSpace(Sifre.Text))
            {
                MessageBox.Show("Şifre boş geçilemez!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Sifre.Focus(); // Kullanıcıyı Sifre alanına yönlendir
                return;
            }

            string connectionString = "Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=disklinik;Integrated Security=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO giris (kullnici_adi, sifre) VALUES (@kadi, @sifre)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@kadi", Kadi.Text);
                    cmd.Parameters.AddWithValue("@sifre", Sifre.Text);

                    try
                    {
                        conn.Open(); // Bağlantıyı açıyoruz
                        cmd.ExecuteNonQuery(); // Veriyi ekliyoruz
                        MessageBox.Show("Kayıt başarılı.");
                        GetData();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message); // Hata mesajı
                    }
                    finally
                    {
                        conn.Close(); // Bağlantıyı kapatıyoruz
                    }
                }
            }


        }

        private void button7_Click(object sender, EventArgs e)
        {
            anasayfa anasayfaForm = new anasayfa();
            anasayfaForm.Show();

            // Recete formunu kapatıyoruz.
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            GetData();

            // adminarama.Text alanı boşsa hata ver
            if (string.IsNullOrWhiteSpace(adminarama.Text))
            {
                MessageBox.Show("Lütfen arama yapacağınız kullanıcı adını girin!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                adminarama.Focus();
                return;
            }

            string connectionString = "Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=disklinik;Integrated Security=True;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Kullanıcı adı ile arama yapmak için sorgu
                string query = "SELECT * FROM giris WHERE kullnici_adi LIKE @searchTerm";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    // Kullanıcı adı arama terimi
                    cmd.Parameters.AddWithValue("@searchTerm", "%" + adminarama.Text + "%");

                    try
                    {
                        conn.Open(); // Bağlantıyı açıyoruz
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        adapter.Fill(dt); // Verileri alıyoruz

                        // DataGridView'e arama sonuçlarını yükleme
                        AdminDataGrid.DataSource = dt;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Hata: " + ex.Message); // Hata mesajı
                    }
                    finally
                    {
                        conn.Close(); // Bağlantıyı kapatıyoruz
                    }
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {

            // DataGridView'den seçilen satırın ID'sini alıyoruz
            if (AdminDataGrid.SelectedRows.Count > 0) // En az bir satır seçildi mi kontrolü
            {
                int selectedId = Convert.ToInt32(AdminDataGrid.SelectedRows[0].Cells["giris_id"].Value); // giris_id'nin sütun adı olduğunu varsayıyoruz

                // Veritabanı bağlantısı
                string connectionString = "Data Source=LENOVO\\SQLEXPRESS;Initial Catalog=disklinik;Integrated Security=True;";

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = "DELETE FROM giris WHERE giris_id = @id"; // ID'ye göre silme sorgusu

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", selectedId); // Parametreyi ekliyoruz

                        try
                        {
                            conn.Open(); // Bağlantıyı açıyoruz
                            int rowsAffected = cmd.ExecuteNonQuery(); // Sorguyu çalıştırıyoruz

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Kayıt başarıyla silindi.");
                                GetData(); // Verileri güncelleme
                            }
                            else
                            {
                                MessageBox.Show("Silinecek kayıt bulunamadı.");
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Hata: " + ex.Message); // Hata mesajı
                        }
                        finally
                        {
                            conn.Close(); // Bağlantıyı kapatıyoruz
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Lütfen silmek istediğiniz kaydı seçin.");
            }

        }
    }
}
