using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request.QueryString["logout"] == "yes")
        {
            AllSessionNull();
        }
    }

    public void Clear()
    {
        txtUserName.Text = string.Empty;
        txtPassword.Text = string.Empty;
        ddlbranchbank.SelectedIndex = 0;
    }

    private void AllSessionNull()
    {
        Session["userid"] = null;
        Session["type"] = null;
        Session["bid"] = null;

    }


    protected void btnLogin_Click(object sender, EventArgs e)
    {

        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["cnstring"].ConnectionString);
        try
        {
            con.Close();
            string query = string.Empty;
            if (txtUserName.Text != string.Empty && txtPassword.Text != string.Empty)
            {

                if (ddlbranchbank.SelectedValue == "bank")
                {
                    query = "select * from zonemaster where  lower(loginname)=lower('" + txtUserName.Text.Trim() + "') and password='" + txtPassword.Text.Trim() + "' and isdeleted=0";
                    SqlCommand cmd = new SqlCommand(query);
                    SqlDataAdapter sda = new SqlDataAdapter();
                    DataTable dtUser = new DataTable();
                    con.Open();
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    sda.Fill(dtUser);
                    if (dtUser != null)
                    {
                        if (dtUser.Rows.Count > 0)
                        {

                            bool Status = Convert.ToBoolean(dtUser.Rows[0]["isactive"]);
                            if (Status)
                            {
                                Session.Timeout = 120;

                                Session["userid"] = dtUser.Rows[0]["id"].ToString();
                                Session["username"] = dtUser.Rows[0]["name"].ToString();
                                Session["type"] = ddlbranchbank.SelectedValue;
                                Session["bid"] = dtUser.Rows[0]["bankid"].ToString();
                                con.Close();
                                Response.Redirect(Page.ResolveUrl("~/bankdashboard.aspx"));
                            }
                            else
                            {
                                ScriptManager.RegisterClientScriptBlock(this, typeof(Page), "", "alert('Your Account Under Admin Observation.Please wait for admin confirmation')", true);
                            }


                        }
                    }

                }
                else
                {
                    query = "select * from branchmaster where  lower(loginname)=lower('" + txtUserName.Text.Trim() + "') and password='" + txtPassword.Text.Trim() + "' and isdeleted=0";
                    SqlCommand cmd = new SqlCommand(query);
                    SqlDataAdapter sda = new SqlDataAdapter();
                    DataTable dtUser = new DataTable();
                    con.Open();
                    cmd.Connection = con;
                    sda.SelectCommand = cmd;
                    sda.Fill(dtUser);
                    if (dtUser != null)
                    {
                        if (dtUser.Rows.Count > 0)
                        {
                            bool Status = Convert.ToBoolean(dtUser.Rows[0]["isactive"]);
                            if (Status)
                            {
                                Session.Timeout = 120;

                                Session["userid"] = Convert.ToString(dtUser.Rows[0]["branchid"]);
                                Session["username"] = dtUser.Rows[0]["name"].ToString();
                                Session["type"] = ddlbranchbank.SelectedValue;
                                Session["bid"] = dtUser.Rows[0]["branchid"].ToString();

                                con.Close();
                                Response.Redirect(Page.ResolveUrl("~/branchdashboard.aspx"));
                            }
                            else
                            {
                                bMsg.InnerText = "Your account under admin observation";
                            }

                        }
                        else
                        {
                            bMsg.InnerText = "Please enter correct user name & password !!!";
                            Clear();
                        }
                    }
                    else
                    {
                        bMsg.InnerText = "Please enter correct user name & password !!!";
                        Clear();
                    }
                }

            }
            else
            {
                bMsg.InnerText = "Please enter user name & password !!!";
            }
        }
        catch (Exception p)
        { }
        finally { con.Close(); }
    }

}