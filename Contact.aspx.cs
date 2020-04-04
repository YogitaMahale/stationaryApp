using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Contact : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {

        }

    }
   
   
    protected void Button1_Click(object sender, EventArgs e)
    {
        try
        {
            con.Open();
            //            txtfullname
            //txtemail
            //txtphone
            //txtsubject
            //txtmessage
            if (txtfullname.Text == "" || txtemail.Text == "" || txtphone.Text == "" || txtsubject.Text == "")
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Please Enter all fileds')", true);
            }
            else
            {
                // SqlCommand cmd = new SqlCommand();
                // cmd.CommandText = "bankmaster_SelectAll";
                // cmd.CommandType = CommandType.StoredProcedure;
                // cmd.Connection = con;
                // DataSet ds = new DataSet();
                //SqlDataAdapter  da = new SqlDataAdapter(cmd);
                // da.Fill(ds);

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "contactus_Insert";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Connection = con;

                SqlParameter param = new SqlParameter();
                param.ParameterName = "@id";
                param.Value = 0;
                param.SqlDbType = SqlDbType.BigInt;
                param.Direction = ParameterDirection.InputOutput;
                cmd.Parameters.Add(param);
                //branchid, zoneid, loginname, password, emailid, name, ifsccode, micrcode, address, phone, country, state, city, pincode, branchcode, mobileNo, gstno, road, appartment, isactive, isdeleted
                cmd.Parameters.AddWithValue("@fullname", txtfullname.Text);
                cmd.Parameters.AddWithValue("@email", txtemail.Text);
                cmd.Parameters.AddWithValue("@phoneno", txtphone.Text);
                cmd.Parameters.AddWithValue("@subject", txtsubject.Text);
                cmd.Parameters.AddWithValue("@message", txtmessage.Text);
                cmd.ExecuteNonQuery();
                Int64 result = Convert.ToInt64(param.Value);                
                if (result > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Record Send')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Record not Send')", true);
                }
                txtfullname.Text = "";
                txtemail.Text = "";
                txtphone.Text = "";
                txtsubject.Text = "";
                txtmessage.Text = "";
            }
        }
        catch(Exception p)
        { }
        finally { con.Close(); }


    }
}