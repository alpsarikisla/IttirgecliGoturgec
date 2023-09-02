CREATE DATABASE IttirgecliGoturgec_DB
GO
USE IttirgecliGoturgec_DB
GO
CREATE TABLE YoneticiTurleri
(
	ID int IDENTITY(1,1),
	Isim nvarchar(50) NOT NULL,
	CONSTRAINT pk_yoneticiTur PRIMARY KEY(ID)
)
GO
INSERT INTO YoneticiTurleri(Isim) VALUES('Admin')
INSERT INTO YoneticiTurleri(Isim) VALUES('Moderatör')
GO
CREATE TABLE Yoneticiler
(
	ID int IDENTITY(1,1),
	YoneticiTurID int,
	Isim nvarchar(50) NOT NULL,
	Soyisim nvarchar(50),
	KullaniciAdi nvarchar(50) NOT NULL,
	Mail nvarchar(150) NOT NULL,
	Sifre nvarchar(18) NOT NULL,
	Telefon nvarchar(11),
	OlusturmaTarihi Date,
	Aktif bit,
	silinmis bit,
	CONSTRAINT pk_yonetici PRIMARY KEY(ID),
	CONSTRAINT fk_yoneticiYoneticiTur FOREIGN KEY(YoneticiTurID) 
	REFERENCES YoneticiTurleri(ID)
)
GO
INSERT INTO Yoneticiler
(YoneticiTurID, Isim, Soyisim, KullaniciAdi, Mail, Sifre,OlusturmaTarihi, Aktif, silinmis)
VALUES(1, 'Alp', 'Sarýkýþla', 'Alpod', 'alpsarikisla@hotmail.com', '1234', '2023/09/02',1,0)
GO
CREATE TABLE Kategoriler
(
	ID int IDENTITY(1,1),
	Isim nvarchar(50) NOT NULL,
	Aciklama nvarchar(700),
	CONSTRAINT pk_kategori PRIMARY KEY(ID),
)
GO
CREATE TABLE Makaleler
(
	ID int IDENTITY(1,1),
	KategoriID int,
	YazarID int,
	Baslik nvarchar(250) NOT NULL,
	Ozet nvarchar(250),
	Icerik nvarchar(max),
	KapakResmi nvarchar(75),
	EklemeTarihi DateTime,
	GuncellenmeTarihi Datetime,
	BegeniSayi int,
	GoruntulemeSayi int,
	Aktif bit,
	silinmis bit,
	CONSTRAINT pk_Makale PRIMARY KEY(ID),
	CONSTRAINT fk_makaleKategori FOREIGN KEY(KategoriID) REFERENCES Kategoriler (ID),
	CONSTRAINT fk_MakaleYazar FOREIGN KEY(YazarID) REFERENCES Yoneticiler(ID)
)
GO
CREATE TABLE Uyeler
(
	ID int IDENTITY(1,1),
	Isim nvarchar(50) NOT NULL,
	Soyisim nvarchar(50),
	KullaniciAdi nvarchar(50) NOT NULL,
	Mail nvarchar(150) NOT NULL,
	Sifre nvarchar(18) NOT NULL,
	UyelikTarihi Date,
	Aktif bit,
	silinmis bit,
	CONSTRAINT pk_uye PRIMARY KEY(ID)
)
GO
CREATE TABLE Yorumlar
(
	ID int IDENTITY(1,1),
	MakaleID int NOT NULL,
	UyeID int NOT NULL,
	YorumTarihi Date NOT NULL,
	Onayli bit,
	YoneticiID int,
	CONSTRAINT pk_Yorum PRIMARY KEY(ID),
	CONSTRAINT fk_yorumMakale FOREIGN KEY(MakaleID) REFERENCES Makaleler (ID),
	CONSTRAINT fk_yorumUye FOREIGN KEY(UyeID) REFERENCES Uyeler(ID),
	CONSTRAINT fk_yorumYonetici FOREIGN KEY(YoneticiID) REFERENCES Yoneticiler(ID)
)