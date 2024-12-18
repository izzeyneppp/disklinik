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
    public partial class doktorkayit : Form
    {
        public doktorkayit()
        {
            InitializeComponent();
        }

        void uyeler()
        {
            doktorlar dr =new doktorlar();
            string query = "select * from doktorkayit";
            DataSet ds = dr.Showdoktor(query);
            doktordata.DataSource = ds.Tables[0];
        }


        void filter()
        {
            doktorlar dr = new doktorlar();
            string query = "select * from doktorkayit where doktorad like'%" + doktorarama.Text + "%'";
            DataSet ds = dr.Showdoktor(query);
            doktordata.DataSource = ds.Tables[0];
        }
        public void yenile()
        {
            doktordg.Text = "";
            doktorad.Text = "";
            doktortel.Text = "";
            doktorcinsiyet.SelectedItem = "";
            doktorbrans.Text = "";
            doktoradres.Text = "";
            doktorarama.Text = "";

        }
        private void button4_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO doktorkayit (doktorad, doktortel,doktordg,doktorcinsiyet,doktorbrans,doktoradres) " +
                       "VALUES ('" + doktorad.Text + "', '" + doktortel.Text + "', '" + doktordg.Text + "', '" +
                       doktorcinsiyet.SelectedItem.ToString() + "', '" + doktorbrans.Text + "', '" + doktoradres.Text + "')";
            doktorlar dr = new doktorlar();

            try
            {
                dr.doktor_ekle(query);
                MessageBox.Show("DOKTOR BAŞARIYLA EKLENDİ");
                yenile();
                uyeler();

            }
            catch (Exception)
            {
                dr.doktor_ekle(query);
                MessageBox.Show("Doktor Başarıyla Eklendi.");
                uyeler();
                yenile();

            }
        }

        private void doktorkayit_Load(object sender, EventArgs e)
        {
            uyeler();
            yenile();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            uyeler();
            yenile();
        }

        private void doktorarama_TextChanged(object sender, EventArgs e)
        {
            filter();
        }
        int key = 0;
        private void button5_Click(object sender, EventArgs e)
        {
            doktorlar dr = new doktorlar();
            if (key == 0)
            {
                MessageBox.Show("Düzenlenecek Doktor Seçiniz");
            }
            else
            {
                try
                {

                    string query = "update doktorkayit set doktorad='" + doktorad.Text + "', doktortel='" + doktortel.Text + "',doktordg='" + doktordg.Text + "',doktorcinsiyet='" + doktorcinsiyet.SelectedItem.ToString() + "', doktorbrans= '" + doktorbrans.Text + "', doktoradres='" + doktoradres.Text + "'  where doktorId=" + key + "";
                    dr.doktorguncelle(query);
                    MessageBox.Show("Doktor Bilgileri Başarıyla güncellendi");
                    uyeler();
                    yenile();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void doktordata_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            doktorad.Text = doktordata.Rows[e.RowIndex].Cells[1].Value.ToString();
            doktortel.Text = doktordata.Rows[e.RowIndex].Cells[2].Value.ToString();
            doktordg.Text = doktordata.Rows[e.RowIndex].Cells[3].Value.ToString();
            doktorcinsiyet.SelectedItem = doktordata.Rows[e.RowIndex].Cells[4].Value.ToString();
            doktorbrans.Text = doktordata.Rows[e.RowIndex].Cells[5].Value.ToString();
            doktoradres.Text = doktordata.Rows[e.RowIndex].Cells[6].Value.ToString();
            if (doktorad.Text == "")
            {
                key = 0;

            }
            else
            {
                key = Convert.ToInt32(doktordata.Rows[e.RowIndex].Cells[0].Value.ToString());

                uyeler();
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            doktorlar dr = new doktorlar();
            if (key == 0)
            {
                MessageBox.Show("Silinecek Doktoru Seçiniz");
            }
            else
            {
                try
                {

                    string query = "delete from doktorkayit where doktorId=" + key + "";
                    dr.doktorsil(query);
                    MessageBox.Show("Doktor Başarıyla Silindi");
                    uyeler();
                    yenile();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            anasayfa frmAnaSayfa = new anasayfa();
            frmAnaSayfa.Show();
            this.Hide();
        }
    }
}
