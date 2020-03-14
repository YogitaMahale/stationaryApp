using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class orderinvoice : System.Web.UI.Page
{
    common ocommon = new common();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Int64 id = Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true));
            BindOrderDetails(Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true)));
        }
    }

    private void BindOrderDetails(Int64 OrderId)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
        DataSet ds = new DataSet();
        SqlDataAdapter da;
        try
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "order_invoice";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@oid", OrderId);
            cmd.Connection = con;
            con.Open();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            if (ds.Tables != null)
            {
                /* Order Details */
                if (ds.Tables[0] != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        sminvoiceNo.InnerText = ds.Tables[0].Rows[0]["oid"].ToString();
                        //smOrderDate.InnerText = "Order Date : " + ds.Tables[0].Rows[0]["orderdate"].ToString();
                        //spnSubTotal.InnerText = ds.Tables[0].Rows[0]["amount"].ToString();
                        //spnTax.InnerText = ds.Tables[0].Rows[0]["tax"].ToString();
                        //spnTotal.InnerText = ds.Tables[0].Rows[0]["totalamount"].ToString();
                        spnToBank.InnerText = ds.Tables[0].Rows[0]["bankname"].ToString();
                        spnToBranch.InnerText = ds.Tables[0].Rows[0]["branchname"].ToString();
                        spnTooaddress.InnerText = ds.Tables[0].Rows[0]["address"].ToString();


                        //spnloginUserName.InnerText = ds.Tables[0].Rows[0]["loginUserName"].ToString();

                        spnTooApartment.InnerText = ds.Tables[0].Rows[0]["apartment"].ToString();
                        spnTooRoad.InnerText = ds.Tables[0].Rows[0]["road"].ToString();
                        spnTooState.InnerText = ds.Tables[0].Rows[0]["state"].ToString();
                        spnTooCity.InnerText = ds.Tables[0].Rows[0]["City"].ToString();
                        spnTooPincode.InnerText = ds.Tables[0].Rows[0]["pincode"].ToString();
                        //spnTooPhoneNo.InnerText = ds.Tables[0].Rows[0]["phone"].ToString();
                        spnTooMobileNo.InnerText = ds.Tables[0].Rows[0]["mobileNo"].ToString();
                        spnTooGst.InnerText = ds.Tables[0].Rows[0]["gstno"].ToString();
                        spnTooZonalmgrName.InnerText = ds.Tables[0].Rows[0]["zonalmgrName"].ToString();
                        spnTooZonalmgrEmail.InnerText = ds.Tables[0].Rows[0]["zonalmgrEmail"].ToString();
                    }
                }

                /* Order Products Details */
                if (ds.Tables[1] != null)
                {
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        repProduct .DataSource = ds.Tables[1];
                        repProduct.DataBind();
                    }
                }

                /* User Details */
                //if (ds.Tables[2] != null)
                //{
                //    if (ds.Tables[2].Rows.Count > 0)
                //    {
                //        spnName.InnerHtml = ds.Tables[2].Rows[0]["name"].ToString();
                //        strGSTNo.Visible = true;
                //        spnGST.InnerHtml = ds.Tables[2].Rows[0]["gstno"].ToString();
                //        spnToAddress.InnerHtml = ds.Tables[2].Rows[0]["address"].ToString();
                //        spnToEmail.InnerHtml = ds.Tables[2].Rows[0]["email"].ToString();
                //        spnToPhone.InnerHtml = ds.Tables[2].Rows[0]["phone"].ToString();
                //    }
                //}

            }
        }
        catch (Exception ex)
        {
            ErrHandler.writeError(ex.Message, ex.StackTrace);
        }
        finally
        {
            con.Close();
        }
    }

}