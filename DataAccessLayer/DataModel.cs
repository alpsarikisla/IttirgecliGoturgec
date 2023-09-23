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
            return true;
        }

        #endregion
    }
}
