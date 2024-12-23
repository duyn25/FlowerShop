<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="FLowerShop.User.Home" %>

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

    <div id="header-carousel" class="carousel slide" data-ride="carousel">
    <div class="carousel-inner">
        <div class="carousel-item active" style="height: 410px;">
            <img class="img-fluid" src="../Assets/Images/carousel-1.jpg" alt="Image">
            <div class="carousel-caption d-flex flex-column align-items-center justify-content-center">
            </div>
        </div>
        <div class="carousel-item" style="height: 410px;">
            <img class="img-fluid" src="../Assets/Images/carousel-2.jpg" alt="Image">
            <div class="carousel-caption d-flex flex-column align-items-center justify-content-center">

            </div>
        </div>
    </div>
    <a class="carousel-control-prev" href="#header-carousel" data-slide="prev">
        <div class="btn btn-dark" style="width: 45px; height: 45px;">
            <span class="carousel-control-prev-icon mb-n2"></span>
        </div>
    </a>
    <a class="carousel-control-next" href="#header-carousel" data-slide="next">
        <div class="btn btn-dark" style="width: 45px; height: 45px;">
            <span class="carousel-control-next-icon mb-n2"></span>
        </div>
    </a>
</div>
</asp:Content>

 <asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
      <link href="../Assets/CSS/style.css" rel="stylesheet">
    <h4 class="text-center">Top sản phẩm bán chạy</h4>
    <asp:DataList ID="DataList1" runat="server" 
        DataKeyField="product_id" 
        DataSourceID="SqlDataSource1"
        RepeatColumns="5" RepeatDirection="Horizontal"
        >
        <ItemTemplate>
           <div class="card product-item border-0 mb-4">
               <div class="card-header product-img position-relative overflow-hidden bg-transparent border p-0">
                <asp:Image ID="img" runat="server" ImageUrl='<%#"~/Assets/Images/"+Eval("image") %>' Width="230" Height="250" />
                </div>
            <div class="card-body border-left border-right text-center p-0 pt-4 pb-3">
                    <asp:Label ID="nameLabel" runat="server" Text='<%# Eval("name") %>' />
                <div class="d-flex justify-content-center">
                    Giá bán: <asp:Label ID="priceLabel" runat="server" Text='<%# String.Format("{0:#,##0} VND", Eval("price")) %>' />
                </div>
            </div>
            <div class="card-footer d-flex justify-content-center bg-light border">
                <a href='ProductDetails.aspx?product_id=<%# Eval("product_id") %>' class="btn btn-sm text-dark p-0"><i class="fas fa-eye text-primary mr-1"></i>Xem Chi tiết</a>
            </div>
        </div>                                         
        </ItemTemplate>
    </asp:DataList>
    <asp:SqlDataSource 
    ID="SqlDataSource1"
    runat="server" 
    ConnectionString="Data Source=LAPTOP-KDQJ22JT\NDSCDL;Initial Catalog=FlowerShop;Integrated Security=True" 
        
    ProviderName="System.Data.SqlClient" 
    SelectCommand="SELECT TOP 5 
                product_id, 
                name, 
                image, 
                price, 
                quantity_sold
            FROM 
                Product
            ORDER BY 
                quantity_sold DESC;" >
    </asp:SqlDataSource>
     <br />
     <h4 class="text-center">Top sản phẩm mới nhất</h4>
<asp:DataList ID="DataList2" runat="server" 
    DataKeyField="product_id" 
    DataSourceID="SqlDataSource3"
    RepeatColumns="5" RepeatDirection="Horizontal"
    >
    <ItemTemplate>
       <div class="card product-item border-0 mb-4">
           <div class="card-header product-img position-relative overflow-hidden bg-transparent border p-0">
            <asp:Image ID="img" runat="server" ImageUrl='<%#"~/Assets/Images/"+Eval("image") %>' Width="230" Height="250" />
            </div>
        <div class="card-body border-left border-right text-center p-0 pt-4 pb-3">
                <asp:Label ID="nameLabel" runat="server" Text='<%# Eval("name") %>' />
            <div class="d-flex justify-content-center">
                Giá bán: <asp:Label ID="priceLabel" runat="server" Text='<%# String.Format("{0:#,##0} VND", Eval("price")) %>' />
            </div>
        </div>
        <div class="card-footer d-flex justify-content-center bg-light border">
            <a href='ProductDetails.aspx?product_id=<%# Eval("product_id") %>' class="btn btn-sm text-dark p-0"><i class="fas fa-eye text-primary mr-1"></i>Xem Chi tiết</a>
        </div>
    </div>                                         
    </ItemTemplate>
</asp:DataList>
<asp:SqlDataSource 
ID="SqlDataSource3"
runat="server" 
ConnectionString="Data Source=LAPTOP-KDQJ22JT\NDSCDL;Initial Catalog=FlowerShop;Integrated Security=True" 
    
ProviderName="System.Data.SqlClient" 
SelectCommand="SELECT TOP 5 
            product_id, 
            name, 
            image, 
            price, 
            created_at
        FROM 
            Product
        ORDER BY 
           created_at DESC;" >
</asp:SqlDataSource>
</asp:Content>