using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BusinessLayer;
public partial class socialpage : System.Web.UI.Page
{
    common ocommon = new common();
    int productImageFrontWidth = 1000;
    int productImageFrontHeight = 900;
    string productMainPath = "~/uploads/socialimg/";
    string productFrontPath = "~/uploads/socialimg/front/";
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
    public void BindsocialInfo(Int64 id)
    {
        //socialinfo objsocialinfo = (new cls_socialinfo_b().SelectById(id));
        //if (objsocialinfo != null)
        //{
        //    txttitle.Text = objsocialinfo.title;
        //    txtshortdesc .Text = objsocialinfo.email;
        //    txtlongdesc.Text = objsocialinfo.phoneNo;
        //    txturl1.Text = objsocialinfo.address;
        //    txturl2.Text = objcustomerRegistration.password;
        //    txturl3.Text = objsocialinfo.address;
        //    txturl4.Text = objcustomerRegistration.password;

        //    //  id, customerid, title, shortdesc, longdesc, videourl1, videourl2, videourl3, videourl4, isactive, isdelete, date1

        //}
        //BindProductGrid(id);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {

            if (Request.QueryString["id"] != null)
            {
               // BindsocialInfo(Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true)));

               // btnSave.Text = "UPDATE";
               //// hPageTitle.InnerText = "Update Customer";
               // Page.Title = "Update";
            }
            else
            {
                BindProductGrid(-1);
                //hPageTitle.InnerText = "New Customer";
                //Page.Title = "New Customer";
                btnSave.Text = "ADD";
            }
        }
    }
    private void Clear()
    {

        txttitle .Text = string.Empty;
        txtshortdesc.Text = string.Empty;
        txtlongdesc.Text = string.Empty;
        txturl1.Text = string.Empty;
        txturl2.Text = string.Empty;
        txturl3.Text = string.Empty;
        txturl4.Text = string.Empty;
        imgProduct .Visible = false;
        ViewState["fileName"] = null;


    }
    public void BindProductGrid(Int64 id)
    {
        try
        {
            con.Open();
            DataTable ds = new DataTable();
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "socialInfoimages_Selectbyid";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Connection = con;
            cmd.Parameters.AddWithValue("@socialinfoid", id);
            //con.Open();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);


            repProduct.DataSource = ds;
            repProduct.DataBind();
            ViewState["dtprod"] = ds;




            con.Close();
        }
        catch { }
        finally { con.Close(); }
    }
    protected void btnImageUpload_Click(object sender, EventArgs e)
    {
        if (fpProduct.HasFile)
        {

            decimal size = Math.Round(((decimal)fpProduct.PostedFile.ContentLength / (decimal)1024), 2);
            if (size <= 2000)
            {
                string fileName = Path.GetFileNameWithoutExtension(fpProduct.FileName.Replace(' ', '_')) + DateTime.Now.Ticks.ToString() + Path.GetExtension(fpProduct.FileName);
                fpProduct.SaveAs(MapPath(productMainPath + fileName));
                ocommon.CreateThumbnail1("uploads\\socialimg\\", productImageFrontWidth, productImageFrontHeight, "~/uploads/socialimg/front/", fileName);


                //WatermarkImageCreate(fileName);
                imgProduct.Visible = true;
                //imgProduct.ImageUrl = productWaterFrontPath + fileName;
                imgProduct.ImageUrl = productFrontPath + fileName;
                ViewState["fileName"] = fileName;
                btnRemove.Visible = true;
                btnImageUpload.Visible = false;
            }
            else
            {
                Response.Write("<script>alert('Image size Must be less than 2MB')</script>");
            }
        }
    }
    protected void btnRemove_Click(object sender, EventArgs e)
    {
        removeImage(ViewState["fileName"].ToString());
    }
    private void removeImage(string filename)
    {

        var filePath = Server.MapPath("~/uploads/socialimg/" + filename);
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }


        var filePath2 = Server.MapPath("~/uploads/socialimg/front/" + filename);
        if (File.Exists(filePath2))
        {
            File.Delete(filePath2);
        }

        btnImageUpload.Visible = true;
        btnRemove.Visible = false;
        ViewState["fileName"] = string.Empty;
        imgProduct.Visible = false;

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        //Int64 Result = 0;
        //customermaster objcustomermaster = new customermaster();
        //objcustomermaster.customername = txtname.Text;
        //objcustomermaster.mobileno = txtmobileno.Text;
        //objcustomermaster.emailid = txtemailid.Text;
        //objcustomermaster.password = txtpassword.Text;
        //objcustomermaster.address = txtaddress.Text;

        //Result = (new cls_customermaster_b().Insert(objcustomermaster));
        //if (Result > 0)
        //{
        //    Clear();
        //    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Account Created ')", true);
        //    // Response.Redirect(Page.ResolveUrl("~/customerlogin.aspx"));
        //}
        //else
        //{
        //    Clear();
        //    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Account Not Created ')", true);

        //}

    }



    protected void btnAdd_Click(object sender, EventArgs e)
    {
        try
        {


            DataTable dtprodn = new DataTable();
            dtprodn = (DataTable)ViewState["dtprod"];

            string imgname = string.Empty;
            if (ViewState["fileName"] != null)
            {
                imgname = ViewState["fileName"].ToString();
                DataRow dr = dtprodn.NewRow();
                int srr = 0;
                srr = dtprodn.Rows.Count + 1;
                dr["sr"] = srr.ToString();
                dr["img"] = imgname;
                dr["id"] = "0";
                dr["socialinfoid"] = "0";
                dtprodn.Rows.Add(dr);




                repProduct.DataSource = dtprodn;
                repProduct.DataBind();
                ViewState["dtprod"] = dtprodn;

            }

            imgProduct.Visible = false;


            btnRemove.Visible = false;
            btnImageUpload.Visible = true;

            ViewState["fileName"] = null;

        }
        catch (Exception ex)
        {

            Response.Write(ex.Message + ex.StackTrace);
        }
    }

    protected void repProduct_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        Image imgCategory = (Image)e.Item.FindControl("imgCategory");

        imgCategory.ImageUrl = productMainPath + DataBinder.Eval(e.Item.DataItem, "img").ToString();

    }

    protected void lnkrepproductDelete_Click(object sender, EventArgs e)
    {
        try
        {
            con.Open();

            RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
            DataTable dtprodn = new DataTable();
            dtprodn = (DataTable)ViewState["dtprod"];
            Int64 txtsr = int.Parse((item.FindControl("lblsr") as Label).Text);
            DataRow[] drr = dtprodn.Select("sr='" + txtsr + " ' ");
            foreach (var row in drr)
                row.Delete();

            //-----------------
            dtprodn.AcceptChanges();
            repProduct.DataSource = dtprodn;
            repProduct.DataBind();

            //if (Request.QueryString["id"] != null)
            //{
            //    Int64 OrderID = Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true));
            //    string s = "update tbl_customerProduct set isdelete =1  where Fk_customerId = " + OrderID + " and fk_productId=" + pid + "";
            //    SqlCommand cmd = new SqlCommand(s, con);
            //    int t = cmd.ExecuteNonQuery();


            //}

            ScriptManager.RegisterStartupScript(this, GetType(), "alertmsg", "alert('Product Remove Successfully');", true);
            con.Close();
        }
        catch (Exception p)
        { }
        finally { con.Close(); }
    }

    protected void btncancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveUrl("~/managesocialpage.aspx"));
    }

    protected void btnsave_Click(object sender, EventArgs e)
    {
        Int64 Result = 0;
        socialinfo objsocialinfo = new socialinfo();

        //id, customerid, title, shortdesc, longdesc, videourl1, videourl2, videourl3, videourl4, isactive, isdelete, date1
        Int64 customerid = 0;
        if (Session["customerid"] == null)
        {

        }
        else
        {
            customerid = Convert.ToInt64(Session["customerid"].ToString());
        }
        objsocialinfo.customerid = customerid;
        objsocialinfo.title = txttitle.Text.Trim();
        objsocialinfo.shortdesc = txtshortdesc.Text.Trim();
        objsocialinfo.longdesc = txtlongdesc.Text.Trim();
        objsocialinfo.videourl1 = txturl1.Text.Trim();
        objsocialinfo.videourl2 = txturl2.Text.Trim();
        objsocialinfo.videourl3 = txturl3.Text.Trim();

        objsocialinfo.videourl4 = txturl4.Text.Trim();



        if (Request.QueryString["id"] != null)
        {
            //objsocialinfo.id = Convert.ToInt32(ocommon.Decrypt(Request.QueryString["id"].ToString(), true));
            //bool res = CheckMobileNumberExitOrNot(objcustomerRegistration.phoneNo, "u", objcustomerRegistration.id.ToString());
            //if (res == true)
            //{
            //    spnMessgae.Style.Add("color", "red");
            //    spnMessgae.InnerText = "Duplicate Mobile No";
            //}
            //else
            //{
            //    Result = (new Cls_customerRegistration_b().Update(objcustomerRegistration));

            //    if (Result > 0)
            //    {
            //        try
            //        {
            //            DataTable ds = new DataTable();
            //            ds = (DataTable)ViewState["dtprod"];

            //            ConnectionString.Close();
            //            ConnectionString.Open();
            //            foreach (RepeaterItem item in repProduct.Items)
            //            {
            //                Label fk_productId = (Label)item.FindControl("lblProductId");
            //                Label type = (Label)item.FindControl("lbltype");
            //                TextBox qty = (TextBox)item.FindControl("lblQty");
            //                TextBox txtprice = (TextBox)item.FindControl("txtprice");
            //                Label lbldays = (Label)item.FindControl("lbldays");
            //                SqlCommand cmd = new SqlCommand();
            //                cmd.CommandText = "Customer_ProductUpdate";
            //                cmd.CommandType = CommandType.StoredProcedure;
            //                cmd.Connection = ConnectionString;

            //                SqlParameter param = new SqlParameter();
            //                param.ParameterName = "@id";
            //                param.Value = 0;
            //                param.SqlDbType = SqlDbType.Int;
            //                param.Direction = ParameterDirection.InputOutput;
            //                cmd.Parameters.Add(param);
            //                cmd.Parameters.AddWithValue("@fk_productId", Convert.ToInt64(fk_productId.Text));
            //                cmd.Parameters.AddWithValue("@Fk_customerId", Result);
            //                cmd.Parameters.AddWithValue("@qty", qty.Text);
            //                cmd.Parameters.AddWithValue("@type", type.Text);
            //                cmd.Parameters.AddWithValue("@price", txtprice.Text);
            //                cmd.Parameters.AddWithValue("@days", lbldays.Text);
            //                Int64 result = cmd.ExecuteNonQuery();



            //            }

            //        }
            //        catch (Exception p)
            //        { }
            //        finally { ConnectionString.Close(); }
            //        Clear();
            //        Response.Redirect(Page.ResolveUrl("~/manageCustomerRegistration.aspx? mode=u"));
            //    }
            //    else
            //    {
            //        Clear();
            //        spnMessgae.Style.Add("color", "red");
            //        spnMessgae.InnerText = "Customer Not Updated";
            //        BindCustomer(Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true)));
            //    }
            //}
        }
        else
        {

            Result = (new cls_socialinfo_b().Insert(objsocialinfo));

            if (Result > 0)
            {
                try
                {
                    DataTable ds = new DataTable();
                    ds = (DataTable)ViewState["dtprod"];


                    con.Open();
                    foreach (RepeaterItem item in repProduct.Items)
                    {
                        //sr,id,socialinfoid,img
                        Label lblimg = (Label)item.FindControl("lblimg");
                        SqlCommand cmd = new SqlCommand();
                        cmd.CommandText = "Customer_ProductUpdate";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Connection = con;
                        SqlParameter param = new SqlParameter();
                        param.ParameterName = "@id";
                        param.Value = 0;
                        param.SqlDbType = SqlDbType.Int;
                        param.Direction = ParameterDirection.InputOutput;
                        cmd.Parameters.Add(param);
                        cmd.Parameters.AddWithValue("@socialinfoid", Result);
                        cmd.Parameters.AddWithValue("@img", lblimg.Text);  
                        Int64 result = cmd.ExecuteNonQuery();

                    }

                }
                catch (Exception p)
                { }
                finally { con.Close(); }

                Clear();
                Response.Redirect(Page.ResolveUrl("~/managesocialpage.aspx? mode=i"));
            }
            else
            {
                Clear();
                spnMessgae.Style.Add("color", "red");
                spnMessgae.InnerText = "Record Not Inserted";

            }

        }

    }
}