using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

//[System.Web.Script.Services.ScriptService]
public partial class managebranches : System.Web.UI.Page
{
    
    common ocommon = new common();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindBranches();
            HtmlGenericControl hPageTitle = (HtmlGenericControl)this.Page.Master.FindControl("hPageTitle");
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
        DataTable dtbranch = (new Cls_branch_b().SelectAll());
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
            HyperLink hlEdit = (HyperLink)e.Item.FindControl("hlEdit");
            hlEdit.NavigateUrl = Page.ResolveUrl("~/addeditbranch.aspx?id=" + ocommon.Encrypt(DataBinder.Eval(e.Item.DataItem, "branchid").ToString(), true));

            CheckBox chkid = (CheckBox)e.Item.FindControl("IsActive");
            chkid.InputAttributes.Add("data-id", DataBinder.Eval(e.Item.DataItem, "branchid").ToString());
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

    //protected void IsActive_CheckedChanged(object sender, EventArgs e)
    //{
    //    RepeaterItem item = (sender as CheckBox).Parent as RepeaterItem;
    //    Int32 BankId = int.Parse((item.FindControl("lblid") as Label).Text);
    //    bool chkSelected = Convert.ToBoolean((item.FindControl("IsActive") as CheckBox).Checked);
    //    bool yes = (new Cls_bankmaster_b().IsActive(BankId, chkSelected));
    //    if (yes)
    //    {
    //        BindBank();
    //        spnMessage.Style.Add("color", "green");
    //        spnMessage.InnerText = "Bank Updated Successfully";
    //    }
    //    else
    //    {
    //        spnMessage.Style.Add("color", "red");
    //        spnMessage.InnerText = "Bank Not Updated";
    //    }
    //}

    [WebMethod(EnableSession = true)]
    //[ScriptMethod(UseHttpGet = false, ResponseFormat = ResponseFormat.Json)]
    public static bool ToggleIsActive(string id)
    {
        bool yes = false;
        yes = new Cls_branch_b().ToggleIsActive(Convert.ToInt64(id));
        if (yes)
            return true;
        else
            return false;

    }
}