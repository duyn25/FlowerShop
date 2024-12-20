using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FLowerShop.User
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPassword.Text;

            // Kiểm tra thông tin đăng nhập (dùng cơ sở dữ liệu hoặc logic đăng nhập)
            if (IsValidLogin(email, password))
            {
                // Chuyển hướng đến trang chính sau khi đăng nhập thành công
                Response.Redirect("Home.aspx");
            }
            else
            {
                // Hiển thị thông báo lỗi nếu thông tin không hợp lệ
                Response.Write("<script>alert('Thông tin đăng nhập không hợp lệ');</script>");
            }
        }

        private bool IsValidLogin(string email, string password)
        {
            // Kiểm tra thông tin đăng nhập với cơ sở dữ liệu
            // (Thực hiện truy vấn cơ sở dữ liệu để xác thực thông tin)
            return email == "user@example.com" && password == "password"; // Placeholder, thay thế bằng logic thực tế
        }
    }
}
    
