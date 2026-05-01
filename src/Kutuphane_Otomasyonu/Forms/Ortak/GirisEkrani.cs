using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane_Otomasyonu
{
    public partial class GirisEkrani : Form
    {
        Kutuphane_OtomasyonuEntities1 sql = new Kutuphane_OtomasyonuEntities1(); // Bu kod ile c# ve sql server arasındaki bağlantıyı sağlıyorum.
        public GirisEkrani()
        {
            InitializeComponent();
        }

        private void giris_btn_Click_1(object sender, EventArgs e)
        {
            string kullaniciAdi = kullanici_txtbx.Text; //Kullanıcı adı ve şifreyi textbox'lardan gelen değerlerle alınmasını sağlıyorum.
            string sifre = sifre_txtbx.Text;

            // Burada admin, görevliler ve kullanıcılar için ayrı giriş yapmasını sağlıyorum textbox'lara girilen değerleri sql serverdaki bilgilerle
            // eşleşiyor mu diye kontrol ediyorum.
            var adminler = sql.AdminBilgileri.Where(x => x.admin_KullaniciAdi == kullaniciAdi && x.admin_KullaniciSifresi == sifre).FirstOrDefault();
            var gorevliler = sql.Gorevliler.Where(x => x.gorevli_KullaniciAdi == kullaniciAdi && x.gorevli_KullaniciSifresi == sifre).FirstOrDefault();
            var kullanicilar = sql.Kullanicilar.Where(x => x.kullanici_KullaniciAdi == kullaniciAdi && x.kullanici_Sifresi == sifre).FirstOrDefault();

            if (adminler == null && gorevliler == null && kullanicilar == null)
            {
                MessageBox.Show("Kullanici adi veya sifre hatali!..");      //Burada bilgiler doğru değilse ekrana hata mesajı veriyorum.
            }
            else if (adminler != null && gorevliler == null && kullanicilar == null)
            {
                MessageBox.Show("Admin girisi gerceklesti..");      //Burada eğer girilen bilgiler Admine aitse Admin Paneline yönlendiriyorum.
                AdminPaneli admin = new AdminPaneli();
                admin.Show();
                this.Hide();
            }

            else if (adminler == null && gorevliler != null && kullanicilar == null)
            {
                MessageBox.Show("Gorevli girisi gerceklesti..");    //Burada eğer girilen bilgiler Görevliye aitse Görevli Paneline yönlendiriyorum.
                GorevliPaneli gorevli = new GorevliPaneli();
                gorevli.Show();
                this.Hide();
            }

            else if (adminler == null && gorevliler == null && kullanicilar != null)
            {
                MessageBox.Show("Kullanıcı girisi gerceklesti..");  //Burada eğer girilen bilgiler Kullanıcıya aitse Kullanıcı Paneline yönlendiriyorum.
                KullaniciPaneli kullanici = new KullaniciPaneli();
                kullanici.Show();
                this.Hide();
            }
        }
    }
}

