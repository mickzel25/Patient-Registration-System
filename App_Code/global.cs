using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Globalization;
using System.Data.SqlClient;
using System.Drawing;

/// <summary>
/// Summary description for global
/// </summary>
public class global
{
    public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["condb"].ConnectionString);
    public SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["condb"].ConnectionString);
    public SqlCommand sqlcmd, cmd;
    public SqlDataReader rdr, dr;
    public string sqlstr;
    DateTime pacificdatenow = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.UtcNow, "Taipei Standard Time");
    public global()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public string Decrypt(string str)
    {
        str = str.Replace(" ", "+");
        string DecryptKey = "2013;[pnuLIT)WebCodeExpert";
        byte[] byKey = { };
        byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
        byte[] inputByteArray = new byte[str.Length];

        byKey = System.Text.Encoding.UTF8.GetBytes(DecryptKey.Substring(0, 8));
        DESCryptoServiceProvider des = new DESCryptoServiceProvider();
        inputByteArray = Convert.FromBase64String(str.Replace(" ", "+"));
        MemoryStream ms = new MemoryStream();
        CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(byKey, IV), CryptoStreamMode.Write);
        cs.Write(inputByteArray, 0, inputByteArray.Length);
        cs.FlushFinalBlock();
        System.Text.Encoding encoding = System.Text.Encoding.UTF8;
        return encoding.GetString(ms.ToArray());
    }
    public string Encrypt(string str)
    {
        string EncrptKey = "2013;[pnuLIT)WebCodeExpert";
        byte[] byKey = { };
        byte[] IV = { 18, 52, 86, 120, 144, 171, 205, 239 };
        byKey = System.Text.Encoding.UTF8.GetBytes(EncrptKey.Substring(0, 8));
        DESCryptoServiceProvider des = new DESCryptoServiceProvider();
        byte[] inputByteArray = Encoding.UTF8.GetBytes(str);
        MemoryStream ms = new MemoryStream();
        CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(byKey, IV), CryptoStreamMode.Write);
        cs.Write(inputByteArray, 0, inputByteArray.Length);
        cs.FlushFinalBlock();
        return Convert.ToBase64String(ms.ToArray());
    }
    public int audit_trail_add(string userid, string pagename, string action, string module, string details)
    {
        int stat = 0;

        using (SqlConnection conn = new SqlConnection(con.ConnectionString))
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into trans_audittrails (pagename,action,callfunction,logdetails,datelog,userid) values(@d1,@d2,@d3,@d4,@d5,@d6)", conn);
            cmd.Parameters.AddWithValue("@d6", userid);
            cmd.Parameters.AddWithValue("@d1", pagename);
            cmd.Parameters.AddWithValue("@d2", action);
            cmd.Parameters.AddWithValue("@d3", module);
            cmd.Parameters.AddWithValue("@d4", details);
            cmd.Parameters.AddWithValue("@d5", pacificdatenow.ToString("yyyy-MM-dd H:mm:ss"));
            int res = cmd.ExecuteNonQuery();
            if (res > 0)
            {
                stat = 1;
            }
            else
            {
                stat = 0;
            }
            conn.Close();
        }

        return stat;

    }
    public int get_userid(string user)
    {
        int uid = 0;
        if (user != null)
        {
            using (SqlConnection conn = new SqlConnection(con.ConnectionString))
            {

                conn.Open();
                string ct = "Select UserId  from Users where Username = '" + user + "'";
                cmd = new SqlCommand(ct);
                cmd.Connection = conn;
                rdr = cmd.ExecuteReader();
                if (rdr.Read())
                {
                    uid = Convert.ToInt32(rdr[0].ToString());
                }

                conn.Close();
                rdr.Close();
            }
        }

        return uid;
    }
}