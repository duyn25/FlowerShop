using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FLowerShop.User
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string productId = Request.QueryString["product_id"];
                if (!string.IsNullOrEmpty(productId))
                {
                    LoadProductDetails(productId);
                }
                else
                {
                    Response.Redirect("ProductList.aspx");
                }
            }
        }
        private void LoadProductDetails(string productId)
        {
            string connectionString = "Data Source=LAPTOP-KDQJ22JT\\NDSCDL;Initial Catalog=FlowerShop;Integrated Security=True";
            string query = "SELECT name, price, description, stock, image FROM [Product] WHERE product_id = @ProductId";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@ProductId", System.Data.SqlDbType.Int).Value = int.Parse(productId);

                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                imgProduct.ImageUrl = "~/Assets/Images/" + reader["image"].ToString();
                                lblName.Text = reader["name"].ToString();
                                lblPrice.Text = string.Format("{0:N0} VND", reader["price"]);
                                lblDescription.Text = reader["description"].ToString();
                                lblStock.Text = string.Format("{0:N0}", reader["stock"]);
                            }
                            else
                            {
                                ShowErrorMessage("Sản phẩm không tồn tại.");
                                Response.Redirect("ProductList.aspx");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                ShowErrorMessage("Lỗi khi tải sản phẩm: " + ex.Message);
            }
        }
        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            string productId = Request.QueryString["product_id"];
            if (!string.IsNullOrEmpty(productId))
            {
                // Khởi tạo giỏ hàng nếu chưa có
                Session["Cart"] = Session["Cart"] ?? new List<string>();
                var cart = (List<string>)Session["Cart"];
                cart.Add(productId);

                // Điều hướng đến trang giỏ hàng
                Response.Redirect("Cart.aspx");
            }
            else
            {
                ShowErrorMessage("Không thể thêm sản phẩm vào giỏ hàng.");
            }
        }
        private void ShowErrorMessage(string message)
        {
            // Hiển thị thông báo lỗi
            lblErrorMessage.Text = message;
            lblErrorMessage.Visible = true;
        }

    }
}
