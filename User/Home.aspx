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
