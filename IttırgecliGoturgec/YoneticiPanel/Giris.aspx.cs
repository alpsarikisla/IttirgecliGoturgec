using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IttırgecliGoturgec.YoneticiPanel
{
    public partial class Giris : System.Web.UI.Page
    {
        DataModel db = new DataModel();
        //Event(Olay) İşlem gerçekleştiğinde(Tetiklendiğinde yapılacak olanlar bu alana yazılır)
        protected void Page_Load(object sender, EventArgs e)
        {
            ////Sayfa açılırken ilk olarak page load çalışır
            //this.Title = "Page Load Çalıştı";
            ////lbl_isim.Text = "Ali Veli mı? öyle mi yazalım";

            //Random rnd = new Random();
            //lbl_isim.Text = Convert.ToString(rnd.Next());
            pnl_hata.Visible = false;
        }

        protected void lbtn_giris_Click(object sender, EventArgs e)
        {
            //lbtn Giris Butonuna basılın çalışacak
            if (!(string.IsNullOrEmpty(tb_isim.Text) && string.IsNullOrEmpty(tb_sifre.Text)))
            {
                if (tb_isim.Text.Length >= 3)
                {
                    Yonetici y = db.YoneticiKontrol(tb_isim.Text, tb_sifre.Text);
                    if (y != null)
                    {
                        if (y.Aktif)
                        {
                            Session["yon"] = y;//BOXING
                            Response.Redirect("Anasayfa.aspx");
                        }
                        else
                        {
                            pnl_hata.Visible = true;
                            lbl_hata.Text = "Hesabınız yönetici tarafından askıya alınmıştır";
                        }
                    }
                    else
                    {
                        pnl_hata.Visible = true;
                        lbl_hata.Text = "Kullanıcı Bulunamadı. Kullanıcı Adı ve şifreyi kontrol ediniz";
                    }
                }
                else
                {
                    pnl_hata.Visible = true;
                    lbl_hata.Text = "Kullanıcı Adı 3 karakterden az olamaz";
                }
            }
            else
            {
                pnl_hata.Visible = true;
                lbl_hata.Text = "Kullanıcı Adı Şifre Boş olamaz";
            }
        }
    }
}