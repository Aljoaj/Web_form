using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Web_form
{
    public partial class WebForm6 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=LAPTOP-8DV8N8U0\SQLEXPRESS;database=aspExample1;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            Bind_Grid();
        }
        public void Bind_Grid()
        {
            string str = "select * from T2";
            SqlDataAdapter suv = new SqlDataAdapter(str, con);
            DataSet ds = new DataSet();
            suv.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();
        }
    }
}