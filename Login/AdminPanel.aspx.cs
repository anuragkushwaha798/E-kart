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

public partial class Login_AdminPanel : System.Web.UI.Page
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

            Label1.Text = (string)Session["sess_UserId"];
            Label2.Text = (string)Session["sess_UserEmail"];
            Autogen();
            bindgrid();


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

                string k = "select max(id+1) from producttb ";

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


                Random rr = new Random();
                int n = (int)(rr.NextDouble() * 99999);
                FileUpload1.SaveAs(Server.MapPath("~/allimages/") + n.ToString() + FileUpload1.FileName);
                path1 = "~/allimages/" + n.ToString() + FileUpload1.FileName;



                if (FileUpload1.FileName == "")
                {
                    path1 = "~/Login/default.png";
                }


                string k = "INSERT INTO producttb(id, catg, name, dprice, oprice, matter, photo) VALUES ('"+ TextBox_Autogen.Text+"','"+ TextBox1_Catg.Text+"','"+ TextBox2_Name.Text+"','"+ TextBox3_Dprice.Text+"','"+ TextBox4_Oprice.Text+"','null','"+ path1.ToString()+"')";
                cm = new MySqlCommand(k, cn);
                cm.ExecuteNonQuery();



                Label_MSG.ForeColor = System.Drawing.Color.DarkGreen;
                Label_MSG.Text = "DATA UPDATED SUCCESSFULLY";

                Autogen();
                bindgrid();

            }
            cn.Close();
        }


        catch (Exception ex)
        {

            Label_MSG.ForeColor = System.Drawing.Color.Crimson;
            Label_MSG.Text = ex.ToString();
        }
    }


    public void bindgrid()
    {
        try
        {
            string connectionstring = cs.Connectionstring();
            cn = new MySqlConnection(connectionstring);
            if (cn.State != ConnectionState.Open)
            {
                cn.Open();
                string k = "select * from producttb ORDER BY id DESC  ";
                cm = new MySqlCommand(k, cn);
                dr = cm.ExecuteReader();
                GridView1.DataSource = dr;
                GridView1.DataBind();
            }
            cn.Close();
        }
        catch (Exception ex)
        {
            Label_MSG.ForeColor = System.Drawing.Color.Crimson;
            Label_MSG.Text = ex.ToString();
        }

    }


    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        try
        {
            string connectionstring = cs.Connectionstring();
            cn = new MySqlConnection(connectionstring);
            if (cn.State != ConnectionState.Open)
            {


                GridViewRow row = GridView1.Rows[e.RowIndex] as GridViewRow;
                Label id1 = (Label)row.FindControl("LabelA") as Label;



                MySqlCommand cm = new MySqlCommand();
                cm.CommandText = "delete from producttb where id=@id1";
                cm.Connection = cn;
                cm.Parameters.AddWithValue("@id1", id1.Text);


                cn.Open();
                cm.ExecuteNonQuery();
                cn.Close();
                bindgrid();
                Autogen();
                Label_MSG.ForeColor = System.Drawing.Color.DarkGreen;
                Label_MSG.Text = "DATA DELETED SUCCESSFULLY";
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