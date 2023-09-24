using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IttırgecliGoturgec.YoneticiPanel
{
    public partial class MakaleListele : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            lv_Makaleler.DataSource = dm.MakaleListele();
            lv_Makaleler.DataBind();
        }

        protected void lv_Makaleler_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "sil")
            {
                dm.MakaleSil(id);
            }
            lv_Makaleler.DataSource = dm.MakaleListele();
            lv_Makaleler.DataBind();
        }
    }
}