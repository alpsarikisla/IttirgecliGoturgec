<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPanel/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="UyeListele.aspx.cs" Inherits="IttırgecliGoturgec.YoneticiPanel.UyeListele" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="panel">
      <div class="panelBaslik">
          <h3>Üye Listesi</h3>
      </div>
      <div class="panelIcerik" style="padding: 0">
          <asp:ListView ID="lv_uyeler" runat="server" >
              <LayoutTemplate>
                  <table cellpadding="0" cellspacing="0">
                      <tr>
                          <th>Isim Soyisim</th>
                           <th>Kullanıcı Adı</th>
                          <th>Üyelik Tarihi</th>
                          <th>Durum</th>
                          <th>Seçenekler</th>
                      </tr>
                      <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                  </table>
              </LayoutTemplate>
              <ItemTemplate>
                  <tr>
                      <td>
                          <%# Eval("Isim") %>  <%# Eval("Soyisim") %>
                      </td>
                      <td>
                          <%# Eval("KullaniciAdi") %>
                      </td>
                      <td>
                          <%# Eval("UyelikTarihStr") %>
                      </td>
                      <td>
                          <%# Eval("Aktif") %>
                      </td>
                      <td>
                          <a href='#' class="tablobutton duzenle">Durum Değiştir</a>
                          <asp:LinkButton ID="lbtn_sil" runat="server" CssClass="tablobutton sil" CommandName="sil" CommandArgument='<%# Eval("ID") %>'>Sil</asp:LinkButton>
                      </td>
                  </tr>
              </ItemTemplate>

          </asp:ListView>

      </div>
  </div>
</asp:Content>
