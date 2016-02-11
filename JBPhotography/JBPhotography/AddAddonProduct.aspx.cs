using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JBPhotography.App_Code;

namespace JBPhotography
{
    public partial class AddAddonProduct : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            DbConn.dBWrite("EXEC AddAddonProduct '" + ProductNameTextBox.Text + "', '" + ProductDisplayNameTextBox.Text + "', " + ProductPriceTextBox.Text + ", " + Session["PID"] + ", " + ProductTypeTextBox.Text + ", " + ProductActiveTextBox.Text);
            Response.Redirect("/EditProduct.aspx");
        }
    }
}