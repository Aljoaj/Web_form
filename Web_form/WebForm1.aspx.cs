using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;

namespace Web_form
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(@"server=LAPTOP-8DV8N8U0\SQLEXPRESS;database=aspExample1;integrated security=true");
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Panel1.Visible = true;
            Label25.Text = TextBox1.Text;
            Label26.Text = TextBox2.Text;
            Label27.Text = TextBox8.Text;
            Label28.Text = TextBox3.Text;
            Label29.Text = TextBox4.Text;
            Label30.Text = RadioButtonList1.SelectedItem.Text;
            Label31.Text = DropDownList1.SelectedItem.Text;

            string s = "";
            for (int i=0;i<CheckBoxList1.Items.Count;i++)
            {
                if (CheckBoxList1.Items[i].Selected)
                {
                    s = s + CheckBoxList1.Items[i].Text + ",";
                }
            }
            Label32.Text = s;

            string p = "~/Photos/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(p));
            Image1.ImageUrl = p;

            Label33.Text = TextBox5.Text;
            Label34.Text = TextBox6.Text;
            Label35.Text = TextBox7.Text;
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            string p = "~/Photos/" + FileUpload1.FileName;
            FileUpload1.SaveAs(MapPath(p));

            string s = "";
            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                if (CheckBoxList1.Items[i].Selected)
                {
                    s = s + CheckBoxList1.Items[i].Text + ",";
                }
            }
            string str = "Insert into T2 values('" + TextBox1.Text + "'," + TextBox2.Text + ",'" + TextBox8.Text + "'," + TextBox3.Text + ",'" + TextBox4.Text + "','" + RadioButtonList1.SelectedItem.Text + "','" + DropDownList1.SelectedItem.Text + "','" + s + "','" + p + "','" + TextBox5.Text + "','" + TextBox6.Text + "')";
            SqlCommand cmd = new SqlCommand(str, con);
            con.Open();
            int j = cmd.ExecuteNonQuery();
            con.Close();
            if (j!=0)
            {
                Label36.Text = "Inserted";
            }
        }

        protected void TextBox5_TextChanged(object sender, EventArgs e)
        {
            string ste = "select count (Id) from T2 where Username='" + TextBox5.Text + "'";
            SqlCommand cmd = new SqlCommand(ste, con);
            con.Open();
            string cid = cmd.ExecuteScalar().ToString();
            con.Close();
            int cid1 = Convert.ToInt32(cid);
            if(cid1>0)
            {
                Label37.Visible = true;
                Label37.Text = "Please choose another username";
            }
            else
            {
                Label37.Visible = false;
            }
        }
    }
}