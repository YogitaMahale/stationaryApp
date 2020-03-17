using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
public partial class bankMaster : System.Web.UI.MasterPage
{
 
    protected void Page_Load(object sender, EventArgs e)
    {
         
       
        try
        {

            //if (Session["type"].ToString().ToLower().Trim() != "Bank".ToLower().Trim() || Session["userid"] == null || Session["username"] == null || Session["type"] == null || Session["bid"] == null)
            if (Session["userid"] == null || Session["username"] == null || Session["type"] == null || Session["bid"] == null)
            {
                Response.Redirect(Page.ResolveUrl("~/Login.aspx"));
            }
            else
            {
                if (Session["type"].ToString().ToLower().Trim() != "Bank".ToLower().Trim())
                {
                    Response.Redirect(Page.ResolveUrl("~/Login.aspx"));
                }
                else
                {
                    loginUsername.InnerText = Session["username"].ToString();
                    string dd = Session["type"].ToString();
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
            if(b.logoimg=="")
            {

            }
            else
            {
               // importantImg.Src = Page.ResolveUrl("uploads\\banklogo\\" + b.logoimg + "");
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
        Response.Redirect(Page.ResolveUrl("~/Login.aspx?logout=yes"));

    }
}
