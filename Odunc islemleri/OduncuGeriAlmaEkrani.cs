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
    public partial class OduncuGeriAlmaEkrani : Form
    {
        Kutuphane_OtomasyonuEntities1 sql = new Kutuphane_OtomasyonuEntities1();  // Bu kod ile c# ve sql server arasındaki bağlantıyı sağlıyorum.
        public OduncuGeriAlmaEkrani()
        {
            InitializeComponent();
        }

        private void OduncuGeriAlmaEkrani_Load(object sender, EventArgs e)
        {
            var oduncler = sql.OduncBilgileri.Where(x => x.odunc_Durumu == false).ToList(); // Burada sadece kullanıcıda olan kitapların listelenmesini sağlıyorum.
            dataGridView1.DataSource = oduncler.ToList();                                   
            dataGridView1.Columns[6].Visible = false;   // Bu satırda ise kitaplar,  kullanıcılar ve ödünç bilgileri tablolarım birbiriyle bağlantılı olduğu için
            dataGridView1.Columns[7].Visible = false;  // 6 ve 7 numaralı kolonda kitaplar ve kullanıcılar isimli bölüm gözüküyor bunu istemediğim için
                                                       // 6 ve 7 numaralı kolonumu gizliyorum.
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                int secilen_OduncID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value); // Burada ödünç kaydı seçiyorum.
                var oduncID = new SqlParameter("@odunc_ID", secilen_OduncID);// Burada değerimi belirliyorum.
                //Burada sql server'ımda yazmış olduğum 'UP_StokDurumunuArtırma' SP'mi çağırıyorum ve belirlediğim değeri SP'imdeki değerle ilişkilendiriyorum.
                sql.Database.ExecuteSqlCommand("EXEC UP_StokDurumunuArtırma @odunc_ID", oduncID);
                var oduncKaydi = sql.OduncBilgileri.FirstOrDefault(x => x.odunc_ID == secilen_OduncID);
                if (oduncKaydi != null)
                {
                    oduncKaydi.odunc_Durumu = true;// Burada Ödünç durumunu güncelliyorum.
                    sql.SaveChanges();
                }

                // Burada kitabı teslim aldıktan sonra stoğun artırıldığına ve ödüncün geri alındığına dair ekrana mesaj yolluyorum.
                MessageBox.Show("Stok başarıyla artırıldı ve ödünç geri alındı!", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Burada güncel ödünç bilgilerimi datagridview1'te listeliyorum.
                var oduncler = sql.OduncBilgileri.Where(x => x.odunc_Durumu == false).ToList();
                dataGridView1.DataSource = oduncler.ToList();
            }
            catch (Exception ex)
            {
                // Burada işlem gerçekleşmezse bir hata mesajı yolluyorum.
                MessageBox.Show("Bir hata oluştu: " + ex.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
