using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JBPhotography.App_Code;

namespace JBPhotography
{
    public partial class EditProductAddon : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            AddonTable.GridLines = GridLines.Both;
            AddonTable.CssClass = "CenterTable";
            getAddons("" + Session["AOID"]);
            if (!IsPostBack)
            {
                getParent("" + Session["AOID"]);
            }
        }

        private void getParent(string AOID)
        {
            var reader = DbConn.dBRead("EXEC GetAddonProductsToEdit " + AOID);

            if (reader.Read())
            {
                ProductIDLabel.Text = "Product ID: " + Convert.ToString(reader["ID"]);
                ProductDisplayNameTextBox.Text = Convert.ToString(reader["ProductDisplayName"]);
                ProductNameTextBox.Text = Convert.ToString(reader["ProductName"]);
                ProductPriceTextBox.Text = Convert.ToString(reader["ProductPrice"]);
                ProductTypeTextbox.Text = Convert.ToString(reader["Type"]);
                ProductActiveTextBox.Text = Convert.ToString(reader["IsActive"]);

                if (ProductActiveTextBox.Text == "False")
                {
                    ProductActiveTextBox.Text = "0";
                }
                else
                {
                    ProductActiveTextBox.Text = "1";
                }


            }
        }

        private void getAddons(string AOID)
        {
            var reader = DbConn.dBRead("EXEC GetAddonProductValues " + AOID + ", 1");

            while (reader.Read())
            {
                TableRow row = new TableRow();

                Label addonID = new Label();
                Label addonName = new Label();
                Label addonDisplayName = new Label();
                Label addonPrice = new Label();
                Label addonOrder = new Label();
                Label addonAcive = new Label();

                addonID.Text = Convert.ToString(reader["ID"]);
                addonID.Enabled = false;
                addonName.Text = Convert.ToString(reader["ProductName"]);
                addonDisplayName.Text = Convert.ToString(reader["DisplayName"]);
                addonPrice.Text = Convert.ToString(reader["Price"]);
                addonOrder.Text = Convert.ToString(reader["DisplayOrder"]);
                addonAcive.Text = Convert.ToString(reader["IsActive"]);

                List<Label> LabelList = new List<Label>();
                LabelList.Add(addonID);
                LabelList.Add(addonName);
                LabelList.Add(addonDisplayName);
                LabelList.Add(addonPrice);
                LabelList.Add(addonOrder);
                LabelList.Add(addonAcive);

                string LabelText = "";

                foreach (Label p in LabelList)
                {
                    TableCell cell = new TableCell();
                    cell.Controls.Add(p);
                    row.Controls.Add(cell);

                    LabelText += p.Text + "|||";
                    ViewState["LabelStrings"] += LabelText;
                }

                Button button = new Button();
                button.Text = "Edit Product";
                button.ID = Convert.ToString(reader["ID"]);
                button.Click += new EventHandler(saveCellMethod);
                TableCell buttonCell = new TableCell();
                buttonCell.Controls.Add(button);
                row.Cells.Add(buttonCell);

                AddonTable.Rows.Add(row);
            }
        }

        protected void saveCellMethod(object sender, EventArgs e)
        {
            string ID = ((Button)sender).ID;
            Session["AOOID"] = ID;
            Response.Redirect("/EditProductAddonOption.aspx");
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            DbConn.dBWrite("EXEC UpdateAddonProduct " + Session["AOID"] + ", '" + ProductNameTextBox.Text + "', '" + ProductDisplayNameTextBox.Text + "', " + ProductPriceTextBox.Text + ", " + ProductTypeTextbox.Text + ", " + ProductActiveTextBox.Text);
            Response.Redirect("/EditProduct.aspx");
        }

        protected void AddButton_Click(object sender, EventArgs e)
        {
            DbConn.dBWrite("EXEC UpdateAddonProduct " + Session["AOID"] + ", '" + ProductNameTextBox.Text + "', '" + ProductDisplayNameTextBox.Text + "', " + ProductPriceTextBox.Text + ", " + ProductTypeTextbox.Text + ", " + ProductActiveTextBox.Text);
            Response.Redirect("/AddProductAddonValue.aspx");
        }
    }
}