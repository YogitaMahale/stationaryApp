using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class addeditbrand : System.Web.UI.Page
{

    common ocommon = new common();
    DataTable dtcategory, dtsubcategory, dttype = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Bind(); // Types
            HtmlGenericControl hPageTitle = (HtmlGenericControl)this.Page.Master.FindControl("hPageTitle");
            if (Request.QueryString["id"] != null)
            {
                BindBrand(Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true)));
                btnSave.Text = "Update";
                hPageTitle.InnerText = "Brand Update";
                Page.Title = "Brand Update";
            }
            else
            {
                hPageTitle.InnerText = "New Brand";
                Page.Title = "New Brand";
            }
        }
    }

    private void Bind()
    {
        dtcategory = new cls_maincategory_b().SelectAll();

        ddlcategory.Items.Clear();
        if (dtcategory != null)
        {
            if (dtcategory.Rows.Count > 0)
            {
                ddlcategory.DataSource = dtcategory;
                ddlcategory.DataTextField = "categoryname";
                ddlcategory.DataValueField = "id";
                ddlcategory.DataBind();
                ListItem objListItem = new ListItem("--Select Category--", "0");
                ddlcategory.Items.Insert(0, objListItem);
            }
        }
        
    }

    public void BindBrand(Int64 id)
    {
        brand objbrand = new Cls_brand_b().SelectById(id);
        if (objbrand != null)
        {
            ddlcategory.SelectedValue = objbrand.Maincategoryid.ToString();
            ddlcategory_SelectedIndexChanged(null, null);
            ddlsubcategory.SelectedValue = objbrand.Subcategoryid.ToString();
            ddlsubcategory_SelectedIndexChanged(null, null);
            ddltype.SelectedValue = objbrand.Typeid.ToString();
            txtbrandname.Text = objbrand.Brandname;
            
        }

    }


    private void Clear()
    {
        ddltype.SelectedIndex = 0;
        txtbrandname.Text = string.Empty;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Int64 Result = 0;
        brand objbrand = new brand();
        objbrand.Typeid = Convert.ToInt64(ddltype.SelectedValue);
        objbrand.Brandname= txtbrandname.Text;
        
        if (Request.QueryString["id"] != null)
        {
            objbrand.Id = Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true));
            Result = (new Cls_brand_b().Update(objbrand));
            if (Result > 0)
            {
                Clear();
                Response.Redirect(Page.ResolveUrl("~/managebrands.aspx?mode=u"));
            }
            else
            {
                Clear();
                spnMessage.Style.Add("color", "red");
                spnMessage.InnerText = "Failed to update...";
                BindBrand(Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true)));
            }
        }
        else
        {
            Result = (new Cls_brand_b().Insert(objbrand));
            if (Result > 0)
            {
                Clear();

                Response.Redirect(Page.ResolveUrl("~/managebrands.aspx?mode=i"));
            }
            else
            {
                Clear();
                spnMessage.Style.Add("color", "red");
                spnMessage.InnerText = "Failed to insert...";
            }
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveUrl("~/managebrands.aspx"));
    }


    protected void ddlcategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        dtsubcategory = new cls_subcategory_b().SelectAll(Convert.ToInt64(ddlcategory.SelectedValue));

        ddlsubcategory.Items.Clear();
        if (dtsubcategory != null)
        {
            if (dtsubcategory.Rows.Count > 0)
            {
                ddlsubcategory.DataSource = dtsubcategory;
                ddlsubcategory.DataTextField = "categoryname";
                ddlsubcategory.DataValueField = "id";
                ddlsubcategory.DataBind();
                ListItem objListItem = new ListItem("--Select Sub Category--", "0");
                ddlsubcategory.Items.Insert(0, objListItem);
            }
        }
    }

    protected void ddlsubcategory_SelectedIndexChanged(object sender, EventArgs e)
    {
        dttype = new cls_typemaster_b().SelectAll(Convert.ToInt64(ddlsubcategory.SelectedValue));

        ddltype.Items.Clear();
        if (dttype != null)
        {
            if (dttype.Rows.Count > 0)
            {
                ddltype.DataSource = dttype;
                ddltype.DataTextField = "typename";
                ddltype.DataValueField = "id";
                ddltype.DataBind();
                ListItem objListItem = new ListItem("--Select Type--", "0");
                ddltype.Items.Insert(0, objListItem);
            }
        }
    }
}