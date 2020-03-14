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
public partial class manageproduct : System.Web.UI.Page
{
    string categoryFrontPath = "~/uploads/product/front/";
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
        DataTable dt = (new cls_subcategory_b().SelectAll(maincategoryId));
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
            //BindCategory();

            HtmlGenericControl hPageTitle = (HtmlGenericControl)this.Page.Master.FindControl("hPageTitle");
            hPageTitle.InnerText = "Manage Product";
        }

        if (Request.QueryString["mode"] == "u")
        {
            spnMessage.Visible = true;
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "Product Updated Successfully";
        }
        else if (Request.QueryString["mode"] == "i")
        {
            spnMessage.Visible = true;
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "Product Inserted Successfully";
        }
    }

    private void bindprodut(Int64 subcategoryId)
    {

        DataTable dtproduct = (new cls_product_b().SelectAll(subcategoryId));
        if (dtproduct != null)
        {
            if (dtproduct.Rows.Count > 0)
            {
                repproduct.DataSource = dtproduct;
                repproduct.DataBind();
            }
            else
            {
                repproduct.DataSource = null;
                repproduct.DataBind();
            }
        }
        else
        {
            repproduct.DataSource = null;
            repproduct.DataBind();
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
        bool yes = (new cls_product_b().Delete(CategoryId));

        if (yes)
        {
            Int64 subcategoryId = Convert.ToInt64(ddlsubcategory.SelectedValue.ToString());
            bindprodut(subcategoryId);
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "Product Deleted Successfully";
        }
        else
        {
            spnMessage.Style.Add("color", "red");
            spnMessage.InnerText = "Product Not Deleted";
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
        bool chkSelected = Convert.ToBoolean((item.FindControl("isactive") as CheckBox).Checked);
        bool yes = (new cls_product_b().IsActive(CategoryId, chkSelected));
        if (yes)
        {
            Int64 subcategoryId = Convert.ToInt64(ddlsubcategory.SelectedValue.ToString());
            bindprodut(subcategoryId);
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "Status Updated Successfully";
        }
        else
        {
            spnMessage.Style.Add("color", "red");
            spnMessage.InnerText = "Status Not Updated";
        }
    }

    protected void btnNewCategoty_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveUrl("~/addeditproduct.aspx"));
    }



    protected void ddlmaincategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int64 maincategoryId = Convert.ToInt64(ddlmaincategory.SelectedValue.ToString());
        Bindsubcategory();
        //btnShow_Click(null, null);
    }

    protected void ddlsubcategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        btnShow_Click(null, null);
        // btnShow_Click(null, null);
        //Int64 subcategoryId = Convert.ToInt64(ddlsubcategory.SelectedValue.ToString());
        //bindType(subcategoryId);
    }


    protected void repproduct_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {

            Image imgCategory = (Image)e.Item.FindControl("imgCategory");
            HyperLink hlEdit = (HyperLink)e.Item.FindControl("hlEdit");
            HyperLink hlimages = (HyperLink)e.Item.FindControl("hlimages");
            HyperLink hlprices = (HyperLink)e.Item.FindControl("hlprices");

            hlEdit.NavigateUrl = Page.ResolveUrl("~/addeditproduct.aspx?id=" + ocommon.Encrypt(DataBinder.Eval(e.Item.DataItem, "id").ToString(), true));
            hlimages.NavigateUrl = Page.ResolveUrl("~/productimages.aspx?pid=" + ocommon.Encrypt(DataBinder.Eval(e.Item.DataItem, "id").ToString(), true)+"&productname="+ DataBinder.Eval(e.Item.DataItem, "productname").ToString());
            hlprices.NavigateUrl = Page.ResolveUrl("~/productprices.aspx?pid=" + ocommon.Encrypt(DataBinder.Eval(e.Item.DataItem, "id").ToString(), true)+"&productname="+ DataBinder.Eval(e.Item.DataItem, "productname").ToString());

            imgCategory.ImageUrl = categoryFrontPath + DataBinder.Eval(e.Item.DataItem, "mainimage").ToString();

        }
    }

    protected void btnShow_Click(object sender, EventArgs e)
    {
        if (ddlmaincategory.SelectedIndex == 0 || ddlsubcategory.SelectedIndex == 0 || ddlsubcategory.SelectedIndex == -1)
        {
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Please select All fields')", true);
        }
        else
        {


            Int64 subcategoryId = Convert.ToInt64(ddlsubcategory.SelectedValue.ToString());
            bindprodut(subcategoryId);
        }
    }
}