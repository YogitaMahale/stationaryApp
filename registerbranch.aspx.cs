using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class registerbranch : System.Web.UI.Page
{
    common ocommon = new common();
    DataTable dtbank, dtstate, dtcity, dtzone = new DataTable();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Bind(); // Bank , State
            //HtmlGenericControl hPageTitle = (HtmlGenericControl)this.Page.Master.FindControl("hPageTitle");
            
        }
    }

    private void Bind()
    {
        dtbank = (new Cls_bankmaster_b().SelectAll());
        //dtcity = (new cls_CityMaster_b().SelectAll());
        dtstate = (new Cls_State_b().SelectAll());

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

        ddlState.Items.Clear();
        if (dtstate != null)
        {
            if (dtstate.Rows.Count > 0)
            {
                ddlState.DataSource = dtstate;
                ddlState.DataTextField = "statename";
                ddlState.DataValueField = "id";
                ddlState.DataBind();
                ListItem objListItem = new ListItem("--Select State--", "0");
                ddlState.Items.Insert(0, objListItem);
            }
        }

    }

    //public void BindBranch(Int64 id)
    //{
    //    branch objbranch = (new Cls_branch_b().SelectById(id));
    //    if (objbranch != null)
    //    {
    //        ddlbank.SelectedValue = objbranch.Bankid.ToString();
    //        ddlbank_SelectedIndexChanged(null, null);
    //        ddlZone.SelectedValue = objbranch.Zoneid.ToString();
    //        txtloginname.Text = objbranch.Loginname;
    //        txtpassword.Text = objbranch.Password;
    //        txtemail.Text = objbranch.Emailid;
    //        txtname.Text = objbranch.Name;
    //        txtifsc.Text = objbranch.Ifsccode;
    //        txtmicr.Text = objbranch.Micrcode;
    //        txtgstno.Text = objbranch.Gstno;
    //        txtapartment.Text = objbranch.Apartment;
    //        txtroad.Text = objbranch.Road;
    //        ddlState.SelectedValue = objbranch.State.ToString();
    //        ddlState_SelectedIndexChanged(null, null);
    //        ddlCity.SelectedValue = objbranch.City.ToString();
    //        txtpincode.Text = objbranch.Pincode;
    //        txtbranchcode.Text = objbranch.Branchcode;
    //        txtphone.Text = objbranch.Phone;
    //        txtmobileno.Text = objbranch.Mobileno;
    //        txtaddress.Text = objbranch.Address;

    //    }

    //}


    private void Clear()
    {
        ddlbank.SelectedIndex = 0;
        ddlZone.SelectedIndex = 0;
        txtloginname.Text = string.Empty;
        txtpassword.Text = string.Empty;
        txtemail.Text = string.Empty;
        txtname.Text = string.Empty;
        txtifsc.Text = string.Empty;
        txtmicr.Text = string.Empty;
        txtgstno.Text = string.Empty;
        txtapartment.Text = string.Empty;
        txtroad.Text = string.Empty;
        ddlCity.SelectedIndex = 0;
        ddlState.SelectedIndex = 0;
        txtpincode.Text = string.Empty;
        txtbranchcode.Text = string.Empty;
        txtphone.Text = string.Empty;
        txtmobileno.Text = string.Empty;
        txtaddress.Text = string.Empty;
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Int64 Result = 0;
        branch objbranch = new branch();
        objbranch.Zoneid = Convert.ToInt64(ddlZone.SelectedValue);
        objbranch.Loginname = txtloginname.Text;
        objbranch.Password = txtpassword.Text;
        objbranch.Emailid = txtemail.Text;
        objbranch.Name = txtname.Text;
        objbranch.Ifsccode = txtifsc.Text;
        objbranch.Micrcode = txtmicr.Text;
        objbranch.Gstno = txtgstno.Text;
        objbranch.Apartment = txtapartment.Text;
        objbranch.Road = txtroad.Text;
        objbranch.City = Convert.ToInt64(ddlCity.SelectedValue);
        objbranch.State = Convert.ToInt64(ddlState.SelectedValue);
        objbranch.Pincode = txtpincode.Text;
        objbranch.Branchcode = txtbranchcode.Text;
        objbranch.Phone = txtphone.Text;
        objbranch.Mobileno = txtmobileno.Text;
        objbranch.Address = txtaddress.Text;


        if (Request.QueryString["id"] != null)
        {
            objbranch.Branchid = Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true));
            Result = (new Cls_branch_b().Update(objbranch));
            if (Result > 0)
            {
                Clear();
                //Response.Redirect(Page.ResolveUrl("~/managebranches.aspx?mode=u"));
            }
            else
            {
                Clear();
                //spnMessage.Style.Add("color", "red");
                //spnMessage.InnerText = "Failed to update...";
                //BindBranch(Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true)));
            }
        }
        else
        {
            Result = (new Cls_branch_b().Insert(objbranch));
            if (Result > 0)
            {
                Clear();

                Response.Redirect(Page.ResolveUrl("~/Default.aspx?reg=" + ocommon.Encrypt(Result.ToString(), true)));
            }
            else
            {
                Clear();
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "Registeration Failed...", true);
                //spnMessage.Style.Add("color", "red");
                //spnMessage.InnerText = "Failed to insert...";
            }
        }
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveUrl("~/Default.aspx"));
    }

    protected void ddlState_SelectedIndexChanged(object sender, EventArgs e)
    {
        dtcity = (new cls_CityMaster_b().SelectAllByStateId(Convert.ToInt64(ddlState.SelectedValue)));

        ddlCity.Items.Clear();
        if (dtcity != null)
        {
            if (dtcity.Rows.Count > 0)
            {
                ddlCity.DataSource = dtcity;
                ddlCity.DataTextField = "cityname";
                ddlCity.DataValueField = "id";
                ddlCity.DataBind();
                ListItem objListItem = new ListItem("--Select City--", "0");
                ddlCity.Items.Insert(0, objListItem);
            }
        }
    }

    protected void ddlbank_SelectedIndexChanged(object sender, EventArgs e)
    {
        dtzone = (new Cls_zone_b().SelectAllByBankId(Convert.ToInt64(ddlbank.SelectedValue)));

        ddlZone.Items.Clear();
        if (dtzone != null)
        {
            if (dtzone.Rows.Count > 0)
            {
                ddlZone.DataSource = dtzone;
                ddlZone.DataTextField = "name";
                ddlZone.DataValueField = "id";
                ddlZone.DataBind();
                ListItem objListItem = new ListItem("--Select Zone--", "0");
                ddlZone.Items.Insert(0, objListItem);
            }
        }
    }
}