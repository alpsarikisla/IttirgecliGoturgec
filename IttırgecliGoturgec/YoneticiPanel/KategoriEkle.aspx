﻿<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPanel/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="KategoriEkle.aspx.cs" Inherits="IttırgecliGoturgec.YoneticiPanel.KategoriEkle" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel">
        <div class="panelBaslik">
            <h3>Kategori Ekle</h3>
        </div>
        <div class="panelIcerik">
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="basarili" Visible="false">
                Kategori Başarıyla Eklenmiştir
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
                <asp:LinkButton ID="lbtn_ekle" runat="server" CssClass="button" OnClick="lbtn_ekle_Click">Kategori Ekle</asp:LinkButton>
                <%-- <a href="" style="color:gray">kategoriler Listesine Dön</a>--%>
            </div>
        </div>
    </div>
</asp:Content>
