# 📚 Kutuphane Otomasyonu
SQL SERVER ve C# kullanarak tasarladığım Kütüphane Otomasyon programım.
Bu proje, **C# (.NET 8)** ve **SQL Server** kullanılarak geliştirilmiş bir masaüstü **kütüphane yönetim sistemidir**.  
Kitap, üye ve ödünç işlemlerinin yönetimini kolaylaştırmak amacıyla hazırlanmıştır.

---

## 🚀 Özellikler
- 📘 Kitap ekleme, güncelleme ve silme
- 👤 Üye (kullanıcı) işlemleri
- 🔄 Kitap ödünç alma ve iade işlemleri
- 🔐 Giriş ekranı (Admin & Görevli & Kullanıcı)
- ⚙️ Veritabanı bağlantısı JSON yapılandırmasıyla yönetilir

---

## 🧩 Kurulum
1. Projeyi bilgisayarınıza klonlayın veya indirin.
2. `dbconfig.example.json` dosyasını kopyalayın ve adını `dbconfig.json` olarak değiştirin.
3. Dosya içindeki `Server` alanını kendi SQL Server adınıza göre düzenleyin:
   ```json
   {
     "Server": "YOUR_SERVER_NAME",
     "Database": "Kutuphane_Otomasyonu",
     "IntegratedSecurity": true,
     "Encrypt": true,
     "TrustServerCertificate": true
   }
