<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="ProductList.aspx.cs" Inherits="FLowerShop.User.ProductList" %>

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
    SelectCommand="SELECT * FROM [Product]">
</asp:SqlDataSource>



</asp:Content>
