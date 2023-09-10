using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IttırgecliGoturgec.YoneticiPanel
{
    public partial class KategoriListele : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_Kategoriler.DataSource = dm.KategoriListele();
            lv_Kategoriler.DataBind();
        }

        protected void lv_Kategoriler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "sil")
            {
                int id = Convert.ToInt32(e.CommandArgument);
                dm.KategoriSil(id);
            }

            lv_Kategoriler.DataSource = dm.KategoriListele();
            lv_Kategoriler.DataBind();
        }
    }
}