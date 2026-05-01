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
    public partial class KitapSilmeEkrani : Form
    {
        Kutuphane_OtomasyonuEntities1 sql = new Kutuphane_OtomasyonuEntities1();  // Bu kod ile c# ve sql server arasındaki bağlantıyı sağlıyorum.
        public KitapSilmeEkrani()
        {
            InitializeComponent();
        }

        private void KitapSilmeEkrani_Load(object sender, EventArgs e)
        {
            Kitaplar kitap = new Kitaplar();      // Burada kitap silme butonuna bastığımızda datagridview'imde direkt olarak kitapların
            sql.Kitaplar.Add(kitap);             // listelenmesini sağlıyorum.
            var kitaplar = sql.Kitaplar.ToList();
            dataGridView1.DataSource = kitaplar.ToList();
            dataGridView1.Columns[10].Visible = false; // Bu satırda ise kitaplar ve ödünç bilgileri tablolarım birbiriyle bağlantılı olduğu için
                                                       // 10 numaralı kolonda ödünç bilgileri isimli bölüm gözüküyor bunu istemediğim için
                                                       // 10 numaralı kolonumu gizliyorum.
        }

        private void button1_Click(object sender, EventArgs e)
        {   // Burada listelenen kitaplardan istediğim birine mouse ile tıklayıp kaydı sil butonuna bastığımızda kitabın silinmesini sağlıyorum. 
            int silID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            var kitap = sql.Kitaplar.Where(x => x.kitap_ID == silID).FirstOrDefault();
            sql.Kitaplar.Remove(kitap);
            sql.SaveChanges(); // Burada kitabı sildikten sonra sql server'ımı güncelliyorum.
            var kitaplar = sql.Kitaplar.ToList();           //Burada kitabı silip kaydet butonuna bastığımızda kütüphanemde kalan
            dataGridView1.DataSource = kitaplar.ToList();   //tüm kitapların tekrar datagridview'imde listelenmesini sağlıyorum. 
        }
    }
}
