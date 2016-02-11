using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using JBPhotography.App_Code;

namespace JBPhotography
{
    public partial class MainTemplate : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            checkHttps();
            getCartInfo();
        }

        private void checkHttps()
        {
            if (HttpContext.Current.Request.IsSecureConnection.Equals(false) && HttpContext.Current.Request.IsLocal.Equals(false))
            {
                Response.Redirect("https://" + Request.ServerVariables["HTTP_HOST"]
                + HttpContext.Current.Request.RawUrl);
            }
        }

        protected void LogoutButton_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            System.Diagnostics.Debug.WriteLine("clicked");
            Response.Redirect("~/default.aspx");
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            string currURL = HttpContext.Current.Request.Url.AbsolutePath;
            currURL = currURL.Replace("/", "");
            Response.Redirect("login.aspx?r=" + currURL);
        }

        private void getCartInfo()
        {
            DbConn.dBWrite("EXEC CreateShoppingCart " + Session["ID"]);
            CartLabel.Text = "View My Cart";
        }
    }
}