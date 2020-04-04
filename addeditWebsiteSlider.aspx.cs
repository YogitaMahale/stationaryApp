using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BusinessLayer;
using System.Data;
using System.Drawing.Drawing2D;

public partial class addeditWebsiteSlider : System.Web.UI.Page
{
    int categoryImageFrontWidth = 1919;
    int categoryImageFrontHeight = 1055;
    string categoryMainPath = "~/uploads/websiteslider/";
    string categoryFrontPath = "~/uploads/websiteslider/front/";
    common ocommon = new common();
    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            
            HtmlGenericControl hPageTitle = (HtmlGenericControl)this.Page.Master.FindControl("hPageTitle");
            if (Request.QueryString["id"] != null)
            {
                BindCategory(Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true)));
                btnSave.Text = "Update";
                hPageTitle.InnerText = "Website Update";
                Page.Title = "Website Update";
            }
            else
            {
                hPageTitle.InnerText = "Website Add";
                Page.Title = "Website Add";
                btnSave.Text = "Add";

            }
        }
    }

    private void Clear()
    {
      
        btnImageUpload.Visible = true;
        btnRemove.Visible = false;
        imgCategory.Visible = false;
        ViewState["fileName"] = null;
    }


    public void BindCategory(Int64 CategoryId)
    {
        websiteslider  objcategory = (new cls_websiteslider_b().SelectById(CategoryId));
        if (objcategory != null)
        {
           
            if (!string.IsNullOrEmpty(objcategory.imagename))
            {
                imgCategory.Visible = true;
                ViewState["fileName"] = objcategory.imagename;
                imgCategory.ImageUrl = categoryFrontPath + objcategory.imagename;
                btnImageUpload.Visible = false;
                btnRemove.Visible = true;
            }
            else
            {
                btnImageUpload.Visible = true;
            }
        }
    }

    protected override void Render(HtmlTextWriter writer)
    {
        string validatorOverrideScripts = "<script src=\"" + Page.ResolveUrl("~") + "js/validators.js\" type=\"text/javascript\"></script>";
        this.Page.ClientScript.RegisterStartupScript(this.GetType(), "ValidatorOverrideScripts", validatorOverrideScripts, false);
        base.Render(writer);
    }

    protected void btnImageUpload_Click(object sender, EventArgs e)
    {
        if (fpCategory.HasFile)
        {
            string fileName = Path.GetFileNameWithoutExtension(fpCategory.FileName.Replace(' ', '_')) + DateTime.Now.Ticks.ToString() + Path.GetExtension(fpCategory.FileName);
            fpCategory.SaveAs(MapPath(categoryMainPath + fileName));
            // ocommon.CreateThumbnail1("uploads\\websiteslider\\", categoryImageFrontWidth, categoryImageFrontHeight, "~/Uploads/websiteslider/front/", fileName);

            int width = 1919;
            int height = 1055;
            Stream inp_Stream = fpCategory.PostedFile.InputStream;
            using (var image = System.Drawing.Image.FromStream(inp_Stream))
            {
                Bitmap myImg = new Bitmap(width, height);
                Graphics myImgGraph = Graphics.FromImage(myImg);
                myImgGraph.CompositingQuality = CompositingQuality.HighQuality;
                myImgGraph.SmoothingMode = SmoothingMode.HighQuality;
                myImgGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                var imgRectangle = new Rectangle(0, 0, width, height);
                myImgGraph.DrawImage(image, imgRectangle);
                string ext = string.Empty;
                ext = System.IO.Path.GetExtension(fpCategory.FileName.ToString()).ToLower();
                 
                // Save the file   
                var path = Path.Combine(Server.MapPath("~/uploads/websiteslider/front/"), fileName);
                myImg.Save(path, image.RawFormat);
               
            }


            imgCategory.Visible = true;
            imgCategory.ImageUrl = categoryFrontPath + fileName;
            ViewState["fileName"] = fileName;
            btnRemove.Visible = true;
            btnImageUpload.Visible = false;
        }
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Int64 Result = 0;
        websiteslider objcategory = new websiteslider();

        if (ViewState["fileName"] != null)
        {
            objcategory.imagename = ViewState["fileName"].ToString();
        }
       
        if (Request.QueryString["id"] != null)
        {
            objcategory.id = Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true));
            Result = (new cls_websiteslider_b().Update(objcategory));
            if (Result > 0)
            {
                Clear();
                Response.Redirect(Page.ResolveUrl("~/manageWebsiteSlider.aspx?mode=u"));
            }
            else
            {
                Clear();
                spnMessgae.Style.Add("color", "red");
                spnMessgae.InnerText = "Slider Not Updated";
                BindCategory(Convert.ToInt64(ocommon.Decrypt(Request.QueryString["id"].ToString(), true)));
            }
        }
        else
        {
            Result = (new cls_websiteslider_b().Insert(objcategory));
            if (Result > 0)
            {
                Clear();
                Response.Redirect(Page.ResolveUrl("~/manageWebsiteSlider.aspx?mode=i"));
            }
            else
            {
                Clear();
                spnMessgae.Style.Add("color", "red");
                spnMessgae.InnerText = "Slider Not Inserted";

            }
        }
    }

    protected void btnRemove_Click(object sender, EventArgs e)
    {
        var filePath = Server.MapPath("~/uploads/websiteslider/" + ViewState["fileName"].ToString());
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
        var filePath1 = Server.MapPath("~/uploads/websiteslider/front/" + ViewState["fileName"].ToString());
        if (File.Exists(filePath1))
        {
            File.Delete(filePath1);
        }

        btnImageUpload.Visible = true;
        btnRemove.Visible = false;
        ViewState["fileName"] = string.Empty;
        imgCategory.Visible = false;
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveUrl("~/manageWebsiteSlider.aspx"));
    }
}