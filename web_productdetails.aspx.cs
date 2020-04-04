using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class productdetails : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
    public static int cnt = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //if (cnt == 0)
            //{
            //    cnt++;
            //    DataTable cartdt = new DataTable();
            //    cartdt.Columns.Add("pid");
            //    cartdt.Columns.Add("productname");
            //    cartdt.Columns.Add("price");
            //    cartdt.Columns.Add("qty");
            //    cartdt.Columns.Add("imagename");
            //    cartdt.Columns.Add("total");
            //    cartdt.Columns.Add("shortdescp");
            //    Session["cartdt"] = cartdt;
            //}
            //else
            //{

            //}

        }
        if (Request.QueryString["pid"] == null)
        {

        }
        else
        {
            // string pid = "1";
            string pid = Request.QueryString["pid"];
            Bindproductslider(Convert.ToInt64(pid));

            BindRelatedproduct(pid);
        }
    }
    private void Bindproductslider(Int64 pid)
    {
        DataSet dtCompany = (new cls_product_b().websiteproductdetails_SelectById(pid));
        if (dtCompany.Tables[0] != null)
        {
            if (dtCompany.Tables[0].Rows.Count > 0)
            {
                lblproductName.InnerText = dtCompany.Tables[0].Rows[0]["productname"].ToString();
                lblprice.InnerText = dtCompany.Tables[0].Rows[0]["mrp"].ToString();
                lblshortdesc.InnerText = dtCompany.Tables[0].Rows[0]["shortdescp"].ToString();
                //lblqty.Text = "0";
                // lblTotalAmt.InnerText = "";
                lbllongdesc.InnerText = dtCompany.Tables[0].Rows[0]["longdescp"].ToString();
            }
            else
            {

            }
        }



        if (dtCompany.Tables[1] != null)
        {
            if (dtCompany.Tables[1].Rows.Count > 0)
            {
                repproductslider.DataSource = dtCompany.Tables[1];
                repproductslider.DataBind();
            }
            else
            {
                repproductslider.DataSource = null;
                repproductslider.DataBind();
            }
        }
        else
        {
            repproductslider.DataSource = null;
            repproductslider.DataBind();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Int64 qty = Convert.ToInt64(txtqty.Value);
        try
        {
            if (Session["cartdt"] != null)
            {

            }
            else
            {
                DataTable cartdt = new DataTable();
                cartdt.Columns.Add("pid", typeof(string));
                cartdt.Columns.Add("productname", typeof(string));
                cartdt.Columns.Add("price", typeof(decimal)); ;
                cartdt.Columns.Add("qty", typeof(Int64));
                cartdt.Columns.Add("imagename", typeof(string));
                cartdt.Columns.Add("total", typeof(decimal));
                cartdt.Columns.Add("shortdescp", typeof(string));
                Session["cartdt"] = cartdt;
            }
        }
        catch { }
        //*-------------------
        bool isexist = false;
        try
        {
           
            if (qty == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Please Enter Quantity')", true);
            }
            else
            {
                DataTable dt = new DataTable();
                dt = (DataTable)Session["cartdt"];

                Int64 pid = Convert.ToInt64(Request.QueryString["pid"].ToString());

                if (dt == null||dt.Rows.Count==0)
                {
                    cls_product_b obj = new cls_product_b();
                    productmaster p = obj.SelectById(pid);
                    DataRow dr = dt.NewRow();
                    dr["pid"] = pid;
                    dr["productname"] = p.productname;
                    dr["price"] = p.mrp.ToString();
                    dr["qty"] = qty.ToString();
                    dr["total"] = (p.mrp * qty);
                    dr["imagename"] = p.mainimage;
                    dr["shortdescp"] = p.shortdescp;

                    dt.Rows.Add(dr);
                }
                else
                {
                    DataRow[] drr = dt.Select("pid='" + pid + " ' ");
                    if (drr.Length > 0  )
                    {
                        isexist = true;
                        ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('This Product already add')", true);
                    }
                    else
                    {
                        cls_product_b obj = new cls_product_b();
                        productmaster p = obj.SelectById(pid);


                        DataRow dr = dt.NewRow();

                        dr["pid"] = pid;
                        dr["productname"] = p.productname;
                        dr["price"] = p.mrp.ToString();
                        dr["qty"] = qty.ToString();
                        dr["total"] = (p.mrp * qty).ToString();
                        dr["imagename"] = p.mainimage;
                        dr["shortdescp"] = p.shortdescp;

                        dt.Rows.Add(dr);
                        
                    }

                }

            }



        }
        catch (Exception p)
        { }
        finally { }
        if(qty==0||isexist==true)
        {

        }
        else {
            Response.Redirect("cart.aspx");
        }
        
    }

    //replated prod
    // Get data from database/repository


    private void BindRelatedproduct(string pid)
    {
         
        DataSet ds = new DataSet();
        SqlDataAdapter da;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "productmaster_relatedproduct";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@pid", Convert.ToInt64(pid));
            cmd.Connection = con;
            con.Open();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
        }
        catch (Exception ex)
        {
            
        }
        finally
        {
            con.Close();
        }
        if (ds.Tables[0] != null)
        {
            if (ds.Tables[0].Rows.Count > 0)
            {
                repRelatedproduct.DataSource = ds.Tables[0];
                repRelatedproduct.DataBind();
            }
            else
            {
                repRelatedproduct.DataSource = null;
                repRelatedproduct.DataBind();
            }
        }
        else
        {
            repRelatedproduct.DataSource = null;
            repRelatedproduct.DataBind();
        }
    }
}