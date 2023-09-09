using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IttırgecliGoturgec.YoneticiPanel
{
    public partial class YoneticiMaster1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["yon"] != null)
            {
                Yonetici y = (Yonetici)Session["yon"];
                lbl_kullanici.Text = y.KullaniciAdi + "(" + y.Isim + ")";
            }
            else
            {
                Response.Redirect("Giris.aspx");
            }
        }

        protected void lbtn_cikis_Click(object sender, EventArgs e)
        {
            Session["yon"] = null;
            Response.Redirect("Giris.aspx");
        }
    }
}