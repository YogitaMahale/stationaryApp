//using System;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
public partial class websitemaster : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindSlider();
             BindMaincategory();
            //  < h6 id = "lblLoginusername" runat = "server" > HELLO!

            if (Session["WebsiteLogincustomerid"] != null || Session["WebsiteLogincustomerName"] != null)
            {
                lblLoginusername.InnerText = "HELLO! " + Session["WebsiteLogincustomerName"].ToString();
                lblcustomerprofile.Visible = true;
                lblloginbtn.Visible = false;
            }
            else
            {
                lblloginbtn.Visible = true ;
                lblLoginusername.InnerText = "";
                lblcustomerprofile.Visible = false ;
            }
            //--------bing cart-------
            DataTable dt = new DataTable();
            dt = (DataTable)Session["cartdt"];
            repcart1.DataSource = dt;
            repcart1.DataBind();
        }
    }

    // protected void Logout_Click(Object sender, EventArgs e)
    protected void Logout_Click(object sender, EventArgs e)
    {
        Session["WebsiteLogincustomerid"] = null;
        Session["WebsiteLogincustomerName"] = null;

        Response.Redirect(Page.ResolveUrl("~/Default.aspx"));

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
    private void BindMaincategory()
    {
        DataTable dtCompany = (new cls_maincategory_b().SelectAll());
        repmaincategory.DataSource = null;
        repmaincategory.DataBind();
        if (dtCompany != null)
        {
            if (dtCompany.Rows.Count > 0)
            {
                repmaincategory.DataSource = dtCompany;
                repmaincategory.DataBind();
            }
            else
            {
                repmaincategory.DataSource = null;
                repmaincategory.DataBind();
            }
        }
        else
        {
            repmaincategory.DataSource = null;
            repmaincategory.DataBind();
        }
    }

}
