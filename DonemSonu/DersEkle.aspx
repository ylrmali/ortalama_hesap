<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="DersEkle.aspx.cs" Inherits="DonemSonu.DersEkle" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .auto-style5 {
            margin-bottom: 2px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="col-12">
        <tr>
            <td class="col-6">
                <div class="p-2">
                    <asp:Label ID="Label5" runat="server" Text="Lütfen tüm alanları doldurunuz!" Enabled="False" EnableTheming="True" Font-Bold="True" Font-Italic="False" Font-Size="Medium" ForeColor="#FF9999" Visible="False"></asp:Label>
                    <br />
                    <asp:Label ID="ders_label" runat="server" Text="Dersin Adı" Font-Bold="True" ForeColor="White"></asp:Label>
                    <br />
                    <asp:TextBox ID="ders_textBox" runat="server" 
                                 BackColor="#CCCCCC" BorderStyle="None" 
                                 MaxLength="240" CssClass="mt-2 p-1 w-75"></asp:TextBox>
                </div>
                <div class="p-2">
                    <asp:Label ID="Label1" runat="server" Text="Yüzdelikler" Font-Bold="True" ForeColor="White"></asp:Label>
                    <br />
                    <div>
                        <asp:Label ID="Label2" runat="server" Text="Vize" ForeColor="White"></asp:Label>
                        <asp:TextBox ID="vize_ort" runat="server" BackColor="#CCCCCC" BorderStyle="None" 
                                     MaxLength="2" CssClass="auto-style5 mt-2 p-1 ms-2 w-50" TextMode="Number"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label3" runat="server" Text="Proje"></asp:Label>
                        <asp:TextBox ID="proje_ort" runat="server" BackColor="#CCCCCC" BorderStyle="None" 
                                     MaxLength="2" CssClass="auto-style5 mt-2 p-1 ms-2 w-50" TextMode="Number"></asp:TextBox>
                        <br />

                        <asp:Label ID="Label4" runat="server" Text="Final"></asp:Label>
                        <asp:TextBox ID="final_ort" runat="server" BackColor="#CCCCCC" BorderStyle="None" 
                                     MaxLength="2" CssClass="auto-style5 mt-2 p-1 ms-2 w-50" TextMode="Number"></asp:TextBox>
                        <br />
                        <asp:Label ID="Label6" runat="server" Text="AKTS"></asp:Label>
                        <asp:TextBox ID="akts" runat="server" BackColor="#CCCCCC" BorderStyle="None" 
                                     MaxLength="2" CssClass="auto-style5 mt-2 p-1 ms-2 w-50" TextMode="Number"></asp:TextBox>
                    </div>
                    <asp:Button ID="Button1" runat="server" Text="EKLE" CssClass="mt-2 p-1 w-50" Width="205px" BackColor="#006600" ForeColor="White" BorderStyle="None" Font-Bold="True" OnClick="Button1_Click"/>
                </div>
            <td class="col-6">
                
                <asp:ListBox ID="dersler" runat="server" Height="296px" Width="338px" BackColor="#CCCCCC"></asp:ListBox>
                
            </td>
            </td>
        </tr>
    </table>
</asp:Content>
