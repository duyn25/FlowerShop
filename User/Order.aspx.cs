using FLowerShop.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FLowerShop.User
{
    public partial class Order : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Customer"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            Customer customer = (Customer)Session["Customer"];          
            txtho.Text = customer.FirstName;
            txtten.Text = customer.LastName;
            txtsdt.Text = customer.PhoneNumber;
            txtemail.Text = customer.Email;
            txtdiachi.Text = customer.Address;
            LoadOrder();
        }

        private void LoadOrder()
        {
            string connectionString = "Data Source=LAPTOP-KDQJ22JT\\NDSCDL;Initial Catalog=FlowerShop;Integrated Security=True";

            Customer customer = (Customer)Session["Customer"];

            int customerId = customer.CustomerId;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = "SELECT c.cart_id, c.customer_id, c.product_id, p.name, p.image, c.quantity, p.price " +
                               "FROM Cart c INNER JOIN Product p ON c.product_id = p.product_id " +
                               "WHERE c.customer_id = @customerId";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@customerId", customerId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            DataTable dt = new DataTable();
                            dt.Load(reader);

                            Repeater1.DataSource = dt;
                            Repeater1.DataBind();
                        }
                        else
                        {

                            Repeater1.DataSource = null;
                            Repeater1.DataBind();
                        }
                    }
                }
            }

            CalculateTotalAmount();
        }
        private void CalculateTotalAmount()
        {
            decimal totalAmount = 0;
            foreach (RepeaterItem item in Repeater1.Items)
            {
                Label totalLabel = (Label)item.FindControl("totalLabel");

                if (totalLabel != null)
                {
                    totalAmount += Convert.ToDecimal(totalLabel.Text);
                }
            }

            lblTotalAmount.Text = totalAmount.ToString("#,0") + " VND";
        }

        protected void btnConfirmOrder_Click(object sender, EventArgs e)
        {
            try
            {
                Customer customer = (Customer)Session["Customer"];
                int customerId = customer.CustomerId;

                decimal totalAmount = Convert.ToDecimal(lblTotalAmount.Text.Replace(" VND", "").Replace(",", ""));

                string connectionString = "Data Source=LAPTOP-KDQJ22JT\\NDSCDL;Initial Catalog=FlowerShop;Integrated Security=True";
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlTransaction transaction = conn.BeginTransaction())
                    {
                        try
                        {
                            string orderQuery = "INSERT INTO [Order] (order_date, customer_id, total_price, status) " +
                                                "VALUES (@OrderDate, @CustomerId, @TotalPrice, @Status); SELECT SCOPE_IDENTITY();";
                            int orderId;

                            using (SqlCommand cmd = new SqlCommand(orderQuery, conn, transaction))
                            {
                                cmd.Parameters.AddWithValue("@OrderDate", DateTime.Now);
                                cmd.Parameters.AddWithValue("@CustomerId", customerId);
                                cmd.Parameters.AddWithValue("@TotalPrice", totalAmount);
                                cmd.Parameters.AddWithValue("@Status", "Complete");

                                orderId = Convert.ToInt32(cmd.ExecuteScalar());
                            }

                            foreach (RepeaterItem item in Repeater1.Items)
                            {
                                var productId = Convert.ToInt32(((HiddenField)item.FindControl("productId")).Value);
                                var price = Convert.ToDecimal(((HiddenField)item.FindControl("price")).Value);
                                var quantity = Convert.ToInt32(((Label)item.FindControl("quantityLabel")).Text);

                                string orderItemQuery = "INSERT INTO Order_Item (order_id, product_id, quantity, price) " +
                                                         "VALUES (@OrderId, @ProductId, @Quantity, @Price)";

                                using (SqlCommand cmd = new SqlCommand(orderItemQuery, conn, transaction))
                                {
                                    cmd.Parameters.AddWithValue("@OrderId", orderId);
                                    cmd.Parameters.AddWithValue("@ProductId", productId);
                                    cmd.Parameters.AddWithValue("@Quantity", quantity);
                                    cmd.Parameters.AddWithValue("@Price", price);

                                    cmd.ExecuteNonQuery(); 
                                }
                            }

                            transaction.Commit();
                        }
                        catch (Exception ex)
                        {
                            transaction.Rollback();
                            throw new Exception("Có lỗi xảy ra khi lưu đơn hàng: " + ex.Message);
                        }
                    }
                }

                lblMessage.Text = "Đơn hàng của bạn đã được xác nhận!";
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Có lỗi xảy ra: " + ex.Message;
            }
        }

    }


}