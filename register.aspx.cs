using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessLayer;
public partial class register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private void Clear()
    {
        txtaddress.Text = string.Empty;
        txtconfirmedpass.Text = string.Empty;
        txtemailid.Text = string.Empty;
        txtmobileno.Text = string.Empty;
        txtname.Text = string.Empty;
        txtpassword .Text = string.Empty;   

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Int64 Result = 0;
        customermaster objcustomermaster = new customermaster();
        objcustomermaster.customername = txtname.Text;
        objcustomermaster.mobileno = txtmobileno .Text;
        objcustomermaster.emailid = txtemailid .Text;
        objcustomermaster.password = txtpassword.Text;
        objcustomermaster.address = txtaddress.Text;  
       
            Result = (new cls_customermaster_b().Insert(objcustomermaster));
            if (Result > 0)
            {
                Clear();
              ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Account Created ')", true);
               // Response.Redirect(Page.ResolveUrl("~/customerlogin.aspx"));
            }
            else
            {
                Clear();
            ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Account Not Created ')", true);

        }
        
    }

    protected void tbnLogin_Click(object sender, EventArgs e)
    {
        Response.Redirect(Page.ResolveUrl("~/customerlogin.aspx"));

    }
}