﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
public partial class _Default : System.Web.UI.Page
{
    protected int RepeatColumns;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
             BindSlider();
            Bindnewarrivalproduct();
            this.BindDummyItem();

        }
    }
   
    private void Bindnewarrivalproduct()
    {
        DataSet dtCompany = (new cls_product_b().newArrivalSelectAll());

        if (dtCompany.Tables[0] != null)
        {
            if (dtCompany.Tables[0].Rows.Count > 0)
            {
                repnewArrival.DataSource = dtCompany.Tables[0];
                repnewArrival.DataBind();
            }
            else
            {
                repnewArrival.DataSource = null;
                repnewArrival.DataBind();
            }
        }
        else
        {
            repnewArrival.DataSource = null;
            repnewArrival.DataBind();
        }
    }
    private void BindSlider()
    {
        DataTable dtCompany = (new cls_websiteslider_b().SelectAll());
        Repeater_Slider.DataSource = null;
        Repeater_Slider.DataBind();
        if (dtCompany != null)
        {
            if (dtCompany.Rows.Count > 0)
            {
                Repeater_Slider.DataSource = dtCompany;
                Repeater_Slider.DataBind();
            }
            else
            {
                Repeater_Slider.DataSource = null;
                Repeater_Slider.DataBind();
            }
        }
        else
        {
            Repeater_Slider.DataSource = null;
            Repeater_Slider.DataBind();
        }
    }

    private void BindDummyItem()
    {
        DataTable dummy = new DataTable();
        dummy.Columns.Add("ProductId");
        dummy.Columns.Add("Name");
        dummy.Columns.Add("Price");
        dummy.Columns.Add("img");


        int count = dlProducts.RepeatColumns == 0 ? 1 : dlProducts.RepeatColumns;
        for (int i = 0; i < count; i++)
        {
            dummy.Rows.Add();
        }
        dlProducts.DataSource = dummy;
        dlProducts.DataBind();
        this.RepeatColumns = dlProducts.RepeatColumns == 0 ? 1 : dlProducts.RepeatColumns;
    }

    [WebMethod]
    public static string GetProducts(int start, int end)
    {
        System.Threading.Thread.Sleep(100);
        string strConnString = ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString;
        DataSet ds = new DataSet();
        using (SqlConnection con = new SqlConnection(strConnString))
        {
            string query = "SELECT id as ProductId,productname as Name,mrp as Price,'uploads/product/websiteproduct/'+mainimage as img FROM product WHERE isdeleted=0 and (mrp BETWEEN @Start AND @End) OR (@Start = 0 AND @End = 0)";
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Connection = con;
                cmd.Parameters.AddWithValue("@Start", start);
                cmd.Parameters.AddWithValue("@End", end);
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(ds, "Products");
                }
            }
        }
        DataTable dt = new DataTable();
        dt.TableName = "Range";
        using (SqlConnection con = new SqlConnection(strConnString))
        {
            string query = "SELECT MIN(mrp) [Min], MAX(mrp) [Max] FROM product where isdeleted=0 ";
            using (SqlCommand cmd = new SqlCommand(query))
            {
                cmd.Connection = con;
                using (SqlDataAdapter sda = new SqlDataAdapter(cmd))
                {
                    sda.Fill(dt);
                }
            }
        }
        ds.Tables.Add(dt);
        return ds.GetXml();
    }
}