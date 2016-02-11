using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JBPhotography.App_Code;

namespace JBPhotography.ErrorPages
{
    public partial class GeneralError : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DbConn.dBWrite("EXEC LogError " + ("" + Session["ID"]));
        }
    }
}