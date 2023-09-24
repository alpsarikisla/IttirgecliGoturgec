<%@ Page Title="" Language="C#" MasterPageFile="~/YoneticiPanel/YoneticiMaster.Master" AutoEventWireup="true" CodeBehind="MakaleDuzenle.aspx.cs" Inherits="IttırgecliGoturgec.YoneticiPanel.MakaleDuzenle" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="panel">
        <div class="panelBaslik">
            <h3>Makale Düzenle</h3>
        </div>
        <div class="panelIcerik">
            <asp:Panel ID="pnl_basarili" runat="server" CssClass="basarili" Visible="false">
                Makale Başarıyla Düzenlenmiştir
            </asp:Panel>
            <asp:Panel ID="pnl_hata" runat="server" CssClass="hata" Visible="false">
                <asp:Label ID="lbl_mesaj" runat="server"></asp:Label>
            </asp:Panel>
            <div class="IcerikSol">
                <div class="satir">
                    <label>Kategori Seçiniz</label><br />
                    <asp:DropDownList ID="ddl_kategoriler" runat="server" CssClass="ddlKutu" DataTextField="Isim" DataValueField="ID"></asp:DropDownList>
                </div>

                <div class="satir">
                    <label>Makale Başlık</label><br />
                    <asp:TextBox ID="tb_isim" runat="server" CssClass="metinKutu"></asp:TextBox>
                </div>
                <div class="satir">
                    <asp:Image ID="img_resim" runat="server" Style="width: 635px" />
                </div>
                <div class="satir">
                    <label>Kapak Resim</label><br />
                    <asp:FileUpload ID="fu_resim" runat="server" CssClass="metinKutu" />
                </div>
                <div class="satir">
                    <label>Makale Özeti</label>
                    <asp:TextBox ID="tb_ozet" runat="server" TextMode="MultiLine" CssClass="metinKutu"></asp:TextBox>
                </div>
                <div class="satir" style="margin-top: 20px; margin-bottom: 20px">
                    <label>Yayınla</label>
                    <asp:CheckBox ID="cb_yayinla" runat="server" />
                </div>
                <div class="satir" style="margin-bottom: 20px;">
                    <asp:LinkButton ID="lbtn_ekle" runat="server" CssClass="button" OnClick="lbtn_ekle_Click">Makale Düzenle</asp:LinkButton>
                </div>
            </div>
            <div class="IcerikSag">

                <div class="satir">
                    <label>Makale İçerik</label>
                    <asp:TextBox ID="tb_icerik" runat="server" TextMode="MultiLine"></asp:TextBox>
                </div>

            </div>
            <div style="clear: both"></div>
        </div>
    </div>
</asp:Content>
