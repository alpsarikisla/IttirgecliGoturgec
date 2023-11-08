using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class DataModel
    {
        SqlConnection con;SqlCommand cmd;
        public DataModel()
        {
            con = new SqlConnection(ConnectionStrings.ConStr);
            cmd = con.CreateCommand();
        }

        #region Giriş İşlemleri

        public Yonetici YoneticiKontrol(string kullaniciAdi, string sifre)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Yoneticiler WHERE KullaniciAdi=@kadi AND Sifre=@sfr";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@kadi", kullaniciAdi);
                cmd.Parameters.AddWithValue("@sfr", sifre);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                if (sayi > 0)
                {
                    cmd.CommandText = "SELECT * FROM Yoneticiler WHERE KullaniciAdi=@kadi AND Sifre=@sfr";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@kadi", kullaniciAdi);
                    cmd.Parameters.AddWithValue("@sfr", sifre);

                    SqlDataReader reader = cmd.ExecuteReader();
                    Yonetici y = new Yonetici();
                    while (reader.Read())
                    {
                        y.ID = reader.GetInt32(0);
                        y.YoneticiTur_ID = reader.GetInt32(1);
                        y.Isim = reader.GetString(2);
                        y.Soyisim = reader.GetString(3);
                        y.KullaniciAdi = reader.GetString(4);
                        y.Mail = reader.GetString(5);
                        y.Sifre = reader.GetString(6);
                        if (!reader.IsDBNull(7))
                        {
                            y.Telefon = reader.GetString(7);
                        }
                        y.OlusturmaTarihi = reader.GetDateTime(8);
                        y.Aktif = reader.GetBoolean(9);
                        y.Silinmis = reader.GetBoolean(10);
                    }
                    return y;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                con.Close();
            }
            
        }

        public Uye UyeGiris(string mail, string sifre)
        {
            try
            {
                cmd.CommandText = "SELECT COUNT(*) FROM Uyeler WHERE Mail=@mail AND Sifre=@sfr";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@mail", mail);
                cmd.Parameters.AddWithValue("@sfr", sifre);
                con.Open();
                int sayi = Convert.ToInt32(cmd.ExecuteScalar());
                if (sayi > 0)
                {
                    cmd.CommandText = "SELECT * FROM Uyeler WHERE Mail=@mail AND Sifre=@sfr";
                    cmd.Parameters.Clear();
                    cmd.Parameters.AddWithValue("@mail", mail);
                    cmd.Parameters.AddWithValue("@sfr", sifre);

                    SqlDataReader reader = cmd.ExecuteReader();
                    Uye y = new Uye();
                    while (reader.Read())
                    {
                        y.ID = reader.GetInt32(0);
                        y.Isim = reader.GetString(1);
                        y.Soyisim = reader.GetString(2);
                        y.KullaniciAdi = reader.GetString(3);
                        y.Mail = reader.GetString(4);
                        y.Sifre = reader.GetString(5);
                        y.UyelikTarihi = reader.GetDateTime(6);
                        y.Aktif = reader.GetBoolean(7);
                        y.Silinmis = reader.GetBoolean(8);
                    }
                    return y;
                }
                else
                {
                    return null;
                }

            }
            catch (Exception)
            {
                return null;
            }
            finally
            {
                con.Close();
            }

        }

        #endregion

        #region Kategori Metotları

        public bool KategoriEkle(Kategori model)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Kategoriler(Isim, Aciklama) VALUES(@i,@a)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@i", model.Isim);
                cmd.Parameters.AddWithValue("@a", model.Aciklama);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Kategori> KategoriListele()
        {
            List<Kategori> kategoriler = new List<Kategori>();
            try
            {
                cmd.CommandText = "SELECT ID,Isim,Aciklama FROM Kategoriler";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Kategori k = new Kategori();
                    k.ID = reader.GetInt32(0);
                    k.Isim = reader.GetString(1);
                    k.Aciklama = !reader.IsDBNull(2) ? reader.GetString(2) : "";
                    kategoriler.Add(k);
                }
                return kategoriler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public void KategoriSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Kategoriler WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }

        public Kategori kategoriGetir(int id)
        {
           
            try
            {
                cmd.CommandText = "SELECT ID, Isim, Aciklama FROM Kategoriler WHERE ID= @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Kategori k = new Kategori();
                while (reader.Read())
                {
                    k.ID = reader.GetInt32(0);
                    k.Isim = reader.GetString(1);
                    k.Aciklama = !reader.IsDBNull(2) ? reader.GetString(2) : "";
                }
                return k;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool KategoriDuzenle(Kategori kat)
        {
            try
            {
                cmd.CommandText = "UPDATE Kategoriler SET Isim =@i, Aciklama =@a WHERE ID=@id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", kat.ID);
                cmd.Parameters.AddWithValue("@i", kat.Isim);
                cmd.Parameters.AddWithValue("@a", kat.Aciklama);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Makale Metotları

        public bool MakaleEkle(Makale mak)
        {
            try
            {
                cmd.CommandText = "INSERT INTO Makaleler(KategoriID, YazarID, Baslik, Ozet, Icerik, KapakResmi, EklemeTarihi,BegeniSayi, GoruntulemeSayi, Aktif, Silinmis) VALUES(@kategoriID, @yazarID, @baslik, @ozet, @icerik, @kapakResmi, @eklemeTarihi,@begeniSayi,@goruntulemeSayi, @aktif, @silinmis)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@kategoriID", mak.Kategori_ID);
                cmd.Parameters.AddWithValue("@yazarID", mak.Yazar_ID);
                cmd.Parameters.AddWithValue("@baslik", mak.Baslik);
                cmd.Parameters.AddWithValue("@ozet", mak.Ozet);
                cmd.Parameters.AddWithValue("@icerik", mak.Icerik);
                cmd.Parameters.AddWithValue("@kapakResmi", mak.KapakResim);
                cmd.Parameters.AddWithValue("@eklemeTarihi", mak.EkelemeTarih);
                cmd.Parameters.AddWithValue("@begeniSayi", mak.Bagenisayi);
                cmd.Parameters.AddWithValue("@goruntulemeSayi", mak.GoruntulemeSayi);
                cmd.Parameters.AddWithValue("@aktif", mak.Aktif);
                cmd.Parameters.AddWithValue("@silinmis", mak.Silinmis);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Makale> MakaleListele()
        {
            List<Makale> makaleler = new List<Makale>();
            try
            {
                cmd.CommandText = "SELECT M.ID, M.KategoriID, K.Isim, M.YazarID, Y.KullaniciAdi, M.Baslik, M.Ozet, M.Icerik, M.KapakResmi, M.EklemeTarihi, M.GuncellenmeTarihi, M.BegeniSayi, M.GoruntulemeSayi, M.Aktif, M.silinmis FROM Makaleler AS M JOIN Kategoriler AS K ON M.KategoriID = K.ID JOIN Yoneticiler AS Y ON M.YazarID = Y.ID";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Makale mak = new Makale();
                    mak.ID = reader.GetInt32(0);
                    mak.Kategori_ID = reader.GetInt32(1);
                    mak.Kategori = reader.GetString(2);
                    mak.Yazar_ID = reader.GetInt32(3);
                    mak.Yazar = reader.GetString(4);
                    mak.Baslik = reader.GetString(5);
                    mak.Ozet = reader.GetString(6);
                    mak.Icerik = reader.GetString(7);
                    mak.KapakResim = reader.GetString(8);
                    mak.EkelemeTarih = reader.GetDateTime(9);
                    if (!reader.IsDBNull(10))
                    {
                        mak.GuncellemeTarih = reader.GetDateTime(10);
                    }
                    mak.Bagenisayi = reader.IsDBNull(11) ? 0 : reader.GetInt32(11);
                    mak.GoruntulemeSayi = reader.IsDBNull(12) ? 0 : reader.GetInt32(12);
                    mak.Aktif = reader.GetBoolean(13);
                    mak.Silinmis = reader.GetBoolean(14);
                    makaleler.Add(mak);
                }
                return makaleler;

            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public Makale MakaleGetir(int id)
        {
            try
            {
                cmd.CommandText = "SELECT M.ID, M.KategoriID, K.Isim, M.YazarID, Y.KullaniciAdi, M.Baslik, M.Ozet, M.Icerik, M.KapakResmi, M.EklemeTarihi, M.GuncellenmeTarihi, M.BegeniSayi, M.GoruntulemeSayi, M.Aktif, M.silinmis FROM Makaleler AS M JOIN Kategoriler AS K ON M.KategoriID = K.ID JOIN Yoneticiler AS Y ON M.YazarID = Y.ID WHERE M.ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                Makale mak = new Makale();
                while (reader.Read())
                {
                   
                    mak.ID = reader.GetInt32(0);
                    mak.Kategori_ID = reader.GetInt32(1);
                    mak.Kategori = reader.GetString(2);
                    mak.Yazar_ID = reader.GetInt32(3);
                    mak.Yazar = reader.GetString(4);
                    mak.Baslik = reader.GetString(5);
                    mak.Ozet = reader.GetString(6);
                    mak.Icerik = reader.GetString(7);
                    mak.KapakResim = reader.GetString(8);
                    mak.EkelemeTarih = reader.GetDateTime(9);
                    if (!reader.IsDBNull(10))
                    {
                        mak.GuncellemeTarih = reader.GetDateTime(10);
                    }
                    mak.Bagenisayi = reader.IsDBNull(11) ? 0 : reader.GetInt32(11);
                    mak.GoruntulemeSayi = reader.IsDBNull(12) ? 0 : reader.GetInt32(12);
                    mak.Aktif = reader.GetBoolean(13);
                    mak.Silinmis = reader.GetBoolean(14);
                    
                }
                return mak;

            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public bool MakaleGuncelle(Makale mak)
        {
            try
            {
                cmd.CommandText = "UPDATE Makaleler SET KategoriID = @kategoriID, Baslik = @baslik, Ozet=@ozet, Icerik = @icerik, KapakResmi=@kapakresmi, GuncellenmeTarihi=@guncellemeTarihi, Aktif=@aktif WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", mak.ID);
                cmd.Parameters.AddWithValue("@kategoriID", mak.Kategori_ID);
                cmd.Parameters.AddWithValue("@baslik", mak.Baslik);
                cmd.Parameters.AddWithValue("@ozet", mak.Ozet);
                cmd.Parameters.AddWithValue("@icerik", mak.Icerik);
                cmd.Parameters.AddWithValue("@kapakresmi", mak.KapakResim);
                cmd.Parameters.AddWithValue("@guncellemeTarihi", mak.GuncellemeTarih);
                cmd.Parameters.AddWithValue("@aktif", mak.Aktif);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;

            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public void MakaleSil(int id)
        {
            try
            {
                cmd.CommandText = "DELETE FROM Makaleler WHERE ID = @id";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);
                con.Open();
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Üye Metotları

        public bool UyeOl(Uye model)
        {
           
            try
            {
                cmd.CommandText = "INSERT INTO Uyeler(Isim,Soyisim,KullaniciAdi,Mail,Sifre,UyelikTarihi,Aktif,Silinmis) VALUES(@isim,@soyisim,@kullaniciAdi,@mail,@sifre,@uyelikTarihi,@aktif,@silinmis)";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@isim", model.Isim);
                cmd.Parameters.AddWithValue("@soyisim", model.Soyisim);
                cmd.Parameters.AddWithValue("@kullaniciAdi", model.KullaniciAdi);
                cmd.Parameters.AddWithValue("@mail", model.Mail);
                cmd.Parameters.AddWithValue("@sifre", model.Sifre);
                cmd.Parameters.AddWithValue("@uyelikTarihi", model.UyelikTarihi);
                cmd.Parameters.AddWithValue("@aktif", model.Aktif);
                cmd.Parameters.AddWithValue("@silinmis", model.Silinmis);
                con.Open();
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Uye> UyeListele()
        {
            try
            {
                List<Uye> uyeler = new List<Uye>();
                cmd.CommandText = "SELECT ID, Isim, Soyisim, KullaniciAdi, Mail, UyelikTarihi, Aktif, Silinmis FROM Uyeler";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Uye u = new Uye();
                    u.ID = reader.GetInt32(0);
                    u.Isim = reader.GetString(1);
                    u.Mail = reader.GetString(4);
                    u.Soyisim = reader.GetString(2);
                    u.UyelikTarihi = reader.GetDateTime(5);
                    u.UyelikTarihStr = reader.GetDateTime(5).ToShortDateString();
                    u.KullaniciAdi = reader.GetString(3);
                    u.Aktif = reader.GetBoolean(6);
                    u.Silinmis = reader.GetBoolean(7);
                    uyeler.Add(u);
                }
                return uyeler;
            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion

        #region Yorum Metotları

        public List<Yorum> YorumListele()
        {
            List<Yorum> yorumlar = new List<Yorum>();
            try
            {
                cmd.CommandText = "SELECT Y.ID, Y.MakaleID, M.Baslik, Y.UyeID, U.KullaniciAdi, Y.YorumTarihi,Y.Icerik,Y.Onayli FROM Yorumlar AS Y JOIN Makaleler AS M ON Y.MakaleID=M.ID JOIN Uyeler AS U ON Y.UyeID = U.ID";
                cmd.Parameters.Clear();
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Yorum yorum = new Yorum();
                    yorum.ID = reader.GetInt32(0);
                    yorum.MakaleID = reader.GetInt32(1);
                    yorum.Makale = reader.GetString(2);
                    yorum.UyeID = reader.GetInt32(3);
                    yorum.Uye = reader.GetString(4);
                    yorum.YorumTarihi = reader.GetDateTime(5);
                    yorum.Icerik = reader.GetString(6);
                    yorum.Onayli = reader.GetBoolean(7);
                    yorumlar.Add(yorum);
                }
                return yorumlar;

            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        public List<Yorum> YorumListele(int MakaleID)
        {
            List<Yorum> yorumlar = new List<Yorum>();
            try
            {
                cmd.CommandText = "SELECT Y.ID, Y.MakaleID, M.Baslik, Y.UyeID, U.KullaniciAdi, Y.YorumTarihi,Y.Icerik,Y.Onayli FROM Yorumlar AS Y JOIN Makaleler AS M ON Y.MakaleID=M.ID JOIN Uyeler AS U ON Y.UyeID = U.ID WHERE Y.MakaleID=@id AND Y.Onayli = 1";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", MakaleID);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Yorum yorum = new Yorum();
                    yorum.ID = reader.GetInt32(0);
                    yorum.MakaleID = reader.GetInt32(1);
                    yorum.Makale = reader.GetString(2);
                    yorum.UyeID = reader.GetInt32(3);
                    yorum.Uye = reader.GetString(4);
                    yorum.YorumTarihi = reader.GetDateTime(5);
                    yorum.Icerik = reader.GetString(6);
                    yorum.Onayli = reader.GetBoolean(7);
                    yorumlar.Add(yorum);
                }
                return yorumlar;

            }
            catch
            {
                return null;
            }
            finally
            {
                con.Close();
            }
        }

        #endregion
    }
}
