using System;
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

    readonly PagedDataSource _pgsource = new PagedDataSource();
    int _firstIndex, _lastIndex;
    private int _pageSize = 8;
    public Int64 maincate = 0;
    private int CurrentPage
    {
        get
        {
            if (ViewState["CurrentPage"] == null)
            {
                return 0;
            }
            return ((int)ViewState["CurrentPage"]);
        }
        set
        {
            ViewState["CurrentPage"] = value;
        }
    }




    SqlDataAdapter dadapter;
    DataSet dset;
    
    //PagedDataSource adsource;
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
   // int pos;
    protected int RepeatColumns;
    protected void Page_Load(object sender, EventArgs e)
    {
        if(!IsPostBack)
        {
           // Bindnewarrivalproduct();
          this.BindDummyItem();
        }
        if (!IsPostBack)
        {
            this.ViewState["vs"] = 0;

            if (Request.QueryString["maincategoryid"] == null)
            {
                maincate = 0;
                BindDataIntoArrivalRepeater(0);
            }
            else
            {
                // string pid = "1";
                string maincategoryid = Request.QueryString["maincategoryid"];
                maincate = Convert.ToInt64(maincategoryid);
                 
                BindDataIntoArrivalRepeater(Convert.ToInt64(maincategoryid));


            }
        }
       
        
        //pos = (int)this.ViewState["vs"];
        //databind();
    }
    
    private void Bindnewarrivalproduct()
    {
        //DataSet dtCompany = (new cls_product_b().newArrivalSelectAll());

        //if (dtCompany.Tables[0] != null)
        //{
        //    if (dtCompany.Tables[0].Rows.Count > 0)
        //    {
        //        repnewArrival.DataSource = dtCompany.Tables[0];
        //        repnewArrival.DataBind();
        //    }
        //    else
        //    {
        //        repnewArrival.DataSource = null;
        //        repnewArrival.DataBind();
        //    }
        //}
        //else
        //{
        //    repnewArrival.DataSource = null;
        //    repnewArrival.DataBind();
        //}
    }
    private void BindDummyItem()
    {
        DataTable dummy = new DataTable();
        dummy.Columns.Add("ProductId");
        dummy.Columns.Add("Name");
        dummy.Columns.Add("Price");
        dummy.Columns.Add("img");
        dummy.Columns.Add("shortdescp");
        
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
        DataSet ds = new DataSet();
        try
        {
            System.Threading.Thread.Sleep(100);
            string strConnString = ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString;
          
            using (SqlConnection con = new SqlConnection(strConnString))
            {
                string query = "SELECT id as ProductId,SUBSTRING(productname, 1, 25)  as Name,mrp as Price,'uploads/product/websiteproduct/'+mainimage as img,SUBSTRING(shortdescp, 1, 50) as shortdescp FROM product WHERE isdeleted=0 and id<50 and (mrp BETWEEN @Start AND @End) OR (@Start = 0 AND @End = 0) ";
            //   string query = "SELECT id as ProductId,SUBSTRING(productname, 1, 25)  as Name,mrp as Price,'uploads/product/websiteproduct/'+mainimage as img,SUBSTRING(shortdescp, 1, 50) as shortdescp FROM product WHERE isdeleted=0 and id=0  ";
                // string query = "SELECT id as ProductId,productname as Name,mrp as Price,'uploads/product/websiteproduct/'+mainimage as img,SUBSTRING(shortdescp, 1, 50) as shortdescp FROM product WHERE isdeleted=0 and id<50 ";
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
                string query = "SELECT MIN(mrp) [Min], MAX(mrp) [Max] FROM product where isdeleted=0  ";
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
            
        }
        catch { }
        finally { }
        return ds.GetXml();

    }

    //public void databind()
    //{
    //    dset = new DataSet();
    //    dset = (new cls_product_b().newArrivalSelectAll());

    //    //dadapter = new SqlDataAdapter("SELECT id as ProductId,productname as Name,mrp as Price,'uploads/product/websiteproduct/'+mainimage as img,SUBSTRING(shortdescp, 1, 50) as shortdescp FROM product WHERE isdeleted=0 ", con);
    //    //dset = new DataSet();
    //    adsource = new PagedDataSource();
    //    //dadapter.Fill(dset);
    //    adsource.DataSource = dset.Tables[0].DefaultView;
    //    adsource.PageSize = 8;
    //    adsource.AllowPaging = true;
    //    adsource.CurrentPageIndex = pos;
    //    btnfirst.Enabled = !adsource.IsFirstPage;
    //    btnprevious.Enabled = !adsource.IsFirstPage;
    //    btnlast.Enabled = !adsource.IsLastPage;
    //    btnnext.Enabled = !adsource.IsLastPage;
    //    repnewArrival.DataSource = adsource;
    //    repnewArrival.DataBind();
    //}

    //protected void btnfirst_Click(object sender, EventArgs e)
    //{
    //    pos = 0;
    //    databind();
    //}

    //protected void btnprevious_Click(object sender, EventArgs e)
    //{
    //    pos = (int)this.ViewState["vs"];
    //    pos -= 1;
    //    this.ViewState["vs"] = pos;
    //    databind();
    //}

    //protected void btnnext_Click(object sender, EventArgs e)
    //{
    //    pos = (int)this.ViewState["vs"];
    //    pos += 1;
    //    this.ViewState["vs"] = pos;
    //    databind();
    //}

    //protected void btnlast_Click(object sender, EventArgs e)
    //{
    //    pos = adsource.PageCount - 1;
    //    databind();
    //}


    protected void Button1_Click(object sender, EventArgs e)
    {

    }



    // Bind PagedDataSource into Repeater
    private void BindDataIntoArrivalRepeater(Int64 maincategoryid)
    {

         var dt = (new cls_product_b().newArrivalSelectAll());
       

        _pgsource.DataSource = dt.Tables[0].DefaultView;
        _pgsource.AllowPaging = true;
        // Number of items to be displayed in the Repeater
        _pgsource.PageSize = _pageSize;
        _pgsource.CurrentPageIndex = CurrentPage;
        // Keep the Total pages in View State
        ViewState["TotalPages"] = _pgsource.PageCount;
        // Example: "Page 1 of 10"
        lblpage.Text = "Page " + (CurrentPage + 1) + " of " + _pgsource.PageCount;
        // Enable First, Last, Previous, Next buttons
        lbPrevious.Enabled = !_pgsource.IsFirstPage;
        lbNext.Enabled = !_pgsource.IsLastPage;
        lbFirst.Enabled = !_pgsource.IsFirstPage;
        lbLast.Enabled = !_pgsource.IsLastPage;

        // Bind data into repeater
        repnewArrival.DataSource = _pgsource;
        repnewArrival.DataBind();

        // Call the function to do paging
        HandlePaging();
    }

    private void HandlePaging()
    {
        var dt = new DataTable();
        dt.Columns.Add("PageIndex"); //Start from 0
        dt.Columns.Add("PageText"); //Start from 1

        _firstIndex = CurrentPage - 5;
        if (CurrentPage > 5)
            _lastIndex = CurrentPage + 5;
        else
            _lastIndex = 10;

        // Check last page is greater than total page then reduced it to total no. of page is last index
        if (_lastIndex > Convert.ToInt32(ViewState["TotalPages"]))
        {
            _lastIndex = Convert.ToInt32(ViewState["TotalPages"]);
            _firstIndex = _lastIndex - 10;
        }

        if (_firstIndex < 0)
            _firstIndex = 0;

        // Now creating page number based on above first and last page index
        for (var i = _firstIndex; i < _lastIndex; i++)
        {
            var dr = dt.NewRow();
            dr[0] = i;
            dr[1] = i + 1;
            dt.Rows.Add(dr);
        }

        rptPaging.DataSource = dt;
        rptPaging.DataBind();
    }

    protected void lbFirst_Click(object sender, EventArgs e)
    {
        CurrentPage = 0;
        BindDataIntoArrivalRepeater(maincate);
    }
    protected void lbLast_Click(object sender, EventArgs e)
    {
        CurrentPage = (Convert.ToInt32(ViewState["TotalPages"]) - 1);
        BindDataIntoArrivalRepeater(maincate);
    }
    protected void lbPrevious_Click(object sender, EventArgs e)
    {
        CurrentPage -= 1;
        BindDataIntoArrivalRepeater(maincate);
    }
    protected void lbNext_Click(object sender, EventArgs e)
    {
        CurrentPage += 1;
        BindDataIntoArrivalRepeater(maincate);
    }

    protected void rptPaging_ItemCommand(object source, DataListCommandEventArgs e)
    {
        if (!e.CommandName.Equals("newPage")) return;
        CurrentPage = Convert.ToInt32(e.CommandArgument.ToString());
        BindDataIntoArrivalRepeater(maincate);
    }

    protected void rptPaging_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        var lnkPage = (LinkButton)e.Item.FindControl("lbPaging");
        if (lnkPage.CommandArgument != CurrentPage.ToString()) return;
        lnkPage.Enabled = false;
        lnkPage.BackColor = System.Drawing.Color.FromName("#00FF00");
    }

    
}