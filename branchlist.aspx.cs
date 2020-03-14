using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class branchlist : System.Web.UI.Page
{
    common ocommon = new common();
    Int64 zoneid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Session["userid"] != null)
            {
                zoneid = Convert.ToInt64(Session["userid"].ToString());
            }
                BindBranches();
            HtmlGenericControl hPageTitle = (HtmlGenericControl)this.Page.Master.FindControl("hPagebankTitle");
            hPageTitle.InnerText = "Manage Branches";
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

    private void BindBranches()
    {

        DataTable dtbranch = (new Cls_branch_b().SelectAllByBankId(zoneid));
        if (dtbranch != null)
        {
            if (dtbranch.Rows.Count > 0)
            {
                repCategory.DataSource = dtbranch;
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
            //HyperLink hlEdit = (HyperLink)e.Item.FindControl("hlEdit");
            //hlEdit.NavigateUrl = Page.ResolveUrl("~/addeditbranch.aspx?id=" + ocommon.Encrypt(DataBinder.Eval(e.Item.DataItem, "branchid").ToString(), true));

        }
    }


    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
        spnMessage.Visible = true;
        Int64 id = int.Parse((item.FindControl("lblid") as Label).Text);
        bool yes = (new Cls_branch_b().Delete(id));
        if (yes)
        {
            BindBranches();
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "Record Deleted Successfully!!!";
        }
        else
        {
            spnMessage.Style.Add("color", "red");
            spnMessage.InnerText = "Failed To Delete Record...";
        }


    }

    protected void btnNewBranch_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveUrl("~/addeditbranch.aspx"));
    }



}