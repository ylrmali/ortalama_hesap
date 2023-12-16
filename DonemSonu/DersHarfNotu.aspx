<%@ Page Title="" Language="C#" MasterPageFile="~/Layout.Master" AutoEventWireup="true" CodeBehind="DersHarfNotu.aspx.cs" Inherits="DonemSonu.DersHarfNotu" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="col-12">
        <tr>
            <td class="col-6">
                <div class="p-2">
                    <asp:Label ID="error" runat="server" Text="Lütfen tüm alanları doldurunuz!" Font-Bold="True" ForeColor="#FF99CC" Visible="False"></asp:Label>
                    <br />
                    <asp:Label ID="Label1" runat="server" Font-Bold="True" ForeColor="White" Text="Ortalama - Harf Notu Bilgisi"></asp:Label>
                    <br />
                    <!-- Ders Dropdown -->
                    <asp:Label ID="Label2" runat="server" Text="Dersler"></asp:Label>
                    <asp:DropDownList ID="dersler_dropdown" runat="server" 
                                      CssClass="ms-2 mt-2 me-2 p-1 w-75" BackColor="#CCCCCC">
                    </asp:DropDownList>
                    <!-- Ders Dropdown -->
                    <br />
                    <!-- Vize Notu Input -->
                    <asp:Label ID="Label3" runat="server" Text="Vize Notu"></asp:Label>
                    <asp:TextBox ID="vize_not" runat="server" 
                                 CssClass="ms-2 mt-2 me-2 p-1 w-50" BackColor="#CCCCCC">
                    </asp:TextBox>
                    <!-- Vize Notu Input -->
                    <br />
                    <!-- Proje Notu Input -->
                    <asp:Label ID="Label4" runat="server" Text="Proje Notu"></asp:Label>
                    <asp:TextBox ID="proje_not" runat="server"  
                                 CssClass="ms-2 mt-2 me-2 p-1 w-50" BackColor="#CCCCCC">
                    </asp:TextBox>
                    <!-- Proje Notu Input -->
                    <br />
                    <!-- Final Notu Input -->
                    <asp:Label ID="Label5" runat="server" Text="Final Notu"></asp:Label>
                    <asp:TextBox ID="final_not" runat="server"  
                                 CssClass="ms-2 mt-2 me-2 p-1 w-50" BackColor="#CCCCCC">
                    </asp:TextBox>
                    <!-- Final Notu Input -->
                    <br />
                    <asp:Button ID="hesapla_btn" runat="server" Text="Hesapla" CssClass="mt-2 p-2 w-25" BackColor="#006600" BorderStyle="None" ForeColor="White" Width="221px" OnClick="hesapla_btn_Click" />
                    <asp:Button ID="accept_btn" runat="server" Text="Ortalamayı Onayla" CssClass="mt-2 p-2 w-25" BackColor="#00CC99" BorderStyle="None" ForeColor="White" Width="221px" OnClick="accept_btn_Click" Visible="False" />
                </div>
            </td>
            <td class="col-6">
                <asp:ListBox ID="ListBox1" runat="server" Height="262px" OnSelectedIndexChanged="ListBox1_SelectedIndexChanged" Visible="False" Width="305px"></asp:ListBox>
            </td>
        </tr>
    </table>
    

</asp:Content>
