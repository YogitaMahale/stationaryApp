using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Aboutus : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        //BindBank();
        if(!IsPostBack)
        {
            HtmlGenericControl hPageTitle = (HtmlGenericControl)this.Page.Master.FindControl("hPageTitle");
            if (Request.QueryString["id"] != null)
            {

            }
            else
            {
                hPageTitle.InnerText = "About US";
                Page.Title = "About US";
                btnSave.Text = "Save";
                try
                {


                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = "aboutus_SelectAll";
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Connection = con;
                    con.Open();
                    DataSet ds = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(ds);

                    if (ds != null)
                    {
                        if (ds.Tables.Count > 0)
                        {
                            if (ds.Tables[0] != null)
                            {
                                txtDescription.Text = ds.Tables[0].Rows[0]["aboutus"].ToString();
                            }
                        }
                    }
                }
                catch
                { }
                finally { con.Close(); }
            }
        }
     
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "aboutus_Update";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@id";
            param.Value = 1;
            param.SqlDbType = SqlDbType.BigInt;
            param.Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add(param);
            cmd.Parameters.AddWithValue("@aboutus", txtDescription.Text.Trim());
           
            con.Open();
            cmd.ExecuteNonQuery();
          Int64   result = Convert.ToInt64(param.Value);

            if(result>0)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Record Saved Successfully')", true);


            }
            else
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Record not Saved')", true);

            }


        }
        catch (Exception ex)
        {
          
        }
        finally
        {
            con.Close();
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveUrl("~/superdashboard.aspx"));
    }

    protected void btnCancel_Click1(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveUrl("~/superdashboard.aspx"));
    }
}