using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class addeditzone : System.Web.UI.Page
{
    common ocommon = new common();
    DataTable dtbank, dtstate, dtcity, dtzone = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Bind(); // Bank
            HtmlGenericControl hPageTitle = (HtmlGenericControl)this.Page.Master.FindControl("hPageTitle");
            if (Request.QueryString["id"] != null)
            {
                BindZone(Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true)));
                btnSave.Text = "Update";
                hPageTitle.InnerText = "Zone Update";
                Page.Title = "Zone Update";
            }
            else
            {
                hPageTitle.InnerText = "New Zone";
                Page.Title = "New Zone";
            }
        }
    }

    private void Bind()
    {
        dtbank = (new Cls_bankmaster_b().SelectAll());
        
        ddlbank.Items.Clear();
        if (dtbank != null)
        {
            if (dtbank.Rows.Count > 0)
            {
                ddlbank.DataSource = dtbank;
                ddlbank.DataTextField = "bankname";
                ddlbank.DataValueField = "id";
                ddlbank.DataBind();
                ListItem objListItem = new ListItem("--Select Bank--", "0");
                ddlbank.Items.Insert(0, objListItem);
            }
        }
        
    }


    public void BindZone(Int64 id)
    {
        zone objzone = (new Cls_zone_b().SelectById(id));
        if (objzone != null)
        {
            ddlbank.SelectedValue = objzone.Bankid.ToString();
            txtloginname.Text = objzone.Loginname;
            txtpassword.Text = objzone.Password;
            txtemail.Text = objzone.Emailid;
            txtname.Text = objzone.Name;
            txtmobileno.Text = objzone.Mobileno;
            txtaddress.Text = objzone.Address;

        }

    }


    private void Clear()
    {
        ddlbank.SelectedIndex = 0;
        txtloginname.Text = string.Empty;
        txtpassword.Text = string.Empty;
        txtemail.Text = string.Empty;
        txtname.Text = string.Empty;
        txtmobileno.Text = string.Empty;
        txtaddress.Text = string.Empty;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Int64 Result = 0;
        zone objzone = new zone();
        objzone.Bankid = Convert.ToInt64(ddlbank.SelectedValue);
        objzone.Loginname = txtloginname.Text;
        objzone.Password = txtpassword.Text;
        objzone.Emailid = txtemail.Text;
        objzone.Name = txtname.Text;
        objzone.Mobileno = txtmobileno.Text;
        objzone.Address = txtaddress.Text;


        if (Request.QueryString["id"] != null)
        {
            objzone.id = Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true));
            Result = (new Cls_zone_b().Update(objzone));
            if (Result > 0)
            {
                Clear();
                Response.Redirect(Page.ResolveUrl("~/managezones.aspx?mode=u"));
            }
            else
            {
                Clear();
                spnMessage.Style.Add("color", "red");
                spnMessage.InnerText = "Failed to update...";
                BindZone(Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true)));
            }
        }
        else
        {
            Result = (new Cls_zone_b().Insert(objzone));
            if (Result > 0)
            {
                Clear();

                Response.Redirect(Page.ResolveUrl("~/managezones.aspx?mode=i"));
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
        Response.Redirect(Page.ResolveUrl("~/managezones.aspx"));
    }

}