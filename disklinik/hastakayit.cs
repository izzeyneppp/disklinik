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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO hastakayit (hasta_adi, hasta_telefon,hasta_adres,hasta_dg,hasta_cinsiyet,hasta_alerji) " +
                        "VALUES ('" + hastaadsoyad.Text + "', '" + telefonhk.Text + "', '" + adreshk.Text + "', '" +
                        doğumtarihihk.Text + "', '" + cinsiyethk.SelectedItem.ToString() + "', '" + alerjihk.Text + "')";
            hastalar hst = new hastalar();

            try
            {
                hst.hasta_ekle(query);
                MessageBox.Show("HASTA BAŞARIYLA EKLENDİ");

            }
            catch (Exception)
            {
                hst.hasta_ekle(query);
                MessageBox.Show("Hasta başarıyla eklendi.");
                yenile();

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void yenile()
        {
            hastalar hst = new hastalar();
            string query = "select * from hastakayit";
            DataSet ds = hst.Showhasta(query);
            hastadata.DataSource = ds.Tables[0];
            hastaadsoyad.Text = "";
            telefonhk.Text = "";
            cinsiyethk.Text = "";
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
        }

        private void hastakayit_Load_1(object sender, EventArgs e)
        {

        }
    }
}

