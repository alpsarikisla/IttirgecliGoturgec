<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="MakaleDetay.aspx.cs" Inherits="IttırgecliGoturgec.MakaleDetay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="makale">
        <div class="baslik">
            <h3>
                <asp:Literal ID="ltrl_baslik" runat="server"></asp:Literal></h3>
        </div>
        <div class="resim">
            <asp:Image ID="img_Resim" runat="server" />
        </div>
        <div class="altbaslik">
            Yazar :<asp:Literal ID="ltrl_yazar" runat="server"></asp:Literal>| Kategori :<asp:Literal ID="ltrl_kategori" runat="server"></asp:Literal>
            | Görüntüleme Sayı :
            <asp:Literal ID="ltrl_goruntuleme" runat="server"></asp:Literal>
        </div>
        <div class="ozet">
            <asp:Literal ID="ltrl_icerik" runat="server"></asp:Literal>
            <br />
        </div>
    </div>
    <div class="yorumpanel">
        <asp:Panel ID="pnl_girisyok" runat="server">
            <h3>Yorum yapabilmek için <a href="UyeGiris.aspx">üye girişi</a> yapmanız gerekmektedir</h3>
        </asp:Panel>
        <asp:Panel ID="pnl_girisvar" runat="server" Visible="false">
            <div class="uyelikPanel">
                <asp:Panel ID="pnl_basarili" runat="server" CssClass="basarili" Visible="false">
                    <label>Yorum ekleme Başarılı</label>
                </asp:Panel>
                <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisiz" Visible="false">
                    <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
                </asp:Panel>
                <div class="satir">
                    <h2>Yorum Paneli</h2>
                </div>
                <div class="satir">
                    <label>Yorum Bırakın:</label><br />
                    <asp:TextBox ID="tb_isim" runat="server" CssClass="metinKutu" TextMode="MultiLine"></asp:TextBox>
                </div>
                <div class="satir">
                    <asp:LinkButton ID="btn_yorumYap" runat="server" CssClass="uyeButton" OnClick="btn_yorumYap_Click">Yorum Yap </asp:LinkButton>
                </div>
            </div>
        </asp:Panel>

    </div>
</asp:Content>
