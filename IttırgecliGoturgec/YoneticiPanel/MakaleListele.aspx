<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPanel/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="MakaleListele.aspx.cs" Inherits="IttırgecliGoturgec.YoneticiPanel.MakaleListele"  %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel">
        <div class="panelBaslik">
            <h3>Makale Listesi</h3>
        </div>
        <div class="panelIcerik" style="padding: 0">
            <asp:ListView ID="lv_Makaleler" runat="server" OnItemCommand="lv_Makaleler_ItemCommand">
                <LayoutTemplate>
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <th>ID</th>
                            <th>Isim</th>
                            <th>Kategori</th>
                            <th>Yazar</th>
                            <th>Ekleme Tarihi</th>
                            <th>Görüntüleme Sayi</th>
                             <th>Durum</th>
                            <th>Seçenekler</th>
                        </tr>
                        <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <%# Eval("ID") %>
                        </td>
                        <td>
                            <%# Eval("Baslik") %>
                        </td>
                        <td>
                            <%# Eval("Kategori") %>
                        </td>
                        <td>
                            <%# Eval("Yazar") %>
                        </td>
                        <td>
                            <%# Eval("EkelemeTarih") %>
                        </td>
                        <td>
                            <%# Eval("GoruntulemeSayi") %>
                        </td>
                        <td>
                             <%# Eval("Aktif") %>
                        </td>
                        <td>
                            <a href='MakaleDuzenle.aspx?mid=<%# Eval("ID") %>' class="tablobutton duzenle">Düzenle</a>
                            <asp:LinkButton ID="lbtn_sil" runat="server" CssClass="tablobutton sil" CommandName="sil" CommandArgument='<%# Eval("ID") %>'>Sil</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>

            </asp:ListView>

        </div>
    </div>
</asp:Content>
