using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
public partial class productdetails : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        
        if(!IsPostBack)
        {
            if (Session["cartdt"] != null)
            {
                DataTable dt = new DataTable();
                dt = (DataTable)Session["cartdt"];
                repcart.DataSource = dt;
                repcart.DataBind();
                if (dt.Rows.Count>0)
                {
                    decimal sum = Convert.ToDecimal(dt.Compute("SUM(total)", string.Empty));
                    lbltotalamt.InnerText = sum.ToString();
                }

               
                

              
            }
        }
    }


    protected void lnkremove_Click(object sender, EventArgs e)
    {
        try
        {

            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;

              

            DataTable dtprodn = new DataTable();
            dtprodn = (DataTable)Session["cartdt"];



            Int64 pid = int.Parse((item.FindControl("lblpid") as Label).Text);
            DataRow[] drr = dtprodn.Select("pid='" + pid + " ' ");

            foreach (var row in drr)
                row.Delete();


            //-----------------
         
            dtprodn.AcceptChanges();
            repcart.DataSource = dtprodn;
            repcart.DataBind();
            Session["cartdt"] = dtprodn;
            decimal sum = Convert.ToDecimal(dtprodn.Compute("SUM(total)", string.Empty));
            lbltotalamt.InnerText = sum.ToString();
        }
        catch { }
    }

    protected void txtqty_TextChanged(object sender, EventArgs e)
    {
        try
        {
            DataTable dtprodn = new DataTable();
            dtprodn = (DataTable)Session["cartdt"];
            foreach (RepeaterItem item in repcart.Items)
            {
                Label lblpid = (Label)item.FindControl("lblpid");
                Label lblprice = (Label)item.FindControl("lblprice");
                TextBox qty = (TextBox)item.FindControl("txtqty");
                //lblpid
                //lblprice
                DataRow[] drr = dtprodn.Select("pid='" + lblpid.Text + " ' ");
                if (drr.Length == 0)
                {


                }
                else
                {
                    foreach (var row in drr)
                    {
                        double price = Convert.ToDouble(lblprice.Text);
                        Int64 qty1 = Convert.ToInt64(qty.Text);
                        row["qty"] = qty1.ToString();
                        row["total"] = (price*qty1).ToString();
                    }

                    dtprodn.AcceptChanges();
                   
                }

            }
            decimal sum = Convert.ToDecimal(dtprodn.Compute("SUM(total)", string.Empty));
            lbltotalamt.InnerText = sum.ToString();
            ViewState["cartdt"] = dtprodn;
            repcart.DataSource = dtprodn;
            repcart.DataBind();
           
             
        }
        catch(Exception p)
        {

        }
        finally { }
    }
}