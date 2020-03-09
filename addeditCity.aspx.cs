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
public partial class addeditCity : System.Web.UI.Page
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
                BindCountry();
                
                BindCompany(Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true)));

                btnSave.Text = "Update";
                hPageTitle.InnerText = "City Update";
                Page.Title = "City Update";
            }
            else
            {
                BindCountry();

                hPageTitle.InnerText = "City Add";
                Page.Title = "City Add";
                btnSave.Text = "Add";
            }
        }
    }

    private void Clear()
    {
        ddlCountry.SelectedIndex = 0;
        ddlState.SelectedIndex = 0;
        txtCityName.Text = string.Empty;

    }

    public void BindCompany(Int64 CompanyId)
    {
        citymaster  objcompany = (new cls_CityMaster_b().SelectById(CompanyId));
        if (objcompany != null)
        {
            BindCountry();
            string CountryID = "0";

            try
            {
                ConnectionString.Open();
                string s = "select id, countryid, statename, isactive, isdelete  from statemaster where id=" + objcompany.stateid.ToString() + "";
                DataTable dt = new DataTable();
                SqlDataAdapter da = new SqlDataAdapter(s, ConnectionString);
                da.Fill(dt);
                if (dt != null)
                {
                    if (dt.Rows[0]["countryid"].ToString().Trim() == "")
                    {
                    }
                    else
                    {
                        CountryID = dt.Rows[0]["countryid"].ToString().Trim();
                    } 
                }
                ConnectionString.Close();
            }
            catch { }
            finally {
                ConnectionString.Close();
            }

            ddlCountry.SelectedValue = CountryID.ToString();
            ddlCountry_SelectedIndexChanged(null, null);
            ddlState.SelectedValue = objcompany.stateid.ToString();
            txtCityName.Text = objcompany.cityname;
        }
    }

    public void BindCountry()
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
        else
        {
            ddlCountry.DataSource = null;
            
            ddlCountry.DataBind();
            
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
        citymaster objcompany = new citymaster();
        objcompany.stateid = Convert.ToInt64(ddlState.SelectedValue.ToString());
        objcompany.cityname = txtCityName.Text.Trim();


        if (Request.QueryString["id"] != null)
        {
            objcompany.id = Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true));
            Result = (new cls_CityMaster_b().Update(objcompany));
            if (Result > 0)
            {
                Clear();
                Response.Redirect(Page.ResolveUrl("~/manageCity.aspx?mode=u"));
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
            Result = (new cls_CityMaster_b().Insert(objcompany));
            if (Result > 0)
            {
                Clear();
                Response.Redirect(Page.ResolveUrl("~/manageCity.aspx?mode=i"));
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
        Response.Redirect(Page.ResolveUrl("~/manageCity.aspx"));
    }

    protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
    {
        DataTable ds = new DataTable();
        Cls_State_b obj = new Cls_State_b();
        ds = obj.getState_byCountryId(Convert.ToInt64(ddlCountry.SelectedValue.ToString()));
        if (ds.Rows.Count > 0)
        {
            // ddkbank.Text = "SELECT";
            ddlState.DataSource = ds;
            ddlState.DataTextField = "statename";
            ddlState.DataValueField = "id";
            ddlState.DataBind();
            ListItem objListItem = new ListItem("-- State --", "0");
            ddlState.Items.Insert(0, objListItem);
        }
        else
        {
            ddlState.DataSource = null;

            ddlState.DataBind();

        }
    }
}