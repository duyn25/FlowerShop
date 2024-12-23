<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/Site.Master" AutoEventWireup="true" CodeBehind="Order.aspx.cs" Inherits="FLowerShop.User.Order" %>
<asp:Content ID="Content1" ContentPlaceHolderID="SideBar" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="SubContent" runat="server">
    
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid pt-0">
    <div class="row px-xl-5">
        <div class="col-lg-8">
            <div class="mb-4">
                <h4 class="font-weight-semi-bold mb-4">Thông tin đơn hàng</h4>
                <div class="row">
                    <div class="col-md-6 form-group">
                        <label>Họ</label>
                        <asp:TextBox ID="txtho" runat="server" class="form-control" type="text" Text=" " placeholder="John"></asp:TextBox>
                    </div>
                    <div class="col-md-6 form-group">
                        <label>Tên</label>
                        <asp:TextBox ID="txtten" runat="server" class="form-control" type="text" Text=" " placeholder="John"></asp:TextBox>
                    </div>
                    <div class="col-md-6 form-group">
                        <label>Email</label>
                        <asp:TextBox ID="txtemail" runat="server" class="form-control" type="text"  Text=" " placeholder="John"></asp:TextBox>
                    </div>
                    <div class="col-md-6 form-group">
                        <label>Số ĐT</label>
                         <asp:TextBox ID="txtsdt" runat="server" class="form-control" type="text" Text=" " placeholder="John"></asp:TextBox>
                    </div>
                    <div class="col-md-6 form-group">
                        <label>Địa chỉ</label>
                         <asp:TextBox ID="txtdiachi" runat="server" class="form-control" type="text"  Text=" " placeholder="John"></asp:TextBox>
                    </div>
                    
                    
                </div>
            </div>
            
            <div class="collapse mb-4" id="shipping-address">
                <h4 class="font-weight-semi-bold mb-4">Shipping Address</h4>
                <div class="row">
                    <div class="col-md-6 form-group">
                        <label>First Name</label>
                        <input class="form-control" type="text" placeholder="John">
                    </div>
                    <div class="col-md-6 form-group">
                        <label>Last Name</label>
                        <input class="form-control" type="text" placeholder="Doe">
                    </div>
                    <div class="col-md-6 form-group">
                        <label>E-mail</label>
                        <input class="form-control" type="text" placeholder="example@email.com">
                    </div>
                    <div class="col-md-6 form-group">
                        <label>Mobile No</label>
                        <input class="form-control" type="text" placeholder="+123 456 789">
                    </div>
                    <div class="col-md-6 form-group">
                        <label>Address Line 1</label>
                        <input class="form-control" type="text" placeholder="123 Street">
                    </div>
                    <div class="col-md-6 form-group">
                        <label>Address Line 2</label>
                        <input class="form-control" type="text" placeholder="123 Street">
                    </div>
                    <div class="col-md-6 form-group">
                        <label>Country</label>
                        <select class="custom-select">
                            <option selected>United States</option>
                            <option>Afghanistan</option>
                            <option>Albania</option>
                            <option>Algeria</option>
                        </select>
                    </div>
                    <div class="col-md-6 form-group">
                        <label>City</label>
                        <input class="form-control" type="text" placeholder="New York">
                    </div>
                    <div class="col-md-6 form-group">
                        <label>State</label>
                        <input class="form-control" type="text" placeholder="New York">
                    </div>
                    <div class="col-md-6 form-group">
                        <label>ZIP Code</label>
                        <input class="form-control" type="text" placeholder="123">
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-4">
                <div class="card border-secondary mb-5">
                    <div class="card-header bg-secondary border-0">
                        <h4 class="font-weight-semi-bold m-0">Tổng tiền</h4>
                    </div>
                    <div class="card-body">
                        <h5 class="font-weight-medium mb-3">Sản phẩm</h5>
                        <asp:Repeater ID="Repeater1" runat="server">
                            <ItemTemplate>
                                <div class="d-flex justify-content-between">
                                    <p><%# Eval("name") %> x <asp:Label ID="quantityLabel" runat="server" Text='<%# Eval("quantity") %>'></asp:Label></p>
                                     <asp:Label ID="totalLabel" runat="server" Text='<%# (Convert.ToInt32(Eval("quantity")) * Convert.ToDecimal(Eval("price"))) %>'></asp:Label> 
                                </div>
                                 <asp:HiddenField ID="productId" runat="server" Value='<%# Eval("product_id") %>' />
                                <asp:HiddenField ID="price" runat="server" Value='<%# Eval("price") %>' />
                            </ItemTemplate>
                        </asp:Repeater>
                        
                    </div>
                    <div class="card-footer border-secondary bg-transparent">
                        <div class="d-flex justify-content-between mt-2">
                            <h5 class="font-weight-bold">Tổng cộng</h5>
                            <h5 class="font-weight-bold" id="lblTotal">
                            <asp:Label ID="lblTotalAmount" runat="server" Text="0"></asp:Label> 
                            </h5>
                        </div>
                    </div>
                </div>
                <div class="card border-secondary mb-5">
                    <div class="card-header bg-secondary border-0">
                        <h4 class="font-weight-semi-bold m-0">Thanh toán</h4>
                    </div>
                    <div class="card-body">
                        <div class="form-group">
                            <div class="custom-control custom-radio">
                                <asp:RadioButton ID="rbPaypal" GroupName="Payment" CssClass="custom-control-input" runat="server" />
                                <label class="custom-control-label" for="rbPaypal">Paypal</label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="custom-control custom-radio">
                                <asp:RadioButton ID="rbDirectCheck" GroupName="Payment" CssClass="custom-control-input" runat="server" />
                                <label class="custom-control-label" for="rbDirectCheck">Direct Check</label>
                            </div>
                        </div>
                        <div class="form-group">
                            <div class="custom-control custom-radio">
                                <asp:RadioButton ID="rbBankTransfer" GroupName="Payment" CssClass="custom-control-input" runat="server" />
                                <label class="custom-control-label" for="rbBankTransfer">Bank Transfer</label>
                            </div>
                        </div>
                    </div>
                    <div class="card-footer border-secondary bg-transparent">
                        <asp:Button ID="btnConfirmOrder" CssClass="btn btn-lg btn-block btn-primary font-weight-bold my-3 py-3" Text="Xác nhận đặt hàng" runat="server" OnClick="btnConfirmOrder_Click" />
                    </div>
                                            <asp:Label ID="lblMessage" runat="server"></asp:Label>

                </div>
            </div>
    </div>
</div>
</asp:Content>
