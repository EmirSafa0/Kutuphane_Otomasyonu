namespace Kutuphane_Otomasyonu
{
    partial class KullaniciPaneli
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KullaniciPaneli));
            this.panel1 = new System.Windows.Forms.Panel();
            this.odunc_btn = new System.Windows.Forms.Button();
            this.kitapGoruntule_btn = new System.Windows.Forms.Button();
            this.kullaniciBilgileri_btn = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Chocolate;
            this.panel1.Controls.Add(this.odunc_btn);
            this.panel1.Controls.Add(this.kitapGoruntule_btn);
            this.panel1.Controls.Add(this.kullaniciBilgileri_btn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(156, 801);
            this.panel1.TabIndex = 0;
            // 
            // odunc_btn
            // 
            this.odunc_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.odunc_btn.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.odunc_btn.Image = ((System.Drawing.Image)(resources.GetObject("odunc_btn.Image")));
            this.odunc_btn.Location = new System.Drawing.Point(0, 234);
            this.odunc_btn.Name = "odunc_btn";
            this.odunc_btn.Size = new System.Drawing.Size(156, 117);
            this.odunc_btn.TabIndex = 2;
            this.odunc_btn.Text = "Ödünç Bilgileri";
            this.odunc_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.odunc_btn.UseVisualStyleBackColor = true;
            this.odunc_btn.Click += new System.EventHandler(this.odunc_btn_Click);
            // 
            // kitapGoruntule_btn
            // 
            this.kitapGoruntule_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.kitapGoruntule_btn.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.kitapGoruntule_btn.Image = ((System.Drawing.Image)(resources.GetObject("kitapGoruntule_btn.Image")));
            this.kitapGoruntule_btn.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.kitapGoruntule_btn.Location = new System.Drawing.Point(0, 117);
            this.kitapGoruntule_btn.Name = "kitapGoruntule_btn";
            this.kitapGoruntule_btn.Size = new System.Drawing.Size(156, 117);
            this.kitapGoruntule_btn.TabIndex = 1;
            this.kitapGoruntule_btn.Text = "Kitapları Görüntüle";
            this.kitapGoruntule_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.kitapGoruntule_btn.UseVisualStyleBackColor = true;
            this.kitapGoruntule_btn.Click += new System.EventHandler(this.kitapGoruntule_btn_Click);
            // 
            // kullaniciBilgileri_btn
            // 
            this.kullaniciBilgileri_btn.Dock = System.Windows.Forms.DockStyle.Top;
            this.kullaniciBilgileri_btn.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.kullaniciBilgileri_btn.Image = ((System.Drawing.Image)(resources.GetObject("kullaniciBilgileri_btn.Image")));
            this.kullaniciBilgileri_btn.Location = new System.Drawing.Point(0, 0);
            this.kullaniciBilgileri_btn.Name = "kullaniciBilgileri_btn";
            this.kullaniciBilgileri_btn.Size = new System.Drawing.Size(156, 117);
            this.kullaniciBilgileri_btn.TabIndex = 0;
            this.kullaniciBilgileri_btn.Text = "Bilgilerini Güncelle";
            this.kullaniciBilgileri_btn.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.kullaniciBilgileri_btn.UseVisualStyleBackColor = true;
            this.kullaniciBilgileri_btn.Click += new System.EventHandler(this.kullaniciBilgileri_btn_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.Snow;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(156, 117);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(1030, 567);
            this.dataGridView1.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(268, 45);
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(189, 24);
            this.textBox1.TabIndex = 2;
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(38, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(224, 24);
            this.label1.TabIndex = 3;
            this.label1.Text = "Kullanıcı ID\'nizi giriniz: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 15.75F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(128, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Kitap arayın :";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Chocolate;
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(156, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1186, 117);
            this.panel2.TabIndex = 5;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Chocolate;
            this.panel3.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel3.Location = new System.Drawing.Point(1186, 117);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(156, 684);
            this.panel3.TabIndex = 6;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.Chocolate;
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(156, 684);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1030, 117);
            this.panel4.TabIndex = 7;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(156, 117);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1030, 567);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 8;
            this.pictureBox1.TabStop = false;
            // 
            // KullaniciPaneli
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DarkRed;
            this.ClientSize = new System.Drawing.Size(1342, 801);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "KullaniciPaneli";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Kullanici Paneli";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.KullaniciPaneli_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button kullaniciBilgileri_btn;
        private System.Windows.Forms.Button odunc_btn;
        private System.Windows.Forms.Button kitapGoruntule_btn;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}