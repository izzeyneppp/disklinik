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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        
        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            anasayfa anaSayfaFormu = new anasayfa(); 
            anaSayfaFormu.Show(); 

            
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();

        }
    }
}
