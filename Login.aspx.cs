using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Security;
using System.Drawing;
using System.Data.SqlTypes;
using System.Data;

public partial class Login : System.Web.UI.Page
{
    public string pagename = "Login.aspx";
    public global gb = new global();
    public int add, edit, delete, view, print;
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["condb"].ConnectionString);
    public string constr = ConfigurationManager.ConnectionStrings["condb"].ConnectionString;
    public SqlCommand sqlcmd, cmd;
    public SqlDataReader rdr;
   


   
    private void ConnectDB()
    {
        con = new SqlConnection(ConfigurationManager.ConnectionStrings["condb"].ConnectionString);
        con.Open();
    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        if (Login1.UserName == "" && Login1.Password == "")
        {
           Login1.FailureText = "Please input Username & Password!";
           // return;
        }
        if (Login1.UserName == "")
        {
            Login1.FailureText = "Please input Username!";
           // return;
        }
        if (Login1.Password == "")
        {
            Login1.FailureText = "Please input Password!";
           // return;
        }
        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
        if (Login1.UserName != "" && Login1.Password != "")
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                using (SqlCommand cmd = new SqlCommand("Select * FROM Users WHERE Username=@Username and Password=@Password and isactive=0"))
                {
                    
                    cmd.CommandType = CommandType.Text;
                    cmd.Parameters.AddWithValue("@Username", Login1.UserName);
                    cmd.Parameters.AddWithValue("@Password", gb.Encrypt(Login1.Password));


                    cmd.Connection = conn;
                    conn.Open();
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.Read())
                    {
                        string usid = dr["UserId"].ToString();
                        //FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet);
                        gb.audit_trail_add(usid, pagename, "Login", "ValidateUser_Auth", "Successfully logged-in " + Login1.UserName);
                        FormsAuthentication.SetAuthCookie(Login1.UserName, true);
                        Response.Redirect("Patient_List.aspx");



                    }
                    else
                    {
                        Login1.FailureText = "Wrong Username Or Password!";

                    }
                }
            }
        }
    }
}