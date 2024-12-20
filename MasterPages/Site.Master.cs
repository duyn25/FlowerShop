﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FLowerShop
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Xóa toàn bộ Session
            Session.Clear();
            Session.Abandon();

            // Điều hướng về trang Home
            Response.Redirect("./Home.aspx");
        }
    }
}