USE Kutuphane_Otomasyonu

ALTER PROCEDURE UP_StokDurumunuAzaltma
    @kullanici_ID INT,       -- Burada Ödünç alan kullanýcýnýn ID'si
    @kitap_ID INT,           -- Ödünç alýnacak kitabýn ID'si
    @verilisTarihi DATETIME, -- Kitabýn ödünç veriliþ tarihi
    @sonTarih DATETIME       -- Kitabýn son teslim tarihi bilgileri için deðiþkenlerimi belirliyorum.
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY
        -- Burada kitap stok kontrolünü saðlýyorum.
        IF EXISTS ( SELECT 1 FROM Kitaplar WHERE kitap_ID = @kitap_ID AND kitap_StokDurumu > 0 )
        BEGIN
            -- OduncBilgileri tablosuna ödünç alma kaydý ekliyorum.
            INSERT INTO OduncBilgileri (kullanici_ID, kitap_ID, odunc_VerilisTarihi, odunc_SonTarih, odunc_Durumu)
            VALUES (@kullanici_ID, @kitap_ID, @verilisTarihi, @sonTarih, 0)
            -- Burada kitap stoðunu azaltmak için kodumu yazýyorum.
            UPDATE Kitaplar
            SET kitap_StokDurumu = kitap_StokDurumu - 1
            WHERE kitap_ID = @kitap_ID
            -- Ýþlem baþarýlý olursa COMMIT TRANSACTION çalýþýyor ve 'Kitap baþarýyla ödünç alýndý.' mesajýný çýktýmda yazdýrýyorum.
            COMMIT TRANSACTION
            PRINT 'Kitap baþarýyla ödünç alýndý.'
        END
        ELSE
        BEGIN
            -- Stoðun yetersizse iþlem gerçekleþemez ve 'Seçilen kitabýn stoðu yetersiz!' mesajýný çýktýmda yazdýrýyorum.
            ROLLBACK TRANSACTION
            PRINT 'Seçilen kitabýn stoðu yetersiz!'
        END
    END TRY
    BEGIN CATCH
        -- Eðer bir hata oluþursa ROLLBACK TRANSACTION çalýþýyor ve 'Bir hata oluþtu: ' mesajýyla birlikte Error bilgisini çýktýmda yazdýrýyorum.
        ROLLBACK TRANSACTION
        PRINT 'Bir hata oluþtu: ' + ERROR_MESSAGE()
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


ALTER PROCEDURE UP_StokDurumunuArtýrma
    @odunc_ID INT  -- Burada Ödünç iþlemine ait odunc_ID deðiþkenimi belirliyorum.
AS
BEGIN
    BEGIN TRANSACTION
    BEGIN TRY
        -- Burada ödünç kaydýný kontrol ediyorum.
        IF EXISTS ( SELECT 1 FROM OduncBilgileri WHERE odunc_ID = @odunc_ID AND odunc_Durumu = 0)
        BEGIN
            -- Ödünç bilgileri üzerinden kitap ID'sini alýyorum.
            DECLARE @kitap_ID INT
            SELECT @kitap_ID = kitap_ID FROM OduncBilgileri WHERE odunc_ID = @odunc_ID
            --Burada Kitap stoðunu bir artýrmak için kodumu yazýyorum.
            UPDATE Kitaplar
            SET kitap_StokDurumu = kitap_StokDurumu + 1
            WHERE kitap_ID = @kitap_ID
            -- Burada ödünç durumunu güncelleyen kodumu yazýyorum.
            UPDATE OduncBilgileri
            SET odunc_Durumu = 1
            WHERE odunc_ID = @odunc_ID
            -- Ýþlem baþarýlý olursa COMMIT TRANSACTION çalýþýyor ve 'Kitap baþarýyla teslim edildi.' mesajýný çýktýmda yazdýrýyorum.
            COMMIT TRANSACTION
            PRINT 'Kitap baþarýyla teslim edildi.'
        END
        ELSE
        BEGIN
            -- Ödünç kaydý bulunamazsa veya zaten teslim edilmiþse ROLLBACK TRANSACTION çalýþýyor ve 'Geçersiz ödünç kaydý veya kitap zaten teslim edilmiþ!' mesajýný çýktýmda yazdýrýyorum.
            ROLLBACK TRANSACTION
            PRINT 'Geçersiz ödünç kaydý veya kitap zaten teslim edilmiþ!'
        END
    END TRY
    BEGIN CATCH
        -- Eðer bir hata oluþursa ROLLBACK TRANSACTION çalýþýyor ve 'Bir hata oluþtu: ' mesajýyla birlikte Error bilgisini çýktýmda yazdýrýyorum.
        ROLLBACK TRANSACTION
        PRINT 'Bir hata oluþtu: ' + ERROR_MESSAGE()
    END CATCH
END

EXEC UP_StokDurumunuArtýrma @odunc_ID = 3010
EXEC UP_StokDurumunuArtýrma @odunc_ID = 3006
EXEC UP_StokDurumunuArtýrma @odunc_ID = 3007
EXEC UP_StokDurumunuArtýrma @odunc_ID = 3008
EXEC UP_StokDurumunuArtýrma @odunc_ID = 3009
EXEC UP_StokDurumunuArtýrma @odunc_ID = 3005
EXEC UP_StokDurumunuArtýrma @odunc_ID = 3011
EXEC UP_StokDurumunuArtýrma @odunc_ID = 3012
EXEC UP_StokDurumunuArtýrma @odunc_ID = 3013
EXEC UP_StokDurumunuArtýrma @odunc_ID = 3014
EXEC UP_StokDurumunuArtýrma @odunc_ID = 5016

SELECT * FROM Kullanicilar

ALTER TRIGGER TRG_KullaniciSilmekIcin
ON [dbo].[Kullanicilar]
INSTEAD OF DELETE
AS
BEGIN
    DECLARE @kullaniciID INT		-- Burada ihtiyacým olan deðiþkenleri tanýmlýyorum.
    DECLARE kullanici CURSOR FOR	-- Burada deleted tablosundaki tüm kullanýcýlarý iþlemek için cursor komutunu kullanýyorum.
    SELECT [kullanici_ID] FROM deleted
    OPEN kullanici
    FETCH NEXT FROM kullanici INTO @kullaniciID
    WHILE @@FETCH_STATUS = 0
    BEGIN
        DELETE FROM [dbo].[OduncBilgileri] WHERE [kullanici_ID] = @kullaniciID	 -- Burada OduncBilgileri tablosundan silmek için kodumu yazýyorum.
																				 --Kullanýcýlar tablomla OduncBilgileri tablom beraber çalýþtýðý için OduncBilgileri tablomuda temizliyorum.
        DELETE FROM [dbo].[Kullanicilar] WHERE [kullanici_ID] = @kullaniciID	-- Burada Kullanicilar tablosundan silmek için kodumu yazýyorum.   
        PRINT 'Kullanýcý ve ödünç bilgileri silindi: Kullanýcý ID ' + CAST(@kullaniciID AS VARCHAR) + '.'
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
SP_HELPTEXT UP_StokDurumunuArtýrma