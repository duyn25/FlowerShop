using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FLowerShop.User
{
    public partial class CategoryList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Kiểm tra nếu có tham số category_id trong QueryString
                if (Request.QueryString["category_id"] != null)
                {
                    int categoryId;
                    if (int.TryParse(Request.QueryString["category_id"], out categoryId))
                    {
                        // Cập nhật câu lệnh SQL để sử dụng category_id đã chọn
                        SqlDataSource1.SelectParameters["category_id"].DefaultValue = categoryId.ToString();
                    }
                }
            }
        }
    }
}