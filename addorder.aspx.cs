using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


public partial class addorder : System.Web.UI.Page
{
    string categoryFrontPath = "~/uploads/product/front/";
    //int categoryImageFrontWidth = 500;
    //int categoryImageFrontHeight = 605;
    //string categoryMainPath = "~/uploads/product/";
    //string categoryFrontPath = "~/uploads/product/front/";
    common ocommon = new common();
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
    private void BindMaincategory()
    {
        DataTable dtRawmaterial = (new cls_maincategory_b().SelectAll());
        ddlmaincategory.Items.Clear();

        if (dtRawmaterial != null)
        {
            if (dtRawmaterial.Rows.Count > 0)
            {
                ddlmaincategory.DataSource = dtRawmaterial;
                ddlmaincategory.DataTextField = "categoryname";
                ddlmaincategory.DataValueField = "id";
                ddlmaincategory.DataBind();
                ListItem objListItem = new ListItem("--Select Category--", "0");

                ddlmaincategory.Items.Insert(0, objListItem);
            }
        }
    }
    private void Bindsubcategory()
    {

    }
    public void BindProductGrid(Int64 id)
    {
        try
        {
            con.Open();
            DataTable ds = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "fillOrderGrid";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@oid", id);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            repProduct.DataSource = ds;
            repProduct.DataBind();
            ViewState["dtprod"] = ds;

            //-------total---------------
            double totalamt = 0;
            for (int i = 0; i < ds.Rows.Count; i++)
            {
                double amt = Convert.ToDouble(ds.Rows[i]["totalamt"].ToString());
                totalamt += amt;
            }
            txtgrandTotal.Text = totalamt.ToString();
            //-------------


            con.Close();
        }
        catch { }
        finally { con.Close(); }
    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            //BindBank();
            BindMaincategory();
            HtmlGenericControl hPageTitle = (HtmlGenericControl)this.Page.Master.FindControl("hPagebranchTitle");
            if (Request.QueryString["id"] != null)
            {
                BindProductGrid(Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true)));
                btnSave.Text = "Update";
                hPageTitle.InnerText = "Order Update";
                Page.Title = "Order Update";
            }
            else
            {
                BindProductGrid(-1);
                hPageTitle.InnerText = "Order Add";
                Page.Title = "Order Add";
                btnSave.Text = "Add";

            }
        }
    }

    private void Clear()
    {
        txtgrandTotal.Text = "0";
        //ddlmaincategory.SelectedIndex = 0;
        //ddlsubcategory.SelectedIndex = -1;

        //ddlmaincategory.SelectedIndex = -1; 
        //ddlsubcategory.SelectedIndex = -1;
        //ddltype.SelectedIndex = -1;
        //ddlbrand.SelectedIndex = -1;
        //txtqty.Text = string.Empty;
        //ddlproduct.SelectedIndex = -1;
    }



    //public void BindCategory(Int64 id)
    //{
    //    productmaster objproductmaster = (new cls_product_b().SelectById(id));
    //    if (objproductmaster != null)
    //    {
    //        //ddlBank.SelectedValue = objcategory.bankid.ToString();
    //        ddlmaincategory.SelectedValue = objproductmaster.maincategoryId.ToString();
    //        ddlmaincategory_SelectedIndexChanged(null, null);
    //        ddlsubcategory.SelectedValue = objproductmaster.subcategoryId.ToString();
    //        ddlsubcategory_SelectedIndexChanged(null, null);
    //        ddltype.SelectedValue = objproductmaster.typeId.ToString();
    //        ddltype_SelectedIndexChanged(null, null);
    //        ddlbrand.SelectedValue = objproductmaster.brandid.ToString();

    //        txtproductName.Text = objproductmaster.productname;
    //        txtgst.Text = objproductmaster.gst.ToString();
    //        txtstock.Text = objproductmaster.stock.ToString();
    //        txtmoq.Text = objproductmaster.moq.ToString();
    //        txtShortDescription.Text = objproductmaster.shortdescp.ToString();
    //        txtLongDescription.Text = objproductmaster.longdescp.ToString();
    //        if (!string.IsNullOrEmpty(objproductmaster.mainimage))
    //        {
    //            imgCategory.Visible = true;
    //            ViewState["fileName"] = objproductmaster.mainimage;
    //            imgCategory.ImageUrl = categoryFrontPath + objproductmaster.mainimage;
    //            btnImageUpload.Visible = false;
    //            btnRemove.Visible = true;
    //        }
    //        else
    //        {
    //            btnImageUpload.Visible = true;
    //        }



    //    }
    //}

    //protected override void Render(HtmlTextWriter writer)
    //{
    //    string validatorOverrideScripts = "<script src=\"" + Page.ResolveUrl("~") + "js/validators.js\" type=\"text/javascript\"></script>";
    //    this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ValidatorOverrideScripts", validatorOverrideScripts, false);
    //    base.Render(writer);
    //}


    protected void btnSave_Click(object sender, EventArgs e)
    {
        Int64 Result = 0;
        orders objorders = new orders();
        objorders.branchid  = Convert.ToInt64(Session["userid"].ToString());
        objorders.typeid = Convert.ToString(Session["type"].ToString());
        objorders.totalamount = Convert.ToDecimal(txtgrandTotal.Text);

        



        if (Request.QueryString["id"] != null)
        {
            objorders.oid = Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true));
            Result = (new cls_order_b().Update (objorders));
            if (Result > 0)
            {
                try
                {
                    DataTable ds = new DataTable();
                    ds = (DataTable)ViewState["dtprod"];

                    con.Close();
                    con.Open();
                    foreach (RepeaterItem item in repProduct.Items)
                    {


                        Label lblProductId = (Label)item.FindControl("lblProductId");
                        Label lblmrp = (Label)item.FindControl("lblmrp");
                        Label lblrate = (Label)item.FindControl("lblrate");
                        Label lblgst = (Label)item.FindControl("lblgst");
                        Label lblQty = (Label)item.FindControl("lblQty");


                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = "CustomerOrderProduct_insert";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;

                        SqlParameter param = new SqlParameter();
                        param.ParameterName = "@opid";
                        param.Value = 0;
                        param.SqlDbType = SqlDbType.Int;
                        param.Direction = ParameterDirection.InputOutput;
                        cmd.Parameters.Add(param);
                        cmd.Parameters.AddWithValue("@pid", Convert.ToInt64(lblProductId.Text));
                        cmd.Parameters.AddWithValue("@oid", Result);
                        cmd.Parameters.AddWithValue("@rate", Convert.ToDecimal(lblrate.Text));
                        cmd.Parameters.AddWithValue("@quantity", Convert.ToDecimal(lblQty.Text));
                        cmd.Parameters.AddWithValue("@gst", Convert.ToDecimal(lblgst.Text));
                        cmd.Parameters.AddWithValue("@mrp", Convert.ToDecimal(lblmrp.Text));
                        Int64 result = cmd.ExecuteNonQuery();

                    }

                }
                catch (Exception p)
                { }
                finally { con.Close(); }

                Clear();
                Response.Redirect(Page.ResolveUrl("~/manageorders.aspx?mode=u"));
            }
            else
            {
                Clear();
                spnMessgae.Style.Add("color", "red");
                spnMessgae.InnerText = "Order Not Updated";

            }
            //objproductmaster.id = Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true));
            //Result = (new cls_product_b().Update(objproductmaster));
            //if (Result > 0)
            //{
            //    Clear();
            //    Response.Redirect(Page.ResolveUrl("~/manageproduct.aspx?mode=u"));
            //}
            //else
            //{
            //    Clear();
            //    spnMessgae.Style.Add("color", "red");
            //    spnMessgae.InnerText = "Product Not Updated";
            //    BindCategory(Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true)));
            //}
        }
        else
        {
            Result = (new cls_order_b().Insert(objorders));
            if (Result > 0)
            {
                string branchmail = "", zonalmail = "";
                try
                {
                    DataTable ds = new DataTable();
                    ds = (DataTable)ViewState["dtprod"];

                    con.Close();
                    con.Open();
                    foreach (RepeaterItem item in repProduct.Items)
                    {

              
                        Label lblProductId = (Label)item.FindControl("lblProductId");
                        Label lblmrp = (Label)item.FindControl("lblmrp");
                        Label lblrate = (Label)item.FindControl("lblrate");
                        Label lblgst = (Label)item.FindControl("lblgst");
                        Label lblQty = (Label)item.FindControl("lblQty");
                        

                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = "CustomerOrderProduct_insert";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;

                        SqlParameter param = new SqlParameter();
                        param.ParameterName = "@opid";
                        param.Value = 0;
                        param.SqlDbType = SqlDbType.Int;
                        param.Direction = ParameterDirection.InputOutput;
                        cmd.Parameters.Add(param);
                        cmd.Parameters.AddWithValue("@pid", Convert.ToInt64(lblProductId.Text));
                        cmd.Parameters.AddWithValue("@oid", Result);
                        cmd.Parameters.AddWithValue("@rate", Convert.ToDecimal(lblrate.Text));
                        cmd.Parameters.AddWithValue("@quantity", Convert.ToDecimal(lblQty.Text));
                        cmd.Parameters.AddWithValue("@gst", Convert.ToDecimal(lblgst .Text));
                        cmd.Parameters.AddWithValue("@mrp", Convert.ToDecimal(lblmrp.Text));
                        Int64 result = cmd.ExecuteNonQuery(); 

                    }


                    //----------------
                   
                    SqlCommand cmdmail = new SqlCommand();
                    cmdmail.CommandText = "branch_SelectById";
                    cmdmail.CommandType = CommandType.StoredProcedure;
                    cmdmail.Connection = con;
                    cmdmail.Parameters.AddWithValue("@id", objorders.branchid);
                    DataTable dtmail = new DataTable();
                  SqlDataAdapter  damail = new SqlDataAdapter(cmdmail);
                    damail.Fill(dtmail);
                    if(dtmail.Rows.Count>0)
                    {
                        branchmail = dtmail.Rows[0]["emailid"].ToString();
                        zonalmail = dtmail.Rows[0]["zonalMailId"].ToString();
                    }
                }
                catch (Exception p)
                { }
                finally { con.Close(); }

                SendConfirmationMail(zonalmail, branchmail, Result);
                Clear();
                Response.Redirect(Page.ResolveUrl("~/manageorders.aspx?mode=i"));
            }
            else
            {
                Clear();
                spnMessgae.Style.Add("color", "red");
                spnMessgae.InnerText = "Order Not Inserted";

            }
        }
    }
    private bool SendConfirmationMail(string ZonalmgrMail, string brachmail, Int64 OrderID)
    {
        common ocommon = new common();
        string oSB = string.Empty;
        bool send = false;
        MailMessage mail = new MailMessage();
        mail.To.Add("all4stationery@gmail.com");

        //mail.To.Add("accounts@all-stationery.com");
       
        //mail.CC.Add("ploutos.acc@gmail.com");
        //mail.To.Add("ploutos.kiran@gmail.com");
        if (ZonalmgrMail.ToString().Trim() == "".Trim())
        {
        }
        else
        {
            mail.To.Add(new MailAddress(ZonalmgrMail));
        }
        if (brachmail.ToString().Trim() == "".Trim())
        {
        }
        else
        {
            mail.To.Add(new MailAddress(brachmail));
        }



        // mail.To.Add(new MailAddress("mahaleyogita233@gmail.com"));
        mail.From = new MailAddress("accounts@all-stationery.com", "Stationery Order");
        mail.Subject = "Order Insert Successfully";
        mail.Body = OrderMailCreate(OrderID);
        //string Filepath = Server.MapPath("~\\PDF\\") + "Invoice" + count + ".pdf";

        //string PdfFile = Request.PhysicalApplicationPath + "1.pdf";
        //System.Net.Mail.Attachment attachment;
        //attachment = new System.Net.Mail.Attachment(Filepath);
        //mail.Attachments.Add(attachment);

        mail.IsBodyHtml = true;
        SmtpClient smtp = new SmtpClient();
        smtp.Host = "103.250.184.62";
        smtp.Port = 25;
        smtp.UseDefaultCredentials = false;
        smtp.Credentials = new System.Net.NetworkCredential("accounts@all-stationery.com", "kiran@123");
        try
        {
            smtp.Send(mail);
            send = true;
        }
        catch (Exception ex)
        {
            send = false;
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('" + ex.Message + "," + ex.StackTrace + "')", true);
            // ErrHandler.writeError(ex.Message, ex.StackTrace);
        }
        return send;
    }

    private string OrderMailCreate(Int64 OrderId)
    {
        common ocommon = new common();
        //string OrderLink = "http://moryaapp.moryatools.com/orderinvoice.aspx?oid=" + ocommon.Encrypt(OrderId.ToString(), true);
        string oSB = string.Empty;
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
            oSB += "<div>Hello Admin,</div>";
            if (ds.Tables != null)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    oSB += "<br/>";
                    oSB += "<table><tr><td><b><u>Order Details - </u></b></td></tr><tr><td> Order ID - " + ds.Tables[0].Rows[0]["oid"].ToString() + "</td></tr><tr><td>Order Date: <span>" + ds.Tables[0].Rows[0]["orderdate"].ToString() + "</span></td></tr><tr><td>Total : <span>" + ds.Tables[0].Rows[0]["totalamount"].ToString() + " ₹ </span></td></tr><tr><td>To <br /> Bank : <span>" + ds.Tables[0].Rows[0]["bankname"].ToString() + "</span></td></tr><tr><td>Branch: <span>" + ds.Tables[0].Rows[0]["branchname"].ToString() + "</span></td></tr><tr><td>Block No: <span>" + ds.Tables[0].Rows[0]["address"].ToString() + "</span></td></tr><tr><td>Apartment/ Building: <span>" + ds.Tables[0].Rows[0]["apartment"].ToString() + "</span></td></tr><tr><td>Road: <span>" + ds.Tables[0].Rows[0]["road"].ToString() + "</span></td></tr><tr><td>State: <span>" + ds.Tables[0].Rows[0]["state"].ToString() + "</span></td></tr><tr><td>City: <span>" + ds.Tables[0].Rows[0]["City"].ToString() + "</span></td></tr><tr><td>Pin Code: <span>" + ds.Tables[0].Rows[0]["pincode"].ToString() + "</span></td></tr></table>";
                    oSB += "<hr/>";
                }

                //if (ds.Tables[0] != null)
                //{
                //    if (ds.Tables[0].Rows.Count > 0)
                //    {
                //        oSB += "<br/>";
                //        oSB += "<table><tr><td><b><u>Order Details -</u></b></td></tr><tr><td> Invoice No - #" + ds.Tables[0].Rows[0]["oid"].ToString() + "</td></tr><tr><td>Order Date: <span>" + ds.Tables[0].Rows[0]["orderdate"].ToString() + "</span></td></tr><tr><td>Total Amount: <span>" + ds.Tables[0].Rows[0]["totalamount"].ToString() + "</span></td></tr></table>";
                //        oSB += "<hr/>";
                //    }
                //}

                if (ds.Tables[1].Rows.Count > 0)
                {
                    oSB += "<br/>";
                    oSB += "<table><tr><td><b><u>Order Products Details - </u></b></td></tr></table>";
                    oSB += "<br/>";
                    oSB += "<table style='border: 1px solid black'><thead><tr style='border: 1px solid black'><th style='border: 1px solid black'>SrNo</th><th style='border: 1px solid black'>Product Name</th><th style='text-align: center;border: 1px solid black'>MOQ</th><th style='text-align: center;border: 1px solid black'>MRP/Unit</th><th style='text-align: center;border: 1px solid black'>Rate/Unit</th><th style='text-align: center;border: 1px solid black'>Total Value</th><th style='text-align: center;border: 1px solid black'>GST</th><th style='text-align: center;border: 1px solid black'>Gst Value</th><th style='text-align: center;border: 1px solid black'>Total Value</th></tr></thead><tbody>";
                    for (int i = 0; i < ds.Tables[1].Rows.Count; i++)
                    {
                        oSB += "<tr style='border: 1px solid black'>";
                        oSB += "<td style='border: 1px solid black'><span>" + ds.Tables[1].Rows[i]["sr"].ToString() + "</span></td>";
                        oSB += "<td style='text-align: center;border: 1px solid black'><span>" + ds.Tables[1].Rows[i]["productname"].ToString() + "</span></td>";
                        //oSB += "<td style='text-align: center;border: 1px solid black'><span>" + ds.Tables[1].Rows[i]["companyName"].ToString() + "</span></td>";
                        oSB += "<td style='text-align: center;border: 1px solid black'><span>" + ds.Tables[1].Rows[i]["quantity"].ToString() + "</span></td>";
                        oSB += "<td style='text-align: center;border: 1px solid black'><span>" + ds.Tables[1].Rows[i]["mrp"].ToString() + "</span></td>";
                        oSB += "<td style='text-align: center;border: 1px solid black'><span>" + ds.Tables[1].Rows[i]["rate"].ToString() + "</span></td>";
                        oSB += "<td style='text-align: center;border: 1px solid black'><span>" + ds.Tables[1].Rows[i]["totalvalue"].ToString() + "</span></td>";

                        oSB += "<td style='text-align: center;border: 1px solid black'><span>" + ds.Tables[1].Rows[i]["gst"].ToString() + "</span></td>";
                        oSB += "<td style='text-align: center;border: 1px solid black'><span>" + ds.Tables[1].Rows[i]["gstamt"].ToString() + "</span></td>";
                        oSB += "<td style='text-align: center;border: 1px solid black'><span>" + ds.Tables[1].Rows[i]["totalamt"].ToString() + "</span></td>";
                        oSB += "</tr>";
                    }
                    oSB += "</tbody></table>";
                    oSB += "<br/>";
                    //oSB += "<b><u>Website Page Link -</u>  <a href=" + OrderLink + ">" + OrderLink + "</a></b>";
                    oSB += "<br/>";
                    oSB += "<br/>";
                    oSB += "<hr/>";
                    oSB += "<div>Thank you,</div>";
                    oSB += "<div>all-stationery- Support Team.</div>";
                }

            }
        }
        catch (Exception ex)
        {
            ErrHandler.writeError(ex.Message, ex.StackTrace);
            return null;
        }
        finally
        {
            con.Close();
        }
        return oSB;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveUrl("~/manageorders.aspx"));
    }

    protected void ddlmaincategory_SelectedIndexChanged(object sender, EventArgs e)
    {

        Int64 maincategoryId = Convert.ToInt64(ddlmaincategory.SelectedValue.ToString()); 
        DataTable dt = (new cls_subcategory_b().SelectAll(maincategoryId));
        ddlsubcategory.Items.Clear();

        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                ddlsubcategory.DataSource = dt;
                ddlsubcategory.DataTextField = "categoryname";
                ddlsubcategory.DataValueField = "id";
                ddlsubcategory.DataBind();
                ListItem objListItem = new ListItem("--Select Subcategory--", "0");

                ddlsubcategory.Items.Insert(0, objListItem);
            }
        }
    }


   



    protected void ddlsubcategory_SelectedIndexChanged(object sender, EventArgs e)
    {

        Int64 subCategoryId = Convert.ToInt64(ddlsubcategory.SelectedValue.ToString()); ;
        DataTable dt = (new cls_typemaster_b().SelectAll(subCategoryId));
        ddltype.Items.Clear();

        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                ddltype.DataSource = dt;
                ddltype.DataTextField = "typename";
                ddltype.DataValueField = "id";
                ddltype.DataBind();
                ListItem objListItem = new ListItem("--Select Type--", "0");

                ddltype.Items.Insert(0, objListItem);
            }
        }
    }



    protected void ddltype_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int64 typeId = Convert.ToInt64(ddltype.SelectedValue.ToString()); ;
        DataTable dt = (new Cls_brand_b().SelectAllByTypeId(typeId));
        ddlbrand.Items.Clear();

        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                ddlbrand.DataSource = dt;
                ddlbrand.DataTextField = "brandname";
                ddlbrand.DataValueField = "id";
                ddlbrand.DataBind();
                ListItem objListItem = new ListItem("--Select Brand--", "0");

                ddlbrand.Items.Insert(0, objListItem);
            }
        }
    }

    protected void ddlbrand_SelectedIndexChanged(object sender, EventArgs e)
    {
        Int64 brandid = Convert.ToInt64(ddlbrand.SelectedValue.ToString()); ;
        DataTable dt = (new cls_product_b().product_SelectBybrandId(brandid));
        ddlproduct .Items.Clear();

        if (dt != null)
        {
            if (dt.Rows.Count > 0)
            {
                ddlproduct.DataSource = dt;
                ddlproduct.DataTextField = "productname";
                ddlproduct.DataValueField = "id";
                ddlproduct.DataBind();
                ListItem objListItem = new ListItem("--Select Product--", "0");

                ddlproduct.Items.Insert(0, objListItem);
            }
        }
    }

    protected void btnadd_Click(object sender, EventArgs e)
    {
        try
        {

            if (ddlmaincategory.SelectedIndex == 0 || ddlsubcategory.SelectedIndex == 0 || ddlproduct.SelectedIndex == 0 || ddlbrand.SelectedIndex == 0 || ddltype.SelectedIndex == 0 || txtqty.Text == "" || txtqty.Text == "0" || txtFinalAmt.Text == "")
            {
                ScriptManager.RegisterStartupScript(this, GetType(), "alertmsg", "alert('Please Enter All Fields ');", true);
                return;
            }
            //sr,pid,productName,quantity,mrp,rate,gst,totalvalue,gstamt,totalamt
            DataTable dtprodn = new DataTable();
            dtprodn = (DataTable)ViewState["dtprod"];

            DataRow[] drr = dtprodn.Select("pid='" + ddlproduct.SelectedValue.ToString() + " ' ");
            if (drr.Length > 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('This Product already add')", true);
            }
            else
            {
                DataRow dr = dtprodn.NewRow();
                int srr = 0;
                srr = dtprodn.Rows.Count + 1;
                dr["sr"] = srr.ToString();
                dr["pid"] = ddlproduct.SelectedValue.ToString();
                dr["productName"] = ddlproduct.SelectedItem.ToString();
                dr["quantity"] = txtqty.Text;
                dr["mainimage"] = txtimagename.Text;
                dr["mrp"] = txtprice1.Text;
                dr["rate"] = txtrate.Text;
                dr["gst"] = txtgst.Text;
                dr["totalvalue"] = txtsubtotal.Text;
                dr["gstamt"] = txtgstamt.Text;
                dr["totalamt"] = txtFinalAmt.Text;
                dtprodn.Rows.Add(dr);
                //sr,pid,productName,quantity,mrp,rate,gst,totalvalue,gstamt,totalamt
            }



            repProduct.DataSource = dtprodn;
            repProduct.DataBind();

            //-------total---------------
            double totalamt = 0;
            for (int i = 0; i < dtprodn.Rows.Count; i++)
            {
                double amt = Convert.ToDouble(dtprodn.Rows[i]["totalamt"].ToString());
                totalamt += amt;
            }
            txtgrandTotal.Text = totalamt.ToString();
            //-------------


            ViewState["dtprod"] = dtprodn;

            ddlmaincategory.SelectedIndex = 0;
            ddlsubcategory.SelectedIndex = 0;
            ddlproduct.SelectedIndex = 0;
            ddltype.SelectedIndex = 0;
            ddlbrand.SelectedIndex = 0;
            txtprice1.Text = string.Empty;
            txtrate.Text = string.Empty;
            txtqty.Text = string.Empty;
            txtsubtotal.Text = string.Empty;
            txtgst.Text = string.Empty;
            txtgstamt.Text = string.Empty;
            txtFinalAmt.Text = string.Empty;


        }
        catch (Exception ex)
        {

            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void ddlproduct_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            if (ddlmaincategory.SelectedIndex == 0 || ddlsubcategory.SelectedIndex == 0 || ddltype.SelectedIndex == 0 || ddlbrand.SelectedIndex == 0)
            {
                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Please select all Fields')", true);
            }
            else
            {
                Int64 branchid = Convert.ToInt64(Session["bid"].ToString());
                Int64 pid = Convert.ToInt64(ddlproduct.SelectedValue.ToString());
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "getProductDetail_bybranchId";
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@pid",pid);
                cmd.Parameters.AddWithValue("@brachid", branchid);
                cmd.Connection = con;
                con.Open();
                DataTable dt = new DataTable();
              SqlDataAdapter  da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                //getProductDetail_bybranchId
                if(dt.Rows.Count>0)
                {
                    txtprice1.Text = dt.Rows[0]["mrp"].ToString();
                    txtrate.Text = dt.Rows[0]["price"].ToString();
                    txtqty.Text = "0";
                    txtsubtotal.Text = "0";
                    txtgst.Text = dt.Rows[0]["gst"].ToString();
                    txtgstamt.Text = "0";
                    txtFinalAmt.Text = "0";
                    txtimagename.Text= dt.Rows[0]["mainimage"].ToString();
                }

            }
        }
        catch { }
        finally { }
    }

    protected void txtqty_TextChanged(object sender, EventArgs e)
    {
        try
        {

            decimal rate = Convert.ToDecimal(txtrate.Text);
            decimal qty = Convert.ToInt64(txtqty.Text);
            decimal subtotal = rate * qty;
            txtsubtotal.Text = subtotal.ToString();
            decimal gst = Convert.ToDecimal(txtgst.Text);
            decimal gstamt = (subtotal * gst) / 100;
            txtgstamt.Text = gstamt.ToString();
            txtFinalAmt.Text = (subtotal + gstamt).ToString();
        }
        catch { }
//        txtprice
//txtrate
//txtqty
//txtsubtotal
//txtgst
//txtgstamt
//txtFinalAmt
    }

    protected void repProduct_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {

         Image imgCategory = (Image)e.Item.FindControl("imgCategory");
           
            imgCategory.ImageUrl = categoryFrontPath + DataBinder.Eval(e.Item.DataItem, "mainimage").ToString();

        }
    }

    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        try
        {
            con.Open();

            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;

            Int64 pid = int.Parse((item.FindControl("lblProductId") as Label).Text);

            //string pid = (gvproduct.Rows[ind].Cells[0].Text);        

            DataTable dtprodn = new DataTable();
            dtprodn = (DataTable)ViewState["dtprod"];

            Int64 txtsr = int.Parse((item.FindControl("txtsr") as Label).Text);
            DataRow[] drr = dtprodn.Select("sr='" + txtsr + " ' ");

            foreach (var row in drr)
                row.Delete();

            //-----------------
            dtprodn.AcceptChanges();
            repProduct.DataSource = dtprodn;
            repProduct.DataBind();

            if (Request.QueryString["id"] != null)
            {
                Int64 OrderID = Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true));
                string s = "update orderproducts set isdeleted =1  where oid = " + OrderID + " and pid=" + pid + "";
                SqlCommand cmd = new SqlCommand(s, con);
                int t = cmd.ExecuteNonQuery();


            }

            ScriptManager.RegisterStartupScript(this, GetType(), "alertmsg", "alert('Product Remove Successfully');", true);
            con.Close();
        }
        catch (Exception p)
        { }
        finally { con.Close(); }
    }
}
