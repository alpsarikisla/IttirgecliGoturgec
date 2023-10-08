using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IttırgecliGoturgec
{
    public partial class UyeGiris : System.Web.UI.Page
    {
        DataModel db = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btn_giris_Click(object sender, EventArgs e)
        {
            if (!(string.IsNullOrEmpty(tb_mail.Text) && string.IsNullOrEmpty(tb_sifre.Text)))
            {
                if (tb_mail.Text.Length >= 3)
                {
                    Uye u = db.UyeGiris(tb_mail.Text, tb_sifre.Text);
                    if (u != null)
                    {
                        if (u.Aktif)
                        {
                            Session["uye"] = u;
                            Response.Redirect("Default.aspx");
                        }
                        else
                        {
                            pnl_basarisiz.Visible = true;
                            lbl_mesaj.Text = "Hesabınız yönetici tarafından askıya alınmıştır";
                        }
                    }
                    else
                    {
                        pnl_basarisiz.Visible = true;
                        lbl_mesaj.Text = "Kullanıcı Bulunamadı. Mail Adresi ve şifreyi kontrol ediniz";
                    }
                }
                else
                {
                    pnl_basarisiz.Visible = true;
                    lbl_mesaj.Text = "mail adresi 3 karakterden az olamaz";
                }
            }
            else
            {
                pnl_basarisiz.Visible = true;
                lbl_mesaj.Text = "Mail Adresi Şifre Boş olamaz";
            }
        }
    }
}