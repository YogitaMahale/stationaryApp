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

public partial class managecategory : System.Web.UI.Page
{
    string categoryFrontPath = "~/uploads/maincategory/front/";
    common ocommon = new common();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindCategory();
            HtmlGenericControl hPageTitle = (HtmlGenericControl)this.Page.Master.FindControl("hPageTitle");
            hPageTitle.InnerText = "Manage Main Category";
        }

        if (Request.QueryString["mode"] == "u")
        {
            spnMessage.Visible = true;
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "Main Category Updated Successfully";
        }
        else if (Request.QueryString["mode"] == "i")
        {
            spnMessage.Visible = true;
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "Main Category Inserted Successfully";
        }
    }

    private void BindCategory()
    {
        DataTable dtCategory = (new cls_maincategory_b().SelectAll());
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
            hlEdit.NavigateUrl = Page.ResolveUrl("~/addeditmaincategory.aspx?id=" + ocommon.Encrypt(DataBinder.Eval(e.Item.DataItem, "id").ToString(), true));
            imgCategory.ImageUrl = categoryFrontPath + DataBinder.Eval(e.Item.DataItem, "imagename").ToString();
             
        }
    }

     
    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
        Int64 ProductCount = int.Parse((item.FindControl("lblProductCount") as Label).Text);
        spnMessage.Visible = true;
        if (ProductCount.ToString() == "0")
        {
            Int64 CategoryId = int.Parse((item.FindControl("lblCategoryId") as Label).Text);
            bool yes = (new cls_maincategory_b().Delete(CategoryId));

            if (yes)
            {
                BindCategory();
                spnMessage.Style.Add("color", "green");
                spnMessage.InnerText = "Main Category Deleted Successfully";
            }
            else
            {
                spnMessage.Style.Add("color", "red");
                spnMessage.InnerText = "Main Category Not Deleted";
            }
        }
        else
        {
            spnMessage.Style.Add("color", "red");
            spnMessage.InnerText = "Sub Category is present in this Main Category... So you can not delete.";
        }

    }

    protected void IsActive_CheckedChanged(object sender, EventArgs e)
    {
        RepeaterItem item = (sender as CheckBox).Parent as RepeaterItem;
        Int64 CategoryId = int.Parse((item.FindControl("lblCategoryId") as Label).Text);
        bool chkSelected = Convert.ToBoolean((item.FindControl("IsActive") as CheckBox).Checked);
        bool yes = (new cls_maincategory_b().Category_IsActive(CategoryId, chkSelected));
        if (yes)
        {
            BindCategory();
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "Main Category Updated Successfully";
        }
        else
        {
            spnMessage.Style.Add("color", "red");
            spnMessage.InnerText = "Main Category Not Updated";
        }
    }

    protected void btnNewCategoty_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveUrl("~/addeditmaincategory.aspx"));
    }

    
}