<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="History.aspx.cs" Inherits="FLowerShop.User.History" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SideBar" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubContent" runat="server">
        <h3 class="text-center">Lịch sử mua hàng</h3>
    <asp:Repeater ID="rptOrderHistory" runat="server">
    <HeaderTemplate>
        <table class="table table-bordered text-center mb-0">
            <thead>
                <tr class="bg-secondary text-dark">
                    <th>Order ID</th>
                    <th>Ngày đặt hàng</th>
                    <th>Sản phẩm</th>
                    <th>Số lượng</th>
                    <th>Tổng giá</th>
                </tr>
            </thead>
            <tbody>
    </HeaderTemplate>
    <ItemTemplate>
        <tr>
            <td><%# Eval("order_id") %></td>
            <td><%# Eval("order_date", "{0:dd/MM/yyyy}") %></td>
             <td><%# Eval("product_names") %></td> <!-- Hiển thị tên các sản phẩm -->
             <td><%# Eval("total_quantity") %></td> <!-- Hiển thị tổng số lượng -->
            <td><%# string.Format("{0:N0} VND", Eval("total_price")) %></td>

        </tr>
    </ItemTemplate>
    <FooterTemplate>
            </tbody>
        </table>
    </FooterTemplate>
</asp:Repeater>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
   
</asp:Content>
