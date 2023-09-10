<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPanel/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="KategoriListele.aspx.cs" Inherits="IttırgecliGoturgec.YoneticiPanel.KategoriListele" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel">
        <div class="panelBaslik">
            <h3>Kategori Listesi</h3>
        </div>
        <div class="panelIcerik" style="padding: 0">
            <asp:ListView ID="lv_Kategoriler" runat="server" OnItemCommand="lv_Kategoriler_ItemCommand">
                <LayoutTemplate>
                    <table cellpadding="0" cellspacing="0">
                        <tr>
                            <th>ID</th>
                            <th>Isim</th>
                            <th>Açıklama</th>
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
                            <%# Eval("Isim") %>
                        </td>
                        <td>
                            <%# Eval("Aciklama") %>
                        </td>
                        <td>
                            <a href="KategoriDuzenle.aspx" class="tablobutton duzenle">Düzenle</a>
                           <asp:LinkButton ID="lbtn_sil" runat="server" CssClass="tablobutton sil" CommandName="sil" CommandArgument='<%# Eval("ID") %>'>Sil</asp:LinkButton>
                        </td>
                    </tr>
                </ItemTemplate>
                <AlternatingItemTemplate>
                    <tr class="alt">
                        <td>
                            <%# Eval("ID") %>
                        </td>
                        <td>
                            <%# Eval("Isim") %>
                        </td>
                        <td>
                            <%# Eval("Aciklama") %>
                        </td>
                        <td>
                            <a href='KategoriDuzenle.aspx?kid=<%# Eval("ID") %>' class="tablobutton duzenle">Düzenle</a>
                            <asp:LinkButton ID="lbtn_sil" runat="server" CssClass="tablobutton sil" CommandName="sil" CommandArgument='<%# Eval("ID") %>'>Sil</asp:LinkButton>
                        </td>
                    </tr>
                </AlternatingItemTemplate>
            </asp:ListView>

        </div>
    </div>
</asp:Content>
