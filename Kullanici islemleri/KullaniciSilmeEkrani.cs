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
    public partial class KullaniciSilmeEkrani : Form
    {
        Kutuphane_OtomasyonuEntities1 sql = new Kutuphane_OtomasyonuEntities1();  // Bu kod ile c# ve sql server arasındaki bağlantıyı sağlıyorum.
        public KullaniciSilmeEkrani()
        {
            InitializeComponent();
        }

        private void KullaniciSilmeEkrani_Load(object sender, EventArgs e)
        {
            Kullanicilar kullanici = new Kullanicilar();    // Burada kullanıcı silme butonuna bastığımızda datagridview'imde direkt olarak 
            sql.Kullanicilar.Add(kullanici);               // kullanıcıların listelenmesini sağlıyorum.
            var kullanicilar = sql.Kullanicilar.ToList();
            dataGridView1.DataSource = kullanicilar.ToList();
            dataGridView1.Columns[9].Visible = false;// Bu satırda ise kullanıcılar ve ödünç bilgileri tablolarım birbiriyle bağlantılı olduğu için
                                                     // 9 numaralı kolonda ödünç bilgileri isimli bölüm gözüküyor bunu istemediğim için
                                                     // 9 numaralı kolonumu gizliyorum.
        }

        private void button1_Click(object sender, EventArgs e)
        {   // Burada listelenen kullanıcılardan istediğim birine mouse ile tıklayıp kaydı sil butonuna tıklayarak
            // trigger'ımı tetikleyip kullanıcının silinmesini sağlıyorum.
            int silID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            var kullanici = sql.Kullanicilar.FirstOrDefault(x => x.kullanici_ID == silID);
            if (kullanici != null)
            {
                sql.Kullanicilar.Remove(kullanici);  // Bu işlemle trigger'ın çalışmasını sağlıyorum.
                sql.SaveChanges(); // Bu kodla da kaydı sil butonuna basınca sql server'ımın bilgilerini güncelliyorum.
            }
            var kullanicilar = sql.Kullanicilar.ToList();  //Burada ise kaydı sil butonuna tıkladığımda sql server'la bağlantımı kurup kullanıcıların
            dataGridView1.DataSource = kullanicilar.ToList();// bilgilerini datagridview'imde listeliyorum.
        }
    }
}
