using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Web_form
{
    public partial class userdetails : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=LAPTOP-8DV8N8U0\SQLEXPRESS;database=aspExample1;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string sel = "select Name,Age,Address,Phone,Photo from T2 where Id=" + Session["uid"] + "";
                SqlCommand cmd = new SqlCommand(sel, con);
                con.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TextBox1.Text = dr["Name"].ToString();
                    TextBox2.Text = dr["Age"].ToString();
                    TextBox3.Text = dr["Address"].ToString();
                    TextBox4.Text = dr["Phone"].ToString();
                    Image1.ImageUrl = dr["Photo"].ToString();
                }
                con.Close();
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = "update T2 set Age ="+TextBox2.Text+",Address='"+TextBox3.Text+"'where Id=" + Session["uid"] + "";
            SqlCommand cmd = new SqlCommand(str, con);
            con.Open();
            int i1 = cmd.ExecuteNonQuery();
            con.Close();
            if (i1==1)
            {
                Label6.Text = "Updated";
            }
        }
    }
}