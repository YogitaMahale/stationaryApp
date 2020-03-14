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

            //if (Session["type"].ToString().ToLower().Trim() != "Bank".ToLower().Trim() || Session["userid"] == null || Session["username"] == null || Session["type"] == null || Session["bid"] == null)
            if (Session["userid"] == null || Session["username"] == null || Session["type"] == null || Session["bid"] == null)
            {
                Response.Redirect(Page.ResolveUrl("~/Default.aspx"));
            }
            else
            {
                if (Session["type"].ToString().ToLower().Trim() != "Bank".ToLower().Trim())
                {
                    Response.Redirect(Page.ResolveUrl("~/Default.aspx"));
                }
                else
                {
                    string dd = Session["type"].ToString();
                }
            }

        }
        catch (Exception ex) { }
        finally { }


        //if (Session["usertype"] != null)
        //{
        //    //if (Session["usertype"].ToString() == "superadmin" || Session["usertype"].ToString() == "user")
        //    if (Session["usertype"].ToString() == "1" || Session["usertype"].ToString() == "2" || Session["usertype"].ToString() == "3")
        //    {
        //        //divUserAuthority.Visible = true;
        //    }
        //    else
        //    {
        //        Response.Redirect(Page.ResolveUrl("~/Default.aspx"));
        //    }
        //}
        //else
        //{
        //    Response.Redirect(Page.ResolveUrl("~/Default.aspx"));
        //}
    }

    protected void Logout_Click(Object sender, EventArgs e)
    {
        Session["userid"] = null;
        Session["username"] = null;
        Session["type"] = null;
        Session["bid"] = null;
        Response.Redirect(Page.ResolveUrl("~/Default.aspx?logout=yes"));

    }
}
