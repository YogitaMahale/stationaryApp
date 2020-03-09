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
public partial class addeditbank : System.Web.UI.Page
{
  
    common ocommon = new common();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //BindBank();
            HtmlGenericControl hPageTitle = (HtmlGenericControl)this.Page.Master.FindControl("hPageTitle");
            if (Request.QueryString["id"] != null)
            {
                bindBank(Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true)));
                btnSave.Text = "Update";
                hPageTitle.InnerText = "Bank  Update";
                Page.Title = "Bank Update";
            }
            else
            {
                hPageTitle.InnerText = "Bank Add";
                Page.Title = "Bank Add";
                btnSave.Text = "Add";
                
            }
        }
    }

    private void Clear()
    {
        txtbankName.Text = string.Empty;
        
        
    }
 
    public void bindBank(Int64  bankId)
    {
        bankmaster objcategory = (new Cls_bankmaster_b().SelectById(bankId));
        if (objcategory != null)
        {
            
            txtbankName.Text = objcategory.bankname;
         
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
        bankmaster  objcategory = new bankmaster();
        objcategory.bankname = txtbankName.Text.Trim();
      
        if (Request.QueryString["id"] != null)
        {
            objcategory.id = Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true));
            Result = (new Cls_bankmaster_b().Update(objcategory));
            if (Result > 0)
            {
                Clear();
                Response.Redirect(Page.ResolveUrl("~/managebank.aspx?mode=u"));
            }
            else
            {
                Clear();
                spnMessgae.Style.Add("color", "red");
                spnMessgae.InnerText = "Bank Not Updated";
                bindBank(Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true)));
            }
        }
        else
        {
            Result = (new Cls_bankmaster_b().Insert(objcategory));
            if (Result > 0)
            {
                Clear();
                Response.Redirect(Page.ResolveUrl("~/managebank.aspx?mode=i"));
            }
            else
            {
                Clear();
                spnMessgae.Style.Add("color", "red");
                spnMessgae.InnerText = "Bank Not Inserted";

            }
        }
    }

     
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveUrl("~/managebank.aspx"));
    }
}