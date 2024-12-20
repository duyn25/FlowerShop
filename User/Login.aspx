<%@ Page Title="Đăng Nhập" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="FLowerShop.User.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SubContent" runat="server">
        <link href="../Assets/CSS/form.css" type="text/css" rel="stylesheet" />

    <h2>Đăng Nhập</h2>
     <table>
            <tr>
                <td><label for="email">Email: </label></td>
                <td><asp:TextBox ID="txtEmail" runat="server" placeholder="Nhập email"></asp:TextBox></td>
            </tr>
            <tr>
                <td><label for="password">Mật khẩu: </label></td>
                <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Nhập mật khẩu"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnLogin" runat="server" Text="Đăng Nhập" OnClick="btnLogin_Click" />
                </td>
            </tr>
            <tr>
                <td colspan="2">
                    Chưa có tài khoản ?
                    <a href="Register.aspx">Đăng ký tài khoản</a>
                </td>
            </tr>
        </table>
      <asp:Label ID="msg" runat="server"></asp:Label>
        
</asp:Content>
