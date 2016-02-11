using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JBPhotography.App_Code;

namespace JBPhotography
{
    public partial class Checkout_Aerial : System.Web.UI.Page
    {
        private List<RadioButtonList> rbList = new List<RadioButtonList>();
        private List<CheckBox> cbList = new List<CheckBox>();

        protected void Page_Load(object sender, EventArgs e)
        {
            getProducts(3);
            ProductTable.CssClass = "CenterMargin";
            getDescription();
        }

        private void getDescription()
        {
            var reader = DbConn.dBRead("EXEC getDescriptions 3");
            if (reader.Read())
            {
                TopLabel.Text = "" + reader["Description"];
            }
        }

        private void getProducts(int product)
        {
            var reader = DbConn.dBRead("EXEC selectProducts " + product);
            DbConn dbconn2 = new DbConn();
            while (reader.Read())
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                Label productLabel = new Label();

                productLabel.Text = (string)reader["Display Name"];
                productLabel.CssClass = "TableHead";
                cell.Controls.Add(productLabel);
                row.Cells.Add(cell);
                ProductTable.Rows.Add(row);

                var addonReader = dbconn2.dBRead2("EXEC getAddonProducts " + product);
                while (addonReader.Read())
                {
                    TableRow headerRow = new TableRow();
                    TableCell headerCell = new TableCell();
                    Label headerLabel = new Label();
                    headerLabel.Text = "" + addonReader["ProductDisplayName"];
                    headerLabel.CssClass = "TableProduct";
                    headerCell.Controls.Add(headerLabel);
                    headerRow.Controls.Add(headerCell);
                    ProductTable.Rows.Add(headerRow);


                    TableRow productRow = new TableRow();
                    TableCell productCell = new TableCell();
                    var addonValueReader = DbConn.dBRead("EXEC getAddonProductValues " + addonReader["ID"]);

                    if ((int)addonReader["Type"] == 1)
                    {
                        //TableCell emptyCell = new TableCell();
                        //productRow.Controls.Add(emptyCell);
                        RadioButtonList radioButtonList = new RadioButtonList();
                        radioButtonList.Attributes.Add("HeaderText", "" + addonReader["ProductDisplayName"]);
                        while (addonValueReader.Read())
                        {
                            ListItem radioItem = new ListItem((string)addonValueReader["DisplayName"], "" + addonValueReader["Price"]);
                            radioButtonList.Items.Add(radioItem);
                            radioButtonList.Attributes.Add("PID", "" + addonReader["ID"]);
                        }
                        productCell.Controls.Add(radioButtonList);
                        rbList.Add(radioButtonList);
                        productRow.Cells.Add(productCell);

                        /*RadioButtonList radioButtonList = new RadioButtonList();
                        radioButtonList.Attributes.Add("HeaderText", "" + addonReader["ProductDisplayName"]);
                        while (addonValueReader.Read())
                        {
                            radioButtonList.Items.Add(new ListItem((string)addonValueReader["DisplayName"], "" + addonValueReader["Price"]));
                            radioButtonList.Attributes.Add("PID", "" + addonReader["ID"]);
                        }
                        productCell.Controls.Add(radioButtonList);
                        rbList.Add(radioButtonList);*/
                    }
                    else if ((int)addonReader["Type"] == 2)
                    {
                        if (addonValueReader.Read())
                        {
                            Label label = new Label();
                            label.CssClass = "CheckboxLabel";
                            CheckBox checkBox = new CheckBox();
                            checkBox.CssClass = "squaredOne";
                            checkBox.Text = " ";
                            label.Text = (string)addonValueReader["DisplayName"];
                            checkBox.InputAttributes.Add("Value", "" + addonValueReader["Price"]);
                            checkBox.InputAttributes.Add("HeaderText", "" + addonReader["ProductDisplayName"]);
                            checkBox.InputAttributes.Add("PID", "" + addonReader["ID"]);
                            productCell.Controls.Add(checkBox);
                            cbList.Add(checkBox);
                            productCell.Controls.Add(label);

                            /*CheckBox checkBox = new CheckBox();
                            checkBox.Text = (string)addonValueReader["DisplayName"];
                            checkBox.InputAttributes.Add("Value", "" + addonValueReader["Price"]);
                            checkBox.InputAttributes.Add("HeaderText", "" + addonReader["ProductDisplayName"]);
                            checkBox.InputAttributes.Add("PID", "" + addonReader["ID"]);
                            productCell.Controls.Add(checkBox);
                            cbList.Add(checkBox);*/
                        }
                    }
                    productRow.Cells.Add(productCell);
                    ProductTable.Rows.Add(productRow);
                }
            }
        }

        private void getSelectedValues()
        {
            var reader = DbConn.dBRead("EXEC CreateShoppingCart " + Session["ID"]);
            string cart = "";
            if (reader.Read())
            {
                cart = "" + reader["Result"];
            }
            if (cart != "")
            {
                foreach (RadioButtonList rb in rbList)
                {
                    if (Convert.ToDouble(rb.SelectedValue) != 0.0 && rb.SelectedItem.Selected)
                    {
                        //Add the product to the cart
                        //Update the cart total\
                        DbConn.dBWrite("EXEC AddItemToCart " + cart + ", " + rb.Attributes["PID"] + ", " + rb.SelectedValue);
                    }
                }

                foreach (CheckBox cb in cbList)
                {
                    if (Convert.ToDouble(cb.InputAttributes["Value"]) != 0.0 && cb.Checked)
                    {
                        DbConn.dBWrite("EXEC AddItemToCart " + cart + ", " + cb.InputAttributes["PID"] + ", " + cb.InputAttributes["Value"]);
                    }
                }
            }
            else
            {
                Response.Redirect("/checkout_Calendar.aspx");
            }
        }

        protected void ContinueButton_Click(object sender, EventArgs e)
        {
            getSelectedValues();
            DbConn.addGuestTime("" + Session["ID"]);
            Response.Redirect("/Checkout_Property.aspx");
        }
    }
}