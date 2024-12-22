<%@ Page Title="Chi tiết sản phẩm" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="ProductDetails.aspx.cs" Inherits="FLowerShop.User.ProductDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SubContent" runat="server">

    <div class="row">
        <div class="col-lg-8 pb-2">
            <div id="product-carousel">
                <div class="carousel-inner border">
                    <div class="carousel-item active">
                        <asp:Image ID="imgProduct" runat="server" CssClass="d-block w-100 ms-4" Width="400" Height="600" />
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-7 pb-5">
            <h3 class="font-weight-semi-bold">
                <asp:Label ID="lblName" runat="server" CssClass="text-dark" />
            </h3>
            <h3 class="font-weight-semi-bold mb-4">
                Giá: <asp:Label ID="lblPrice" runat="server" CssClass="text-danger" />
            </h3>
            Mô tả:
            <asp:Label ID="lblDescription" runat="server" CssClass="text-muted" />
            <p class="mr-3">Còn: <asp:Label ID="lblStock" runat="server" CssClass="text-success" /></p>

            <div class="d-flex align-items-center mb-4 pt-2">
                Số lượng:
                <div class="input-group quantity mr-3" style="width: 130px;">
                    <div class="input-group-btn">
                        <button class="btn btn-primary btn-minus">
                            <i class="fa fa-minus"></i>
                        </button>
                    </div>
                    <input id="quantity" type="text" class="form-control bg-secondary text-center" value="1" runat="server" />                    
                    <div class="input-group-btn">
                        <button class="btn btn-primary btn-plus">
                            <i class="fa fa-plus"></i>
                        </button>
                    </div>
                </div>
                <asp:Button ID="btnAddToCart" runat="server" CssClass="btn btn-primary px-3" Text="Thêm vào giỏ" OnClick="btnAddToCart_Click" />
                <asp:HiddenField ID="hiddenProductId" runat="server" Value='<%# Eval("ProductId") %>' />
                
            </div>
            <asp:Label ID="lblErrorMessage" runat="server"></asp:Label>
        </div>
    </div>
    <script src="../Assets/js/productdetail.js"></script>
</asp:Content>
