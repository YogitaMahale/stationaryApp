using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class branchMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            
            //if (Session["type"].ToString().ToLower().Trim() != "Branch".ToLower().Trim() || Session["userid"] == null || Session["username"] == null || Session["type"] == null || Session["bid"] == null)
            if (Session["userid"] == null || Session["username"] == null || Session["type"] == null || Session["bid"] == null)
            {
                if (Session["type"].ToString().ToLower().Trim() != "Branch".ToLower().Trim())
                    Response.Redirect(Page.ResolveUrl("~/Default.aspx"));
            }
            else
            {
                if (Session["type"].ToString().ToLower().Trim() != "Branch".ToLower().Trim())
                {
                    Response.Redirect(Page.ResolveUrl("~/Default.aspx"));
                }
                else
                {
                    string dd = Session["type"].ToString();
                    loginUsername.InnerText = Session["username"].ToString();
                }

            }
        }
        catch (Exception ex) { }
        finally { }
    }
    protected void Logout_Click(Object sender, EventArgs e)
    {
        Session["userid"] = null;
        Session["username"] = null;
        Session["type"] = null;
        Session["bid"] = null;
        Response.Redirect(Page.ResolveUrl("~/Default.aspx"));

    }
}
