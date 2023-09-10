using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IttırgecliGoturgec.YoneticiPanel
{
    public partial class KategoriEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_isim.Text))
            {
                Kategori k = new Kategori();
                k.Isim = tb_isim.Text;
                k.Aciklama = tb_aciklama.Text;

                if (dm.KategoriEkle(k))
                {
                    pnl_basarili.Visible = true;
                    pnl_hata.Visible = false;
                    lbl_mesaj.Text = "kategori başarıyla eklenmiştir";
                }
                else
                {
                    pnl_basarili.Visible = false;
                    pnl_hata.Visible = true;
                    lbl_mesaj.Text = "Kategori eklenirken bir hata oluştu";
                }
            }
            else
            {
                pnl_hata.Visible = true;
                lbl_mesaj.Text = "İsim boş bırakılamaz";
            }
        }
    }
}