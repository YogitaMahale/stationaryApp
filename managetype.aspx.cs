using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class managetype : System.Web.UI.Page
{
    string categoryFrontPath = "~/uploads/subcategory/front/";
    common ocommon = new common();
    private void BindMaincategory()
    {
        DataTable dtRawmaterial = (new cls_maincategory_b().SelectAll());
        ddlmaincategory.Items.Clear();

        if (dtRawmaterial != null)
        {
            if (dtRawmaterial.Rows.Count > 0)
            {
                ddlmaincategory.DataSource = dtRawmaterial;
                ddlmaincategory.DataTextField = "categoryname";
                ddlmaincategory.DataValueField = "id";
                ddlmaincategory.DataBind();
                ListItem objListItem = new ListItem("--Select Category--", "0");

                ddlmaincategory.Items.Insert(0, objListItem);
            }
        }
    }
    private void Bindsubcategory()
    {
        Int64 maincategoryId = Convert.ToInt64(ddlmaincategory.SelectedValue.ToString()); ;
        DataTable dt  = (new cls_subcategory_b().SelectAll(maincategoryId));
        ddlsubcategory.Items.Clear();

        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                ddlsubcategory.DataSource = dt;
                ddlsubcategory.DataTextField = "categoryname";
                ddlsubcategory.DataValueField = "id";
                ddlsubcategory.DataBind();
                ListItem objListItem = new ListItem("--Select Subcategory--", "0");

                ddlsubcategory.Items.Insert(0, objListItem);
            }
        }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindMaincategory();
            //  BindCategory();
            HtmlGenericControl hPageTitle = (HtmlGenericControl)this.Page.Master.FindControl("hPageTitle");
            hPageTitle.InnerText = "Manage Type";
        }

        if (Request.QueryString["mode"] == "u")
        {
            spnMessage.Visible = true;
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "Type Updated Successfully";
        }
        else if (Request.QueryString["mode"] == "i")
        {
            spnMessage.Visible = true;
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "Type Inserted Successfully";
        }
    }

    private void bindType(Int64 subcategoryId)
    {

        DataTable dtCategory = (new cls_typemaster_b().SelectAll(subcategoryId));
        if (dtCategory != null)
        {
            if (dtCategory.Rows.Count > 0)
            {
                repType.DataSource = dtCategory;
                repType.DataBind();
            }
            else
            {
                repType.DataSource = null;
                repType.DataBind();
            }
        }
        else
        {
            repType.DataSource = null;
            repType.DataBind();
        }
    }

    

    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
        // Int64 ProductCount = int.Parse((item.FindControl("lblProductCount") as Label).Text);
        spnMessage.Visible = true;
        //if (ProductCount.ToString() == "0")
        //{
        Int64 CategoryId = int.Parse((item.FindControl("lblCategoryId") as Label).Text);
        bool yes = (new cls_typemaster_b().Delete(CategoryId));

        if (yes)
        {
            bindType(Convert.ToInt64(ddlsubcategory.SelectedValue.ToString()));
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "Type Deleted Successfully";
        }
        else
        {
            spnMessage.Style.Add("color", "red");
            spnMessage.InnerText = "Type Not Deleted";
        }
        //}
        //else
        //{
        //    spnMessage.Style.Add("color", "red");
        //    spnMessage.InnerText = "In this Maincategory Category added..so you can not delete.";
        //}

    }

    //protected void IsActive_CheckedChanged(object sender, EventArgs e)
    //{
    //    RepeaterItem item = (sender as CheckBox).Parent as RepeaterItem;
    //    spnMessage.Visible = true;
    //    Int64 CategoryId = int.Parse((item.FindControl("lblCategoryId") as Label).Text);
    //    bool chkSelected = Convert.ToBoolean((item.FindControl("IsActive") as CheckBox).Checked);
    //    bool yes = (new cls_subcategory_b().Category_IsActive(CategoryId, chkSelected));
    //    if (yes)
    //    {
    //        BindCategory(Convert.ToInt64(ddlmaincategory.SelectedValue.ToString()));
    //        spnMessage.Style.Add("color", "green");
    //        spnMessage.InnerText = "Subcategory Updated Successfully";
    //    }
    //    else
    //    {
    //        spnMessage.Style.Add("color", "red");
    //        spnMessage.InnerText = "Subcategory Not Updated";
    //    }
    //}

    protected void btnNewCategoty_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveUrl("~/addeditType.aspx"));
    }



    protected void ddlmaincategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int64 maincategoryId = Convert.ToInt64(ddlmaincategory.SelectedValue.ToString());
        Bindsubcategory();
    }

    protected void ddlsubcategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int64 subcategoryId = Convert.ToInt64(ddlsubcategory .SelectedValue.ToString());
        bindType(subcategoryId);
    }

    protected void repType_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {


            HyperLink hlEdit = (HyperLink)e.Item.FindControl("hlEdit");
            hlEdit.NavigateUrl = Page.ResolveUrl("~/addeditType.aspx?id=" + ocommon.Encrypt(DataBinder.Eval(e.Item.DataItem, "id").ToString(), true));

        }
    }
}