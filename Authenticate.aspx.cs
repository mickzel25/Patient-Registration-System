using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;

using System.Drawing;
using System.Text.RegularExpressions;
using System.Data.SqlTypes;
using System.Net.NetworkInformation;
using System.Data;
using System.Web.Services.Protocols;
using System.Diagnostics;

public partial class Authenticate : System.Web.UI.Page
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["condb"].ConnectionString);

    public SqlCommand sqlcmd, cmd;
    public SqlDataReader rdr;
    public string pagename = "Login.aspx";
    public string action, module;
    public string sqlstr;
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            user_authenticate();
        }
    }
    public void user_authenticate()
    {

        using (SqlConnection conn = new SqlConnection(con.ConnectionString))
        {
            using (SqlCommand cmd = new SqlCommand("Select * FROM Users WHERE  Username = @Username"))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Username", LoginName1.Page.User.Identity.Name);

                cmd.Connection = conn;
                conn.Open();
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {

                   
                        Page.Response.Redirect("Patiet_List.aspx");
                    

                }
                else
                {
                    //FormsAuthentication.RedirectToLoginPage();
                    //Page.Response.Redirect("Login");
                }
            }

        }
    }

}