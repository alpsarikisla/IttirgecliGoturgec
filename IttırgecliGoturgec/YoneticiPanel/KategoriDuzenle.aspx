<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPanel/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="KategoriDuzenle.aspx.cs" Inherits="IttırgecliGoturgec.YoneticiPanel.KategoriDuzenle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel">
    <div class="panelBaslik">
        <h3>Kategori Düzenle</h3>
    </div>
    <div class="panelIcerik">
        <asp:Panel ID="pnl_basarili" runat="server" CssClass="basarili" Visible="false">
            Kategori Başarıyla Düzenlenmiştir
        </asp:Panel>
        <asp:Panel ID="pnl_hata" runat="server" CssClass="hata" Visible="false">
            <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
        </asp:Panel>
        <div class="satir">
            <label>Kategori Adı</label><br />
            <asp:TextBox ID="tb_isim" runat="server" CssClass="metinKutu"></asp:TextBox>
        </div>
        <div class="satir">
            <label>Kategori Açıklama</label><br />
            <asp:TextBox ID="tb_aciklama" runat="server" TextMode="MultiLine" CssClass="metinKutu"></asp:TextBox>
        </div>
        <div class="satir" style="margin: 25px 0px;">
            <asp:LinkButton ID="lbtn_duzenle" runat="server" CssClass="button" OnClick="lbtn_duzenle_Click">Kategori Düzenle</asp:LinkButton>
            <%-- <a href="" style="color:gray">kategoriler Listesine Dön</a>--%>
        </div>
    </div>
</div>
</asp:Content>
