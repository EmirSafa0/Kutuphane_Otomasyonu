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
    public partial class GorevliBilgiGuncelleme : Form
    {
        Kutuphane_OtomasyonuEntities1 sql = new Kutuphane_OtomasyonuEntities1();  // Bu kod ile c# ve sql server arasındaki bağlantıyı sağlıyorum.
        public GorevliBilgiGuncelleme()
        {
            InitializeComponent();
        }

        private void kaydet_btn_Click(object sender, EventArgs e)
        {   //Burada sql serverla bağlantımı gerçekleştirip görevli için sırasıyla ad , soyad , tc , telefon , kullanıcıAdı ve şifresini sırasıyla
            //girmesini sağlıyorum.
            var gorevli = sql.Gorevliler.FirstOrDefault();
            gorevli.gorevli_Adi = gorevliAdGuncelle_txtbx.Text;
            gorevli.gorevli_Soyadi = gorevliSoyadGuncelle_txtbx.Text;
            gorevli.gorevli_TC = gorevliTcGuncelle_txtbx.Text;
            gorevli.gorevli_TelefonNumarasi = gorevliTelGuncelle_txtbx.Text;
            gorevli.gorevli_KullaniciAdi = gorevliKullaniciAdiGuncelle_txtbx.Text;
            gorevli.gorevli_KullaniciSifresi = gorevliSifreGuncelle_txtbx.Text;
            sql.SaveChanges();  //Bu komutla bilgileri görevlinin isteğine göre girmesine izin verdikten sonra kaydı güncelle isimli butona tıkladığında
                                //yeni bilgilerin sql server'ımızda güncellenmesini sağlıyorum.
        }
    }
}
