using FLowerShop.Models;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;

namespace FLowerShop.User
{
    public partial class Cart : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Customer"] == null)
            {
                Response.Redirect("~/User/Login.aspx");
            }
            else
            {

                LoadCart();

            }
        }
        protected void DeleteItem_Click(object sender, EventArgs e)
        {
            Button btnDelete = (Button)sender;
            int cartId = Convert.ToInt32(btnDelete.CommandArgument);

            try
            {
                DeleteCartItem(cartId);
                LoadCart();
                CalculateTotalAmount();


            }
            catch (Exception ex)
            {
                lblMessage.Text = "Có lỗi xảy ra: " + ex.Message;
            }
        }
        private void DeleteCartItem(int cartId)
        {
            string connectionString = "Data Source=LAPTOP-KDQJ22JT\\NDSCDL;Initial Catalog=FlowerShop;Integrated Security=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "DELETE FROM Cart WHERE cart_id = @cartId";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@cartId", cartId);
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();
                }
                catch (Exception ex)
                {

                    throw new Exception("Không thể xóa sản phẩm: " + ex.Message);
                }
            }
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

        private void LoadCart()
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
                            lblMessage.Text = "Giỏ hàng của bạn hiện tại trống!";
                        }
                    }
                }
            }

            CalculateTotalAmount();
        }

    }
}
