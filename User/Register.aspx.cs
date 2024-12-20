using System;
using System.Collections.Generic;
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
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string email = txtEmail.Text;
            string address = txtAddress.Text;
            string phone = txtPhone.Text;   
            string password = txtPassword.Text;
            string confirmPassword = txtConfirmPassword.Text;

            string query = $"INSERT INTO Customer (first_name, last_name, email, password, address, phone_number) " +
                          $"VALUES ('{firstName}', '{lastName}', '{email}', '{password}', '{address}', '{phone}')";
         
        }

        private bool RegisterUser(string firstName, string lastName, string email, string password)
        {
            // Thêm thông tin người dùng vào cơ sở dữ liệu (chưa cài đặt)
            return true; // Placeholder, thay thế bằng logic đăng ký thực tế
        }
    }
}