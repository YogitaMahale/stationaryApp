using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class manageCity : System.Web.UI.Page
{
    string strcon = ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString;
    string CompanyFrontPath = "~/uploads/Company/front/";
    common ocommon = new common();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            BindState();
            HtmlGenericControl hPageTitle = (HtmlGenericControl)this.Page.Master.FindControl("hPageTitle");
            hPageTitle.InnerText = "Manage City";
        }

        if (Request.QueryString["mode"] == "u")
        {
            spnMessage.Visible = true;
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "City Updated Successfully";
        }
        else if (Request.QueryString["mode"] == "i")
        {
            spnMessage.Visible = true;
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "City Inserted Successfully";
        }
    }

    private void BindState()
    {
        DataTable dtCompany = (new cls_CityMaster_b().SelectAll());
        if (dtCompany != null)
        {
            if (dtCompany.Rows.Count > 0)
            {
                repCompany.DataSource = dtCompany;
                repCompany.DataBind();
            }
            else
            {
                repCompany.DataSource = null;
                repCompany.DataBind();
            }
        }
        else
        {
            repCompany.DataSource = null;
            repCompany.DataBind();
        }
    }

    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(strcon);
        RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
        Int64 Companyid = int.Parse((item.FindControl("lblCompanyId") as Label).Text);
        Int64 Count = int.Parse((item.FindControl("lblProductCount") as Label).Text);
        //SqlCommand cmd = new SqlCommand("select * from [dbo].[product] where companyid=" + Companyid + " and isdelete=0", con);
        //SqlDataAdapter ad = new SqlDataAdapter(cmd);
        //DataTable dt = new System.Data.DataTable();
        //ad.Fill(dt);
        //Int64 Count = dt.Rows.Count;
        Int64 ProductCount = int.Parse((item.FindControl("lblProductCount") as Label).Text);
        spnMessage.Visible = true;
        if (Count.ToString() == "0")
        {
            Int64 CompanyId = int.Parse((item.FindControl("lblCompanyId") as Label).Text);
            bool yes = (new cls_CityMaster_b().Delete(CompanyId));

            if (yes)
            {
                BindState();
                spnMessage.Style.Add("color", "green");
                spnMessage.InnerText = "City Deleted Successfully";
            }
            else
            {
                spnMessage.Style.Add("color", "red");
                spnMessage.InnerText = "City Not Deleted";
            }
        }
        else
        {
            spnMessage.Style.Add("color", "red");
            spnMessage.InnerText = "In this City Sub Area added..so you can not delete.";
        }
    }

    protected void IsActive_CheckedChanged(object sender, EventArgs e)
    {
        //RepeaterItem item = (sender as CheckBox).Parent as RepeaterItem;
        //Int64 CompanyId = int.Parse((item.FindControl("lblCompanyId") as Label).Text);
        //bool chkSelected = Convert.ToBoolean((item.FindControl("IsActive") as CheckBox).Checked);
        //bool yes = (new Cls_company_b().Company_IsActive(CompanyId, chkSelected));
        //if (yes)
        //{
        //    BindCompany();
        //    spnMessage.Style.Add("color", "green");
        //    spnMessage.InnerText = "Company Updated Successfully";
        //}
        //else
        //{
        //    spnMessage.Style.Add("color", "red");
        //    spnMessage.InnerText = "Company Not Updated";
        //}
    }

    protected void repCompany_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            HyperLink hlEdit = (HyperLink)e.Item.FindControl("hlEdit");
            //Image imgCompany = (Image)e.Item.FindControl("imgCompany");
            //imgCompany.ImageUrl = DataBinder.Eval(e.Item.DataItem, "imagename").ToString();
            hlEdit.NavigateUrl = Page.ResolveUrl("~/addeditCity.aspx?id=" + ocommon.Encrypt(DataBinder.Eval(e.Item.DataItem, "id").ToString(), true));
        }
    }

    protected void btnNewCompany_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveUrl("~/addeditCity.aspx"));
    }
}