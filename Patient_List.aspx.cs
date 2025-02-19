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
public partial class Patient_List : System.Web.UI.Page
{
    public string pagename = "Patient_List.aspx";
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
        this.branch_table("");
    }
    protected void txtSearch_TextChanged(object sender, EventArgs e)
    {

        this.branch_table("");

    }
    protected void OnPaging(object sender, GridViewPageEventArgs e)
    {

        gv_branch.PageIndex = e.NewPageIndex;
        this.branch_table("");
    }
   
    private void branch_table(string top10)
    {

        //try
        //{
            using (SqlConnection conn = new SqlConnection(constr))
            {



                string sql = "select * from tbl_patient_info where void=0";

                if (txtSearch.Text != "")
                {
                    sql += " AND (lname LIKE '%" + txtSearch.Text + "%' OR fname LIKE'%" + txtSearch.Text + "%')";
                }
                //sql += "order by lname desc";
                using (SqlCommand cmd = new SqlCommand(sql))
                {
                    using (SqlDataAdapter sda = new SqlDataAdapter())
                    {
                        cmd.Connection = conn;
                        sda.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            sda.Fill(dt);
                            gv_branch.DataSource = dt;
                            gv_branch.DataBind();

                        }
                    }
                }
            }

        DecryptPatientData();
          //  lbl_item.Text = gb.footerinfo_gridview(gv_branch);
        //}
        //catch (Exception ex)
        //{
        //    WriteErrorLog(ex);
        //    ShowMessage("Sorry, some error occurred. Please contact the system administrator or check the log file.", "", MessageType.Error);
        //}



    }
    private void DecryptPatientData()
    {
     

        foreach (GridViewRow row in gv_branch.Rows)
        {
            Label lbl_lname = (Label)row.FindControl("lbl_lname");
            Label lbl_fname = (Label)row.FindControl("lbl_fname");
            Label lbl_mname = (Label)row.FindControl("lbl_mname");
            HiddenField hd_id = (HiddenField)row.FindControl("hd_id");
            HiddenField hd_lname = (HiddenField)row.FindControl("hd_lname");
            HiddenField hd_fname = (HiddenField)row.FindControl("hd_fname");
            HiddenField hd_mname = (HiddenField)row.FindControl("hd_mname");
            lbl_lname.Text = gb.Decrypt(hd_lname.Value);
            lbl_fname.Text = gb.Decrypt(hd_fname.Value);
            lbl_mname.Text = gb.Decrypt(hd_mname.Value);
        }
      



    }

    protected void gv_branch_RowDataBound(object sender, GridViewRowEventArgs e)
    {
    }

    protected void btn_view_Click(object sender, EventArgs e)
    {
        LinkButton btn_view = (LinkButton)sender;
        GridViewRow item = (GridViewRow)btn_view.NamingContainer;
        HiddenField hd_idselect = (HiddenField)item.FindControl("hd_id");

        //if (rp.identify_counter(" ref_motor where motorbrand ='" + hd_brandname.Value + "' ") > 0)
        //{
        //    ShowMessage("Unable to edit, already used by another process!", MessageType.Warning);
        //    return;
        //}
        hd_idview.Value = hd_idselect.Value;
       
      
        getdata1(hd_idselect.Value);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openViewModal();", true);
    }
    
   
    protected void btn_search_Click(object sender, EventArgs e)
    {
       
        branch_table("");
    }
        protected void btn_update_Click(object sender, EventArgs e)
    {
        ConnectDB();

        cmd = new SqlCommand("Update tbl_patient_info set lname=@lname,fname=@fname,mname=@mname,sex=@sex,bdate=@bdate,address=@address where patient_id='"+hd_idedit.Value+"'", con);
        cmd.Parameters.AddWithValue("@lname", gb.Encrypt(TextBox1.Text));
        cmd.Parameters.AddWithValue("@fname", gb.Encrypt(TextBox2.Text));
        cmd.Parameters.AddWithValue("@mname", gb.Encrypt(TextBox3.Text));
        cmd.Parameters.AddWithValue("@sex", TextBox4.Text);
        cmd.Parameters.AddWithValue("@bdate", TextBox5.Text);
        cmd.Parameters.AddWithValue("@address", TextBox6.Text);

        cmd.ExecuteNonQuery();
        gb.audit_trail_add(gb.get_userid(User.Identity.Name).ToString(), pagename, "Update", "Update_Patient", "Successfully Updated Patient " + hd_idedit.Value);
        Response.Redirect("Patient_List.aspx");

    }
        public void getdata(string patid)
    {

        if (patid.Length <= 0)
        {
            ShowMessage("Invalid selection!", "", MessageType.Warning);
            return;
        }
       
        using (SqlConnection conn = new SqlConnection(constr))
        {
            conn.Open();
            String cb = "select patient_id,lname,fname,mname,sex,address, REPLACE(CONVERT(VARCHAR(10), bdate, 102), '.', '-') as bdate from tbl_patient_info where patient_id=@patient_id";

            cmd = new SqlCommand(cb);
            cmd.Parameters.AddWithValue("@patient_id", patid);
            cmd.Connection = conn;
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                TextBox1.Text = gb.Decrypt(rdr["lname"].ToString());

               TextBox2.Text = gb.Decrypt(rdr["fname"].ToString());
                TextBox3.Text = gb.Decrypt(rdr["mname"].ToString());
                TextBox4.Text = rdr["sex"].ToString();
                TextBox5.Text= Convert.ToDateTime(rdr["bdate"].ToString()).ToString("yyyy-MM-dd");
                TextBox6.Text = rdr["address"].ToString();
            }
            rdr.Close();
            conn.Close();
        }

    }


    public void getdata1(string provid)
    {

        if (provid.Length <= 0)
        {
            ShowMessage("Invalid selection!", "", MessageType.Warning);
            return;
        }
        using (SqlConnection conn = new SqlConnection(constr))
        {
            conn.Open();
            String cb = "select * from tbl_patient_info where patient_id=@ID ";

            cmd = new SqlCommand(cb);
            cmd.Parameters.AddWithValue("@ID", provid);
            cmd.Connection = conn;
            rdr = cmd.ExecuteReader();
            if (rdr.Read())
            {
                txt_lname.Text = gb.Decrypt(rdr["lname"].ToString());

                txt_fname.Text = gb.Decrypt(rdr["fname"].ToString());
                txt_mname.Text = gb.Decrypt(rdr["mname"].ToString());
                txt_sex.Text = rdr["sex"].ToString();
                txt_bdate.Text = Convert.ToDateTime(rdr["bdate"].ToString()).ToString("yyyy-MM-dd");
                txt_address.Text = rdr["address"].ToString();
            }
            rdr.Close();
            conn.Close();
        }

    }
    protected void btn_edit_Click(object sender, EventArgs e)
    {
        LinkButton btn_view = (LinkButton)sender;
        GridViewRow item = (GridViewRow)btn_view.NamingContainer;
        HiddenField hd_idselect = (HiddenField)item.FindControl("hd_id");

        hd_idedit.Value = hd_idselect.Value;


        getdata(hd_idselect.Value);
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openEditModal();", true);
    }
    protected void btn_delete_Click(object sender, EventArgs e)
    {
        LinkButton btn_view = (LinkButton)sender;
        GridViewRow item = (GridViewRow)btn_view.NamingContainer;
        HiddenField hd_idselect = (HiddenField)item.FindControl("hd_id");

        
        hd_iddelete.Value = hd_idselect.Value;
        ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "openDeleteModal();", true);
    }
    protected void btn_softdelete_Click(object sender, EventArgs e)
    {
        ConnectDB();
        cmd = new SqlCommand("Update tbl_patient_info set void=1 where patient_id='"+ hd_iddelete.Value +"' ", con);
        cmd.ExecuteNonQuery();
        gb.audit_trail_add(gb.get_userid(User.Identity.Name).ToString(), pagename, "Delete", "Delete_Patient", "Successfully Deleted Patient " + hd_iddelete.Value);
        this.branch_table("");

        Response.Redirect("Patient_List.aspx");
    }
        protected void btn_selectbranch3_Click(object sender, EventArgs e)
    {
        string ID = string.Format((sender as LinkButton).CommandArgument);
        string ID1 = Convert.ToString(ID);
        string valueToPass = ID1;
       
    }
}