<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UyeOl.aspx.cs" Inherits="IttırgecliGoturgec.UyeOl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Panel ID="pnl_basarili" runat="server" CssClass="basarili" Visible="false">
        <label>Üyelik Başarılı</label>
    </asp:Panel>
    <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisiz" Visible="false">
        <asp:Label ID="lbl_mesaj" runat="server">Şifreler Eşleşmiyor</asp:Label>
    </asp:Panel>
    <div class="uyelikPanel">
        <div class="satir">
            <h2>Üyelik Paneli</h2>
            <label>*Lütfen bilgileri eksiksiz doldurunuz</label>
        </div>
        <div class="satir">
            <label>Isim:</label><br />
            <asp:TextBox ID="tb_isim" runat="server" CssClass="metinKutu"></asp:TextBox>
        </div>

        <div class="satir">
            <label>Soyisim:</label><br />
            <asp:TextBox ID="tb_soyisim" runat="server" CssClass="metinKutu"></asp:TextBox>
        </div>
        <div class="satir">
            <label>Kullanıcı Adı:</label><br />
            <asp:TextBox ID="tb_kullaniciAdi" runat="server" CssClass="metinKutu"></asp:TextBox>
        </div>
        <div class="satir">
            <label>Mail:</label><br />
            <asp:TextBox ID="tb_mail" runat="server" CssClass="metinKutu"></asp:TextBox>
        </div>
        <div class="satir">
            <label>Şifre:</label><br />
            <asp:TextBox ID="tb_sifre" runat="server" CssClass="metinKutu" TextMode="Password"></asp:TextBox>
        </div>
        <div class="satir">
            <label>Şifre Tekrar:</label><br />
            <asp:TextBox ID="tb_sifretekrar" runat="server" CssClass="metinKutu" TextMode="Password"></asp:TextBox>
        </div>
        <div class="satir">
            <asp:LinkButton ID="btn_uyeOl" runat="server" CssClass="uyeButton" OnClick="btn_uyeOl_Click">Üye Ol </asp:LinkButton>
        </div>
    </div>
</asp:Content>
