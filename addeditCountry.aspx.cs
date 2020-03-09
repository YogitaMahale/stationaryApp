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

public partial class addeditCountry : System.Web.UI.Page
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
                BindBank();
                BindCompany(Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true)));
                //    BindBank();
                btnSave.Text = "Update";
                hPageTitle.InnerText = "Country Update";
                Page.Title = "Country Update";
            }
            else
            {
                BindBank();
                hPageTitle.InnerText = "Country Add";
                Page.Title = "Country Add";
                btnSave.Text = "Add";
            }
        }
    }

    private void Clear()
    {
        txtCountrycode.Text = string.Empty;
        txtCountryName.Text = string.Empty;
        
    }

    public void BindCompany(Int64 CompanyId)
    {
        countrymaster objcompany = (new Cls_country_b().SelectById(CompanyId));
        if (objcompany != null)
        {
            txtCountrycode.Text = objcompany.countrycode;
            txtCountryName.Text = objcompany.countryname;          
        }
    }

    public void BindBank()
    {
        //string SelectBank = "SELECT [PkBankId] , [BankName]   FROM [BankMaster]";
        //SqlDataAdapter cmdbank = new SqlDataAdapter(SelectBank, ConnectionString);
        //DataSet ds = new DataSet();
        //cmdbank.Fill(ds);

        //if (ds.Tables[0].Rows.Count > 0)
        //{
        //    // ddkbank.Text = "SELECT";
        //    ddkbank.DataSource = ds;
        //    ddkbank.DataTextField = "BankName";
        //    ddkbank.DataValueField = "PkBankId";
        //    ddkbank.DataBind();
        //    ListItem objListItem = new ListItem("--Select Company--", "0");
        //    ddkbank.Items.Insert(0, objListItem);
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
        Int64 Result = 0;
        countrymaster objcompany = new countrymaster();
        objcompany.countrycode = txtCountrycode.Text.Trim();
        objcompany.countryname = txtCountryName.Text.Trim();
        

        if (Request.QueryString["id"] != null)
        {
            objcompany.id = Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true));
            Result = (new Cls_country_b().Update(objcompany));
            if (Result > 0)
            {
                Clear();
                Response.Redirect(Page.ResolveUrl("~/manageCountry.aspx?mode=u"));
            }
            else
            {
                Clear();
                spnMessgae.Style.Add("color", "red");
                spnMessgae.InnerText = "Country Not Updated";
                BindCompany(Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true)));
            }
        }
        else
        {
            Result = (new Cls_country_b().Insert(objcompany));
            if (Result > 0)
            {
                Clear();
                Response.Redirect(Page.ResolveUrl("~/managecompany.aspx?mode=i"));
            }
            else
            {
                Clear();
                spnMessgae.Style.Add("color", "red");
                spnMessgae.InnerText = "Country Not Inserted";

            }
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveUrl("~/manageCountry.aspx"));
    }

   }