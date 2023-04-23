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

public partial class _Default : System.Web.UI.Page
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
            bindgrid();
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
                Repeater1.DataSource = dr;
                Repeater1.DataBind();
            }
            cn.Close();
        }
        catch (Exception ex)
        {
             
        }

    }
}