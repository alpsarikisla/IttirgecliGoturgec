using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IttırgecliGoturgec.YoneticiPanel
{
    public partial class KategoriDuzenle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                if (!IsPostBack)
                {
                    int id = Convert.ToInt32(Request.QueryString["kid"]);
                    Kategori k = dm.kategoriGetir(id);
                    tb_isim.Text = k.Isim;
                    tb_aciklama.Text = k.Aciklama;
                }
            }
            else
            {
                Response.Redirect("KategoriListele.aspx");
            }
        }

        protected void lbtn_duzenle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["kid"]);
            Kategori k = new Kategori();
            k.ID = id;
            k.Isim = tb_isim.Text;
            k.Aciklama = tb_aciklama.Text;
            if (dm.KategoriDuzenle(k))
            {
                pnl_basarili.Visible = true;
            }
            else
            {
                pnl_hata.Visible = true;
                pnl_basarili.Visible = false;
                lbl_mesaj.Text = "Güncelleme esnasında hata oluştu";
            }
        }
    }
}