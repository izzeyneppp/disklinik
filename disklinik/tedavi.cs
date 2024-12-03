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
            hastalar hst = new hastalar();

            try
            {
                hst.hasta_ekle(query);
                MessageBox.Show("TEDAVİ KAYDI BAŞARIYLA EKLENDİ");
                

            }
            catch (Exception)
            {
                hst.hasta_ekle(query);
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
           


        }
        int key = 0;

        private void button5_Click(object sender, EventArgs e)
        {
            hastalar hst = new hastalar();
            if (key == 0)
            {
                MessageBox.Show("Düzenlenecek Tedaviyi Seçiniz");
            }
            else
            {
                try
                {

                    string query = "update hastakayit set tedavi_ad='" + tedaviadited.Text + "', tedavi_fiyat='" + fiyatted.Text + "',tedavi_aciklama='" + açiklamated.Text + "' where tedavi_id"+ key +"";
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
            hastalar hst = new hastalar();
            if (key == 0)
            {
                MessageBox.Show("Silinecek Tedaviyi Seçiniz");
            }
            else
            {
                try
                {

                    string query = "delete from Tedavi where tedavi_id=" + key + "";
                    hst.hastasil(query);
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
    }
}
