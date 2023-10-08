using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IttırgecliGoturgec
{
    public partial class UyeOl : System.Web.UI.Page
    {
        DataModel dm = new DataModel();

        protected void Page_Load(object sender, EventArgs e)
        {
            //tb_isim.BorderColor = Color.Red;
        }

        protected void btn_uyeOl_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_sifre.Text))
            {
                if (tb_sifre.Text == tb_sifretekrar.Text)
                {
                    Uye u = new Uye();
                    u.Isim = tb_isim.Text;
                    u.Soyisim = tb_soyisim.Text;
                    u.UyelikTarihi = DateTime.Now;
                    u.Aktif = true;
                    u.Silinmis = false;
                    u.KullaniciAdi = tb_kullaniciAdi.Text;
                    u.Sifre = tb_sifre.Text;
                    u.Mail = tb_mail.Text;

                    if (dm.UyeOl(u))
                    {
                        pnl_basarili.Visible = true;
                    }
                    else
                    {
                        pnl_basarili.Visible = false;
                        pnl_basarisiz.Visible = true;
                        lbl_mesaj.Text = "Bir Hata oluştu. Lütfen daha sonra tekrar deneyiniz";
                    }
                }
                else
                {
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "Girdiğiniz şifreler Eşleşmiyor";
                    tb_sifre.BorderColor = Color.Red;
                    tb_sifretekrar.BorderColor = Color.Red;
                }
            }
            else
            {
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Alan Boş Bırakılamaz";
                tb_sifre.BorderColor = Color.Red;
            }
        }
    }
}