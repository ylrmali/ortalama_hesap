<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DonemSonu.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="padding: 15px; margin-top: 20%; text-align:center; background-color: #0099CC; color: #FFFFFF;" class="auto-style1">
            <h1>GİRİŞ YAP</h1>
            <asp:Label ID="error" runat="server" Text="Girmiş Olduğun kullanıcı bilgileri hatalı!" Font-Bold="True" ForeColor="#CC3300" Visible="False"></asp:Label>
            <br /> <br />
            <asp:Label ID="Label1" runat="server" Text="E-posta"></asp:Label>
            <br />
            <asp:TextBox ID="mail_box" runat="server" Width="188px" ></asp:TextBox>
            <br />
            <asp:Label ID="Label2" runat="server" Text="Şifre"></asp:Label>
            <br />
            <asp:TextBox ID="pass_box" runat="server" Width="180px"></asp:TextBox>
            <br />
            <asp:Button ID="Button1" runat="server" Text="Giriş" OnClick="Button1_Click" 
                BackColor="Fuchsia" style="margin-top: 10px;" Width="135px" />
        </div>
    </form>
</body>
</html>
