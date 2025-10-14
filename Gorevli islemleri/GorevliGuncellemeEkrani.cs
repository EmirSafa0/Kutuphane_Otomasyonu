using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kutuphane_Otomasyonu.Gorevli
{
    public partial class GorevliGuncellemeEkrani : Form
    {
        Kutuphane_OtomasyonuEntities1 sql = new Kutuphane_OtomasyonuEntities1();  // Bu kod ile c# ve sql server arasındaki bağlantıyı sağlıyorum.
        public GorevliGuncellemeEkrani()
        {
            InitializeComponent();
        }

        private void GorevliGuncellemeEkrani_Load(object sender, EventArgs e)
        {
            Gorevliler gorevliler = new Gorevliler();    // Burada görevli güncelleme butonuna bastığımızda datagridview'imde direkt olarak görevlilerin
            sql.Gorevliler.Add(gorevliler);             // listelenmesini sağlıyorum.                         
            var gorevli = sql.Gorevliler.ToList();
            dataGridView1.DataSource = gorevli.ToList();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {   // Burada listelenen görevlilerden istediğim birine mouse ile tıklayarak textbox'larıma bilgilerinin gelmesini sağlıyorum. 
            gorevliAdGuncelle_txtbx.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            gorevliSoyadGuncelle_txtbx.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            gorevliTcGuncelle_txtbx.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            gorevliTelGuncelle_txtbx.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            gorevliKullaniciAdGuncelle_txtbx.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            gorevliKullaniciSifreGuncelle_txtbx.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
        }

        private void kaydet_btn_Click(object sender, EventArgs e)
        {   // Burada sadece adminin erişiminin olduğu görevli güncelleme ekranına geliyoruz ve sırasıyla görevli Adı, Soyadı, Tc'si, Telefonu,
            // Kullanıcı adı ve şifresini adminin textbox'lara girmesini sağlıyorum.
            int guncelleID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            var gorevliler = sql.Gorevliler.Where(x => x.gorevli_ID == guncelleID).FirstOrDefault();
            gorevliler.gorevli_Adi = gorevliAdGuncelle_txtbx.Text;
            gorevliler.gorevli_Soyadi = gorevliSoyadGuncelle_txtbx.Text;
            gorevliler.gorevli_TC = gorevliTcGuncelle_txtbx.Text;
            gorevliler.gorevli_TelefonNumarasi = gorevliTelGuncelle_txtbx.Text;
            gorevliler.gorevli_KullaniciAdi = gorevliKullaniciAdGuncelle_txtbx.Text;
            gorevliler.gorevli_KullaniciSifresi = gorevliKullaniciSifreGuncelle_txtbx.Text;

            sql.SaveChanges(); // Bu kodla da sql server'ımdaki bilgileri güncelliyorum.
            var gorevli = sql.Gorevliler.ToList(); 
            dataGridView1.DataSource = gorevli.ToList();// Burada ise güncellenmiş haliyle görevli bilgilerinin tekrar datagridview'imde listelenmesini sağlıyorum.
        }
    }
}
