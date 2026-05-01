using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane_Otomasyonu
{
    public partial class KullaniciBilgiGuncelleme : Form
    {
        Kutuphane_OtomasyonuEntities1 sql = new Kutuphane_OtomasyonuEntities1();  // Bu kod ile c# ve sql server arasındaki bağlantıyı sağlıyorum.
        public KullaniciBilgiGuncelleme()
        {
            InitializeComponent();
        }

        private void kaydet_btn_Click(object sender, EventArgs e)
        {   //Burada sql serverla bağlantımı gerçekleştirip kullanıcı için sırasıyla ad , soyad , tc , telefon , doğum tarihi , kullanıcıAdı ,
            // şifresini ve cinsiyetini sırasıyla girmesini sağlıyorum.
            var kullanici = sql.Kullanicilar.FirstOrDefault();
            kullanici.kullanici_Adi = kullaniciAdGuncelle_txtbx.Text;
            kullanici.kullanici_Soyadi = kullaniciSoyadGuncelle_txtbx.Text;
            kullanici.kullanici_TC = kullaniciTcGuncelle_txtbx.Text;
            kullanici.kullanici_TelNumarasi = kullaniciTelGuncelle_txtbx.Text;
            kullanici.kullanici_Dogumtarihi = kullaniciDogumTarihiGuncelle_date.Value;
            kullanici.kullanici_KullaniciAdi = kullaniciKullaniciAdiGuncelle_txtbx.Text;
            kullanici.kullanici_Sifresi = KullaniciSifreGuncelle_txtbx.Text;
            if (radioErkek.Checked == true)
            {
                kullanici.kullanici_cinsiyet = "E";
            }
            else if (radioKadın.Checked == true)
            {
                kullanici.kullanici_cinsiyet = "K";
            }
            sql.SaveChanges();  //Bu komutla bilgileri kullanıcının isteğine göre girmesine izin verdikten sonra kaydı güncelle isimli butona tıkladığında
                                //yeni bilgilerin sql server'ımızda güncellenmesini sağlıyorum.
        }
    }
}
