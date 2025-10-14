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
    public partial class AdminBilgiGuncelleme : Form
    {
        Kutuphane_OtomasyonuEntities1 sql = new Kutuphane_OtomasyonuEntities1();  // Bu kod ile c# ve sql server arasındaki bağlantıyı sağlıyorum.
        public AdminBilgiGuncelleme()
        {
            InitializeComponent();
        }

        private void kaydet_btn_Click(object sender, EventArgs e)
        {   //Burada sql serverla bağlantımı gerçekleştirip admin için sırasıyla ad , soyad , tc , telefon , kullanıcıAdı ve şifresini sırasıyla
            //girmesini sağlıyorum.
            var admin = sql.AdminBilgileri.FirstOrDefault();
            admin.admin_Adi = adminAdGuncelle_txtbx.Text;
            admin.admin_Soyadi = adminSoyadGuncelle_txtbx.Text;
            admin.admin_TC = adminTcGuncelle_txtbx.Text;
            admin.admin_TelefonNumarasi = adminTelGuncelle_txtbx.Text;
            admin.admin_KullaniciAdi = adminKullaniciAdiGuncelle_txtbx.Text;
            admin.admin_KullaniciSifresi = adminSifreGuncelle_txtbx.Text;
            sql.SaveChanges();  //Bu komutla bilgileri adminin isteğine göre girmesine izin verdikten sonra kaydı güncelle isimli butona tıkladığında
                                //yeni bilgilerin sql server'ımızda güncellenmesini sağlıyorum.
        }
    }
}
