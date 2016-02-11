using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JBPhotography.App_Code;


namespace JBPhotography.AdminPages
{
    public partial class Admin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!AdminInfo.checkCredentials(Convert.ToString(HttpContext.Current.Session["ID"])))
            {
                if (HttpContext.Current.Session["ID"] != null)
                {
                    Response.Redirect("~/default.aspx");
                }
                else
                {
                    Response.Redirect("login.aspx?r=Admin.aspx");
                }
            }
        }
    }
}