using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane_Otomasyonu
{
    public partial class KullaniciEklemeEkrani : Form
    {
        Kutuphane_OtomasyonuEntities1 sql = new Kutuphane_OtomasyonuEntities1();  // Bu kod ile c# ve sql server arasındaki bağlantıyı sağlıyorum.
        public KullaniciEklemeEkrani()
        {
            InitializeComponent();
        }

        private void kaydet_btn_Click(object sender, EventArgs e)
        {   // Burada sadece adminlerin ve görevlilerin erişiminin olduğu kullanıcı ekleme ekranına geliyoruz ve sırasıyla kullanıcı
            // Adı, Soyadı, Tc'si, Telefonu, Doğum tarihini, Kullanıcı adı ve şifresini ve cinsiyetini adminin veya görevlinin
            // textbox'lara, datetimepicker ve radio butonlarına girmesini sağlıyorum.
            Kullanicilar kullanici = new Kullanicilar();
            kullanici.kullanici_Adi=kullaniciAdEkle_txtbx.Text;
            kullanici.kullanici_Soyadi = kullaniciSoyadEkle_txtbx.Text;
            kullanici.kullanici_TC = kullaniciTcEkle_txtbx.Text;
            kullanici.kullanici_TelNumarasi = kullaniciTelEkle_txtbx.Text;
            kullanici.kullanici_Dogumtarihi = kullaniciDogumTarihiEkle_date.Value;
            kullanici.kullanici_KullaniciAdi = kullaniciKullaniciAdiEkle_txtbx.Text;
            kullanici.kullanici_Sifresi = KullaniciSifreEkle_txtbx.Text;
            if (radioErkek.Checked == true)
            {
                kullanici.kullanici_cinsiyet = "E";
            }
            else if (radioKadın.Checked == true)
            {
                kullanici.kullanici_cinsiyet = "K";
            }
            sql.Kullanicilar.Add(kullanici); // Bu kodla beraber adminin veya görevlinin girdiği verilerin kaydet butonuna tıklandığında sql server'ıma
                                             // eklenmesini sağlıyorum.
            sql.SaveChanges(); // Bu kodla da sql server'ımın bilgilerini güncelliyorum.
            var kullanicilar = sql.Kullanicilar.ToList();       //Burada ise kaydet butonuna tıkladığımda sql server'la bağlantımı kurup kullanıcıların
            dataGridView1.DataSource = kullanicilar.ToList();   // bilgilerini datagridview'imde listeliyorum.

        }

        private void KullaniciEklemeEkrani_Load(object sender, EventArgs e)
        {
            Kullanicilar kullanici = new Kullanicilar();    // Burada kullanıcı ekleme butonuna bastığımızda datagridview'imde direkt olarak kullanıcıların
            sql.Kullanicilar.Add(kullanici);               // listelenmesini sağlıyorum.
            var kullanicilar = sql.Kullanicilar.ToList();
            dataGridView1.DataSource = kullanicilar.ToList();
            dataGridView1.Columns[9].Visible = false;// Bu satırda ise kullanıcılar ve ödünç bilgileri tablolarım birbiriyle bağlantılı olduğu için
                                                     // 9 numaralı kolonda ödünç bilgileri isimli bölüm gözüküyor bunu istemediğim için
                                                     // 9 numaralı kolonumu gizliyorum.
        }
    }
}
