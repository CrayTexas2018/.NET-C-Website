using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JBPhotography.App_Code;

namespace JBPhotography
{
    public partial class EditProductAddonOption : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                getOption((string)Session["AOOID"]);
            }

            TableCell cell = new TableCell();
            Button button = new Button();
            button.ID = "SaveButton";
            button.Text = "Update Option";
            button.Click += new EventHandler(saveChanges);

            cell.Controls.Add(button);
            Row.Controls.Add(cell);
        }

        private void getOption(string ID)
        {
            var reader = DbConn.dBRead("Exec getAddonValue " + ID);

            if (reader.Read())
            {
                string productID = ID;
                string productName = Convert.ToString(reader["ProductName"]);
                string displayName = Convert.ToString(reader["DisplayName"]);
                string price = Convert.ToString(reader["Price"]);
                string displayorder = Convert.ToString(reader["DisplayOrder"]);
                string isActive = Convert.ToString(reader["IsActive"]);

                ProductIDLabel.Text = productID;
                ProductNameTextBox.Text = productName;
                ProductDisplayNameTextBox.Text = displayName;
                ProductPriceTextBox.Text = price;
                ProductOrderTextBox.Text = displayorder;
                if (isActive == "False")
                {
                    ProductActiveTextBox.Text = "0";
                }
                else
                {
                    ProductActiveTextBox.Text = "1";
                }                
            }
        }

        private void saveChanges(object sender, EventArgs e)
        {
            DbConn.dBWrite("EXEC UpdateAddonValue " + ProductIDLabel.Text + ", '" + ProductNameTextBox.Text + "', '" + ProductDisplayNameTextBox.Text + "', " + ProductPriceTextBox.Text + ", " + ProductOrderTextBox.Text + ", " + ProductActiveTextBox.Text);
            Response.Redirect("/EditProductAddon.aspx");
        }
    }
}