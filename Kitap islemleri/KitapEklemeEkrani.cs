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
    public partial class KitapEklemeEkrani : Form
    {
        Kutuphane_OtomasyonuEntities1 sql = new Kutuphane_OtomasyonuEntities1();  // Bu kod ile c# ve sql server arasındaki bağlantıyı sağlıyorum.
        public KitapEklemeEkrani()
        {
            InitializeComponent();
        }

        private void KitapEklemeEkrani_Load(object sender, EventArgs e)
        {
            Kitaplar kitap = new Kitaplar();      // Burada kitap ekleme butonuna bastığımızda datagridview'imde direkt olarak kitapların
            sql.Kitaplar.Add(kitap);             // listelenmesini sağlıyorum.
            var kitaplar = sql.Kitaplar.ToList();
            dataGridView1.DataSource = kitaplar.ToList();
            dataGridView1.Columns[10].Visible = false; // Bu satırda ise kitaplar ve ödünç bilgileri tablolarım birbiriyle bağlantılı olduğu için
                                                       // 10 numaralı kolonda ödünç bilgileri isimli bölüm gözüküyor bunu istemediğim için
                                                       // 10 numaralı kolonumu gizliyorum.
        }

        private void kaydet_btn_Click_1(object sender, EventArgs e)
        {   // Burada sadece adminlerin ve görevlilerin erişiminin olduğu kitap ekleme ekranına geliyoruz ve sırasıyla kitap Adı, Yazarı,
            // Türü, Dili, Sayfa sayısı, Yayın tarihi, Yayınevi, Kayıt tarihi ve Stok durumunu adminin veya görevlinin textbox'lara girmesini sağlıyorum.
            Kitaplar kitap = new Kitaplar();
            kitap.kitap_Adi = kitapAdEkle_txtbx.Text;
            kitap.kitap_Yazar = kitapYazarEkle_txtbx.Text;
            kitap.kitap_Turu = kitapTurEkle_txtbx.Text;
            kitap.kitap_Dili = kitapDilEkle_txtbx.Text;
            kitap.kitap_SayfaSayisi = Convert.ToInt32(kitapSayfaSayisiEkle_txtbx.Text);
            kitap.kitap_YayinTarihi = Convert.ToInt32(kitapYayinTarihiEkle_txtbx.Text);
            kitap.kitap_Yayinevi = kitapYayineviEkle_txtbx.Text;
            kitap.kitap_KayitTarihi = Convert.ToInt32(kitapKayitTarihiEkle_txtbx.Text);
            kitap.kitap_StokDurumu= Convert.ToInt32(kitapStokDurumu_txtbx.Text);

            sql.Kitaplar.Add(kitap); // Bu kodla beraber adminin veya görevlinin girdiği verilerin kaydet butonuna tıklandığında sql server'ıma
                                     // eklenmesini sağlıyorum.
            sql.SaveChanges(); // Bu kodla da sql server'ımın bilgilerini güncelliyorum.
            var kitaplar = sql.Kitaplar.ToList();           //Burada verileri girip kaydet butonuna bastığımızda yeni eklenen kitap bilgisiyle
            dataGridView1.DataSource = kitaplar.ToList();   //beraber tüm kitapların tekrar datagridview'imde listelenmesini sağlıyorum. 
        }
    }
}
