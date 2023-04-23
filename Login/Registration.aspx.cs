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

public partial class Login_Registration : System.Web.UI.Page
{

    MySqlCommand cm;
    MySqlConnection cn;
    MySqlDataReader dr;
    Class1 cs = new Class1();

    string path1;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           

            Autogen();
            

        }
    }

    public void Autogen()
    {
        //Auto Generate ID

        try
        {
            string connectionstring = cs.Connectionstring();
            cn = new MySqlConnection(connectionstring);
            if (cn.State != ConnectionState.Open)
            {

                cn.Open();
                if (TextBox_Autogen.Text == "")
                {
                    TextBox_Autogen.Text = " 1";
                }

                string k = "select max(id+1) from registertb ";

                cm = new MySqlCommand(k, cn);
                dr = cm.ExecuteReader();
                dr.Read();

                TextBox_Autogen.Text = dr[0].ToString();
                if (TextBox_Autogen.Text == "")
                {
                    TextBox_Autogen.Text = " 1";
                }
            }
            cn.Close();
        }
        catch (Exception ex)
        {
            Label_MSG.ForeColor = System.Drawing.Color.Crimson;
            Label_MSG.Text = ex.ToString();

        }
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {

            Autogen();
            string connectionstring = cs.Connectionstring();
            cn = new MySqlConnection(connectionstring);
            if (cn.State != ConnectionState.Open)
            {

                cn.Open();

                string k = "INSERT INTO registertb(id, name, email, password, mobile) VALUES ('" + TextBox_Autogen.Text + "','" + TextBox1_FullName.Text + "','" + TextBox2_Email.Text + "','" + TextBox3_Password.Text + "','" + TextBox4_Mobile.Text + "')";
                cm = new MySqlCommand(k, cn);
                cm.ExecuteNonQuery();



                Label_MSG.ForeColor = System.Drawing.Color.DarkGreen;
                Label_MSG.Text = "DATA UPDATED SUCCESSFULLY";

                Autogen();
                

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