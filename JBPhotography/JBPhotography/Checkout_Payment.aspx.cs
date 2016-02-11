using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JBPhotography.App_Code;

namespace JBPhotography
{
    public partial class Checkout_Payment : System.Web.UI.Page
    {

        int cartID = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            cartID = 0;
            var reader = DbConn.dBRead("EXEC CreateShoppingCart " + Session["ID"]);
            try
            {
                if (reader.Read())
                {
                    cartID = Convert.ToInt32(reader["Result"]);
                }
            }
            catch
            {
                Response.Redirect("~/Defualt.aspx");
            }

            //  MAKE SURE TO REPLACE 1 WITH SESSION["ID"]
            // MAKE SURE TO RUN THROUGH LIST TO GET ALL PRODUCTS AND NOT HARD CODE
            getProducts("" + Session["ID"], 5);
            getProducts("" + Session["ID"], 3);
            getProducts("" + Session["ID"], 4);
            getTotal(cartID);
            ProductTable.GridLines = GridLines.Both;
            getPropertyInfo(cartID);
            PropertyTable.GridLines = GridLines.Both;
            
            
        }

        private void getProducts(string ID, int PID)
        {
            var reader = DbConn.dBRead("Exec getCartItemsForPayment " + ID + ", " + PID + ", " + cartID);
            var reader2 = DbConn.dBRead("Exec getCartItemsForPayment " + ID + ", " + PID + ", " + cartID);

            if (reader2.Read())
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                Label label = new Label();

                label.Text = "" + reader2["MainProduct"];
                label.Font.Bold = true;
                cell.Controls.Add(label);
                row.Controls.Add(cell);
                ProductTable.Rows.Add(row);
                
            }

            while (reader.Read())
            {
                TableRow row = new TableRow();
                TableCell Namecell = new TableCell();
                Label Namelabel = new Label();
                Namelabel.Text = "" + reader["ProductDisplayName"];
                Namecell.Controls.Add(Namelabel);
                row.Controls.Add(Namecell);

                TableCell Pricecell = new TableCell();
                Label Pricelabel = new Label();
                decimal price = decimal.Round(Convert.ToDecimal(reader["Price"]),2);

                Pricelabel.Text = price.ToString(); 
                Pricecell.Controls.Add(Pricelabel);
                Pricecell.CssClass = "AlignMoney";
                row.Controls.Add(Pricecell);

                if ("" + reader["ProductID"] != "7" && "" + reader["ProductID"] != "12")
                {
                    TableCell deleteCell = new TableCell();
                    Button deleteButotn = new Button();
                    deleteButotn.ID = "" + reader["ProductID"];
                    deleteButotn.Text = "Remove";
                    deleteButotn.Click += new EventHandler(deleteButton_Click);
                    deleteCell.Controls.Add(deleteButotn);
                    row.Controls.Add(deleteCell);
                }

                ProductTable.Rows.Add(row);
            }

