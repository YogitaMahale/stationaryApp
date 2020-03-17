using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class managebranchorders : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);

    common ocommon = new common();
    Int64 zoneid = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            
            bindOrders();
            HtmlGenericControl hPageTitle = (HtmlGenericControl)this.Page.Master.FindControl("hPagebankTitle");
            hPageTitle.InnerText = "Manage Orders";
        }

        if (Request.QueryString["mode"] == "u")
        {
            spnMessage.Visible = true;
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "Orders Updated Successfully";
        }
        else if (Request.QueryString["mode"] == "i")
        {
            spnMessage.Visible = true;
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "Orders Inserted Successfully";
        }
    }

    private void bindOrders()
    {
        if (Session["userid"] != null)
        {
            zoneid = Convert.ToInt64(Session["userid"].ToString());
        }
        DataTable dtproduct = (new cls_order_b().order_SelectAllByZoneId(zoneid));
        
        if (dtproduct != null)
        {
            if (dtproduct.Rows.Count > 0)
            {
                reporders.DataSource = dtproduct;
                reporders.DataBind();
            }
            else
            {
                reporders.DataSource = null;
                reporders.DataBind();
            }
        }
        else
        {
            reporders.DataSource = null;
            reporders.DataBind();
        }
    }



    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        //RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
        //// Int64 ProductCount = int.Parse((item.FindControl("lblProductCount") as Label).Text);
        //spnMessage.Visible = true;
        ////if (ProductCount.ToString() == "0")
        ////{
        //Int64 CategoryId = int.Parse((item.FindControl("lblCategoryId") as Label).Text);
        //bool yes = (new cls_product_b().Delete(CategoryId));

        //if (yes)
        //{
        //    Int64 subcategoryId = Convert.ToInt64(ddlsubcategory.SelectedValue.ToString());
        //    bindprodut(subcategoryId);
        //    spnMessage.Style.Add("color", "green");
        //    spnMessage.InnerText = "Product Deleted Successfully";
        //}
        //else
        //{
        //    spnMessage.Style.Add("color", "red");
        //    spnMessage.InnerText = "Product Not Deleted";
        //}
        ////}
        ////else
        ////{
        ////    spnMessage.Style.Add("color", "red");
        ////    spnMessage.InnerText = "In this Maincategory Category added..so you can not delete.";
        ////}

    }

    
    protected void repproduct_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {


            HyperLink hlEdit = (HyperLink)e.Item.FindControl("hlEdit");
            hlEdit.NavigateUrl = Page.ResolveUrl("~/addorder.aspx?id=" + ocommon.Encrypt(DataBinder.Eval(e.Item.DataItem, "oid").ToString(), true));

            HyperLink hlinvoice = (HyperLink)e.Item.FindControl("hlinvoice");
            hlinvoice.NavigateUrl = Page.ResolveUrl("~/orderinvoice.aspx?id=" + ocommon.Encrypt(DataBinder.Eval(e.Item.DataItem, "oid").ToString(), true));


        }
    }



    protected void btnNeworder_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveUrl("~/addorder.aspx"));
    }



    protected void btnApprove_Click(object sender, EventArgs e)
    {
        RepeaterItem item = (sender as Button).Parent as RepeaterItem;

        //string icon = btnIcon.Attributes["data-icon"].ToString();
        Int64 result = 0;
        Int64 oid = Convert.ToInt64( (item.FindControl("btnApprove") as Button).Attributes["data-id"].ToString());
        
        try {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "approveorder";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;

            SqlParameter param = new SqlParameter();
            param.ParameterName = "@oid";
            param.Value = oid;
            param.SqlDbType = SqlDbType.BigInt;
            param.Direction = ParameterDirection.InputOutput;
            cmd.Parameters.Add(param);

            con.Open();
            cmd.ExecuteNonQuery();

            result = Convert.ToInt64(param.Value);

            spnMessage.Visible = true;
            if (result > 0)
            {

                spnMessage.Style.Add("color", "green");
                spnMessage.InnerText = "Order Approved Successfully !!!";
                bindOrders();
            }
            else
            {
                spnMessage.Style.Add("color", "red");
                spnMessage.InnerText = "Failed to approve order";
            }

        }
        catch(Exception ex) { }
        finally { con.Close(); }





    }
}