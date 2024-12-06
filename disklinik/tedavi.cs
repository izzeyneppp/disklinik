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
    public partial class tedavi : Form
    {
        public tedavi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            anasayfa frmAnaSayfa = new anasayfa();
            frmAnaSayfa.Show();
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Tedavi (tedavi_ad, tedavi_fiyat, tedavi_aciklama) " +
                      "VALUES ('" + tedaviadited.Text + "', '" + fiyatted.Text + "', '" + açiklamated.Text + "')";
            tedaviler ted = new tedaviler();

            try
            {
                ted.tedavi_ekle(query);
                MessageBox.Show("TEDAVİ KAYDI BAŞARIYLA EKLENDİ");
                

            }
            catch (Exception)
            {
                ted.tedavi_ekle(query);
                MessageBox.Show("Tedavi kaydı başarıyla eklendi.");
                yenile();

            }
        }
        void uyeler()
        {
            tedaviler ted = new tedaviler();
            string query = "select * from Tedavi";
            DataSet ds = ted.Showtedavi(query);
            tedavidata.DataSource = ds.Tables[0];
        }
        public void yenile()
        {

            tedaviadited.Text = "";
            fiyatted.Text = "";
            açiklamated.Text = "";
            tedaviarama.Text = "";


        }
        int key = 0;

        private void button5_Click(object sender, EventArgs e)
        {
            tedaviler ted = new tedaviler();
            if (key == 0)
            {
                MessageBox.Show("Düzenlenecek Tedaviyi Seçiniz");
            }
            else
            {
                try
                {

                    string query = "update Tedavi set tedavi_ad='" + tedaviadited.Text + "', tedavi_fiyat='" + fiyatted.Text + "',tedavi_aciklama='" + açiklamated.Text + "' where tedavi_id"+ key +"";
                    MessageBox.Show("Tedavi Başarıyla güncellendi");
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
            tedaviler ted = new tedaviler();
            if (key == 0)
            {
                MessageBox.Show("Silinecek Tedaviyi Seçiniz");
            }
            else
            {
                try
                {

                    string query = "delete from Tedavi where tedavi_id=" + key + "";
                    ted.tedavisil(query);
                    MessageBox.Show("Tedavi Başarıyla Silindi");
                    uyeler();
                    yenile();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            yenile();
            uyeler();
        }
        void filter()
        {
            tedaviler ted  = new tedaviler();
            string query = "select * from Tedavi where tedavi_ad like'%" + tedaviarama.Text + "%'";
            DataSet ds = ted.Showtedavi(query);
            tedavidata.DataSource = ds.Tables[0];
        }
        private void tedavi_Load(object sender, EventArgs e)
        {
            uyeler();
            yenile();

        }

        private void tedavidata_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tedaviadited.Text = tedavidata.Rows[e.RowIndex].Cells[1].Value.ToString();
            fiyatted.Text = tedavidata.Rows[e.RowIndex].Cells[2].Value.ToString();
            açiklamated.Text = tedavidata.Rows[e.RowIndex].Cells[3].Value.ToString();
          
            if (tedaviadited.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(tedavidata.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }

        private void tedavidata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            tedaviadited.Text = tedavidata.Rows[e.RowIndex].Cells[1].Value.ToString();
            fiyatted.Text = tedavidata.Rows[e.RowIndex].Cells[2].Value.ToString();
            açiklamated.Text = tedavidata.Rows[e.RowIndex].Cells[3].Value.ToString();

            if (tedaviadited.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(tedavidata.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }

        private void tedaviarama_TextChanged(object sender, EventArgs e)
        {
            filter();
        }
    }
}
