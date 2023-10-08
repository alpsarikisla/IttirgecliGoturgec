using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IttırgecliGoturgec
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            rp_kategoriler.DataSource = dm.KategoriListele();
            rp_kategoriler.DataBind();
            if (Session["uye"] == null)
            {
                pnl_girisyok.Visible = true;
                pnl_girisvar.Visible = false;
            }
            else
            {
                Uye u = Session["uye"] as Uye;
                lbtn_uye.Text = u.KullaniciAdi;
                pnl_girisyok.Visible = false;
                pnl_girisvar.Visible = true;
            }
        }

        protected void lbtn_uye_Click(object sender, EventArgs e)
        {
            Response.Redirect("Profil.aspx");
        }

        protected void lbtn_cikis_Click(object sender, EventArgs e)
        {
            Session["uye"] = null;
            Response.Redirect("Default.aspx");
        }
    }
}