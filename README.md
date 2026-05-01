# 📚 Kütüphane Otomasyonu

![C#](https://img.shields.io/badge/C%23-.NET%208-blue)
![SQL Server](https://img.shields.io/badge/Database-SQL%20Server-red)
![Status](https://img.shields.io/badge/Status-Active-success)
![License](https://img.shields.io/badge/License-MIT-green)

SQL Server ve C# kullanılarak geliştirilmiş bu proje, masaüstü ortamda çalışan kapsamlı bir **kütüphane yönetim sistemidir**. Sistem; kitap, kullanıcı ve ödünç işlemlerini merkezi bir yapı üzerinden yönetmeyi amaçlar.

Bu çalışma, **.NET 8**, **Entity Framework** ve **SQL Server** teknolojileri kullanılarak geliştirilmiş olup, rol bazlı erişim kontrolü içeren gerçekçi bir otomasyon örneğidir.

---

## 🎯 Amaç

Bu projenin amacı:

* Kütüphane yönetim süreçlerini dijital ortama taşımak
* Kullanıcı, görevli ve admin rollerini ayrıştırarak yetki bazlı bir yapı kurmak
* CRUD işlemlerini (Create, Read, Update, Delete) etkin şekilde uygulamak
* Veritabanı ile entegre çalışan bir masaüstü uygulama geliştirmek

---

## 🚀 Özellikler

* 📘 **Kitap Yönetimi**

  * Kitap ekleme, güncelleme ve silme
  * Kitap bilgilerini detaylı görüntüleme

* 👤 **Kullanıcı Yönetimi**

  * Kullanıcı ekleme, güncelleme ve silme
  * Kullanıcı bilgilerini listeleme

* 🧑‍💼 **Görevli Yönetimi**

  * Görevli ekleme, güncelleme ve silme
  * Yetkili kullanıcı kontrolü

* 🔄 **Ödünç İşlemleri**

  * Kitap ödünç verme
  * Kitap iade alma
  * Ödünç geçmişini görüntüleme

* 🔐 **Rol Bazlı Giriş Sistemi**

  * Admin
  * Görevli
  * Kullanıcı

* ⚙️ **Yapılandırılabilir Veritabanı**

  * JSON tabanlı bağlantı ayarları

---

## 🧠 Teknik Detaylar

* Katmanlı mimari (UI - Data - Entity)
* Entity Framework ile ORM kullanımı
* LINQ ile veri sorgulama
* JSON tabanlı konfigürasyon yönetimi
* Role-based authorization (Admin / Görevli / Kullanıcı)

---

## 🖼️ Uygulama Ekran Görüntüleri

### 🔐 Giriş Ekranı

Kullanıcıların rol bazlı olarak sisteme giriş yaptığı ekran.

![Login](docs/screenshots/login.png)

### 🧑‍💼 Admin Paneli

Sistemin genel yönetim ekranı.

![Admin Panel](docs/screenshots/admin-panel.png)

### 👤 Kullanıcı İşlemleri

Kullanıcı ekleme, güncelleme ve listeleme işlemleri.

![Kullanıcı İşlemleri](docs/screenshots/kullanici-islemleri.png)

### 🧑‍💼 Görevli İşlemleri

Görevli yönetimi ve yetkilendirme işlemleri.

![Görevli İşlemleri](docs/screenshots/gorevli-islemleri.png)

### 📘 Kitap İşlemleri

Kütüphanedeki kitapların yönetimi.

![Kitap İşlemleri](docs/screenshots/kitap-islemleri.png)

### 🔄 Ödünç İşlemleri

Kitap ödünç verme ve iade işlemleri.

![Ödünç İşlemleri](docs/screenshots/odunc-islemleri.png)

---

## 🛠️ Kullanılan Teknolojiler

* **Programlama Dili:** C# (.NET 8)
* **Veritabanı:** Microsoft SQL Server
* **ORM:** Entity Framework
* **Arayüz:** Windows Forms (WinForms)
* **Veri İşleme:** LINQ

---

## 🧩 Kurulum

1. Bu repoyu bilgisayarınıza klonlayın:

```bash
git clone https://github.com/EmirSafa0/Kutuphane_Otomasyonu.git
```

2. `dbconfig.example.json` dosyasını kopyalayın ve adını:

```
dbconfig.json
```

olarak değiştirin.

3. İçeriğini kendi SQL Server ayarlarınıza göre düzenleyin:

```json
{
  "Server": "YOUR_SERVER_NAME",
  "Database": "Kutuphane_Otomasyonu",
  "IntegratedSecurity": true,
  "Encrypt": true,
  "TrustServerCertificate": true
}
```

4. SQL Server üzerinde veritabanını oluşturun:

* `database` klasöründeki `.sql` scriptlerini çalıştırın
* veya `.bak` dosyasını restore edin

5. Visual Studio ile `.sln` dosyasını açın ve projeyi çalıştırın.

---

## ⚠️ Notlar

* Proje yeniden yapılandırılırken bazı dosyalar klasör yapısına taşınmıştır.
* Namespace yapıları geliştirme ortamına göre güncellenmesi gerekebilir.
* `.csproj.user` dosyası kullanıcıya özeldir ve farklı ortamlarda değişiklik gösterebilir.

---

## 📌 Proje Yapısı

```
📁 src/
 └── Kutuphane_Otomasyonu/
      ├── Data/
      │    └── Models/
      ├── Entities/
      ├── Forms/
      ├── Helpers/

📁 database/
📁 config/
📁 docs/screenshots/
```

---

## 👨‍💻 Geliştirici

**Emir Safa Kaymakçı**

Bu proje, yazılım geliştirme sürecinde veri tabanı entegrasyonu, katmanlı yapı ve kullanıcı arayüzü geliştirme becerilerini göstermek amacıyla hazırlanmıştır.

---

## 📄 Lisans

Bu proje **MIT Lisansı** ile lisanslanmıştır.
