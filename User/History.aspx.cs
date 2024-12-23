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
    public partial class History : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Customer"] == null)
            {
                Response.Redirect("Login.aspx");
            }

            Customer customer = (Customer)Session["Customer"];
            int customerId = customer.CustomerId;

            DataTable orderHistory = GetOrderHistory(customerId);

            rptOrderHistory.DataSource = orderHistory;
            rptOrderHistory.DataBind();
        }

        public DataTable GetOrderHistory(int customerId)
        {
            string connectionString = "Data Source=LAPTOP-KDQJ22JT\\NDSCDL;Initial Catalog=FlowerShop;Integrated Security=True";
            DataTable orderHistory = new DataTable();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                SELECT 
                    o.order_id, 
                    o.order_date, 
                    STRING_AGG(p.name, ', ') AS product_names,
                    SUM(oi.quantity) AS total_quantity, 
                    SUM(oi.quantity * oi.price) AS total_price
                FROM [Order] o
                INNER JOIN Order_Item oi ON o.order_id = oi.order_id
                INNER JOIN Product p ON oi.product_id = p.product_id
                WHERE o.customer_id = @customerId
                GROUP BY o.order_id, o.order_date
                ORDER BY o.order_date DESC;

                ";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@customerId", customerId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        orderHistory.Load(reader);
                    }
                }
            }

            return orderHistory;
        }

    }
}