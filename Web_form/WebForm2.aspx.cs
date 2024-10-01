using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;


namespace Web_form
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=LAPTOP-8DV8N8U0\SQLEXPRESS;database=aspExample1;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string str ="insert into T1 values('"+TextBox1.Text+"',"+TextBox2.Text+",'"+TextBox3.Text+"')";
            SqlCommand cmd = new SqlCommand(str, con);
            con.Open();
            int i = cmd.ExecuteNonQuery();
            con.Close();
            if (i!=0)
            {
                Label4.Text = "Inserted";
            }
        }
    }
}