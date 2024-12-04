﻿using System;
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
        public void yenile()
        {

           recetead.SelectedItem  = "";
           fiyatrecete.Text = "";
            ilacad.Text = "";
            aciklamarecete.Text = "";
            


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
            string query = "INSERT INTO recete (hasta_adi_soyadi, ilac_recete,fiyat_recete,aciklama_recete) " +
                        "VALUES ('" + recetead.SelectedItem.ToString() + "', '" + ilacad.Text + "', '" + fiyatrecete.Text + "', '" +
                        aciklamarecete.Text + "')";
           receteler rec = new receteler();

            try
            {
                rec.recete_ekle(query);
                MessageBox.Show("HASTA BAŞARIYLA EKLENDİ");
                yenile();
                uyeler();

            }
            catch (Exception)
            {
                rec.recete_ekle(query);
                MessageBox.Show("Hasta Başarıyla Eklendi.");
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
                MessageBox.Show("Düzenlenecek Receteyi Seçiniz");
            }
            else
            {
                try
                {

                    string query = "update hastakayit set hasta_adi_soyadi='" + recetead.SelectedItem.ToString() + "', ilac_recete='" + ilacad.Text + "',fiyat_recete='" + fiyatrecete.Text + "',aciklama_recete='" + aciklamarecete.Text + "' where recete_id=" + key + "";
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

        }
    }
}
