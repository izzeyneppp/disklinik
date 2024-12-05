using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace disklinik
{
    public partial class hastakayit : Form
    {
        

        public hastakayit()
        {
            InitializeComponent();
        }
        int key = 0;
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {         
                hastaadsoyad.Text = hastadata.Rows[e.RowIndex].Cells[1].Value.ToString();
                telefonHst.Text= hastadata.Rows[e.RowIndex].Cells[2].Value.ToString();
                adreshk.Text= hastadata.Rows[e.RowIndex].Cells[3].Value.ToString(); 
                doğumtarihihk.Text= hastadata.Rows[e.RowIndex].Cells[4].Value.ToString();
                cinsiyethk.SelectedItem= hastadata.Rows[e.RowIndex].Cells[5].Value.ToString();
                alerjihk.Text= hastadata.Rows[e.RowIndex].Cells[6].Value.ToString();
            if (hastaadsoyad.Text == "")
            {
                key = 0;
                
            }
            else
            {
                key = Convert.ToInt32(hastadata.Rows[e.RowIndex].Cells[0].Value.ToString());
                
                uyeler();
            }   
        }


        private void button4_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO hastakayit (hasta_adi, hasta_telefon,hasta_adres,hasta_dg,hasta_cinsiyet,hasta_alerji) " +
                        "VALUES ('" + hastaadsoyad.Text + "', '" + telefonHst.Text + "', '" + adreshk.Text + "', '" +
                        doğumtarihihk.Text + "', '" + cinsiyethk.SelectedItem.ToString() + "', '" + alerjihk.Text + "')";
            hastalar hst = new hastalar();

            try
            {
                hst.hasta_ekle(query);
                MessageBox.Show("HASTA BAŞARIYLA EKLENDİ");
                yenile();
                uyeler();

            }
            catch (Exception)
            {
                hst.hasta_ekle(query);
                MessageBox.Show("Hasta Başarıyla Eklendi.");
                uyeler();
                yenile();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        void uyeler()
        {
            hastalar hst = new hastalar();
            string query = "select * from hastakayit";
            DataSet ds = hst.Showhasta(query);
            hastadata.DataSource = ds.Tables[0];
        }
        public void yenile()
        {
            
            hastaadsoyad.Text = "";
            telefonHst.Text = "";
            cinsiyethk.SelectedItem= "";
            alerjihk.Text = "";
            adreshk.Text = "";


        }

        private void hastakayit_Load(object sender, EventArgs e)
        {
            yenile();


        }


        private void button3_Click_1(object sender, EventArgs e)
        {
            yenile();
            uyeler();
        }

        private void hastakayit_Load_1(object sender, EventArgs e)
        {

        }

        private void homeHasta_Click(object sender, EventArgs e)
        {
            anasayfa frmAnaSayfa = new anasayfa();
            frmAnaSayfa.Show();
            this.Hide();
        }

        private void maskedTextBox1_MaskInputRejected(object sender, MaskInputRejectedEventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            anasayfa frmAnaSayfa = new anasayfa();
            frmAnaSayfa.Show();
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            hastalar hst = new hastalar();
            if (key == 0)
            {
                MessageBox.Show("Silinecek Hastayı Seçiniz");
            }
            else
            {
                try
                {
                    
                    string query = "delete from hastakayit where hasta_id=" + key + "";
                    hst.hastasil(query);
                    MessageBox.Show("Hasta Başarıyla Silindi");
                    uyeler();
                    yenile();
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            hastalar hst = new hastalar();
            if (key == 0)
            {
                MessageBox.Show("Düzenlenecek Hastayı Seçiniz");
            }
            else
            {
                try
                {

                    string query = "update hastakayit set hasta_adi='" + hastaadsoyad.Text + "', hasta_telefon='"+telefonHst.Text+"',hasta_adres='"+adreshk.Text+"',hasta_dg='"+doğumtarihihk.Text+"', hasta_cinsiyet= '"+cinsiyethk.SelectedItem.ToString()+"', hasta_alerji='"+alerjihk.Text+"'  where hasta_id=" + key + "";
                    hst.hastasil(query);
                    MessageBox.Show("Hasta Başarıyla güncellendi");
                    uyeler();
                    yenile();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void hastadata_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            hastaadsoyad.Text = hastadata.Rows[e.RowIndex].Cells[1].Value.ToString();
            telefonHst.Text = hastadata.Rows[e.RowIndex].Cells[2].Value.ToString();
            adreshk.Text = hastadata.Rows[e.RowIndex].Cells[3].Value.ToString();
            doğumtarihihk.Text = hastadata.Rows[e.RowIndex].Cells[4].Value.ToString();
            cinsiyethk.SelectedItem = hastadata.Rows[e.RowIndex].Cells[5].Value.ToString();
            alerjihk.Text = hastadata.Rows[e.RowIndex].Cells[6].Value.ToString();
            if (hastaadsoyad.Text == "")
            {
                key = 0;

            }
            else
            {
                key = Convert.ToInt32(hastadata.Rows[e.RowIndex].Cells[0].Value.ToString());

                uyeler();
            }
        }
    }
}

