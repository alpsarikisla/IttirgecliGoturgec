using DataAccessLayer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IttırgecliGoturgec.YoneticiPanel
{
    public partial class MakaleDuzenle : System.Web.UI.Page
    {
        DataModel dm = new DataModel();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.QueryString.Count != 0)
            {
                if (!IsPostBack)
                {
                    ddl_kategoriler.DataSource = dm.KategoriListele();
                    ddl_kategoriler.DataBind();


                    int id = Convert.ToInt32(Request.QueryString["mid"]);
                    Makale mak = dm.MakaleGetir(id);
                    ddl_kategoriler.SelectedValue = Convert.ToString(mak.Kategori_ID);
                    tb_isim.Text = mak.Baslik;
                    tb_ozet.Text = mak.Ozet;
                    tb_icerik.Text = mak.Icerik;
                    cb_yayinla.Checked = mak.Aktif;
                    img_resim.ImageUrl = "~/MakaleResimleri/" + mak.KapakResim;
                }
            }
            else
            {
                Response.Redirect("MakaleListele.aspx");
            }
        }

        protected void lbtn_ekle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(Request.QueryString["mid"]);
            Makale mak = dm.MakaleGetir(id);
            mak.Baslik = tb_isim.Text;
            mak.Kategori_ID = Convert.ToInt32(ddl_kategoriler.SelectedItem.Value);
            mak.Ozet = tb_ozet.Text;
            mak.Icerik = tb_icerik.Text;
            mak.Aktif = cb_yayinla.Checked;
            mak.GuncellemeTarih = DateTime.Now;
            bool UygunUzanti = true;
            if (fu_resim.HasFile)
            {
                FileInfo fi = new FileInfo(fu_resim.FileName);
                if (fi.Extension == ".jpg" || fi.Extension == ".png" || fi.Extension == ".gif")
                {
                    string dosyaAdi = Guid.NewGuid().ToString();
                    string uzanti = fi.Extension;//.jpg,.png
                    fu_resim.SaveAs(Server.MapPath("~/MakaleResimleri/" + dosyaAdi + uzanti));
                    mak.KapakResim = dosyaAdi + uzanti;
                }
                else
                {
                    UygunUzanti = false;
                }
            }

            if (UygunUzanti)
            {
                if (dm.MakaleGuncelle(mak))
                {
                    pnl_basarili.Visible = true;
                    pnl_hata.Visible = false;
                }
                else
                {
                    pnl_hata.Visible = true;
                    pnl_basarili.Visible = false;
                    lbl_mesaj.Text = "Makale güncellenirken bir hata oluştu";
                }
            }
            else
            {
                pnl_hata.Visible = true;
                pnl_basarili.Visible = false;
                lbl_mesaj.Text = "Resim uzantısı jpg, png, veya gif formatında olabilir";
            }
        }
    }
}