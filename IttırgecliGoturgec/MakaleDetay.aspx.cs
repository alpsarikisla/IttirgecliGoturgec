using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IttırgecliGoturgec
{
    public partial class MakaleDetay : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                int ID = Convert.ToInt32(Request.QueryString["makaleid"]);
                Makale m = dm.MakaleGetir(ID);
                ltrl_baslik.Text = m.Baslik;
                ltrl_goruntuleme.Text = m.GoruntulemeSayi.ToString();
                ltrl_icerik.Text = m.Icerik;
                ltrl_kategori.Text = m.Kategori;
                ltrl_yazar.Text = m.Yazar;
                img_Resim.ImageUrl = "~/MakaleResimleri/" + m.KapakResim;

                rp_yorumlar.DataSource = dm.YorumListele(ID);
                rp_yorumlar.DataBind();

                if (Session["uye"] != null)
                {
                    pnl_girisvar.Visible = true;
                    pnl_girisyok.Visible = false;
                }
                else
                {
                    pnl_girisvar.Visible = false;
                    pnl_girisyok.Visible = true;
                }
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }

        protected void btn_yorumYap_Click(object sender, EventArgs e)
        {

        }
    }
}