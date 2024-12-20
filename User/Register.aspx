<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="Register.aspx.cs" Inherits="FLowerShop.User.Register" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SubContent" runat="server">
    <link href="../Assets/CSS/form.css" type="text/css" rel="stylesheet" />
     <h2>Đăng Ký Tài Khoản</h2>
    <table>
            <tr>
                <td><label for="firstName">Họ: </label></td>
                <td><asp:TextBox ID="txtFirstName" runat="server" placeholder="Nhập họ"></asp:TextBox></td>
            </tr>
            <tr>
                <td><label for="lastName">Tên: </label></td>
                <td><asp:TextBox ID="txtLastName" runat="server" placeholder="Nhập tên"></asp:TextBox></td>
            </tr>
            <tr>
                <td><label for="email">Email: </label></td>
                <td><asp:TextBox ID="txtEmail" runat="server" placeholder="Nhập email"></asp:TextBox></td>
            </tr>
            <tr>
                <td><label for="address">Địa chỉ: </label></td>
                <td><asp:TextBox ID="txtAddress" runat="server" placeholder="Nhập địa chỉ"></asp:TextBox></td>
            </tr>
            <tr>
                <td><label for="sdt">Số ĐT: </label></td>
                <td><asp:TextBox ID="txtPhone" runat="server" placeholder="Nhập SĐT"></asp:TextBox></td>
            </tr>

            <tr>
                <td><label for="password">Mật khẩu: </label></td>
                <td><asp:TextBox ID="txtPassword" runat="server" TextMode="Password" placeholder="Nhập mật khẩu"></asp:TextBox></td>
            </tr>
            <tr>
                <td><label for="confirmPassword">Xác nhận mật khẩu: </label></td>
                <td><asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password" placeholder="Xác nhận mật khẩu"></asp:TextBox></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Button ID="btnRegister" runat="server" Text="Đăng Ký" OnClick="btnRegister_Click" />
                    Đã có tài khoản ? <a href="Login.aspx">Đăng nhập</a>
                </td>
            </tr>
      
        </table>
      <asp:Label ID="msg" runat="server"></asp:Label>
</asp:Content>
