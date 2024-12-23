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
                if (Request.QueryString["category_id"] != null)
                {
                    int categoryId;
                    if (int.TryParse(Request.QueryString["category_id"], out categoryId))
                    {
                        SqlDataSource1.SelectParameters["category_id"].DefaultValue = categoryId.ToString();
                    }
                }
            }
        }
    }
}