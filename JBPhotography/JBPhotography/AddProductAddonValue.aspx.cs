using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JBPhotography.App_Code;

namespace JBPhotography
{
    public partial class AddProductAddonValue : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void addProduct()
        {
            var reader = DbConn.dBWrite("EXEC AddProductAddonValue '" + ProductNameTextBox.Text + "', '" + ProductDisplayNameTextBox.Text + "', " + ProductPriceTextBox.Text + ", " + ProductOrderTextBox.Text + ", " + ProductIsActive.Text + ", " + Session["AOID"]);
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            addProduct();
            Response.Redirect("/EditProduct.aspx");
        }
    }
}