using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Privacy : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        //lblabout.InnerHtml = "yogita;";
        if (!IsPostBack)
        {
            try
            {


                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "privacyandpolicy_SelectAll";
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
                            lblabout.InnerHtml = ds.Tables[0].Rows[0]["description"].ToString();
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