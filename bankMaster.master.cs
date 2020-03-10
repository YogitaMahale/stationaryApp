using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class bankMaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (Session["type"].ToString().ToLower().Trim() != "Bank".ToLower().Trim() || Session["userid"]  == null || Session["username"] == null|| Session["type"]==null|| Session["bid"]==null)
            {
                Response.Redirect(Page.ResolveUrl("~/Default.aspx"));
            }
            else
            {
                
            }        
        }
        catch { }
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
