<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="IttırgecliGoturgec.Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:Repeater ID="rp_makaleler" runat="server">
        <ItemTemplate>
            <div class="makale">
                <div class="baslik">
                    <h3><%# Eval("Baslik") %></h3>
                </div>
                <div class="resim">
                    <img src='MakaleResimleri/<%# Eval("KapakResim") %>' />
                </div>
                <div class="altbaslik">
                    Yazar : <%# Eval("Yazar") %> | Kategori : <%# Eval("Kategori") %> | Görüntüleme Sayı : <%# Eval("GoruntulemeSayi") %>
                </div>
                <div class="ozet">
                    <%# Eval("Ozet") %>
                    <br />
                    <a href='MakaleDetay.aspx?makaleid=<%# Eval("ID")  %>'>Devamı...</a>
                </div>
            </div>
        </ItemTemplate>
    </asp:Repeater>
</asp:Content>
