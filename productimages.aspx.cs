using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class productimages : System.Web.UI.Page
{
    common ocommon = new common();
    int productImageFrontWidth = 1000;
    int productImageFrontHeight = 900;
    string productMainPath = "~/uploads/product/";
    string productFrontPath = "~/uploads/product/front/";
   // string productWaterFrontPath = "~/uploads/product/water/";


    Int64 pid = 0;
    string productname = string.Empty;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            if (Request.QueryString["productname"] !=null)
            {
                productname = Request.QueryString["productname"].ToString();
            }
                BindProductImages();
            HtmlGenericControl hPageTitle = (HtmlGenericControl)this.Page.Master.FindControl("hPageTitle");
            hPageTitle.InnerText = "Manage Images For '" + productname+"'";
        }

        if (Request.QueryString["mode"] == "u")
        {
            spnMessage.Visible = true;
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "Information Updated Successfully!!!";
        }
        else if (Request.QueryString["mode"] == "i")
        {
            spnMessage.Visible = true;
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "Information Saved Successfully!!!";
        }
    }

    private void BindProductImages()
    {
        if (Request.QueryString["pid"] != null)
        {
            pid = Convert.ToInt64(ocommon.Decrypt(Request.QueryString["pid"].ToString(), true));
        }
        DataTable dtproductimages = (new Cls_productimage_b().SelectAllByProductId(pid));
        if (dtproductimages != null)
        {
            if (dtproductimages.Rows.Count > 0)
            {
                repCategory.DataSource = dtproductimages;
                repCategory.DataBind();
            }
            else
            {
                repCategory.DataSource = null;
                repCategory.DataBind();
            }
        }
        else
        {
            repCategory.DataSource = null;
            repCategory.DataBind();
        }
    }

    protected void repCategory_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            //HyperLink hlEdit = (HyperLink)e.Item.FindControl("hlEdit");
            //hlEdit.NavigateUrl = Page.ResolveUrl("~/addeditbrand.aspx?id=" + ocommon.Encrypt(DataBinder.Eval(e.Item.DataItem, "id").ToString(), true));
            System.Web.UI.WebControls.Image imgCategory = (System.Web.UI.WebControls.Image)e.Item.FindControl("imgCategory");
            imgCategory.ImageUrl = productFrontPath + DataBinder.Eval(e.Item.DataItem, "imagename").ToString();

        }
    }


    protected void lnkDelete_Click(object sender, EventArgs e)
    {
        RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
        spnMessage.Visible = true;
        string imagename = (item.FindControl("lblimagename") as Label).Text;
        Int64 id = int.Parse((item.FindControl("lblid") as Label).Text);
        bool yes = (new Cls_productimage_b().Delete(id));
        if (yes)
        {
            removeImage(imagename);
            BindProductImages();
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "Image Deleted Successfully!!!";
        }
        else
        {
            spnMessage.Style.Add("color", "red");
            spnMessage.InnerText = "Failed To Delete Image...";
        }


    }

    //protected void btnNewBrand_Click(object sender, EventArgs e)
    //{
    //    Response.Redirect(Page.ResolveUrl("~/addeditbrand.aspx"));
    //}


    protected void btnImageUpload_Click(object sender, EventArgs e)
    {
        if (fpProduct.HasFile)
        {

            decimal size = Math.Round(((decimal)fpProduct.PostedFile.ContentLength / (decimal)1024), 2);
            if (size <= 2000)
            {
                string fileName = Path.GetFileNameWithoutExtension(fpProduct.FileName.Replace(' ', '_')) + DateTime.Now.Ticks.ToString() + Path.GetExtension(fpProduct.FileName);
                fpProduct.SaveAs(MapPath(productMainPath + fileName));
               //  ocommon.CreateThumbnail1("uploads\\product\\", productImageFrontWidth, productImageFrontHeight, "~/uploads/product/front/", fileName);

                //------front website product-----------------------
                int width = 700;
                int height = 710;
                Stream inp_Stream = fpProduct.PostedFile.InputStream;
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
                    ext = System.IO.Path.GetExtension(fpProduct.FileName.ToString()).ToLower();

                    // Save the file   
                    var path = Path.Combine(Server.MapPath("~/uploads/product/front/"), fileName);
                    myImg.Save(path, image.RawFormat);

                }











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

    private void removeImage(string filename) {

        var filePath = Server.MapPath("~/uploads/product/" + filename);
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
        }
        var filePath1 = Server.MapPath("~/uploads/product/water/" + filename);
        if (File.Exists(filePath1))
        {
            File.Delete(filePath1);
        }

        var filePath2 = Server.MapPath("~/uploads/product/front/" + filename);
        if (File.Exists(filePath2))
        {
            File.Delete(filePath2);
        }

        btnImageUpload.Visible = true;
        btnRemove.Visible = false;
        ViewState["fileName"] = string.Empty;
        imgProduct.Visible = false;

    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Int64 Result = 0;
        productimage objproduct = new productimage();


        if (ViewState["fileName"] != null)
        {
            objproduct.Imagename = ViewState["fileName"].ToString();
        }
        if (Request.QueryString["pid"] != null)
        {
            objproduct.Pid = Convert.ToInt64(ocommon.Decrypt(Request.QueryString["pid"].ToString(), true));
            //objproduct.Pid = 1;
            Result = (new Cls_productimage_b().Insert(objproduct));
            if (Result > 0)
            {
                Clear();
                spnMessage.Visible = true;
                spnMessage.Style.Add("color", "green");
                spnMessage.InnerText = "Image saved successfully !!!";
                BindProductImages();
                //Response.Redirect(Page.ResolveUrl("~/manageproduct.aspx?mode=u&catid=" + objproduct.cid.ToString()));
            }
            else
            {
                Clear();
                spnMessage.Style.Add("color", "red");
                spnMessage.InnerText = "Failed to save image...";
                BindProductImages();
            }
        }
        else
        {
            Clear();
            spnMessage.Style.Add("color", "red");
            spnMessage.InnerText = "Failed to save image...";
            BindProductImages();
        }
    }

    private void Clear()
    {
        btnImageUpload.Visible = true;
        btnRemove.Visible = false;
        ViewState["fileName"] = string.Empty;
        imgProduct.Visible = false;

    }

}