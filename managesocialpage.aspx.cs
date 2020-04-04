using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
public partial class managesocialpage : System.Web.UI.Page
{
    common ocommon = new common();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        Int64 customerid = 1;
        if (!Page.IsPostBack)
        {
            if (Session["WebsiteLogincustomerid"] != null || Session["WebsiteLogincustomerName"] != null)
            {
                customerid = Convert.ToInt64(Session["WebsiteLogincustomerid"].ToString());
            }
            //if (Session["customerid"] != null)
            //{
            //    customerid = Convert.ToInt64(Session["customerid"].ToString());

            //}
            bindsocialInfo(customerid);
        }
    }
    private void bindsocialInfo(Int64 customerid)
    {
        DataTable dtVendor = (new cls_socialinfo_b().SelectAll(customerid));
        if (dtVendor != null)
        {
            if (dtVendor.Rows.Count > 0)
            {
                repsocialinfo.DataSource = dtVendor;
                repsocialinfo.DataBind();
            }
            else
            {
                repsocialinfo.DataSource = null;
                repsocialinfo.DataBind();
            }
        }
        else
        {
            repsocialinfo.DataSource = null;
            repsocialinfo.DataBind();
        }
    }
    protected void lnkremove_Click(object sender, EventArgs e)
    {
        RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;

        spnMessage.Visible = true;

        Int32 lblid = int.Parse((item.FindControl("lblid") as Label).Text);
        bool yes = (new cls_socialinfo_b().Delete(lblid));

        if (yes)
        {
            

            bindsocialInfo(Convert.ToInt64(Session["customerid"].ToString()));
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "Record Deleted Successfully";
        }
        else
        {
            spnMessage.Style.Add("color", "red");
            spnMessage.InnerText = "Record Boy Not Deleted";
        }

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveUrl("~/socialpage.aspx"));
    }

    protected void repsocialinfo_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            HyperLink hlEdit = (HyperLink)e.Item.FindControl("hlEdit");
            hlEdit.NavigateUrl = Page.ResolveUrl("~/socialpage.aspx?id=" + ocommon.Encrypt(DataBinder.Eval(e.Item.DataItem, "id").ToString(), true));
 
        }
    }
}