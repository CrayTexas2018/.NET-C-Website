using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JBPhotography.App_Code;

namespace JBPhotography
{
    public partial class EditProduct : System.Web.UI.Page
    {
        private string PID;
        bool canDelete = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            PID = Convert.ToString(HttpContext.Current.Session["PID"]);
            if (!IsPostBack)
            {
                getProductInfo();
            }

            getAddonProducts(PID);
        }

        private void getProductInfo()
        {
            var reader = DbConn.dBRead("Exec SelectProducts " + PID);

            if (reader.Read())
            {
                ProductIDLabel.Text = "Product ID: " + reader["ID"];
                ProductNameLabel.Text = "Product Name:";
                ProductPriceLabel.Text = "Product Price:";
                ProductDescriptionLabel.Text = "Product Description:";
                ProductActiveLabel.Text = "Product Active:";

                ProductNameTextBox.Text = (string)reader["Display Name"];
                ProductPriceTextBox.Text = "" + reader["Price"];
                ProductDescriptionTextBox.Text = (string)reader["Description"];

                if ((bool)reader["Active"] == true)
                {
                    ProductActiveList.SelectedValue = "1";
                }
                else
                {
                    ProductActiveList.SelectedValue = "0";
                }

            }
        }

        protected void SaveButton_Click(object sender, EventArgs e)
        {
            string pName = ProductNameTextBox.Text;
            string pPrice = ProductPriceTextBox.Text;
            string pDescription = ProductDescriptionTextBox.Text;
            string pActive = ProductActiveList.SelectedValue;

            DbConn.dBWrite("EXEC UpdateProduct " + PID + ", '" + pName + "', " 
                + pPrice + ", '" + pDescription + "', " + pActive);

            Response.Redirect("Admin_Products.aspx");
        }

        protected void DeleteButton_Click(object sender, EventArgs e)
        {
            if (canDelete == true)
            {
                DbConn.dBWrite("Exec DeleteProduct " + PID);
                Response.Redirect("Admin_Products.aspx");
            }
        }

        protected void DeleteCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (DeleteCheckBox.Checked == true)
            {
                canDelete = true;
            }
             else
            {
                canDelete = false;
            }
        }

        private void getAddonProducts(string PID)
        {
            AddonTable.GridLines = GridLines.Both;
            var reader = DbConn.dBRead("EXEC GetAddonProducts " + PID);

            while (reader.Read())
            {
                TableRow row = new TableRow();

                Label productName = new Label();
                Label productDisplayName = new Label();
                Label ProductID = new Label();
                Label productType = new Label();
                Label productActive = new Label();

                productName.Text = Convert.ToString(reader["ProductName"]);
                productDisplayName.Text = Convert.ToString(reader["ProductDisplayName"]);
                ProductID.Text = Convert.ToString(reader["ID"]);
                productType.Text = Convert.ToString(reader["Type"]);
                productActive.Text = Convert.ToString(reader["IsActive"]);

                List<Label> addonProducts = new List<Label>();
                addonProducts.Add(productName);
                addonProducts.Add(productDisplayName);
                addonProducts.Add(ProductID);
                addonProducts.Add(productType);
                addonProducts.Add(productActive);

                foreach (Label p in addonProducts)
                {
                    
                    TableCell cell = new TableCell();
                    cell.Controls.Add(p);
                    row.Controls.Add(cell);
                }

                Button button = new Button();
                button.Text = "Edit Addon";
                button.ID = Convert.ToString(reader["ID"]);
                button.Click += new EventHandler(editCellMethod);
                TableCell buttonCell = new TableCell();
                buttonCell.Controls.Add(button);
                row.Cells.Add(buttonCell);

                AddonTable.Rows.Add(row);
            }
        }

        protected void editCellMethod(object sender, EventArgs e)
        {
            string ID = ((Button)sender).ID;
            HttpContext.Current.Session["AOID"] = ID;
            Response.Redirect("/EditProductAddon.aspx");
        }

        protected void AddAddonButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/AddAddonProduct.aspx");
        }
    }
}