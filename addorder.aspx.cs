﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
public partial class addorder : System.Web.UI.Page
{
    int categoryImageFrontWidth = 500;
    int categoryImageFrontHeight = 605;
    string categoryMainPath = "~/uploads/product/";
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

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //BindBank();
            BindMaincategory();
            HtmlGenericControl hPageTitle = (HtmlGenericControl)this.Page.Master.FindControl("hPagebranchTitle");
            if (Request.QueryString["id"] != null)
            {
                BindCategory(Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true)));
                btnSave.Text = "Update";
                hPageTitle.InnerText = "Order Update";
                Page.Title = "Order Update";
            }
            else
            {
                hPageTitle.InnerText = "Order Add";
                Page.Title = "Order Add";
                btnSave.Text = "Add";

            }
        }
    }

    private void Clear()
    {

        ddlmaincategory.SelectedIndex = 0;
        ddlsubcategory.SelectedIndex = 0;

        ddlmaincategory.SelectedIndex = 0;
        ddlsubcategory.SelectedIndex = 0;
        ddltype.SelectedIndex = 0;
        ddlbrand.SelectedIndex = 0;
        txtqty.Text = string.Empty;
        ddlproduct.SelectedIndex = 0;
    }



    public void BindCategory(Int64 id)
    {
        //productmaster objproductmaster = (new cls_product_b().SelectById(id));
        //if (objproductmaster != null)
        //{
        //    //ddlBank.SelectedValue = objcategory.bankid.ToString();
        //    ddlmaincategory.SelectedValue = objproductmaster.maincategoryId.ToString();
        //    ddlmaincategory_SelectedIndexChanged(null, null);
        //    ddlsubcategory.SelectedValue = objproductmaster.subcategoryId.ToString();
        //    ddlsubcategory_SelectedIndexChanged(null, null);
        //    ddltype.SelectedValue = objproductmaster.typeId.ToString();
        //    ddltype_SelectedIndexChanged(null, null);
        //    ddlbrand.SelectedValue = objproductmaster.brandid.ToString();

        //    txtproductName.Text = objproductmaster.productname;
        //    txtgst.Text = objproductmaster.gst.ToString();
        //    txtstock.Text = objproductmaster.stock.ToString();
        //    txtmoq.Text = objproductmaster.moq.ToString();
        //    txtShortDescription.Text = objproductmaster.shortdescp.ToString();
        //    txtLongDescription.Text = objproductmaster.longdescp.ToString();
        //    if (!string.IsNullOrEmpty(objproductmaster.mainimage))
        //    {
        //        imgCategory.Visible = true;
        //        ViewState["fileName"] = objproductmaster.mainimage;
        //        imgCategory.ImageUrl = categoryFrontPath + objproductmaster.mainimage;
        //        btnImageUpload.Visible = false;
        //        btnRemove.Visible = true;
        //    }
        //    else
        //    {
        //        btnImageUpload.Visible = true;
        //    }



        //}
    }

    protected override void Render(HtmlTextWriter writer)
    {
        string validatorOverrideScripts = "<script src=\"" + Page.ResolveUrl("~") + "js/validators.js\" type=\"text/javascript\"></script>";
        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ValidatorOverrideScripts", validatorOverrideScripts, false);
        base.Render(writer);
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        //Int64 Result = 0;
        //productmaster objproductmaster = new productmaster();
        //objproductmaster.brandid = Convert.ToInt64(ddlbrand.SelectedValue.ToString());
        //objproductmaster.productname = txtproductName.Text.Trim();

        //objproductmaster.stock = Convert.ToInt64(txtstock.Text.Trim());
        //objproductmaster.gst = Convert.ToInt64(txtgst.Text);
        //objproductmaster.moq = Convert.ToInt64(txtmoq.Text.Trim());
        //objproductmaster.shortdescp = txtShortDescription.Text.Trim();
        //objproductmaster.longdescp = txtLongDescription.Text;

        //if (ViewState["fileName"] != null)
        //{
        //    objproductmaster.mainimage = ViewState["fileName"].ToString();
        //}

        ////id, brandid, productname, mainimage, stock, gst, moq, shortdescp, longdescp, isactive, isdeleted

        //if (Request.QueryString["id"] != null)
        //{
        //    objproductmaster.id = Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true));
        //    Result = (new cls_product_b().Update(objproductmaster));
        //    if (Result > 0)
        //    {
        //        Clear();
        //        Response.Redirect(Page.ResolveUrl("~/manageproduct.aspx?mode=u"));
        //    }
        //    else
        //    {
        //        Clear();
        //        spnMessgae.Style.Add("color", "red");
        //        spnMessgae.InnerText = "Product Not Updated";
        //        BindCategory(Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true)));
        //    }
        //}
        //else
        //{
        //    Result = (new cls_product_b().Insert(objproductmaster));
        //    if (Result > 0)
        //    {
        //        Clear();
        //        Response.Redirect(Page.ResolveUrl("~/manageproduct.aspx?mode=i"));
        //    }
        //    else
        //    {
        //        Clear();
        //        spnMessgae.Style.Add("color", "red");
        //        spnMessgae.InnerText = "Product Not Inserted";

        //    }
        //}
    }


    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveUrl("~/manageorders.aspx"));
    }

    protected void ddlmaincategory_SelectedIndexChanged(object sender, EventArgs e)
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


   



    protected void ddlsubcategory_SelectedIndexChanged(object sender, EventArgs e)
    {

        Int64 subCategoryId = Convert.ToInt64(ddlsubcategory.SelectedValue.ToString()); ;
        DataTable dt = (new cls_typemaster_b().SelectAll(subCategoryId));
        ddltype.Items.Clear();

        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                ddltype.DataSource = dt;
                ddltype.DataTextField = "typename";
                ddltype.DataValueField = "id";
                ddltype.DataBind();
                ListItem objListItem = new ListItem("--Select Type--", "0");

                ddltype.Items.Insert(0, objListItem);
            }
        }
    }



    protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int64 typeId = Convert.ToInt64(ddltype.SelectedValue.ToString()); ;
        DataTable dt = (new Cls_brand_b().SelectAllByTypeId(typeId));
        ddlbrand.Items.Clear();

        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                ddlbrand.DataSource = dt;
                ddlbrand.DataTextField = "brandname";
                ddlbrand.DataValueField = "id";
                ddlbrand.DataBind();
                ListItem objListItem = new ListItem("--Select Brand--", "0");

                ddlbrand.Items.Insert(0, objListItem);
            }
        }
    }

    protected void ddlbrand_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int64 brandid = Convert.ToInt64(ddlbrand.SelectedValue.ToString()); ;
        DataTable dt = (new cls_product_b().product_SelectBybrandId(brandid));
        ddlproduct .Items.Clear();

        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                ddlproduct.DataSource = dt;
                ddlproduct.DataTextField = "productname";
                ddlproduct.DataValueField = "id";
                ddlproduct.DataBind();
                ListItem objListItem = new ListItem("--Select Product--", "0");

                ddlproduct.Items.Insert(0, objListItem);
            }
        }
    }
}