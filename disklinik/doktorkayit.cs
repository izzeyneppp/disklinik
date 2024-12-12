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
            string query = "select * from hdoktorkayit";
            DataSet ds = dr.Showdoktor(query);
            doktordata.DataSource = ds.Tables[0];
        }


        void filter()
        {
            doktorlar dr = new doktorlar();
            string query = "select * from hastakayit where hasta_adi like'%" + doktorarama.Text + "%'";
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
            string query = "INSERT INTO doktorkayit (doktorad, doktortel,doktordg,dokotrcinsiyet,doktorbrans,doktoradres) " +
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
    }
}
