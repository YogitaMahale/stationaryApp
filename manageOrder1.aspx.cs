using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Web;

using System.Web.Script.Serialization;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class manageOrder1 : System.Web.UI.Page
{
    common ocommon = new common();
    Int64 zoneid = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            bindOrders();
            HtmlGenericControl hPageTitle = (HtmlGenericControl)this.Page.Master.FindControl("hPageTitle");
            hPageTitle.InnerText = "Manage Orders";
        }
        if (Request.QueryString["mode"] == "u")
        {
            spnMessage.Visible = true;
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "Orders Updated Successfully";
        }
        else if (Request.QueryString["mode"] == "i")
        {
            spnMessage.Visible = true;
            spnMessage.Style.Add("color", "green");
            spnMessage.InnerText = "Orders Inserted Successfully";
        }
    }

    private void bindOrders()
    {
        DataTable dtproduct = (new cls_order_b().SelectAll());

        if (dtproduct != null)
        {
            if (dtproduct.Rows.Count > 0)
            {
                reporders.DataSource = dtproduct;
                reporders.DataBind();
            }
            else
            {
                reporders.DataSource = null;
                reporders.DataBind();
            }
        }
        else
        {
            reporders.DataSource = null;
            reporders.DataBind();
        }
    }

     

    //protected void repproduct_ItemDataBound(object sender, RepeaterItemEventArgs e)
    //{
    //    if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
    //    {

    //        if (Request.QueryString["Mode"] != null)
    //        {
    //            LinkButton lnkpodnoupdate = (LinkButton)e.Item.FindControl("lnkpodnoupdate");
    //            lnkpodnoupdate.Visible = false;

    //            TextBox txtpodNo = (TextBox)e.Item.FindControl("txtpodNo");
    //            txtpodNo.ReadOnly = true;

    //            if (Request.QueryString["Mode"] == "Bank")
    //            {
    //            }
    //            else if (Request.QueryString["Mode"] == "Branch")
    //            {
    //            }
    //            else
    //            {
    //            }

    //        }
    //        else
    //        {
    //            LinkButton lnkpodnoupdate = (LinkButton)e.Item.FindControl("lnkpodnoupdate");
    //            lnkpodnoupdate.Visible = true;
    //            TextBox txtpodNo = (TextBox)e.Item.FindControl("txtpodNo");
    //            txtpodNo.ReadOnly = false;
    //        }
    //        //lnkpodnoupdate
    //    }
    //}



    



    protected void lnkInvoice_Click(object sender, EventArgs e)
    {
        RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
        Int64 lbloid1 = int.Parse((item.FindControl("lbloid1") as Label).Text);
        //Response.Redirect("orderinvoice.aspx?id="+ lbloid1);

        Response.Redirect("orderinvoice.aspx?id=" + ocommon.Encrypt(lbloid1.ToString(), true));

    }

    protected void lnkpodnoupdate_Click(object sender, EventArgs e)
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
        RepeaterItem item = (sender as LinkButton).Parent as RepeaterItem;
        Int64 orderID = int.Parse((item.FindControl("lbloid1") as Label).Text);
        string podNo = (item.FindControl("txtpodNo") as TextBox).Text;
        string branchemailId = string.Empty, zonalMgrMailid = string.Empty;
        try
        {
            con.Open();
            string s = "update orders set podno='" + podNo + "' where oid=" + orderID + "";
            SqlCommand cmd1 = new SqlCommand(s, con);
            int t = cmd1.ExecuteNonQuery();
            //**************************

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "order_invoice";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@oid", orderID);
            cmd.Connection = con;

            DataSet ds = new DataSet();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(ds);
            if (ds.Tables != null)
            {
                /* Order Details */
                if (ds.Tables[0] != null)
                {
                    if (ds.Tables[0].Rows.Count > 0)
                    {
                        branchemailId = ds.Tables[0].Rows[0]["branchemail"].ToString();
                        zonalMgrMailid = ds.Tables[0].Rows[0]["zonalmgrEmail"].ToString();
                    }
                }

                //-------------------
                spnMessage.Visible = true;
                if (t > 0)
                {
                    SendMail(zonalMgrMailid, branchemailId, podNo);
                    spnMessage.Style.Add("color", "green");
                    spnMessage.InnerText = "POD No. Updated Successfully";


                }
                else
                {
                    spnMessage.Style.Add("color", "green");
                    spnMessage.InnerText = "POD No. Not Updated";
                }
            }
        }

        catch { }
        finally { con.Close(); }
    }
    private bool SendMail(string ZonalmgrMail, string branchMail, string podno)
    {
        common ocommon = new common();
        string oSB = string.Empty;
        bool send = false;
        MailMessage mail = new MailMessage();
        // mail.To.Add("mahaleyogita233@gmail.com");

        // mail.To.Add("ploutos.kiran@gmail.com");
        //  mail.To.Add("all4stationery@gmail.com");
        mail.To.Add("technologiesvsys@gmail.com");
        mail.To.Add("mahaleyogita233@gmail.com");
        if (branchMail.ToString().Trim() == "".Trim())
        {
        }
        else
        {
            mail.To.Add(new MailAddress(branchMail));
        }


        oSB += "<br/>";
        oSB += "<div>Dear Sir/Madam,</div>";
        oSB += "<table>" +
            "<tr><td>The POD No for your order for stationery from ALL STATIONERY is " + podno + "  </td> </tr>" +
            "<tr><td>Delivery timelines - Mumbai - 48 hrs (after next day of order)</td> </tr>" +
               "<tr><td>Other than Mumbai - 72 hrs ( after next day of order).</td> </tr>" +
                  "<tr><td>Regards,</td> </tr>" +
                     "<tr><td>Kiran Patil.</td> </tr>" +
                        "<tr><td>Ploutos Gifts.. for all your promotional needs.</td> </tr>" +
                        "<tr><td>305/306, Bhavehswar Arcade, LBS Marg, Ghatkopar W. Mumbai -400086.</td> </tr>" +
                        "<tr><td>Email - ploutos.kiran@gmail.com</td> </tr>" +
                        "<tr><td>Mobile -9920104157. Landline - 022-25002111.</td> </tr>" +

                "</table>";


        oSB += "<hr/>";
        oSB += "<div>Thank you,</div>";
        oSB += "<div>all-stationery- Support Team.</div>";


        mail.From = new MailAddress("info@all-stationery.com", "Stationery");
        mail.Subject = "POD No";
        mail.Body = oSB.ToString();
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
        smtp.Credentials = new System.Net.NetworkCredential("info@all-stationery.com", "8^75uttA");
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
}