namespace disklinik
{
    partial class doktorkayit
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.doktortel = new System.Windows.Forms.MaskedTextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.doktorarama = new System.Windows.Forms.TextBox();
            this.doktorcinsiyet = new System.Windows.Forms.ComboBox();
            this.doktordata = new System.Windows.Forms.DataGridView();
            this.doktorbrans = new System.Windows.Forms.TextBox();
            this.doktoradres = new System.Windows.Forms.TextBox();
            this.doktordg = new System.Windows.Forms.DateTimePicker();
            this.doktorad = new System.Windows.Forms.TextBox();
            this.llabbel = new System.Windows.Forms.Label();
            this.llaaabbell = new System.Windows.Forms.Label();
            this.llabel = new System.Windows.Forms.Label();
            this.labeel = new System.Windows.Forms.Label();
            this.labeeel = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.doktordata)).BeginInit();
            this.SuspendLayout();
            // 
            // doktortel
            // 
            this.doktortel.Location = new System.Drawing.Point(130, 128);
            this.doktortel.Margin = new System.Windows.Forms.Padding(2);
            this.doktortel.Mask = "(999) 000-0000";
            this.doktortel.Name = "doktortel";
            this.doktortel.Size = new System.Drawing.Size(150, 20);
            this.doktortel.TabIndex = 77;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.AliceBlue;
            this.button6.Font = new System.Drawing.Font("Franklin Gothic Medium", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button6.Location = new System.Drawing.Point(325, 294);
            this.button6.Margin = new System.Windows.Forms.Padding(2);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(84, 37);
            this.button6.TabIndex = 75;
            this.button6.Text = "SİL";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.AliceBlue;
            this.button5.Font = new System.Drawing.Font("Franklin Gothic Medium", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button5.Location = new System.Drawing.Point(413, 294);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(84, 37);
            this.button5.TabIndex = 74;
            this.button5.Text = "DÜZENLE";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.AliceBlue;
            this.button4.Font = new System.Drawing.Font("Franklin Gothic Medium", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button4.Location = new System.Drawing.Point(501, 294);
            this.button4.Margin = new System.Windows.Forms.Padding(2);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(84, 37);
            this.button4.TabIndex = 73;
            this.button4.Text = "KAYDET";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.AliceBlue;
            this.button3.Font = new System.Drawing.Font("Franklin Gothic Medium", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.button3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button3.Location = new System.Drawing.Point(514, 73);
            this.button3.Margin = new System.Windows.Forms.Padding(2);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(84, 37);
            this.button3.TabIndex = 72;
            this.button3.Text = "YENİLE\r\n";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // doktorarama
            // 
            this.doktorarama.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.doktorarama.Location = new System.Drawing.Point(305, 83);
            this.doktorarama.Margin = new System.Windows.Forms.Padding(2);
            this.doktorarama.Name = "doktorarama";
            this.doktorarama.Size = new System.Drawing.Size(143, 20);
            this.doktorarama.TabIndex = 71;
            this.doktorarama.TextChanged += new System.EventHandler(this.doktorarama_TextChanged);
            // 
            // doktorcinsiyet
            // 
            this.doktorcinsiyet.FormattingEnabled = true;
            this.doktorcinsiyet.Items.AddRange(new object[] {
            "Kadin",
            "Erkek"});
            this.doktorcinsiyet.Location = new System.Drawing.Point(130, 207);
            this.doktorcinsiyet.Margin = new System.Windows.Forms.Padding(2);
            this.doktorcinsiyet.Name = "doktorcinsiyet";
            this.doktorcinsiyet.Size = new System.Drawing.Size(152, 21);
            this.doktorcinsiyet.TabIndex = 76;
            // 
            // doktordata
            // 
            this.doktordata.BackgroundColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.LightSeaGreen;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.doktordata.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.doktordata.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.doktordata.Location = new System.Drawing.Point(305, 117);
            this.doktordata.Name = "doktordata";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.LightSeaGreen;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.doktordata.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.doktordata.RowHeadersWidth = 51;
            this.doktordata.Size = new System.Drawing.Size(293, 160);
            this.doktordata.TabIndex = 70;
            this.doktordata.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.doktordata_CellClick);
            // 
            // doktorbrans
            // 
            this.doktorbrans.BackColor = System.Drawing.Color.White;
            this.doktorbrans.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.doktorbrans.Location = new System.Drawing.Point(130, 248);
            this.doktorbrans.Name = "doktorbrans";
            this.doktorbrans.Size = new System.Drawing.Size(150, 20);
            this.doktorbrans.TabIndex = 69;
            // 
            // doktoradres
            // 
            this.doktoradres.BackColor = System.Drawing.Color.White;
            this.doktoradres.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.doktoradres.Location = new System.Drawing.Point(130, 285);
            this.doktoradres.Name = "doktoradres";
            this.doktoradres.Size = new System.Drawing.Size(150, 20);
            this.doktoradres.TabIndex = 68;
            // 
            // doktordg
            // 
            this.doktordg.Location = new System.Drawing.Point(130, 170);
            this.doktordg.Name = "doktordg";
            this.doktordg.Size = new System.Drawing.Size(150, 20);
            this.doktordg.TabIndex = 67;
            // 
            // doktorad
            // 
            this.doktorad.BackColor = System.Drawing.Color.White;
            this.doktorad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.doktorad.Location = new System.Drawing.Point(130, 92);
            this.doktorad.Name = "doktorad";
            this.doktorad.Size = new System.Drawing.Size(150, 20);
            this.doktorad.TabIndex = 66;
            // 
            // llabbel
            // 
            this.llabbel.AutoSize = true;
            this.llabbel.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.llabbel.Location = new System.Drawing.Point(51, 245);
            this.llabbel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.llabbel.Name = "llabbel";
            this.llabbel.Size = new System.Drawing.Size(65, 21);
            this.llabbel.TabIndex = 65;
            this.llabbel.Text = "Branş :";
            // 
            // llaaabbell
            // 
            this.llaaabbell.AutoSize = true;
            this.llaaabbell.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.llaaabbell.Location = new System.Drawing.Point(49, 284);
            this.llaaabbell.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.llaaabbell.Name = "llaaabbell";
            this.llaaabbell.Size = new System.Drawing.Size(64, 21);
            this.llaaabbell.TabIndex = 64;
            this.llaaabbell.Text = "Adres :";
            // 
            // llabel
            // 
            this.llabel.AutoSize = true;
            this.llabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.llabel.Location = new System.Drawing.Point(36, 206);
            this.llabel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.llabel.Name = "llabel";
            this.llabel.Size = new System.Drawing.Size(81, 21);
            this.llabel.TabIndex = 63;
            this.llabel.Text = "Cinsiyet :";
            // 
            // labeel
            // 
            this.labeel.AutoSize = true;
            this.labeel.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labeel.Location = new System.Drawing.Point(4, 167);
            this.labeel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labeel.Name = "labeel";
            this.labeel.Size = new System.Drawing.Size(124, 21);
            this.labeel.TabIndex = 62;
            this.labeel.Text = "Doğum Tarihi :";
            // 
            // labeeel
            // 
            this.labeeel.AutoSize = true;
            this.labeeel.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.labeeel.Location = new System.Drawing.Point(39, 128);
            this.labeeel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labeeel.Name = "labeeel";
            this.labeeel.Size = new System.Drawing.Size(77, 21);
            this.labeeel.TabIndex = 61;
            this.labeeel.Text = "Telefon :";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Franklin Gothic Medium", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label.Location = new System.Drawing.Point(27, 89);
            this.label.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(88, 21);
            this.label.TabIndex = 60;
            this.label.Text = "Ad Soyad:";
            // 
            // doktorkayit
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(608, 404);
            this.Controls.Add(this.doktortel);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.doktorarama);
            this.Controls.Add(this.doktorcinsiyet);
            this.Controls.Add(this.doktordata);
            this.Controls.Add(this.doktorbrans);
            this.Controls.Add(this.doktoradres);
            this.Controls.Add(this.doktordg);
            this.Controls.Add(this.doktorad);
            this.Controls.Add(this.llabbel);
            this.Controls.Add(this.llaaabbell);
            this.Controls.Add(this.llabel);
            this.Controls.Add(this.labeel);
            this.Controls.Add(this.labeeel);
            this.Controls.Add(this.label);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "doktorkayit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.doktorkayit_Load);
            ((System.ComponentModel.ISupportInitialize)(this.doktordata)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MaskedTextBox doktortel;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.TextBox doktorarama;
        private System.Windows.Forms.ComboBox doktorcinsiyet;
        private System.Windows.Forms.DataGridView doktordata;
        private System.Windows.Forms.TextBox doktorbrans;
        private System.Windows.Forms.TextBox doktoradres;
        private System.Windows.Forms.DateTimePicker doktordg;
        private System.Windows.Forms.TextBox doktorad;
        private System.Windows.Forms.Label llabbel;
        private System.Windows.Forms.Label llaaabbell;
        private System.Windows.Forms.Label llabel;
        private System.Windows.Forms.Label labeel;
        private System.Windows.Forms.Label labeeel;
        private System.Windows.Forms.Label label;
    }
}