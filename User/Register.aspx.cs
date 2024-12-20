using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FLowerShop.Models;


namespace FLowerShop.User
{
    public partial class Register : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnRegister_Click(object sender, EventArgs e)
        {
            string firstName = txtFirstName.Text.Trim();
            string lastName = txtLastName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string address = txtAddress.Text.Trim();
            string phone = txtPhone.Text.Trim();   
            string password = txtPassword.Text.Trim();
            string confirmPassword = txtConfirmPassword.Text.Trim();
            if (password != confirmPassword)
            {
                msg.Text = "Mật khẩu và xác nhận mật khẩu không khớp!";
                return;
            }

            if (IsEmailExist(email))
            {
                msg.Text = "Email này đã được đăng ký!";
                return;
            }

            string hashedPassword = HashPassword(password);

            if (RegisterUser(firstName, lastName, email, hashedPassword, address, phone))
            {
                ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Đăng ký thành công!'); window.location='Login.aspx';", true);
            }
            else
            {
                msg.Text = "Đăng ký không thành công. Vui lòng thử lại.";
            }
        }

        private bool IsEmailExist(string email)
        {
            bool emailExist = false;

            string connectionString = "Data Source=LAPTOP-KDQJ22JT\\NDSCDL;Initial Catalog=FlowerShop;Integrated Security=True";
            string query = "SELECT COUNT(*) FROM Customer WHERE email = @Email";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@Email", email);
                conn.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                emailExist = count > 0;
            }

            return emailExist;
        }
        private string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return Convert.ToBase64String(bytes);
            }
        }
        private bool RegisterUser(string firstName, string lastName, string email, string password, string address, string phone)
        {
            string connectionString = "Data Source=LAPTOP-KDQJ22JT\\NDSCDL;Initial Catalog=FlowerShop;Integrated Security=True";
            string query = "INSERT INTO Customer (first_name, last_name, email, password, address, phone_number, role) " +
                          "VALUES (@FirstName, @LastName, @Email, @Password, @Address, @Phone, 'User')";
            using (SqlConnection conn = new SqlConnection(connectionString)) { 
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@FirstName", firstName);
                cmd.Parameters.AddWithValue("@LastName", lastName);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Password", password);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@Phone", phone);
                try
                {
                    conn.Open();
                    int rowsAffected = cmd.ExecuteNonQuery();
                    return rowsAffected > 0;
                }
                catch (Exception ex)
                {
                    msg.Text = ex.Message;
                    return false;
                }
            }
        }
    }
}