            if (PID == 5)
            {
                var creader = DbConn.dBRead("EXEC CreateShoppingCart " + Session["ID"]);
                if (creader.Read())
                {
                    int cartID = Convert.ToInt32(creader["Result"]);
                    getPropertyProducts(cartID);
                }
            }

            
        }

        protected void deleteButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            var reader = DbConn.dBRead("EXEC CreateShoppingCart " + Session["ID"]);
            if (reader.Read())
            {
                string cartID = "" + reader["Result"];
                DbConn.dBWrite("EXEC removeItemFromCart " + cartID + "," + button.ID);
            }
            Response.Redirect(Request.RawUrl);
            
        }

        public void getTotal(int ID)
        {
            var reader = DbConn.dBRead("EXEC getCartTotal " + ID);

            if (reader.Read())
            {
                decimal total = decimal.Round(Convert.ToDecimal(reader["Total"]),2);
                decimal newTotal = total * 100;
                Session["ChargeTotal"] = "" + total;
                Session["ChargeTotalCents"] = "" + newTotal;
                TableRow totalRow = new TableRow();
                TableCell totalCell = new TableCell();
                Label totalLabel = new Label();
                totalLabel.Text = "" + total;
                totalLabel.ForeColor = System.Drawing.Color.White;
                totalCell.BackColor = System.Drawing.Color.DarkGray;
                totalCell.Controls.Add(totalLabel);


                TableCell totalPriceCell = new TableCell();
                Label total2 = new Label();
                total2.Text = "Total: ";
                total2.ForeColor = System.Drawing.Color.White;
                totalPriceCell.BackColor = System.Drawing.Color.DarkGray;
                totalPriceCell.Controls.Add(total2);

                totalRow.Controls.Add(totalPriceCell);
                totalRow.Controls.Add(totalCell);
                
                ProductTable.Controls.Add(totalRow);
            }
        }

        private void getPropertyProducts(int cartID)
        {
            var reader = DbConn.dBRead("EXEC getPropertyProduct " + cartID);
            while (reader.Read())
            {
                if (decimal.Round(Convert.ToDecimal(reader["Price"]), 2) != 0)
                {
                    TableRow row = new TableRow();
                    TableCell nameCell = new TableCell();
                    Label productName = new Label();
                    nameCell.Controls.Add(productName);

                    productName.Text = "" + reader["ProductName"];

                    TableCell priceCell = new TableCell();
                    Label productPrice = new Label();
                    productPrice.Text = "" + decimal.Round(Convert.ToDecimal(reader["Price"]), 2);
                    priceCell.CssClass = "AlignMoney";
                    priceCell.Controls.Add(productPrice);

                    row.Controls.Add(nameCell);
                    row.Controls.Add(priceCell);
                    ProductTable.Controls.Add(row);
                }
            }
        }

        private void getPropertyInfo(int cartID)
        {
            var sReader = DbConn.dBRead("EXEC GetSchedule " + cartID);
            if (sReader.Read())
            {
                TableRow dateRow = new TableRow();
                TableCell dateCell = new TableCell();
                TableCell dateLabelCell = new TableCell();
                Label dateLabel = new Label();
                dateLabel.Text = "<b>Date Scheduled </b>";
                dateCell.Controls.Add(dateLabel);
                dateRow.Controls.Add(dateCell);


                TableCell dateCellInfo = new TableCell();
                TableCell dateLabelCellInfo = new TableCell();
                Label dateLabelInfo = new Label();
                DateTime dateAndTime = Convert.ToDateTime(sReader["Date"]);
                dateLabelInfo.Text = "" + dateAndTime.ToString("MM/dd/yyyy");
                dateCellInfo.Controls.Add(dateLabelInfo);
                dateRow.Controls.Add(dateCellInfo);
                PropertyTable.Controls.Add(dateRow);
            }

            List<Label> labelList = new List<Label>();

            var reader = DbConn.dBRead("EXEC GetPropertyInfo " + cartID);
            if (reader.Read())
            {
                Label HouseSizeLabel = new Label();
                HouseSizeLabel.Text = "<b>House Size:</b> " + reader["HouseSize"];
                labelList.Add(HouseSizeLabel);

                Label LotSizeLabel = new Label();
                LotSizeLabel.Text = "<b>Lot Size:</b> " + reader["LotSize"];
                labelList.Add(LotSizeLabel);

                Label ListingPriceLabel = new Label();
                ListingPriceLabel.Text = "<b>Listing Price:</b> " + reader["ListingPrice"];
                labelList.Add(ListingPriceLabel);

                Label HouseAddressLabel = new Label();
                HouseAddressLabel.Text = "<b>House Address:</b> " + reader["HouseAddress"];
                labelList.Add(HouseAddressLabel);

                Label HowToLabel = new Label();
                HowToLabel.Text = "<b>How To Access:</b> " + reader["HowTo"];
                labelList.Add(HowToLabel);

                Label RealtorNameLabel = new Label();
                RealtorNameLabel.Text = "<b>Realtor Name:</b> " + reader["RealtorName"];
                labelList.Add(RealtorNameLabel);

                Label RealtorPhoneLabel = new Label();
                RealtorPhoneLabel.Text = "<b>Realtor Phone:</b> " + reader["RealtorPhone"];
                labelList.Add(RealtorPhoneLabel);

                Label RealtorCompanyLabel = new Label();
                RealtorCompanyLabel.Text = "<b>Realtor Company:</b> " + reader["RealtorCompany"];
                labelList.Add(RealtorCompanyLabel);

                Label OwnerNameLabel = new Label();
                OwnerNameLabel.Text = "<b>Owner Name:</b> " + reader["OwnerName"];
                labelList.Add(OwnerNameLabel);

                Label OwnerPhoneLabel = new Label();
                OwnerPhoneLabel.Text = "<b>Owner Phone:</b> " + reader["OwnerPhone"];
                labelList.Add(OwnerPhoneLabel);

                Label NotesLabel = new Label();
                NotesLabel.Text = "<b>Notes:</b> " + reader["Notes"];
                labelList.Add(NotesLabel);

                foreach (Label label in labelList)
                {
                    TableRow row = new TableRow();

                    string[] words = label.Text.Split(':');
                    TableCell metaCell = new TableCell();
                    Label metaLabel = new Label();
                    metaLabel.Text = words[0];
                    metaCell.Controls.Add(metaLabel);
                    row.Controls.Add(metaCell);
                    
                    TableCell cell = new TableCell();
                    Label infoLabel = new Label();
                    infoLabel.Text = words[1];

                    cell.Controls.Add(infoLabel);
                    row.Controls.Add(cell);
                    PropertyTable.Controls.Add(row);
                }
            }
        }

        protected void ContinuePaymentButton_Click1(object sender, EventArgs e)
        {
            if (ConfirmCheckBox.Checked)
            {
                DbConn.addGuestTime("" + Session["ID"]);
                Response.Redirect("/Checkout_StripePayment.aspx");
            }
            else
            {
                ConfirmLabel.BackColor = System.Drawing.Color.LightPink;
            }
        }
    }
}