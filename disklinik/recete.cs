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
    public partial class recete : Form
    {
        public recete()
        {
            InitializeComponent();
        }

        private void label5_Click(object sender, EventArgs e)
        {

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

        private void homeRecete_Click(object sender, EventArgs e)
        {
            anasayfa frmAnaSayfa = new anasayfa();
            frmAnaSayfa.Show();
            this.Hide();
        }
        void filter()
        {
            receteler rec = new receteler();
            string query = "select * from recete where hasta_adi_soyadi like'%" + recetearama.Text + "%'";
            DataSet ds = rec.Showrecete(query);
            recetedata.DataSource = ds.Tables[0];
        }
        public void yenile()
        {

           recetead.SelectedItem  = "";
           fiyatrecete.Text = "";
            ilacad.Text = "";
            aciklamarecete.Text = "";
            recetearama.Text = "";



        }
        ConnectionString mycon = new ConnectionString();
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
            recetead.ValueMember = "hasta_adi";
            recetead.DataSource = dt;
            baglanti.Close();
        }
        void uyeler()
        {
            receteler rec = new receteler();
            string query = "select * from recete ";
            DataSet ds = rec.Showrecete(query);
            recetedata.DataSource = ds.Tables[0];
        }
        private void button4_Click(object sender, EventArgs e)
        {


            // Reçete Adı Kontrolü
            if (string.IsNullOrWhiteSpace(recetead.Text))
            {
                MessageBox.Show("Ad boş bırakılamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                recetead.Focus();
                return;
            }

            // İlacın Adı Kontrolü
            if (string.IsNullOrWhiteSpace(ilacad.Text))
            {
                MessageBox.Show("İlacın adı boş bırakılamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ilacad.Focus();
                return;
            }

            // Fiyat Bilgisi Kontrolü
            if (string.IsNullOrWhiteSpace(fiyatrecete.Text))
            {
                MessageBox.Show("Fiyat bilgisi boş bırakılamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                fiyatrecete.Focus();
                return;
            }

            // Açıklama Kontrolü
            if (string.IsNullOrWhiteSpace(aciklamarecete.Text))
            {
                MessageBox.Show("Açıklama boş bırakılamaz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                aciklamarecete.Focus();
                return;
            }

            string query = "INSERT INTO recete (hasta_adi_soyadi, fiyat_recete,ilac_recete,aciklama_recete) " +
                        "VALUES ('" + recetead.SelectedValue.ToString() + "', '" + fiyatrecete.Text + "', '" + ilacad.Text + "', '" +
                        aciklamarecete.Text + "')";
           receteler rec = new receteler();

            try
            {
                rec.recete_ekle(query);
                MessageBox.Show("REÇETE BAŞARIYLA EKLENDİ");
                yenile();
                uyeler();

            }
            catch (Exception)
            {
                rec.recete_ekle(query);
                MessageBox.Show("Reçete Başarıyla Eklendi.");
                uyeler();
                yenile();

            }
        }
        int key = 0;
        private void button5_Click(object sender, EventArgs e)
        {
            receteler rec = new receteler();
            if (key == 0)
            {
                MessageBox.Show("Düzenlenecek Reçeteyi Seçiniz");
            }
            else
            {
                try
                {

                    string query = "update recete set hasta_adi_soyadi='" + recetead.SelectedItem.ToString() + "', ilac_recete='" + ilacad.Text + "',fiyat_recete='" + fiyatrecete.Text + "',aciklama_recete='" + aciklamarecete.Text + "' where recete_id=" + key + "";
                    MessageBox.Show("Reçete Başarıyla güncellendi");
                    uyeler();
                    yenile();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void recetedata_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            recetead.SelectedItem = recetedata.Rows[e.RowIndex].Cells[1].Value.ToString();
            ilacad.Text = recetedata.Rows[e.RowIndex].Cells[2].Value.ToString();
            fiyatrecete.Text = recetedata.Rows[e.RowIndex].Cells[3].Value.ToString();
            aciklamarecete.Text= recetedata.Rows[e.RowIndex].Cells[4].Value.ToString();

            if (recetead.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(recetedata.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            yenile();
            uyeler();
        }

        private void recetedata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            recetead.SelectedItem = recetedata.Rows[e.RowIndex].Cells[1].Value.ToString();
            ilacad.Text = recetedata.Rows[e.RowIndex].Cells[2].Value.ToString();
            fiyatrecete.Text = recetedata.Rows[e.RowIndex].Cells[3].Value.ToString();
            aciklamarecete.Text = recetedata.Rows[e.RowIndex].Cells[4].Value.ToString();

            if (recetead.Text == "")
            {
                key = 0;
            }
            else
            {
                key = Convert.ToInt32(recetedata.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
        }

        private void recete_Load(object sender, EventArgs e)
        {
            uyeler();
            yenile();
            fillhasta();
        }

        private void recetead_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void recetearama_TextChanged(object sender, EventArgs e)
        {
            filter();
        }
        Bitmap bitmap;
        private void button6_Click(object sender, EventArgs e)
        {
            int height = recetedata.Height;
            recetedata.Height = recetedata.RowCount * recetedata.RowTemplate.Height * 2;
            bitmap = new Bitmap(recetedata.Width,recetedata.Height);
            recetedata.DrawToBitmap(bitmap, new Rectangle(0,20,recetedata.Width, recetedata.Height));
            recetedata.Height=height;
            printPreviewDialog1.ShowDialog();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(bitmap, 0, 0); 
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

        }
    }
}
