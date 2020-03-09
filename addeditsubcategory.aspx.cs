using System;
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

public partial class addeditsubcategory : System.Web.UI.Page
{

    int categoryImageFrontWidth = 500;
    int categoryImageFrontHeight = 605;
    string categoryMainPath = "~/uploads/subcategory/";
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
            //BindBank();
            BindMaincategory();
            HtmlGenericControl hPageTitle = (HtmlGenericControl)this.Page.Master.FindControl("hPageTitle");
            if (Request.QueryString["id"] != null)
            {
                BindCategory(Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true)));
                btnSave.Text = "Update";
                hPageTitle.InnerText = "Subcategory Update";
                Page.Title = "Subcategory Update";
            }
            else
            {
                hPageTitle.InnerText = "Subcategory Add";
                Page.Title = "Subcategory Add";
                btnSave.Text = "Add";

            }
        }
    }

    private void Clear()
    {
        txtCategoryName.Text = string.Empty;
        ddlmaincategory.SelectedIndex = 0;
        txtCategoryShortDescription.Text = string.Empty;
        txtCategoryLongDescription.Text = string.Empty;
        btnImageUpload.Visible = true;
        btnRemove.Visible = false;
        imgCategory.Visible = false;
        ViewState["fileName"] = null;
    }



    public void BindCategory(Int64 CategoryId)
    {
        subCategoryMaster objcategory = (new cls_subcategory_b().SelectById(CategoryId));
        if (objcategory != null)
        {
            //ddlBank.SelectedValue = objcategory.bankid.ToString();
            ddlmaincategory.SelectedValue = objcategory.maincategoryid.ToString();
            txtCategoryName.Text = objcategory.categoryname;
            txtCategoryShortDescription.Text = objcategory.shortdesc;
            txtCategoryLongDescription.Text = objcategory.longdescp;
            if (!string.IsNullOrEmpty(objcategory.imagename))
            {
                imgCategory.Visible = true;
                ViewState["fileName"] = objcategory.imagename;
                imgCategory.ImageUrl = categoryFrontPath + objcategory.imagename;
                btnImageUpload.Visible = false;
                btnRemove.Visible = true;
            }
            else
            {
                btnImageUpload.Visible = true;
            }
        }
    }

    protected override void Render(HtmlTextWriter writer)
    {
        string validatorOverrideScripts = "<script src=\"" + Page.ResolveUrl("~") + "js/validators.js\" type=\"text/javascript\"></script>";
        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ValidatorOverrideScripts", validatorOverrideScripts, false);
        base.Render(writer);
    }

    protected void btnImageUpload_Click(object sender, EventArgs e)
    {
        if (fpCategory.HasFile)
        {
            string fileName = Path.GetFileNameWithoutExtension(fpCategory.FileName.Replace(' ', '_')) + DateTime.Now.Ticks.ToString() + Path.GetExtension(fpCategory.FileName);
            fpCategory.SaveAs(MapPath(categoryMainPath + fileName));
            ocommon.CreateThumbnail1("uploads\\subcategory\\", categoryImageFrontWidth, categoryImageFrontHeight, "~/Uploads/subcategory/front/", fileName);
            imgCategory.Visible = true;
            imgCategory.ImageUrl = categoryFrontPath + fileName;
            ViewState["fileName"] = fileName;
            btnRemove.Visible = true;
            btnImageUpload.Visible = false;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Int64 Result = 0;
        subCategoryMaster objcategory = new subCategoryMaster();
        objcategory.categoryname = txtCategoryName.Text.Trim();

        objcategory.shortdesc = txtCategoryShortDescription.Text.Trim();
        objcategory.longdescp = txtCategoryLongDescription.Text.Trim();
        objcategory.maincategoryid = Convert.ToInt64(ddlmaincategory.SelectedValue.ToString());
        if (ViewState["fileName"] != null)
        {
            objcategory.imagename = ViewState["fileName"].ToString();
        }
        if (Request.QueryString["id"] != null)
        {
            objcategory.id = Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true));
            Result = (new cls_subcategory_b().Update(objcategory));
            if (Result > 0)
            {
                Clear();
                Response.Redirect(Page.ResolveUrl("~/managesubcategory.aspx?mode=u"));
            }
            else
            {
                Clear();
                spnMessgae.Style.Add("color", "red");
                spnMessgae.InnerText = "Subcategory Not Updated";
                BindCategory(Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true)));
            }
        }
        else
        {
            Result = (new cls_subcategory_b().Insert(objcategory));
            if (Result > 0)
            {
                Clear();
                Response.Redirect(Page.ResolveUrl("~/managesubcategory.aspx?mode=i"));
            }
            else
            {
                Clear();
                spnMessgae.Style.Add("color", "red");
                spnMessgae.InnerText = "Subcategory Not Inserted";

            }
        }
    }

    protected void btnRemove_Click(object sender, EventArgs e)
    {
        var filePath = Server.MapPath("~/uploads/subcategory/" + ViewState["fileName"].ToString());
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
        var filePath1 = Server.MapPath("~/uploads/subcategory/front/" + ViewState["fileName"].ToString());
        if (File.Exists(filePath1))
        {
            File.Delete(filePath1);
        }

        btnImageUpload.Visible = true;
        btnRemove.Visible = false;
        ViewState["fileName"] = string.Empty;
        imgCategory.Visible = false;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveUrl("~/managesubcategory.aspx"));
    }
}