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

public partial class managesubcategory : System.Web.UI.Page
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
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindMaincategory();
          //  BindCategory();
            HtmlGenericControl hPageTitle = (HtmlGenericControl)this.Page.Master.FindControl("hPageTitle");
            hPageTitle.InnerText = "Manage Sub Category";
        }

        if (Request.QueryString["mode"] == "u")
        {
            spnMessage.Visible = true;
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "Sub Category Updated Successfully";
        }
        else if (Request.QueryString["mode"] == "i")
        {
            spnMessage.Visible = true;
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "Sub Category Inserted Successfully";
        }
    }

    private void BindCategory(Int64 maincategoryId)
    {
        DataTable dtCategory = (new cls_subcategory_b().SelectAll(maincategoryId));
        if (dtCategory != null)
        {
            if (dtCategory.Rows.Count > 0)
            {
                repCategory.DataSource = dtCategory;
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

            Image imgCategory = (Image)e.Item.FindControl("imgCategory");
            HyperLink hlEdit = (HyperLink)e.Item.FindControl("hlEdit");
            hlEdit.NavigateUrl = Page.ResolveUrl("~/addeditsubcategory.aspx?id=" + ocommon.Encrypt(DataBinder.Eval(e.Item.DataItem, "id").ToString(), true));
            imgCategory.ImageUrl = categoryFrontPath + DataBinder.Eval(e.Item.DataItem, "imagename").ToString();

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
            bool yes = (new cls_subcategory_b().Delete(CategoryId));

            if (yes)
            {
                BindCategory(Convert.ToInt64(ddlmaincategory.SelectedValue.ToString()));
                spnMessage.Style.Add("color", "green");
                spnMessage.InnerText = "Sub Category Deleted Successfully";
            }
            else
            {
                spnMessage.Style.Add("color", "red");
                spnMessage.InnerText = "Sub Category Not Deleted";
            }
        //}
        //else
        //{
        //    spnMessage.Style.Add("color", "red");
        //    spnMessage.InnerText = "In this Maincategory Category added..so you can not delete.";
        //}

    }

    protected void IsActive_CheckedChanged(object sender, EventArgs e)
    {
        RepeaterItem item = (sender as CheckBox).Parent as RepeaterItem;
        spnMessage.Visible = true;
        Int64 CategoryId = int.Parse((item.FindControl("lblCategoryId") as Label).Text);
        bool chkSelected = Convert.ToBoolean((item.FindControl("IsActive") as CheckBox).Checked);
        bool yes = (new cls_subcategory_b().Category_IsActive(CategoryId, chkSelected));
        if (yes)
        {
            BindCategory(Convert.ToInt64(ddlmaincategory.SelectedValue.ToString()));
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "Sub Category Updated Successfully";
        }
        else
        {
            spnMessage.Style.Add("color", "red");
            spnMessage.InnerText = "Sub Category Not Updated";
        }
    }

    protected void btnNewCategoty_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveUrl("~/addeditsubcategory.aspx"));
    }



    protected void ddlmaincategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int64 maincategoryId = Convert.ToInt64(ddlmaincategory.SelectedValue.ToString());
        BindCategory(maincategoryId);
    }
}