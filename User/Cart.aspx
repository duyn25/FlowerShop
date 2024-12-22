<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="Cart.aspx.cs" Inherits="FLowerShop.User.Cart" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SideBar" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubContent" runat="server">
    <h3 class="text-center">Giỏ hàng</h3>
   <table class="table table-bordered text-center mb-0">
       <tr class="bg-secondary text-dark">
           <th>Sản phẩm</th>
           <th>Tên sản phẩm</th>
           <th>Số lượng</th>
           <th>Giá bán</th> 
           <th>Tổng</th>
           <th>Xóa</th>

       </tr>
       <asp:Repeater ID="Repeater1" runat="server">
           <ItemTemplate>
               <tr  id="productRow1">
                   <td> <asp:Image ID="img" runat="server" ImageUrl='<%#"~/Assets/Images/"+Eval("image") %>' Width="70" Height="" /></td>
                   <td><%# Eval("name") %></td>
                   <td>
                   <asp:Label ID="quantityLabel" runat="server" Text='<%# Eval("quantity") %>'></asp:Label>
                   </td>     
                   <td><asp:Label ID="priceLabel" runat="server" Text='<%# Eval("price") %>'></asp:Label></td>
                   <td>
                       <asp:Label ID="totalLabel" runat="server" Text='<%# (Convert.ToInt32(Eval("quantity")) * Convert.ToDecimal(Eval("price"))) %>'></asp:Label> 
                   </td>
                   <td class="align-middle">
                        <asp:Button ID="btnDelete" runat="server" Text="Xoá" CssClass="btn btn-sm btn-primary"
                            CommandName="Delete" CommandArgument='<%# Eval("cart_id") %>' OnClick="DeleteItem_Click"  OnClientClick="return confirm('Bạn có chắc chắn muốn xóa sản phẩm này?');" />
                    </td>

               </tr>                  
           </ItemTemplate>
       </asp:Repeater>
   </table>
    <strong>Tổng tiền:</strong>
    <asp:Label ID="lblTotalAmount" runat="server" Text="0"></asp:Label> 
     <a href="Order.aspx" class="btn btn-block btn-primary my-3 py-3">Đặt hàng</a>
    <asp:Label ID="lblMessage" runat="server"></asp:Label>

</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
