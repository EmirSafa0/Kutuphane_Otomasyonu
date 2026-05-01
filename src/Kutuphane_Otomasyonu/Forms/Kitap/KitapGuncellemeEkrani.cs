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
    public partial class KitapGuncellemeEkrani : Form
    {
        Kutuphane_OtomasyonuEntities1 sql = new Kutuphane_OtomasyonuEntities1();  // Bu kod ile c# ve sql server arasındaki bağlantıyı sağlıyorum.
        public KitapGuncellemeEkrani()
        {
            InitializeComponent();
        }

        private void KitapGuncellemeEkrani_Load(object sender, EventArgs e)
        {
            Kitaplar kitap = new Kitaplar();      // Burada kitap guncelleme butonuna bastığımızda datagridview'imde direkt olarak kitapların
            sql.Kitaplar.Add(kitap);             // listelenmesini sağlıyorum.
            var kitaplar = sql.Kitaplar.ToList();
            dataGridView1.DataSource = kitaplar.ToList();
            dataGridView1.Columns[10].Visible = false; // Bu satırda ise kitaplar ve ödünç bilgileri tablolarım birbiriyle bağlantılı olduğu için
                                                       // 10 numaralı kolonda ödünç bilgileri isimli bölüm gözüküyor bunu istemediğim için
                                                       // 10 numaralı kolonumu gizliyorum.
        }


        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {   // Burada listelenen kitaplardan istediğim birine mouse ile tıklayarak textbox'larıma bilgilerinin gelmesini sağlıyorum. 
            kitapAdGuncelle_txtbx.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            kitapYazarGuncelle_txtbx.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            kitapTurGuncelle_txtbx.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            kitapDilGuncelle_txtbx.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            kitapSayfaSayisiGuncelle_txtbx.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            kitapYayinTarihiGuncelle_txtbx.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            kitapYayineviGuncelle_txtbx.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
            kitapKayitTarihiGuncelle_txtbx.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
            kitapStokDurumuGuncelle_txtbx.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
        }

        private void kaydet_btn_Click(object sender, EventArgs e)
        {   // Burada sadece adminlerin ve görevlilerin erişiminin olduğu kitap guncelleme ekranına geliyoruz ve mouse ile seçtiğim kitabın
            // Adı, Yazarı, Türü, Dili, Sayfa sayısı, Yayın tarihi, Yayınevi, Kayıt tarihi ve Stok durumunu adminin veya görevlinin textbox'lara
            // girmesini sağlıyorum.
            int guncelleID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            var kitap = sql.Kitaplar.Where(x => x.kitap_ID == guncelleID).FirstOrDefault();
            kitap.kitap_Adi = kitapAdGuncelle_txtbx.Text;
            kitap.kitap_Yazar = kitapYazarGuncelle_txtbx.Text;
            kitap.kitap_Turu=kitapTurGuncelle_txtbx.Text;
            kitap.kitap_Dili = kitapDilGuncelle_txtbx.Text;
            kitap.kitap_SayfaSayisi = Convert.ToInt32(kitapSayfaSayisiGuncelle_txtbx.Text);
            kitap.kitap_YayinTarihi = Convert.ToInt32(kitapYayinTarihiGuncelle_txtbx.Text);
            kitap.kitap_Yayinevi = kitapYayineviGuncelle_txtbx.Text;
            kitap.kitap_KayitTarihi = Convert.ToInt32(kitapKayitTarihiGuncelle_txtbx.Text);
            kitap.kitap_StokDurumu = Convert.ToInt32(kitapStokDurumuGuncelle_txtbx.Text);

            sql.SaveChanges(); // Bilgileri güncelledikten sonra kaydet butonuna basıyoruz ve bu kodla sql server'ımı güncelliyorum.
            var kitaplar = sql.Kitaplar.ToList();           //Burada verileri girip kaydet butonuna bastığımızda güncellenen kitap bilgisiyle
            dataGridView1.DataSource = kitaplar.ToList();   //beraber tüm kitapların tekrar datagridview'imde listelenmesini sağlıyorum. 
        }
    }
}
