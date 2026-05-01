using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane_Otomasyonu
{
    public partial class OduncVermeEkranı : Form
    {
        Kutuphane_OtomasyonuEntities1 sql = new Kutuphane_OtomasyonuEntities1();  // Bu kod ile c# ve sql server arasındaki bağlantıyı sağlıyorum.
        public OduncVermeEkranı()
        {
            InitializeComponent();
        }

        private void OduncVermeEkranı_Load(object sender, EventArgs e)
        {
            var kullanicilar = sql.Kullanicilar.ToList();   // Bu kodla datagridview1'de kullanıcılarımı listeliyorum.
            dataGridView1.DataSource = kullanicilar.ToList();

            var kitaplar = sql.Kitaplar.ToList();   // Bu kodla datagridview2'de kitaplarımı listeliyorum.
            dataGridView2.DataSource = kitaplar.ToList();

            var oduncler = sql.OduncBilgileri.ToList();   // Bu kodla datagridview3'de ödünç bilgilerimi listeliyorum.
            dataGridView3.DataSource = oduncler.ToList();
            dataGridView3.Columns[6].Visible = false;   // Bu satırda ise kitaplar,  kullanıcılar ve ödünç bilgileri tablolarım birbiriyle bağlantılı olduğu için
            dataGridView3.Columns[7].Visible = false;  // 6 ve 7 numaralı kolonda kitaplar ve kullanıcılar isimli bölüm gözüküyor bunu istemediğim için
                                                      // 6 ve 7 numaralı kolonumu gizliyorum.
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {   // Burada textbox1'e kullanıcının Adını, Soyadını veya Tc'sini giriyorum bu değer eğer datagridview1'imde bulunan kullanıcılar içinde varsa
            // datagridview1'imde kullanıcımı buluyorum.
            string kullanici = textBox1.Text;
            var kullanicilar = sql.Kullanicilar.Where(x => x.kullanici_Adi.Contains(kullanici) || x.kullanici_Soyadi.Contains(kullanici) || x.kullanici_TC.Contains(kullanici)).ToList();
            dataGridView1.DataSource = kullanicilar.ToList();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {   // Burada textbox2'e kitabın Adını veya Yazarını giriyorum bu değer eğer datagridview2'imde bulunan kitaplar içinde varsa
            // datagridview2'imde kitabımı buluyorum.
            string kitap = textBox2.Text;
            var kitaplar = sql.Kitaplar.Where(x => x.kitap_Adi.Contains(kitap) || x.kitap_Yazar.Contains(kitap)).ToList();
            dataGridView2.DataSource = kitaplar.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int secilen_KullaniciID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);// Burada kullanıcımı seçiyorum.
                int secilenKitapID = Convert.ToInt32(dataGridView2.CurrentRow.Cells[0].Value);// Burada da istediği kitabı seçiyorum
                DateTime verilisTarihi = DateTime.Today;// Burada kitabın veriliş tarihini o günün tarihi ne ise ona göre tarih girmek için .Today'i kulanıyorum.
                DateTime sonTarih = verilisTarihi.AddDays(15);// Burada ise veriliş tarihine 15 gün ekleyecek ve son tarihi girecek kodu yazıyorum.

                // Burada seçmiş olduğum kullanıcı ve kitabı ödünç ver butonuna tıklayarak değerleri belirliyorum.
                var kullaniciID = new SqlParameter("@kullanici_ID", secilen_KullaniciID);
                var kitapID = new SqlParameter("@kitap_ID", secilenKitapID);
                var verilisTarihiParam = new SqlParameter("@verilisTarihi", verilisTarihi);
                var sonTarihParam = new SqlParameter("@sonTarih", sonTarih);

                // Burada sql server'ımda yazmış olduğum 'UP_StokDurumunuAzaltma' SP'mi çağırıyorum ve belirlediğim değerleri SP'imdeki değerlerle ilişkilendiriyorum.
                sql.Database.ExecuteSqlCommand("EXEC UP_StokDurumunuAzaltma @kullanici_ID, @kitap_ID, @verilisTarihi, @sonTarih", kullaniciID, kitapID, verilisTarihiParam, sonTarihParam);

                // Burada kitabı ödünç verdikten sonra stok azalttığımın ve ödüncün verildiğine dair ekrana mesaj yolluyorum.
                MessageBox.Show("Stok başarıyla azaltıldı ve ödünç verildi!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                var oduncler = sql.OduncBilgileri.ToList();  // Burada yeni ödünçle beraber ödünç bilgilerimi datagridview3'te listeliyorum.
                dataGridView3.DataSource = oduncler.ToList();
            }
            catch (Exception ex)
            {
                // Burada ise stok yetersizse veya başka bir sorun yaşandıysa hata mesajı yolluyorum.
                MessageBox.Show("Bir hata oluştu veya kitap stoğu yetersiz! " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
