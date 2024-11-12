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
            string query = "insert into hastakayit values('" + hastaadsoyad.Text + "','" + telefonhk.Text + "','" + adreshk.Text + "','" + doğumtarihihk.Value.Date + "','" + cinsiyethk.SelectedItem.ToString() + "','" + alerjihk.Text + "',)";
            hastalar hst = new hastalar();  

            try
            {
                hst.hasta_ekle(query);
                MessageBox.Show("Hasta Başarıyla Eklendi"); 

            }catch(Exception Ex)
            {
                MessageBox.Show(Ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
           this.Close();
            Application.Exit();

        }
    }
}
