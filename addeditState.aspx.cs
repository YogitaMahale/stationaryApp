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
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
public partial class addeditState : System.Web.UI.Page
{
    SqlConnection ConnectionString = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["cnstring"].ToString());
    int CompanyImageFrontWidth = 500;
    int CompanyImageFrontHeight = 226;
    string CompanyMainPath = "~/uploads/Company/";
    string CompanyFrontPath = "~/uploads/Company/front/";
    common ocommon = new common();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            HtmlGenericControl hPageTitle = (HtmlGenericControl)this.Page.Master.FindControl("hPageTitle");
            if (Request.QueryString["id"] != null)
            {
                BindState();
                BindCompany(Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true)));
                
                btnSave.Text = "Update";
                hPageTitle.InnerText = "Update State";
                Page.Title = "Update State";
            }
            else
            {
                BindState();
                hPageTitle.InnerText = "Add State";
                Page.Title = "Add State";
                btnSave.Text = "Add";
            }
        }
    }

    private void Clear()
    {
        ddlCountry.SelectedIndex=0;
        txtStateName.Text = string.Empty;

    }

    public void BindCompany(Int64 CompanyId)
    {
        statemaster objcompany = (new Cls_State_b().SelectById(CompanyId));
        if (objcompany != null)
        {
           ddlCountry.SelectedValue = objcompany.countryid.ToString();
            txtStateName.Text = objcompany.statename;
        }
    }

    public void  BindState()
    {

        DataTable ds = new DataTable();
        Cls_country_b obj = new Cls_country_b();
        ds = obj.SelectAll();
        if (ds.Rows.Count > 0)
        {
            // ddkbank.Text = "SELECT";
            ddlCountry.DataSource = ds;
            ddlCountry.DataTextField = "countryname";
            ddlCountry.DataValueField = "id";
            ddlCountry.DataBind();
            ListItem objListItem = new ListItem("-- Country --", "0");
            ddlCountry.Items.Insert(0, objListItem);
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
        statemaster objcompany = new statemaster();
        objcompany.countryid = Convert.ToInt64(ddlCountry.SelectedValue.ToString());
        objcompany.statename = txtStateName.Text.Trim();


        if (Request.QueryString["id"] != null)
        {
            objcompany.id = Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true));
            Result = (new Cls_State_b().Update(objcompany));
            if (Result > 0)
            {
                Clear();
                Response.Redirect(Page.ResolveUrl("~/manageState.aspx?mode=u"));
            }
            else
            {
                Clear();
                spnMessgae.Style.Add("color", "red");
                spnMessgae.InnerText = "State Not Updated";
                BindCompany(Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true)));
            }
        }
        else
        {
            Result = (new Cls_State_b().Insert(objcompany));
            if (Result > 0)
            {
                Clear();
                Response.Redirect(Page.ResolveUrl("~/manageState.aspx?mode=i"));
            }
            else
            {
                Clear();
                spnMessgae.Style.Add("color", "red");
                spnMessgae.InnerText = "State Not Inserted";

            }
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveUrl("~/manageState.aspx"));
    }

}