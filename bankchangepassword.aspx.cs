using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class bankchangepassword : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            HtmlGenericControl hPageTitle = (HtmlGenericControl)this.Page.Master.FindControl("hPagebankTitle");
            hPageTitle.InnerText = "Manage Password";
        }
    }

    protected void btnChangePassword_Click(object sender, EventArgs e)
    {
        try
        {
            con.Open();
            if (Session["userid"] != null)
            {
                string UserID = Session["userid"].ToString();
                string s = "update zonemaster set password='" + txtPassword.Text.Trim() + "' where id=" + UserID + "";
                SqlCommand cmd = new SqlCommand(s, con);
                int t = cmd.ExecuteNonQuery();
                if (t > 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Password changed successfully !!!')", true);
                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Failed to change password...')", true);
                }
                txtPassword.Text = string.Empty;
                txtConfirmPassword.Text = string.Empty;
            }
        }
        catch { }
        finally { con.Close(); }
    }
}