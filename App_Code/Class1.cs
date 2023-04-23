using System;
using System.Data;
using System.Configuration;

using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

using MySql.Data;
using MySql.Data.MySqlClient;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Class1
{
    MySqlCommand  cm;
    MySqlConnection cn;
    MySqlDataReader dr;
    

    


    public string Connectionstring()
    {
        //mysql database


        string cs = @"Server=localhost;Port=3306;Database=ekartdb;User=root;Password=12345678;Character Set=utf8;";
      
        
        
        return cs;

    }


}