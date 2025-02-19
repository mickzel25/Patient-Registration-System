using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;


public partial class Register_Patient : System.Web.UI.Page
{
    public string pagename = "Register_Patient.aspx";
    public global gb = new global();
    public int add, edit, delete, view, print;
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["condb"].ConnectionString);
    public string constr = ConfigurationManager.ConnectionStrings["condb"].ConnectionString;
    public SqlCommand sqlcmd, cmd;
    public SqlDataReader rdr;
    public enum MessageType { Success, Error, Warning, Information };

  
    public void ShowMessage(string msg, string title, MessageType type)
    {
        ScriptManager.RegisterStartupScript(this, typeof(Page), "msg1", "<script>MessageShow('" + msg + "', '" + title + "','" + type + "')</script>", false);
    }
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
        ConnectDB();

        cmd = new SqlCommand("Insert into tbl_patient_info (lname,fname,mname,sex,bdate,address,void)VALUES(@lname,@fname,@mname,@sex,@bdate,@address,@void)", con);
        cmd.Parameters.AddWithValue("@lname", gb.Encrypt(txt_lname.Text));
        cmd.Parameters.AddWithValue("@fname", gb.Encrypt(txt_fname.Text));
        cmd.Parameters.AddWithValue("@mname", gb.Encrypt(txt_mname.Text));
        cmd.Parameters.AddWithValue("@sex", txt_sex.Text);
        cmd.Parameters.AddWithValue("@bdate", txt_bdate.Text);
        cmd.Parameters.AddWithValue("@address", txt_address.Text);
        cmd.Parameters.AddWithValue("void", "0");
        cmd.ExecuteNonQuery();
        ShowMessage("Successfully Save", "", MessageType.Success);
        gb.audit_trail_add(gb.get_userid(User.Identity.Name).ToString(), pagename, "Add", "Add_Patient", "Successfully Added Patient " + txt_lname.Text);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openModal();", true);
    }
}