<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="UyeGiris.aspx.cs" Inherits="IttırgecliGoturgec.UyeGiris" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <asp:Panel ID="pnl_basarisiz" runat="server" CssClass="basarisiz" Visible="false">
      <asp:Label ID="lbl_mesaj" runat="server">Şifreler Eşleşmiyor</asp:Label>
  </asp:Panel>
  <div class="uyelikPanel">
      <div class="satir">
          <h2>Üye Giriş Paneli</h2>
          <label>*Lütfen bilgileri eksiksiz doldurunuz</label>
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
          <asp:LinkButton ID="btn_giris" runat="server" CssClass="uyeButton" OnClick="btn_giris_Click">Giriş Yap </asp:LinkButton>
      </div>
  </div>
</asp:Content>
