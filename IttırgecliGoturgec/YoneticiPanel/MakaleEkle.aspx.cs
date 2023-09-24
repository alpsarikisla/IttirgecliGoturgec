using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace IttırgecliGoturgec.YoneticiPanel
{
    public partial class MakaleEkle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddl_kategoriler.DataSource = dm.KategoriListele();
                ddl_kategoriler.DataBind();
            }
        }

        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tb_isim.Text))
            {
                Makale makale = new Makale();
                makale.Baslik = tb_isim.Text;
                makale.Kategori_ID = Convert.ToInt32(ddl_kategoriler.SelectedItem.Value);
                makale.Ozet = tb_ozet.Text;
                makale.Icerik = tb_icerik.Text;
                makale.Aktif = cb_yayinla.Checked;
                makale.EkelemeTarih = DateTime.Now;
                makale.GoruntulemeSayi = 0;
                makale.Bagenisayi = 0;
                Yonetici y = (Yonetici)Session["yon"];
                makale.Yazar_ID = y.ID;
                makale.Silinmis = false;
                bool UygunUzanti = true;
                if (fu_resim.HasFile)
                {
                    FileInfo fi = new FileInfo(fu_resim.FileName);
                    if (fi.Extension == ".jpg" || fi.Extension == ".png" || fi.Extension == ".gif")
                    {
                        string dosyaAdi = Guid.NewGuid().ToString();
                        string uzanti = fi.Extension;//.jpg,.png
                        fu_resim.SaveAs(Server.MapPath("~/MakaleResimleri/" + dosyaAdi + uzanti));
                        makale.KapakResim = dosyaAdi + uzanti;
                    }
                    else
                    {
                        UygunUzanti = false;
                    }
                }
                else
                {
                    makale.KapakResim = "none.jpg";
                }

                if (UygunUzanti)
                {
                    if (dm.MakaleEkle(makale))
                    {
                        pnl_basarili.Visible = true;
                        pnl_hata.Visible = false;
                    }
                    else
                    {
                        pnl_hata.Visible = true;
                        pnl_basarili.Visible = false;
                        lbl_mesaj.Text = "Bir Hata Oluştu";
                    }
                }
                else
                {
                    pnl_hata.Visible = true;
                    pnl_basarili.Visible = false;
                    lbl_mesaj.Text = "Resim uzantısı jpg, png, veya gif formatında olabilir";
                }
            }
            else
            {
                pnl_hata.Visible = true;
                pnl_basarili.Visible = false;
                lbl_mesaj.Text = "Makale başlığı boş bırakılamaz";
            }
        }
    }
}