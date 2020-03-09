using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class managezones : System.Web.UI.Page
{
    common ocommon = new common();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindZones();
            HtmlGenericControl hPageTitle = (HtmlGenericControl)this.Page.Master.FindControl("hPageTitle");
            hPageTitle.InnerText = "Manage Zones";
        }

        if (Request.QueryString["mode"] == "u")
        {
            spnMessage.Visible = true;
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "Information Updated Successfully!!!";
        }
        else if (Request.QueryString["mode"] == "i")
        {
            spnMessage.Visible = true;
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "Information Saved Successfully!!!";
        }
    }

    private void BindZones()
    {
        DataTable dtzone = (new Cls_zone_b().SelectAll());
        if (dtzone != null)
        {
            if (dtzone.Rows.Count > 0)
            {
                repCategory.DataSource = dtzone;
                repCategory.DataBind();
            }
            else
            {
                repCategory.DataSource = null;
                repCategory.DataBind();
            }
        }
        else
        {
            repCategory.DataSource = null;
            repCategory.DataBind();
        }
    }

    protected void repCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            HyperLink hlEdit = (HyperLink)e.Item.FindControl("hlEdit");
            hlEdit.NavigateUrl = Page.ResolveUrl("~/addeditzone.aspx?id=" + ocommon.Encrypt(DataBinder.Eval(e.Item.DataItem, "id").ToString(), true));
        }
    }


    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
        spnMessage.Visible = true;
        Int64 id = int.Parse((item.FindControl("lblid") as Label).Text);
        bool yes = (new Cls_zone_b().Delete(id));
        if (yes)
        {
            BindZones();
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "Record Deleted Successfully!!!";
        }
        else
        {
            spnMessage.Style.Add("color", "red");
            spnMessage.InnerText = "Failed To Delete Record...";
        }


    }

    protected void btnNewZone_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveUrl("~/addeditzone.aspx"));
    }



}