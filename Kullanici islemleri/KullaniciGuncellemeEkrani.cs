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
    public partial class KullaniciGuncellemeEkrani : Form
    {
        Kutuphane_OtomasyonuEntities1 sql = new Kutuphane_OtomasyonuEntities1();  // Bu kod ile c# ve sql server arasındaki bağlantıyı sağlıyorum.

        public KullaniciGuncellemeEkrani()
        {
            InitializeComponent();
        }

        private void KullaniciGuncellemeEkrani_Load(object sender, EventArgs e)
        {
            Kullanicilar kullanici = new Kullanicilar();    // Burada kullanıcı güncelleme butonuna bastığımızda datagridview'imde direkt olarak    
            sql.Kullanicilar.Add(kullanici);               // kullanıcıların listelenmesini sağlıyorum.
            var kullanicilar = sql.Kullanicilar.ToList();
            dataGridView1.DataSource = kullanicilar.ToList();
            dataGridView1.Columns[9].Visible = false;// Bu satırda ise kullanıcılar ve ödünç bilgileri tablolarım birbiriyle bağlantılı olduğu için
                                                     // 9 numaralı kolonda ödünç bilgileri isimli bölüm gözüküyor bunu istemediğim için
                                                     // 9 numaralı kolonumu gizliyorum.
        }
        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {   // Burada listelenen kullanıcılardan istediğim birine mouse ile tıklayarak
            // textbox'larıma, datetimepicker'ıma ve radio butonlarıma bilgilerinin gelmesini sağlıyorum. 
            kullaniciAdGuncelle_txtbx.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            kullaniciSoyadGuncelle_txtbx.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            kullaniciTcGuncelle_txtbx.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            kullaniciTelGuncelle_txtbx.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            kullaniciDogumTarihiGuncelle_date.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            kullaniciKullaniciAdiGuncelle_txtbx.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            KullaniciSifreGuncelle_txtbx.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();

            if (dataGridView1.CurrentRow.Cells[5].Value.ToString() == "E")
            {
                radioErkek.Checked = true;
            }
            else
            {
                radioKadın.Checked = true;
            }
        }

        private void kaydet_btn_Click(object sender, EventArgs e)
        {   // Burada sadece adminlerin ve görevlilerin erişiminin olduğu kullanıcı güncelleme ekranına geliyoruz ve sırasıyla kullanıcı
            // Adı, Soyadı, Tc'si, Telefonu, Doğum tarihini, Kullanıcı adı ve şifresini ve cinsiyetini adminin veya görevlinin
            // textbox'lara, datetimepicker ve radio butonlarına girmesini sağlıyorum.
            int guncelleID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            var kullanici = sql.Kullanicilar.Where(x => x.kullanici_ID == guncelleID).FirstOrDefault();
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
            sql.SaveChanges(); // Bu kodla da kaydı güncelle butonuna basınca sql server'ımın bilgilerini güncelliyorum.
            var kullanicilar = sql.Kullanicilar.ToList();  //Burada ise kaydı güncelle butonuna tıkladığımda sql server'la bağlantımı kurup kullanıcıların
            dataGridView1.DataSource = kullanicilar.ToList();// bilgilerini datagridview'imde listeliyorum.
        }
    }
}
