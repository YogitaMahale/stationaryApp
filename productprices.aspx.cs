using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class productprices : System.Web.UI.Page
{
    common ocommon = new common();
    int productImageFrontWidth = 1000;
    int productImageFrontHeight = 900;
    string productMainPath = "~/uploads/product/";
    string productFrontPath = "~/uploads/product/front/";
    string productWaterFrontPath = "~/uploads/product/water/";


    Int64 pid = 0;
    string productname = string.Empty;
    bool insert = true;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["productname"] != null)
            {
                productname = Request.QueryString["productname"].ToString();
            }
            BindBank();
            BindProductRates();
            HtmlGenericControl hPageTitle = (HtmlGenericControl)this.Page.Master.FindControl("hPageTitle");
            hPageTitle.InnerText = "Manage Rates For '" + productname + "'";
        }

        if (Request.QueryString["mode"] == "u")
        {
            spnMessage.Visible = true;
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "Information Updated Successfully!!!";
        }
        else if (Request.QueryString["mode"] == "i")
        {
            spnMessage.Visible = true;
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "Information Saved Successfully!!!";
        }
    }


    private void BindBank()
    {
        DataTable dtbank= (new Cls_bankmaster_b().SelectAll());
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

    private void BindProductRates()
    {
        if (Request.QueryString["pid"] != null)
        {
            pid = Convert.ToInt64(ocommon.Decrypt(Request.QueryString["pid"].ToString(), true));
        }
        DataTable dtproductprices = (new Cls_productprice_b().SelectAllByProductId(pid));
        if (dtproductprices != null)
        {
            if (dtproductprices.Rows.Count > 0)
            {
                repCategory.DataSource = dtproductprices;
                repCategory.DataBind();
            }
            else
            {
                repCategory.DataSource = null;
                repCategory.DataBind();
            }
        }
        else
        {
            repCategory.DataSource = null;
            repCategory.DataBind();
        }
    }

    protected void repCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            //HyperLink hlEdit = (HyperLink)e.Item.FindControl("hlEdit");
            //hlEdit.NavigateUrl = Page.ResolveUrl("~/addeditbrand.aspx?id=" + ocommon.Encrypt(DataBinder.Eval(e.Item.DataItem, "id").ToString(), true));
            //Image imgCategory = (Image)e.Item.FindControl("imgCategory");
            //imgCategory.ImageUrl = productFrontPath + DataBinder.Eval(e.Item.DataItem, "imagename").ToString();

        }
    }


    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
        spnMessage.Visible = true;
        //string imagename = (item.FindControl("lblimagename") as Label).Text;
        Int64 id = int.Parse((item.FindControl("lblid") as Label).Text);
        bool yes = (new Cls_productprice_b().Delete(id));
        if (yes)
        {
            //removeImage(imagename);
            BindProductRates();
            spnMessage.Visible = true;
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "Deleted Successfully !!!";
        }
        else
        {
            spnMessage.Visible = true;
            spnMessage.Style.Add("color", "red");
            spnMessage.InnerText = "Failed To Delete...";
        }


    }

    //protected void btnNewBrand_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect(Page.ResolveUrl("~/addeditbrand.aspx"));
    //}

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Int64 Result = 0;
        productprice objprice= new productprice();
        
        if (Request.QueryString["pid"] != null)
        {
            objprice.Pid = Convert.ToInt64(ocommon.Decrypt(Request.QueryString["pid"].ToString(), true));
            objprice.Bankid = Convert.ToInt64(ddlbank.SelectedValue);
            objprice.Price = Convert.ToDecimal(txtprice.Text);
            foreach(RepeaterItem item in repCategory.Items)
            {
                Label productid = (Label)item.FindControl("lblproductid");
                Label bankid = (Label)item.FindControl("lblbankid");
                if (string.Equals(bankid.Text, objprice.Bankid.ToString()) && string.Equals(productid.Text, objprice.Pid.ToString()))
                    insert = false;
            }

            if (insert) {
                Result = (new Cls_productprice_b().Insert(objprice));
                if (Result > 0)
                {
                    Clear();
                    spnMessage.Visible = true;
                    spnMessage.Style.Add("color", "green");
                    spnMessage.InnerText = "Image saved successfully !!!";
                    BindProductRates();
                    //Response.Redirect(Page.ResolveUrl("~/manageproduct.aspx?mode=u&catid=" + objproduct.cid.ToString()));
                }
                else
                {
                    Clear();
                    spnMessage.Visible = true;
                    spnMessage.Style.Add("color", "red");
                    spnMessage.InnerText = "Failed to save...";
                    BindProductRates();
                }
            }
            else
            {
                //Clear();
                spnMessage.Visible = true;
                spnMessage.Style.Add("color", "red");
                spnMessage.InnerText = "Rate for this bank is already present...";
                BindProductRates();
            }
            
        }
        else
        {
            Clear();
            spnMessage.Visible = true;
            spnMessage.Style.Add("color", "red");
            spnMessage.InnerText = "Failed to save...";
            BindProductRates();
        }
    }

    private void Clear()
    {
        ddlbank.SelectedIndex = 0;
        txtprice.Text = "0";
    }



}