using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Web;

namespace FLowerShop.User
{
    public partial class ProductDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CustomerID"] == null || string.IsNullOrEmpty(Session["CustomerID"].ToString()))
            {
                Response.Redirect("Login.aspx"); 
            }
            if (!IsPostBack)
            {
                string productId = Request.QueryString["product_id"];
                if (!string.IsNullOrEmpty(productId) && int.TryParse(productId, out int productIdInt))
                {
                    hiddenProductId.Value = productId;
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
            string query = "SELECT product_id, name, price, description, stock, image FROM [Product] WHERE product_id = @ProductId";

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
        private void AddToCart(int customerId, int productId, int quantity)
        {          
            string connectionString = "Data Source=LAPTOP-KDQJ22JT\\NDSCDL;Initial Catalog=FlowerShop;Integrated Security=True";
            string query;
            if (IsAlreadyInCart(customerId, productId))
            {
                query = "UPDATE Cart SET quantity = quantity + @Quantity WHERE customer_id=@CustomerId AND product_id = @ProductId";
            }
            else
            {
                query = "INSERT INTO Cart (customer_id, product_id, quantity) VALUES (@CustomerId, @ProductId, @Quantity)";
            }          
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using(SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue("@CustomerId",customerId);
                    command.Parameters.AddWithValue("@ProductId", productId);
                    command.Parameters.AddWithValue("@Quantity",quantity);
                    try
                    {
                        conn.Open();
                        command.ExecuteNonQuery();
                        ShowErrorMessage("Sản phẩm đã được thêm vào giỏ hàng.");
                    }
                    catch (Exception ex)
                    {

                        ShowErrorMessage("Lỗi khi thêm sản phẩm: " + ex.Message);
                    }
                }
            }
        }
        protected void btnAddToCart_Click(object sender, EventArgs e)
        {

            int productId = Convert.ToInt32(hiddenProductId.Value);
            int cart_quantity = Convert.ToInt32(quantity.Value);
            int customerId = GetCustomerId();
            if (!IsCustomerValid(customerId))
            {
                ShowErrorMessage("Vui lòng đăng nhập.");
                return;
            }
            AddToCart(customerId, productId, cart_quantity);
        }

        private bool IsProductAvailableInStock(int productId, int quantity)
        {
            string connectionString = "Data Source=LAPTOP-KDQJ22JT\\NDSCDL;Initial Catalog=FlowerShop;Integrated Security=True";
            string query = "SELECT stock from Product WHERE product_id=@ProductID";
            using (SqlConnection connection = new SqlConnection(connectionString)) {
                using (SqlCommand command = new SqlCommand(query, connection)) {
                    command.Parameters.AddWithValue("@ProductId", productId);
                    try
                    {
                        connection.Open();
                        int stock = Convert.ToInt32(command.ExecuteScalar());
                        if(stock >= quantity)
                        {
                            return true;
                        }
                        else
                        {
                            ShowErrorMessage("Sản phẩm không đủ số lượng");
                            return false;
                        }
                    }
                    catch (Exception ex)
                    {
                        ShowErrorMessage("Lỗi khi kiểm tra sản phẩm: " + ex.Message);
                        return false;
                    }
                }
            }
        }
        private bool IsCustomerValid(int customerId)
        {
            string connectionString = "Data Source=LAPTOP-KDQJ22JT\\NDSCDL;Initial Catalog=FlowerShop;Integrated Security=True";
            string query = "SELECT COUNT(*) FROM Customer WHERE customer_id = @CustomerId";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@CustomerId", customerId);

                    try
                    {
                        conn.Open();
                        int count = Convert.ToInt32(cmd.ExecuteScalar());
                        return count > 0;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
        }

        private bool IsAlreadyInCart(int customerId, int productId)
        {
            string connectionString = "Data Source=LAPTOP-KDQJ22JT\\NDSCDL;Initial Catalog=FlowerShop;Integrated Security=True";
            string query = "SELECT COUNt(*) from Cart WHERE customer_id = @CustomerId AND product_id = @ProductId";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", customerId);
                    command.Parameters.AddWithValue("@ProductId", productId);

                    try
                    {
                        connection.Open();
                        int count = Convert.ToInt32(command.ExecuteScalar());

                        if (count > 0)
                        {
                            return true;
                        }
                        return false; 
                    }
                    catch (Exception ex)
                    {
                        ShowErrorMessage("Lỗi khi kiểm tra giỏ hàng: " + ex.Message);
                        return false;
                    }
                }
            }
        }
         private int GetCustomerId()
         {
            object customerId = HttpContext.Current.Session["CustomerID"];
            return customerId != null ? Convert.ToInt32(customerId) : 0;        
         }
        private void ShowErrorMessage(string message)
        {
            lblErrorMessage.Text = message;
            lblErrorMessage.Visible = true;
        }

    }
}

  

