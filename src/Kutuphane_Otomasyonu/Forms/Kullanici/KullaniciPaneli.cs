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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Kutuphane_Otomasyonu
{
    public partial class KullaniciPaneli : Form
    {
        Kutuphane_OtomasyonuEntities1 sql = new Kutuphane_OtomasyonuEntities1();  // Bu kod ile c# ve sql server arasındaki bağlantıyı sağlıyorum.
        public KullaniciPaneli()
        {
            InitializeComponent();
        }

        private void KullaniciPaneli_Load(object sender, EventArgs e)
        {   //Burada öncelikle datagridview'in label 1 ve 2'nin ve textbox1'in görünürlüğünü kapatıyorum.
            dataGridView1.Visible = false;
            label1.Visible = false;
            textBox1.Visible = false;
            label2.Visible = false;
        }

        private void kitapGoruntule_btn_Click(object sender, EventArgs e)
        {  // Burada Kitapları görüntüle butonuna tıkladığımda datagridview'in label2'nin ve textbox1'in görünürlüğünü aktifleştirecek ve tekrar 
           // tıkladığımda görünürlüğünü kapatacak şekilde kodumu yazıyorum.

            if (dataGridView1.Visible == false)
            {
                dataGridView1.Visible = true;
                label1.Visible = false;
                textBox1.Visible = true;
                label2.Visible = true;
            }
            else
            {
                dataGridView1.Visible = false;
                label1.Visible = false;
                textBox1.Visible = false;
                label2.Visible = false;
            }
            var kitaplar = sql.Kitaplar.ToList();           //Burada ise Kitaplar butonuna tıkladığımda sql server'la bağlantımı kurup kitaplarların 
            dataGridView1.DataSource = kitaplar.ToList();  //bilgilerini datagridview'imde listeliyorum.

            dataGridView1.Columns[10].Visible = false; // Bu satırda ise kitaplar ve ödünç bilgileri tablolarım birbiriyle bağlantılı olduğu için
                                                       // 10 numaralı kolonda ödünç bilgileri isimli bölüm gözüküyor bunu istemediğim için
                                                       // 10 numaralı kolonumu gizliyorum.
        }

        private void kullaniciBilgileri_btn_Click(object sender, EventArgs e)
        { //Burada bilgilerini güncelle butonuna tıklayınca kullanıcı için bilgilerini güncelleme ekranının açılmasını sağlıyorum.
            KullaniciBilgiGuncelleme bilgiler = new KullaniciBilgiGuncelleme();
            bilgiler.Show();
        }

        private void odunc_btn_Click(object sender, EventArgs e)
        {  // Burada Kitapları görüntüle butonuna tıkladığımda datagridview'in label1'nin ve textbox1'in görünürlüğünü aktifleştirecek ve tekrar 
           // tıkladığımda görünürlüğünü kapatacak şekilde kodumu yazıyorum.

            if (dataGridView1.Visible == false)
            {
                dataGridView1.Visible = true;
                label1.Visible = true;
                textBox1.Visible = true;
                label2.Visible = false;
            }
            else
            {
                dataGridView1.Visible = false;
                label1.Visible = false;
                textBox1.Visible = false;
                label2.Visible = false;
            }

            var oduncler = sql.OduncBilgileri.ToList();    //Burada ise Ödünç bilgileri butonuna tıkladığımda sql server'la bağlantımı kurup Ödünç bilgilerini
            dataGridView1.DataSource = oduncler.ToList(); // datagridview'imde listeliyorum.

            dataGridView1.Columns[6].Visible = false;   // Bu satırda ise kitaplar,  kullanıcılar ve ödünç bilgileri tablolarım birbiriyle bağlantılı olduğu için
            dataGridView1.Columns[7].Visible = false;  // 6 ve 7 numaralı kolonda kitaplar ve kullanıcılar isimli bölüm gözüküyor bunu istemediğim için
                                                      // 6 ve 7 numaralı kolonumu gizliyorum.
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            string girilenDeger = textBox1.Text;  //Burada textbox'tan bir değer alıyorum.

            if (int.TryParse(girilenDeger, out int kullaniciID)) // Eğer girdiğim değer bir sayıysa bu bu değeri kullaniciID değişkeninde atıyoruz.
            {
                var odunclerim = sql.OduncBilgileri.Where(x => x.kullanici_ID == kullaniciID).ToList();
                // 96. satırda Veri tabanındaki ödünç bilgileri tablosundaki kullanici_ID ile eşleşen kayıtları listeliyoruz.
                if (odunclerim.Any()) // Eğer eşleşen bir kayıt varsa 
                {
                    dataGridView1.DataSource = odunclerim; // Burada eşleşen kaydı datagridview'de göstermemizi sağlıyorum.
                    if (dataGridView1.Columns.Count > 6)            //101. ve 104. satırlar arasında yine burada gözükmesini istemediğim ama sql serverda 
                        dataGridView1.Columns[6].Visible = false;  // bağlantısını gerçekleştirdiğim kullanıcılar , kitaplar ve ödünç bilgilerinden 
                    if (dataGridView1.Columns.Count > 7)          // dolayı gözüken kullanıcılar ve kitaplar kolonlarını gizleme işlemini gerçekleştiriyorum.
                        dataGridView1.Columns[7].Visible = false;
                    return; // Fonksiyonu sonlandırıyorum.
                }
            }
            var kitaplar = sql.Kitaplar.Where(x => x.kitap_Adi.Contains(girilenDeger) || x.kitap_Yazar.Contains(girilenDeger)) .ToList();
            //108. satırda textbox'a girdiğimiz değer bir sayı değilse kitaplar tablomdan kitap adı veya yazar'a göre arama gerçekleştiriyorum.
            dataGridView1.DataSource = kitaplar; // Burada ise gelen değeri datagridview'imde listeliyorum.
        }
    }
}

