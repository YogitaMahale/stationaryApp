using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class branchMaster : System.Web.UI.MasterPage
{
    string userid = string.Empty;
    common ocommon = new common();

    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            
            //if (Session["type"].ToString().ToLower().Trim() != "Branch".ToLower().Trim() || Session["userid"] == null || Session["username"] == null || Session["type"] == null || Session["bid"] == null)
            if (Session["userid"] == null || Session["username"] == null || Session["type"] == null || Session["bid"] == null)
            {
                //if (Session["type"].ToString().ToLower().Trim() != "Branch".ToLower().Trim())
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
        catch   { }
        finally { }
        if (!IsPostBack)
        {
            Cls_bankmaster_b obj = new Cls_bankmaster_b();
            Int64 bankid = Convert.ToInt64(Session["bankid"].ToString());
            bankmaster b = obj.SelectById(bankid);
            if (b.logoimg == "")
            {

            }
            else
            {
              //  importantImg.Src = Page.ResolveUrl("uploads\\banklogo\\" + b.logoimg + "");
                Img1.Src = Page.ResolveUrl("uploads\\banklogo\\" + b.logoimg + "");
            }

        }
    }
    protected void Logout_Click(Object sender, EventArgs e)
    {
        Session["userid"] = null;
        Session["username"] = null;
        Session["type"] = null;
        Session["bid"] = null;
        Response.Redirect(Page.ResolveUrl("~/Default.aspx"));

    }

    protected void EP_ServerClick(object sender, EventArgs e)
    {
        if(Session["userid"]!= null)
        {
            userid = Session["userid"].ToString();
            Response.Redirect(Page.ResolveUrl("~/addeditbranch.aspx?id=" + ocommon.Encrypt(userid.ToString(), true)));

        }

    }
}
