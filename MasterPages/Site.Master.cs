using FLowerShop.Models;
using System;
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
            if (Session["Customer"] != null)
            {
                // Lấy đối tượng Customer từ session
                Customer customer = (Customer)Session["Customer"];
                string fullName = customer.FirstName + " " + customer.LastName;

               
                lblFullname.Text = fullName;

            }
        }
        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();

            Response.Redirect("./Home.aspx");
        }
    }
}