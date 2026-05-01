using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane_Otomasyonu.Gorevli
{
    public partial class GorevliEklemeEkrani : Form
    {
        Kutuphane_OtomasyonuEntities1 sql = new Kutuphane_OtomasyonuEntities1();  // Bu kod ile c# ve sql server arasındaki bağlantıyı sağlıyorum.
        public GorevliEklemeEkrani()
        {
            InitializeComponent();
        }

        private void kaydet_btn_Click(object sender, EventArgs e)
        {   // Burada sadece adminin erişiminin olduğu görevli ekleme ekranına geliyoruz ve sırasıyla görevli Adı, Soyadı, Tc'si, Telefonu, Kullanıcı adı
            // ve şifresini adminin textbox'lara girmesini sağlıyorum.
            Gorevliler gorevliler = new Gorevliler();
            gorevliler.gorevli_Adi = gorevliAdEkle_txtbx.Text;
            gorevliler.gorevli_Soyadi = gorevliSoyadEkle_txtbx.Text;
            gorevliler.gorevli_TC = gorevliTcEkle_txtbx.Text;
            gorevliler.gorevli_TelefonNumarasi = gorevliTelEkle_txtbx.Text;
            gorevliler.gorevli_KullaniciAdi = gorevliKullaniciAdEkle_txtbx.Text;
            gorevliler.gorevli_KullaniciSifresi = gorevliKullaniciSifreEkle_txtbx.Text;

            sql.Gorevliler.Add(gorevliler); // Bu kodla beraber adminin girdiği verilerin kaydet butonuna tıklandığında sql server'ıma eklenmesini sağlıyorum. 
            sql.SaveChanges(); // Bu kodla da sql server'ımın bilgilerini güncelliyorum.
            var gorevli = sql.Gorevliler.ToList();        //Burada ise kaydet butonuna tıkladığımda sql server'la bağlantımı kurup görevlilerin bilgilerini
            dataGridView1.DataSource = gorevli.ToList(); // datagridview'imde listeliyorum.
        }

        private void GorevliEklemeEkrani_Load(object sender, EventArgs e)
        {
            Gorevliler gorevliler = new Gorevliler();   // Burada görevli ekleme butonuna bastığımızda datagridview'imde direkt olarak görevlilerin
            sql.Gorevliler.Add(gorevliler);             // listelenmesini sağlıyorum.
            var gorevli = sql.Gorevliler.ToList();
            dataGridView1.DataSource = gorevli.ToList();
        }
    }
}
