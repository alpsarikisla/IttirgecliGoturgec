using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IttırgecliGoturgec.Yonetici
{
    public partial class Giris : System.Web.UI.Page
    {
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