using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace JBPhotography
{
    public partial class Checkout_SelectCalendar : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void DaytimeButton_Click(object sender, EventArgs e)
        {
            Session["isDay"] = "Daytime";
            Response.Redirect("/Checkout_Calendar.aspx");
        }

        protected void TwilightButton_Click(object sender, EventArgs e)
        {
            Session["isDay"] = "Twilight";
            Response.Redirect("/Checkout_Calendar.aspx");
        }
    }
}