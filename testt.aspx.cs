using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

public partial class testt : System.Web.UI.Page
{
    SqlDataAdapter dadapter;
    DataSet dset;
    PagedDataSource adsource;
    SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
    
    int pos;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            this.ViewState["vs"] = 0;
        }
        pos = (int)this.ViewState["vs"];
        databind();
    }
    public void databind()
    {
        dadapter = new SqlDataAdapter("select id,productname,mainimage,mrp from product", con);
        dset = new DataSet();
        adsource = new PagedDataSource();
        dadapter.Fill(dset);
        adsource.DataSource = dset.Tables[0].DefaultView;
        adsource.PageSize = 100;
        adsource.AllowPaging = true;
        adsource.CurrentPageIndex = pos;
        btnfirst.Enabled = !adsource.IsFirstPage;
        btnprevious.Enabled = !adsource.IsFirstPage;
        btnlast.Enabled = !adsource.IsLastPage;
        btnnext.Enabled = !adsource.IsLastPage;
        DataList1.DataSource = adsource;
        DataList1.DataBind();
    }

    protected void btnfirst_Click(object sender, EventArgs e)
    {
        pos = 0;
        databind();
    }

    protected void btnprevious_Click(object sender, EventArgs e)
    {
        pos = (int)this.ViewState["vs"];
        pos -= 1;
        this.ViewState["vs"] = pos;
        databind();
    }

    protected void btnnext_Click(object sender, EventArgs e)
    {
        pos = (int)this.ViewState["vs"];
        pos += 1;
        this.ViewState["vs"] = pos;
        databind();
    }

    protected void btnlast_Click(object sender, EventArgs e)
    {
        pos = adsource.PageCount - 1;
        databind();
    }
 
}
 