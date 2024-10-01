using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Web_form
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=LAPTOP-8DV8N8U0\SQLEXPRESS;database=aspExample1;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = "select count(Id) from T2 where UserName='" + TextBox1.Text + "' and password='" + TextBox2.Text+ "'";
            SqlCommand cmd = new SqlCommand(str, con);
            con.Open();
            string cid = cmd.ExecuteScalar().ToString();
            con.Close();
            if (cid=="1")
            {
                string strr = "select Id from T2 where UserName='" + TextBox1.Text + "'and password='" + TextBox2.Text + "'";
                SqlCommand cmd1 = new SqlCommand(strr, con);
                con.Open();
                string id = cmd1.ExecuteScalar().ToString();
                con.Close();
                Session["uid"] = id;
                Response.Redirect("userdetails.aspx");
            }
            else
            {
                Label3.Text = "Invalid UserName and Password";
            }
        }
    }
}