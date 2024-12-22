using System;
using System.Data.SqlClient;
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
           
            
            var user = GetUser(email, password);

            if (user != null)
            {
                // Lưu thông tin người dùng vào Session
                Session["CustomerName"] = user.FullName;
                Session["CustomerEmail"] = email;
                Session["CustomerID"] = user.User_id;
                // Chuyển hướng đến trang chủ
                Response.Redirect("ProductList.aspx");
            }
            else
            {
                // Hiển thị thông báo lỗi
                msg.Text = "Email hoặc mật khẩu không đúng!";
            }
        }

        private User GetUser(string email, string password)
        {
            User user = null;
            string connectionString = "Data Source=LAPTOP-KDQJ22JT\\NDSCDL;Initial Catalog=FlowerShop;Integrated Security=True";
            string query = "SELECT customer_id, first_name, last_name, password FROM Customer WHERE email = @Email";

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

                        // Kiểm tra mật khẩu nhập vào
                        if (VerifyPassword(password, storedPassword))
                        {
                            string firstName = reader["first_name"].ToString();
                            string lastName = reader["last_name"].ToString();
                            string customer_id = reader["customer_id"].ToString();
                            user = new User
                            {
                                FullName = $"{firstName} {lastName}",
                                User_id = $"{customer_id}"
                            };
                        }
                    }
                }
            }

            return user;
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

    public class User
    {
        public string FullName { get; set; }
        public string User_id { get; set; }
    }
}
