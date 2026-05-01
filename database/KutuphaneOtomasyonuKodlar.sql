USE Kutuphane_Otomasyonu

ALTER PROCEDURE UP_StokDurumunuAzaltma
    @kullanici_ID INT,       -- Burada Ödünç alan kullanıcının ID'si
    @kitap_ID INT,           -- Ödünç alınacak kitabın ID'si
    @verilisTarihi DATETIME, -- Kitabın ödünç veriliş tarihi
    @sonTarih DATETIME       -- Kitabın son teslim tarihi bilgileri için değişkenlerimi belirliyorum.
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY
        -- Burada kitap stok kontrolünü sağlıyorum.
        IF EXISTS ( SELECT 1 FROM Kitaplar WHERE kitap_ID = @kitap_ID AND kitap_StokDurumu > 0 )
        BEGIN
            -- OduncBilgileri tablosuna ödünç alma kaydı ekliyorum.
            INSERT INTO OduncBilgileri (kullanici_ID, kitap_ID, odunc_VerilisTarihi, odunc_SonTarih, odunc_Durumu)
            VALUES (@kullanici_ID, @kitap_ID, @verilisTarihi, @sonTarih, 0)
            -- Burada kitap stoğunu azaltmak için kodumu yazıyorum.
            UPDATE Kitaplar
            SET kitap_StokDurumu = kitap_StokDurumu - 1
            WHERE kitap_ID = @kitap_ID
            -- İşlem başarılı olursa COMMIT TRANSACTION çalışıyor ve 'Kitap başarıyla ödünç alındı.' mesajını çıktımda yazdırıyorum.
            COMMIT TRANSACTION
            PRINT 'Kitap başarıyla ödünç alındı.'
        END
        ELSE
        BEGIN
            -- Stoğun yetersizse işlem gerçekleşemez ve 'Seçilen kitabın stoğu yetersiz!' mesajını çıktımda yazdırıyorum.
            ROLLBACK TRANSACTION
            PRINT 'Seçilen kitabın stoğu yetersiz!'
        END
    END TRY
    BEGIN CATCH
        -- Eğer bir hata oluşursa ROLLBACK TRANSACTION çalışıyor ve 'Bir hata oluştu: ' mesajıyla birlikte Error bilgisini çıktımda yazdırıyorum.
        ROLLBACK TRANSACTION
        PRINT 'Bir hata oluştu: ' + ERROR_MESSAGE()
    END CATCH
END


EXEC UP_StokDurumunuAzaltma @kullanici_ID = 5, @kitap_ID = 3017, @verilisTarihi = '2025-01-02', @sonTarih = '2025-01-15'
EXEC UP_StokDurumunuAzaltma @kullanici_ID = 2, @kitap_ID = 3016, @verilisTarihi = '2025-01-05', @sonTarih = '2025-01-20'
EXEC UP_StokDurumunuAzaltma @kullanici_ID = 2, @kitap_ID = 3016, @verilisTarihi = '2025-01-02', @sonTarih = '2025-01-15'
EXEC UP_StokDurumunuAzaltma @kullanici_ID = 3, @kitap_ID = 3016, @verilisTarihi = '2025-01-02', @sonTarih = '2025-01-15'
EXEC UP_StokDurumunuAzaltma @kullanici_ID = 1002, @kitap_ID = 3016, @verilisTarihi = '2025-01-02', @sonTarih = '2025-01-15'
EXEC UP_StokDurumunuAzaltma @kullanici_ID = 2002, @kitap_ID = 3016, @verilisTarihi = '2025-01-02', @sonTarih = '2025-01-15'
EXEC UP_StokDurumunuAzaltma @kullanici_ID = 2005, @kitap_ID = 3016, @verilisTarihi = '2025-01-02', @sonTarih = '2025-01-15'
EXEC UP_StokDurumunuAzaltma @kullanici_ID = 5010, @kitap_ID = 3016, @verilisTarihi = '2025-01-02', @sonTarih = '2025-01-15'
EXEC UP_StokDurumunuAzaltma @kullanici_ID = 7003, @kitap_ID = 3016, @verilisTarihi = '2025-01-02', @sonTarih = '2025-01-15'
EXEC UP_StokDurumunuAzaltma @kullanici_ID = 5, @kitap_ID = 3016, @verilisTarihi = '2025-01-02', @sonTarih = '2025-01-15'
EXEC UP_StokDurumunuAzaltma @kullanici_ID = 5, @kitap_ID = 3016, @verilisTarihi = '2025-01-02', @sonTarih = '2025-01-15'


