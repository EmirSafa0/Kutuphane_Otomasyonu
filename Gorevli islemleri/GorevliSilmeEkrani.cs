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
    public partial class GorevliSilmeEkrani : Form
    {
        Kutuphane_OtomasyonuEntities1 sql = new Kutuphane_OtomasyonuEntities1();  // Bu kod ile c# ve sql server arasındaki bağlantıyı sağlıyorum.
        public GorevliSilmeEkrani()
        {
            InitializeComponent();
        }

        private void GorevliSilmeEkrani_Load(object sender, EventArgs e)
        {
            Gorevliler gorevliler = new Gorevliler();    // Burada görevli silme butonuna bastığımızda datagridview'imde direkt olarak görevlilerin
            sql.Gorevliler.Add(gorevliler);             // listelenmesini sağlıyorum.
            var gorevli = sql.Gorevliler.ToList();
            dataGridView1.DataSource = gorevli.ToList();
        }

        private void kaydet_btn_Click(object sender, EventArgs e)
        {   // Burada listelenen görevlilerden istediğim birine mouse ile tıklayıp kaydı sil butonuna tıklayarak görevlinin silinmesini sağlıyorum.
            int silID = Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value);
            var gorevliler = sql.Gorevliler.Where(x => x.gorevli_ID == silID).FirstOrDefault();
            sql.Gorevliler.Remove(gorevliler); 
            sql.SaveChanges();// Göreliyi sildikten sonra sql server'ımı güncelliyorum.
            var gorevli = sql.Gorevliler.ToList();
            dataGridView1.DataSource = gorevli.ToList();// Burada ise güncellenmiş haliyle görevli bilgilerinin tekrar datagridview'imde listelenmesini sağlıyorum.
        }
    }
}
