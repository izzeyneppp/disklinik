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

namespace disklinik
{
    public partial class randevu : Form
    {
        ConnectionString mycon= new ConnectionString();
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
            string query = "INSERT INTO randevu (ad_soyad, randevu_tedavi,randevu_tarih,randevu_saat) " +
                      "VALUES ('" + adrandevu.SelectedItem.ToString() + "', '" + tedavirandevu.SelectedItem.ToString() + "', '" + tarihrandevu.Text + "', '" +
                      saatrandevu.SelectedItem.ToString() + "' )";
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

                    string query = "update randevu set ad_soyad='" + adrandevu.SelectedItem + "', randevu_tedavi='" + tedavirandevu.SelectedItem + "',randevu_tarih='" + tarihrandevu.Text + "',randevu_saat='" + saatrandevu.SelectedItem + "'  where randevu_id=" + key + "";
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
    }
}
