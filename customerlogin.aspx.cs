using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
public partial class customerlogin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {

        }
    }

    protected void btnlogin_Click(object sender, EventArgs e)
    {
        try
        {
            cls_customermaster_b obj = new cls_customermaster_b();
            DataTable dt = obj.customerLogin(txtmobileno.Text, txtpassword.Text);
            if (dt != null)
            {
                if (dt.Rows.Count > 0)
                {

                    //bool Status = Convert.ToBoolean(dtUser.Rows[0]["isactive"]);
                    //if (Status)
                    //{
                        Session.Timeout = 120;
                        Session["customerid"] = dt.Rows[0]["id"].ToString();
                      Session["WebsiteLogincustomerid"] = dt.Rows[0]["id"].ToString();
                    Session["WebsiteLogincustomerName"] = dt.Rows[0]["customername"].ToString();
                    Response.Redirect(Page.ResolveUrl("~/Default.aspx"));

                    //}
                    //else
                    //{
                    //    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Your Account Under Admin Observation. Please wait for admin confirmation')", true);
                    //}


                }
                else
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Please Enter Proper Mobile no and Password')", true);
                    Session["WebsiteLogincustomerid"] = null;
                    Session["WebsiteLogincustomerName"] = null;
                }

            }
        }
        catch { }
        finally { }
    }
}