ALTER PROCEDURE UP_StokDurumunuArtırma
    @odunc_ID INT  -- Burada Ödünç işlemine ait odunc_ID değişkenimi belirliyorum.
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY
        -- Burada ödünç kaydını kontrol ediyorum.
        IF EXISTS ( SELECT 1 FROM OduncBilgileri WHERE odunc_ID = @odunc_ID AND odunc_Durumu = 0)
        BEGIN
            -- Ödünç bilgileri üzerinden kitap ID'sini alıyorum.
            DECLARE @kitap_ID INT
            SELECT @kitap_ID = kitap_ID FROM OduncBilgileri WHERE odunc_ID = @odunc_ID
            --Burada Kitap stoğunu bir artırmak için kodumu yazıyorum.
            UPDATE Kitaplar
            SET kitap_StokDurumu = kitap_StokDurumu + 1
            WHERE kitap_ID = @kitap_ID
            -- Burada ödünç durumunu güncelleyen kodumu yazıyorum.
            UPDATE OduncBilgileri
            SET odunc_Durumu = 1
            WHERE odunc_ID = @odunc_ID
            -- İşlem başarılı olursa COMMIT TRANSACTION çalışıyor ve 'Kitap başarıyla teslim edildi.' mesajını çıktımda yazdırıyorum.
            COMMIT TRANSACTION
            PRINT 'Kitap başarıyla teslim edildi.'
        END
        ELSE
        BEGIN
            -- Ödünç kaydı bulunamazsa veya zaten teslim edilmişse ROLLBACK TRANSACTION çalışıyor ve 'Geçersiz ödünç kaydı veya kitap zaten teslim edilmiş!' mesajını çıktımda yazdırıyorum.
            ROLLBACK TRANSACTION
            PRINT 'Geçersiz ödünç kaydı veya kitap zaten teslim edilmiş!'
        END
    END TRY
    BEGIN CATCH
        -- Eğer bir hata oluşursa ROLLBACK TRANSACTION çalışıyor ve 'Bir hata oluştu: ' mesajıyla birlikte Error bilgisini çıktımda yazdırıyorum.
        ROLLBACK TRANSACTION
        PRINT 'Bir hata oluştu: ' + ERROR_MESSAGE()
    END CATCH
END

EXEC UP_StokDurumunuArtırma @odunc_ID = 3010
EXEC UP_StokDurumunuArtırma @odunc_ID = 3006
EXEC UP_StokDurumunuArtırma @odunc_ID = 3007
EXEC UP_StokDurumunuArtırma @odunc_ID = 3008
EXEC UP_StokDurumunuArtırma @odunc_ID = 3009
EXEC UP_StokDurumunuArtırma @odunc_ID = 3005
EXEC UP_StokDurumunuArtırma @odunc_ID = 3011
EXEC UP_StokDurumunuArtırma @odunc_ID = 3012
EXEC UP_StokDurumunuArtırma @odunc_ID = 3013
EXEC UP_StokDurumunuArtırma @odunc_ID = 3014
EXEC UP_StokDurumunuArtırma @odunc_ID = 5016

SELECT * FROM Kullanicilar

ALTER TRIGGER TRG_KullaniciSilmekIcin
ON [dbo].[Kullanicilar]
INSTEAD OF DELETE
AS
BEGIN
    DECLARE @kullaniciID INT		-- Burada ihtiyacım olan değişkenleri tanımlıyorum.
    DECLARE kullanici CURSOR FOR	-- Burada deleted tablosundaki tüm kullanıcıları işlemek için cursor komutunu kullanıyorum.
    SELECT [kullanici_ID] FROM deleted
    OPEN kullanici
    FETCH NEXT FROM kullanici INTO @kullaniciID
    WHILE @@FETCH_STATUS = 0
    BEGIN
        DELETE FROM [dbo].[OduncBilgileri] WHERE [kullanici_ID] = @kullaniciID	 -- Burada OduncBilgileri tablosundan silmek için kodumu yazıyorum.
																				 --Kullanıcılar tablomla OduncBilgileri tablom beraber çalıştığı için OduncBilgileri tablomuda temizliyorum.
        DELETE FROM [dbo].[Kullanicilar] WHERE [kullanici_ID] = @kullaniciID	-- Burada Kullanicilar tablosundan silmek için kodumu yazıyorum.   
        PRINT 'Kullanıcı ve ödünç bilgileri silindi: Kullanıcı ID ' + CAST(@kullaniciID AS VARCHAR) + '.'
        FETCH NEXT FROM kullanici INTO @kullaniciID
    END
    CLOSE kullanici
    DEALLOCATE kullanici
END
ALTER TABLE [dbo].[OduncBilgileri]
DROP CONSTRAINT [FK_OduncBilgileri_Kullanicilar]  
ALTER TABLE [dbo].[OduncBilgileri]
ADD CONSTRAINT FK_OduncBilgileri_Kullanicilar
FOREIGN KEY (kullanici_ID)
REFERENCES [dbo].[Kullanicilar](kullanici_ID)
ON DELETE CASCADE

DELETE FROM Kullanicilar WHERE kullanici_ID = 2005
DELETE FROM Kullanicilar WHERE kullanici_ID = 3
DELETE FROM Kullanicilar WHERE kullanici_ID = 1002
SELECT * FROM Kullanicilar
SELECT * FROM OduncBilgileri
SELECT * FROM Kitaplar

SP_HELPTEXT UP_StokDurumunuAzaltma
SP_HELPTEXT UP_StokDurumunuArtırma
