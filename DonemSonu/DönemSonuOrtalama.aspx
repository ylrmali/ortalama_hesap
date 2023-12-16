<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="DönemSonuOrtalama.aspx.cs" Inherits="DonemSonu.DönemSonuOrtalama" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="col-12">
        <tr>
            <td class="col-6">
                 <!-- Onaylanmış Ders ortalamları buraya gelecek -->
                <asp:ListBox ID="DersPuanlari" runat="server" Height="155px" Width="296px">
                   
                </asp:ListBox>
            </td>
            <td class="col-6">
                <!--  Donem Sonu Ortalaması buraya gelecek -->
                <div class="p-2" style="text-align: center;">
                    <asp:Label ID="Label1" runat="server" Text="Dönem Sonu Ortalaması" Font-Bold="True" ForeColor="White"></asp:Label>
                    <br />
                    <asp:Label ID="ortalama" runat="server" Text="Label" Visible="False" Font-Bold="True" ForeColor="White"></asp:Label>
                </div>
            </td>
        </tr>
    </table>
</asp:Content>

