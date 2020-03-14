using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Web.UI.HtmlControls;

public partial class bankdashboard : System.Web.UI.Page
{

    public static Int64 bankid = 0;
    public  DataTable  Bindslider()
    {
          bankid = Convert.ToInt64(Session["bankid"].ToString());
        DataTable dtCategory = (new Cls_slider_b().slider_SelectAllbybankid(bankid));
        return dtCategory;
        //if (dtCategory != null)
        //{
        //    if (dtCategory.Rows.Count > 0)
        //    {
        //        repslider.DataSource = dtCategory;
        //        repslider.DataBind();
        //    }
        //    else
        //    {
        //        repslider.DataSource = null;
        //        repslider.DataBind();
        //    }
        //}
        //else
        //{
        //    repslider.DataSource = null;
        //    repslider.DataBind();
        //}
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            bankid = Convert.ToInt64(Session["bankid"].ToString());
           // Bindslider();
            //HtmlGenericControl hPageTitle = (HtmlGenericControl)this.Page.Master.FindControl("hPageTitle");
            //hPageTitle.InnerText = "Manage Slider";
        }

    }
    [System.Web.Services.WebMethod]
    //[System.Web.Script.Services.ScriptMethod]
    public static AjaxControlToolkit.Slide[] GetSlides()
    {        
       
        DataTable dtCategory = (new Cls_slider_b().slider_SelectAllbybankid(bankid));


        // AjaxControlToolkit.Slide[] imgSlide = new AjaxControlToolkit.Slide[4];

        //imgSlide[0] = new AjaxControlToolkit.Slide("img/1.jpg", "Autumn", "Autumn Leaves");
        //imgSlide[1] = new AjaxControlToolkit.Slide("img/2.jpg", "Creek", "Creek");
        //imgSlide[2] = new AjaxControlToolkit.Slide("img/3.jpg", "Landscape", "Landscape");
        //imgSlide[3] = new AjaxControlToolkit.Slide("img/4.jpg", "Dock", "Dock");


        // return (imgSlide);

        AjaxControlToolkit.Slide[] imgSlide = new AjaxControlToolkit.Slide[dtCategory.Rows.Count];
        for(int  i=0;i<dtCategory.Rows.Count;i++)
        {
            string path = "uploads/slider/" + dtCategory.Rows[i]["imagename"].ToString();
            imgSlide[i] = new AjaxControlToolkit.Slide(path, "", "");
        }
        return (imgSlide);
    }
}