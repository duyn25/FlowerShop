using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FLowerShop.User
{
    public partial class SearchResult : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
              
                string keyword = Request.QueryString["keyword"];

                if (!string.IsNullOrEmpty(keyword))
                {
                  
                    SqlDataSourceSearch.SelectParameters["keyword"].DefaultValue = "%" + keyword + "%";
                }
                else
                {
                    
                   Response.Write("Không có từ khóa tìm kiếm"); 
                }
            }
        }
    }
}