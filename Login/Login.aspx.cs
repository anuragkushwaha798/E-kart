using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using MySql.Data;
using MySql.Data.MySqlClient;

using System.Net.Mail;
using System.Globalization;
using System.IO;
using System.Text;
using System.Net;

public partial class Login_Login : System.Web.UI.Page
{
    MySqlCommand cm;
    MySqlConnection cn;
    MySqlDataReader dr;
    Class1 cs = new Class1();

    string path1;

    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            string connectionstring = cs.Connectionstring();
            cn = new MySqlConnection(connectionstring);
            if (cn.State != ConnectionState.Open)
            {
                cn.Open();

                string k = "select id, email from registertb WHERE email='" + TextBox1_Email.Text + "' AND password='" + TextBox2_Pass.Text + "' ";

                cm = new MySqlCommand(k, cn);
                dr = cm.ExecuteReader();
                if (dr.Read())
                {
                    Session["sess_UserId"] = dr[0].ToString();
                    Session["sess_UserEmail"] = dr[1].ToString();

                    Response.Redirect("AdminPanel.aspx");

                }
                else
                {
                    Label_MSG.ForeColor = System.Drawing.Color.OrangeRed;
                    Label_MSG.Text = "INCORRECT USERNAME or PASSWORD. PLEASE LOGIN or FORGOT PASSWORD";
                }
                dr.Close();
            }
            cn.Close();
        }
        catch (Exception ex)
        {
            Label_MSG.ForeColor = System.Drawing.Color.Crimson;
            Label_MSG.Text = ex.ToString();

        }
    }
}