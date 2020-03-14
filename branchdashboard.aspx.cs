using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Web.UI.HtmlControls;
using AjaxControlToolkit;
public partial class branchdashboard : System.Web.UI.Page
{
    public static Int64 bankid = 0;
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

 
        AjaxControlToolkit.Slide[] imgSlide = new AjaxControlToolkit.Slide[dtCategory.Rows.Count];
        for (int i = 0; i < dtCategory.Rows.Count; i++)
        {
            string path = "uploads/slider/" + dtCategory.Rows[i]["imagename"].ToString();
            imgSlide[i] = new AjaxControlToolkit.Slide(path, "", "");
        }
        return (imgSlide);
    }
}