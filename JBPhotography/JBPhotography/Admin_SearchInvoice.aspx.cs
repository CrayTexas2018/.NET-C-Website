using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JBPhotography.App_Code;

namespace JBPhotography
{
    public partial class Admin_SearchInvoice : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void searchInvoice(string invoice)
        {
            Response.Redirect("/Admin_OrderDetails.aspx?i=" + invoice);
        }

        protected void InvoiceButton_Click(object sender, EventArgs e)
        {
            searchInvoice(InvoiceTextBox.Text);
        }
    }
}