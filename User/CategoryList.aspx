<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="CategoryList.aspx.cs" Inherits="FLowerShop.User.CategoryList" %>
<asp:Content ID="sibebar" ContentPlaceHolderID="SideBar" runat="server">
        <a class="btn shadow-none d-flex align-items-center justify-content-between bg-primary text-white w-100" data-toggle="collapse" href="#navbar-vertical" style="height: 65px; margin-top: -1px; padding: 0 30px;">
    <h6 class="m-0">Danh mục sản phẩm</h6>
    <i class="fa fa-angle-down text-dark"></i>
</a>
<nav class="collapse show navbar navbar-vertical navbar-light align-items-start p-0 border border-top-0 border-bottom-0" id="navbar-vertical">
    <div class="navbar-nav w-100 overflow-hidden" style="height: 410px">
       
       
        <asp:Repeater ID="Repeater1" runat="server" DataSourceID="SqlDataSource2">
            <ItemTemplate>
                 <a href='/User/CategoryList.aspx?category_id=<%#Eval("category_id") %>' class="nav-item nav-link"><%#Eval("name") %></a>
            </ItemTemplate>

        </asp:Repeater>
<asp:SqlDataSource 
    ID="SqlDataSource2" 
    runat="server" 
    ConnectionString="Data Source=LAPTOP-KDQJ22JT\NDSCDL;Initial Catalog=FlowerShop;Integrated Security=True" 
    ProviderName="System.Data.SqlClient" 
    SelectCommand="SELECT * FROM [Category]">
</asp:SqlDataSource>
       
    </div>
</nav>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubContent" runat="server">
    <h4>Danh sách sản phẩm</h4>
    <asp:DataList ID="DataList1" runat="server" 
        DataKeyField="product_id" DataSourceID="SqlDataSource1"
        RepeatColumns="4" RepeatDirection="Horizontal"
        >
        <ItemTemplate>
                            <div class="card product-item border-0 mb-4">
                                 <div class="card-header product-img position-relative overflow-hidden bg-transparent border p-0">
                                   <asp:Image ID="img" runat="server" ImageUrl='<%#"~/Assets/Images/"+Eval("image") %>' Width="230" Height="250" />
                                 </div>
                                <div class="card-body border-left border-right text-center p-0 pt-4 pb-3">
                                     <asp:Label ID="nameLabel" runat="server" Text='<%# Eval("name") %>' />
                                    <div class="d-flex justify-content-center">
                                     Giá bán:<asp:Label ID="priceLabel" runat="server" Text='<%# Eval("price") %>' />
                                    </div>
                                </div>
                                <div class="card-footer d-flex justify-content-between bg-light border">
                                    <a href="ProductDetails.aspx" class="btn btn-sm text-dark p-0"><i class="fas fa-eye text-primary mr-1"></i>View Detail</a>
                                    <a href="Cart.aspx" class="btn btn-sm text-dark p-0"><i class="fas fa-shopping-cart text-primary mr-1"></i>Add To Cart</a>
                                </div>
                            </div>      
        </ItemTemplate>

    </asp:DataList>
    <asp:SqlDataSource 
    ID="SqlDataSource1" 
    runat="server" 
    ConnectionString="Data Source=LAPTOP-KDQJ22JT\NDSCDL;Initial Catalog=FlowerShop;Integrated Security=True" 
    ProviderName="System.Data.SqlClient" 
    SelectCommand="SELECT * FROM [Product] where category_id = @category_id">
        <SelectParameters>
            <asp:QueryStringParameter Name="category_id" Type="Int16" QueryStringField="category_id" />
        </SelectParameters>
</asp:SqlDataSource>



</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
</asp:Content>
