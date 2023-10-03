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
</asp:Content>
