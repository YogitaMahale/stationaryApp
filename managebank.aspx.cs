using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class managebank : System.Web.UI.Page
{
     
    common ocommon = new common();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            bindBank();
            HtmlGenericControl hPageTitle = (HtmlGenericControl)this.Page.Master.FindControl("hPageTitle");
            hPageTitle.InnerText = "Manage Bank";
        }

        if (Request.QueryString["mode"] == "u")
        {
            spnMessage.Visible = true;
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "Bank Updated Successfully";
        }
        else if (Request.QueryString["mode"] == "i")
        {
            spnMessage.Visible = true;
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "Bank Inserted Successfully";
        }
    }

    private void bindBank()
    {
        DataTable dtCategory = (new Cls_bankmaster_b().SelectAll());
        if (dtCategory != null)
        {
            if (dtCategory.Rows.Count > 0)
            {
                repbank .DataSource = dtCategory;
                repbank.DataBind();
            }
            else
            {
                repbank.DataSource = null;
                repbank.DataBind();
            }
        }
        else
        {
            repbank.DataSource = null;
            repbank.DataBind();
        }
    }

    
   
    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
        //Int64 ProductCount = int.Parse((item.FindControl("lblProductCount") as Label).Text);
        //spnMessage.Visible = true;
        //if (ProductCount.ToString() == "0")
        //{
            Int32 bankId = int.Parse((item.FindControl("lblbankId") as Label).Text);
            bool yes = (new Cls_bankmaster_b ().Delete(bankId));

            if (yes)
            {
                bindBank();
                spnMessage.Style.Add("color", "green");
                spnMessage.InnerText = "Bank Deleted Successfully";
            }
            else
            {
                spnMessage.Style.Add("color", "red");
                spnMessage.InnerText = "Bank Not Deleted";
            }
        //}
        //else
        //{
        //    spnMessage.Style.Add("color", "red");
        //    spnMessage.InnerText = "In this category product added..so you can not delete.";
        //}

    }

    protected void IsActive_CheckedChanged(object sender, EventArgs e)
    {
        RepeaterItem item = (sender as CheckBox).Parent as RepeaterItem;
        Int32 bankId = int.Parse((item.FindControl("lblbankId") as Label).Text);
        bool chkSelected = Convert.ToBoolean((item.FindControl("IsActive") as CheckBox).Checked);
        bool yes = (new Cls_bankmaster_b ().IsActive (bankId, chkSelected));
        spnMessage.Visible = true;
        if (yes)
        {
            bindBank();
          
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "Bank Updated Successfully";
        }
        else
        {
            spnMessage.Style.Add("color", "red");
            spnMessage.InnerText = "Bank Not Updated";
        }
    }

    protected void btnNewCategoty_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveUrl("~/addeditbank.aspx"));
    }

   

   
    protected void repbank_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            
            HyperLink hlEdit = (HyperLink)e.Item.FindControl("hlEdit");
            hlEdit.NavigateUrl = Page.ResolveUrl("~/addeditbank.aspx?id=" + ocommon.Encrypt(DataBinder.Eval(e.Item.DataItem, "id").ToString(), true));
           
        }
    }
}