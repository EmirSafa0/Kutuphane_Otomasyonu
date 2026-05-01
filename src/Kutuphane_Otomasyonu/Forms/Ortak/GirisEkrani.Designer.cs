namespace Kutuphane_Otomasyonu
{
    partial class GirisEkrani
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GirisEkrani));
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.SafaKutup = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.kullanici_txtbx = new System.Windows.Forms.TextBox();
            this.sifre_txtbx = new System.Windows.Forms.TextBox();
            this.kullaniciAdi_lbl = new System.Windows.Forms.Label();
            this.sifre_lbl = new System.Windows.Forms.Label();
            this.giris_btn = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Gainsboro;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(1342, 801);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 7;
            this.pictureBox2.TabStop = false;
            // 
            // SafaKutup
            // 
            this.SafaKutup.BackColor = System.Drawing.Color.Chocolate;
            this.SafaKutup.Font = new System.Drawing.Font("Times New Roman", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.SafaKutup.Location = new System.Drawing.Point(48, 312);
            this.SafaKutup.Name = "SafaKutup";
            this.SafaKutup.Size = new System.Drawing.Size(391, 50);
            this.SafaKutup.TabIndex = 8;
            this.SafaKutup.Text = "Safa\'nın Kütüphanesi";
            this.SafaKutup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(205, 396);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(158, 162);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // kullanici_txtbx
            // 
            this.kullanici_txtbx.Location = new System.Drawing.Point(205, 600);
            this.kullanici_txtbx.Name = "kullanici_txtbx";
            this.kullanici_txtbx.Size = new System.Drawing.Size(158, 20);
            this.kullanici_txtbx.TabIndex = 10;
            // 
            // sifre_txtbx
            // 
            this.sifre_txtbx.Location = new System.Drawing.Point(205, 646);
            this.sifre_txtbx.Name = "sifre_txtbx";
            this.sifre_txtbx.Size = new System.Drawing.Size(158, 20);
            this.sifre_txtbx.TabIndex = 11;
            this.sifre_txtbx.UseSystemPasswordChar = true;
            // 
            // kullaniciAdi_lbl
            // 
            this.kullaniciAdi_lbl.BackColor = System.Drawing.Color.Peru;
            this.kullaniciAdi_lbl.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.kullaniciAdi_lbl.Location = new System.Drawing.Point(48, 590);
            this.kullaniciAdi_lbl.Name = "kullaniciAdi_lbl";
            this.kullaniciAdi_lbl.Size = new System.Drawing.Size(151, 36);
            this.kullaniciAdi_lbl.TabIndex = 12;
            this.kullaniciAdi_lbl.Text = "Kullanıcı Adı: ";
            this.kullaniciAdi_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // sifre_lbl
            // 
            this.sifre_lbl.BackColor = System.Drawing.Color.Peru;
            this.sifre_lbl.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.sifre_lbl.Location = new System.Drawing.Point(48, 636);
            this.sifre_lbl.Name = "sifre_lbl";
            this.sifre_lbl.Size = new System.Drawing.Size(151, 36);
            this.sifre_lbl.TabIndex = 13;
            this.sifre_lbl.Text = "Şifre: ";
            this.sifre_lbl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // giris_btn
            // 
            this.giris_btn.BackColor = System.Drawing.Color.Chocolate;
            this.giris_btn.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold);
            this.giris_btn.Location = new System.Drawing.Point(205, 693);
            this.giris_btn.Name = "giris_btn";
            this.giris_btn.Size = new System.Drawing.Size(158, 36);
            this.giris_btn.TabIndex = 14;
            this.giris_btn.Text = "GİRİŞ";
            this.giris_btn.UseVisualStyleBackColor = false;
            this.giris_btn.Click += new System.EventHandler(this.giris_btn_Click_1);
            // 
            // GirisEkrani
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Silver;
            this.ClientSize = new System.Drawing.Size(1342, 801);
            this.Controls.Add(this.giris_btn);
            this.Controls.Add(this.sifre_lbl);
            this.Controls.Add(this.kullaniciAdi_lbl);
            this.Controls.Add(this.sifre_txtbx);
            this.Controls.Add(this.kullanici_txtbx);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.SafaKutup);
            this.Controls.Add(this.pictureBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "GirisEkrani";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Giris Ekrani";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label SafaKutup;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox kullanici_txtbx;
        private System.Windows.Forms.TextBox sifre_txtbx;
        private System.Windows.Forms.Label kullaniciAdi_lbl;
        private System.Windows.Forms.Label sifre_lbl;
        private System.Windows.Forms.Button giris_btn;
    }
}

