using FLowerShop.Models;
using System;
using System.Data.SqlClient;
using System.Web;
using System.Web.UI;

namespace FLowerShop.User
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           

        }
        
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text.Trim();
            string password = txtPassword.Text.Trim();
           
            
            Customer customer = GetCustomer(email, password);

            if (customer != null)
            {
                Session["Customer"] = customer;
               
                Response.Redirect("ProductList.aspx");
            }
            else
            {
                msg.Text = "Email hoặc mật khẩu không đúng!";
            }
        }

        private Customer GetCustomer(string email, string password)
        {
            Customer customer = null;
            string connectionString = "Data Source=LAPTOP-KDQJ22JT\\NDSCDL;Initial Catalog=FlowerShop;Integrated Security=True";
            string query = "SELECT customer_id, first_name, last_name, password, address, phone_number FROM Customer WHERE email = @Email";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string storedPassword = reader["password"].ToString();                    
                        if (VerifyPassword(password, storedPassword))
                        {
                            string firstName = reader["first_name"].ToString();
                            string lastName = reader["last_name"].ToString();                       
                            string customer_id = reader["customer_id"].ToString();
                            string address = reader["address"].ToString();  
                            string phone = reader["phone_number"].ToString();
                            customer = new Customer
                            {
                                CustomerId = Convert.ToInt32(customer_id),  
                                FirstName = firstName,
                                LastName = lastName,
                                Address = address,  
                                PhoneNumber = phone,      
                                Email = email
                            };
                        }
                    }
                }
            }
            return customer;
        }

        private bool VerifyPassword(string enteredPassword, string storedPassword)
        {
            string hashedPassword = HashPassword(enteredPassword);
            return hashedPassword == storedPassword;
        }

        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }
    }
}
