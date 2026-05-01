using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane_Otomasyonu
{
    public partial class GorevliPaneli : Form
    {
        Kutuphane_OtomasyonuEntities1 sql = new Kutuphane_OtomasyonuEntities1();  // Bu kod ile c# ve sql server arasındaki bağlantıyı sağlıyorum.
        public GorevliPaneli()
        {
            InitializeComponent();
        }

        private void GorevliPaneli_Load(object sender, EventArgs e)
        {   //  Burada ilk önce Bilgileri Güncelleme , Kullanıcılar , Ödünç Bilgileri ve Kitaplar
            // butonlarını görünür olarak bırakıp diğer bütün butonların ve datagridview'in
            // görünürlüğünü kapatıyorum. 

            kullaniciEkle_btn.Visible = false;
            kullaniciGuncelle_btn.Visible = false;
            kullaniciSil_btn.Visible = false;
            dataGridView1.Visible = false;
            kitapEkle_btn.Visible = false;
            kitapGuncelle_btn.Visible = false;
            kitapSil_btn.Visible = false;
            oduncVer_btn.Visible = false;
            oduncGeriAl_btn.Visible = false;

        }

        private void kullanicilar_btn_Click(object sender, EventArgs e)
        {  // Burada Kullanıcılar butonuna tıkladığımda kullanıcı ekleme, silme , güncelleme ve datagridview'in
           // görünürlüğünü aktifleştirecek şekilde kodumu yazıyorum.

            if (kullaniciEkle_btn.Visible == false)
            {
                kullaniciEkle_btn.Visible = true;
                kullaniciGuncelle_btn.Visible = true;
                kullaniciSil_btn.Visible = true;
                dataGridView1.Visible = true;
            }
            else
            {
                kullaniciEkle_btn.Visible = false;
                kullaniciGuncelle_btn.Visible = false;
                kullaniciSil_btn.Visible = false;
                dataGridView1.Visible = false;
            }
            var kullanicilar = sql.Kullanicilar.ToList();       //Burada ise Kullanıcılar butonuna tıkladığımda sql server'la bağlantımı kurup kullanıcıların
            dataGridView1.DataSource = kullanicilar.ToList();  //bilgilerini datagridview'imde listeliyorum.

            dataGridView1.Columns[9].Visible = false;// Bu satırda ise kitaplar ve ödünç bilgileri tablolarım birbiriyle bağlantılı olduğu için
                                                     // 9 numaralı kolonda ödünç bilgileri isimli bölüm gözüküyor bunu istemediğim için
                                                     // 9 numaralı kolonumu gizliyorum.
        }

        private void kullaniciEkle_btn_Click(object sender, EventArgs e)
        {   //Burada kullanıcı ekle butonuna tıklayınca kullanıcı ekleme ekranının açılmasını sağlıyorum.
            KullaniciEklemeEkrani ekle = new KullaniciEklemeEkrani();
            ekle.Show();
        }

        private void kullaniciSil_btn_Click(object sender, EventArgs e)
        {    //Burada kullanıcı sil butonuna tıklayınca kullanıcı silme ekranının açılmasını sağlıyorum.
            KullaniciSilmeEkrani sil = new KullaniciSilmeEkrani();
            sil.Show();
        }

        private void kullaniciGuncelle_btn_Click(object sender, EventArgs e)
        {   //Burada kullanıcı güncelleme butonuna tıklayınca kullanıcı güncelle ekranının açılmasını sağlıyorum.
            KullaniciGuncellemeEkrani guncelle = new KullaniciGuncellemeEkrani();
            guncelle.Show();
        }

        private void kitaplar_btn_Click(object sender, EventArgs e)
        {  // Burada Kitaplar butonuna tıkladığımda kitap ekleme, silme , güncelleme ve datagridview'in
           // görünürlüğünü aktifleştirecek şekilde kodumu yazıyorum.

            if (kitapEkle_btn.Visible == false)
            {
                kitapEkle_btn.Visible = true;
                kitapGuncelle_btn.Visible = true;
                kitapSil_btn.Visible = true;
                dataGridView1.Visible = true;
            }
            else
            {
                kitapEkle_btn.Visible = false;
                kitapGuncelle_btn.Visible = false;
                kitapSil_btn.Visible = false;
                dataGridView1.Visible = false;
            }
            var kitaplar = sql.Kitaplar.ToList();            //Burada ise Kitaplar butonuna tıkladığımda sql server'la bağlantımı kurup kitaplarların
            dataGridView1.DataSource = kitaplar.ToList();   //bilgilerini datagridview'imde listeliyorum.

            dataGridView1.Columns[10].Visible = false;    // Bu satırda ise kitaplar ve ödünç bilgileri tablolarım birbiriyle bağlantılı olduğu için
                                                         // 10 numaralı kolonda ödünç bilgileri isimli bölüm gözüküyor bunu istemediğim için
                                                        // 10 numaralı kolonumu gizliyorum.
        }

        private void kitapEkle_btn_Click(object sender, EventArgs e)
        {   //Burada kitap ekleme butonuna tıklayınca kitap ekle ekranının açılmasını sağlıyorum.
            KitapEklemeEkrani ekle = new KitapEklemeEkrani();
            ekle.Show();
        }

        private void kitapGuncelle_btn_Click(object sender, EventArgs e)
        {   //Burada kitap guncelleme butonuna tıklayınca kitap guncelle ekranının açılmasını sağlıyorum.
            KitapGuncellemeEkrani guncelle = new KitapGuncellemeEkrani();
            guncelle.Show();
        }

        private void kitapSil_btn_Click(object sender, EventArgs e)
        {   //Burada kitap silme butonuna tıklayınca kitap sil ekranının açılmasını sağlıyorum.
            KitapSilmeEkrani sil = new KitapSilmeEkrani();
            sil.Show();
        }

        private void kullaniciBilgileri_btn_Click(object sender, EventArgs e)
        {   //Burada bilgilerini güncelle butonuna tıklayınca görevli için bilgilerini güncelleme ekranının açılmasını sağlıyorum.
            GorevliBilgiGuncelleme gorevliBilgi = new GorevliBilgiGuncelleme();
            gorevliBilgi.Show();
        }

        private void oduncBilgileri_btn_Click(object sender, EventArgs e)
        {    // Burada Ödünç bilgileri butonuna tıkladığımda Ödünç ver , Ödüncü geri al ve datagridview'in
            // görünürlüğünü aktifleştirecek şekilde , tekrar Ödünç bilgilerine tıkladığımda ise görünür olan butonlar kapanmasını sağlayacak şekilde
           // kodumu yazıyorum.
            if (oduncVer_btn.Visible == false)
            {
                oduncVer_btn.Visible = true;
                oduncGeriAl_btn.Visible = true;
                dataGridView1.Visible = true;
            }
            else
            {
                oduncVer_btn.Visible = false;
                oduncGeriAl_btn.Visible = false;
                dataGridView1.Visible = false;
            }
            var oduncler = sql.OduncBilgileri.ToList();    //Burada ise Ödünç bilgileri butonuna tıkladığımda sql server'la bağlantımı kurup Ödünç bilgilerini
            dataGridView1.DataSource = oduncler.ToList(); // datagridview'imde listeliyorum.

            dataGridView1.Columns[6].Visible = false;   // Bu satırda ise kitaplar,  kullanıcılar ve ödünç bilgileri tablolarım birbiriyle bağlantılı olduğu için
            dataGridView1.Columns[7].Visible = false;  // 6 ve 7 numaralı kolonda kitaplar ve kullanıcılar isimli bölüm gözüküyor bunu istemediğim için
                                                      // 6 ve 7 numaralı kolonumu gizliyorum.

        }

        private void oduncVer_btn_Click(object sender, EventArgs e)
        {   //Burada Ödünç verme butonuna tıklayınca ödünç ver ekranının açılmasını sağlıyorum.
            OduncVermeEkranı oduncVer=new OduncVermeEkranı();
            oduncVer.Show();
        }

        private void oduncGeriAl_btn_Click(object sender, EventArgs e)
        {   //Burada Ödündü geri alma butonuna tıklayınca ödünç geri al ekranının açılmasını sağlıyorum.
            OduncuGeriAlmaEkrani oduncAl=new OduncuGeriAlmaEkrani();
            oduncAl.Show();
        }
    }
}
