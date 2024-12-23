using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI.WebControls;

namespace FLowerShop.User
{
    public partial class ProductList : System.Web.UI.Page
    {
        private int CurrentPageIndex
        {
            get
            {
                if (ViewState["CurrentPageIndex"] == null)
                {
                    ViewState["CurrentPageIndex"] = 0;
                }
                return (int)ViewState["CurrentPageIndex"];
            }
            set
            {
                ViewState["CurrentPageIndex"] = value;
            }
        }

        private const int PageSize = 8;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {          
            DataTable dt = GetProductData();
            PagedDataSource pagedDataSource = new PagedDataSource
            {
                DataSource = dt.DefaultView,
                AllowPaging = true,
                PageSize = PageSize,
                CurrentPageIndex = CurrentPageIndex
            };
            DataList1.DataSource = pagedDataSource;
            DataList1.DataBind();

            btnFirst.Enabled = CurrentPageIndex > 0;
            btnPrev.Enabled = CurrentPageIndex > 0;
            btnNext.Enabled = CurrentPageIndex < pagedDataSource.PageCount - 1;
            btnLast.Enabled = CurrentPageIndex < pagedDataSource.PageCount - 1;
        }

        private DataTable GetProductData()
        {           
            string connectionString = "Data Source=LAPTOP-KDQJ22JT\\NDSCDL;Initial Catalog=FlowerShop;Integrated Security=True";
            string query = "SELECT * FROM Product"; 

            using (var connection = new SqlConnection(connectionString))
            {
                var command = new SqlCommand(query, connection);
                var adapter = new SqlDataAdapter(command);
                var dt = new DataTable();
                adapter.Fill(dt);
                return dt;
            }
        }
        protected void btnFirst_Click(object sender, EventArgs e)
        {
            CurrentPageIndex = 0;
            BindData();
        }

        protected void btnPrev_Click(object sender, EventArgs e)
        {
            if (CurrentPageIndex > 0)
            {
                CurrentPageIndex--;
                BindData();
            }
        }

        protected void btnNext_Click(object sender, EventArgs e)
        {
            CurrentPageIndex++;
            BindData();
        }

        protected void btnLast_Click(object sender, EventArgs e)
        {
            CurrentPageIndex = int.MaxValue; 
            BindData();
        }
    }
}
