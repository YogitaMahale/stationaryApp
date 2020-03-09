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

public partial class addeditType : System.Web.UI.Page
{
     
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
        txtType.Text = string.Empty;
        ddlmaincategory.SelectedIndex = 0;
        ddlsubcategory .SelectedIndex = 0;
         
    }



    public void BindCategory(Int64 id)
    {
        typemaster objtypemaster = (new cls_typemaster_b().SelectById(id));
        if (objtypemaster != null)
        {
            //ddlBank.SelectedValue = objcategory.bankid.ToString();
            ddlmaincategory.SelectedValue = objtypemaster.maincategoryId .ToString();
            Bindsubcategory();
            ddlsubcategory.SelectedValue = objtypemaster.categoryid.ToString();
            txtType.Text = objtypemaster.typename ;
           
        }
    }

    protected override void Render(HtmlTextWriter writer)
    {
        string validatorOverrideScripts = "<script src=\"" + Page.ResolveUrl("~") + "js/validators.js\" type=\"text/javascript\"></script>";
        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ValidatorOverrideScripts", validatorOverrideScripts, false);
        base.Render(writer);
    }

    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Int64 Result = 0;
        typemaster objtypemaster = new typemaster();
        objtypemaster.categoryid = Convert.ToInt64(ddlsubcategory.SelectedValue.ToString());
        objtypemaster.typename  = txtType.Text.Trim();

      
        if (Request.QueryString["id"] != null)
        {
            objtypemaster.id = Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true));
            Result = (new cls_typemaster_b().Update(objtypemaster));
            if (Result > 0)
            {
                Clear();
                Response.Redirect(Page.ResolveUrl("~/managetype.aspx?mode=u"));
            }
            else
            {
                Clear();
                spnMessgae.Style.Add("color", "red");
                spnMessgae.InnerText = "Type Not Updated";
                BindCategory(Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true)));
            }
        }
        else
        {
            Result = (new cls_typemaster_b().Insert(objtypemaster));
            if (Result > 0)
            {
                Clear();
                Response.Redirect(Page.ResolveUrl("~/managetype.aspx?mode=i"));
            }
            else
            {
                Clear();
                spnMessgae.Style.Add("color", "red");
                spnMessgae.InnerText = "Type Not Inserted";

            }
        }
    }

   
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveUrl("~/managetype.aspx"));
    }

    protected void ddlmaincategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        Bindsubcategory();
    }
}