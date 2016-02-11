using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JBPhotography.App_Code;

namespace JBPhotography
{
    public partial class Checkout_PaymentSuccess : System.Web.UI.Page
    {
        //string cartID = "0";

        protected void Page_Load(object sender, EventArgs e)
        {
            sendAdminEmail();
            sendCustomerEmail();
            disableCart("" + Session["ID"]);
            Session["hasCart"] = "False";
        }

        private void disableCart(string ID)
        {
            DbConn.dBWrite("EXEC DeactivateCart " + ID);
        }

        private string logInvoice()
        {
            string invoiceNumber = "";
            string cartID = "";
            var creader = DbConn.dBRead("EXEC CreateShoppingCart " + Session["ID"]);
            if (creader.Read())
            {
                cartID = "" + creader["Result"];
            }
             var reader = DbConn.dBRead("EXEC CreateInvoice " + cartID);
            if (reader.Read())
            {
                invoiceNumber = "" + reader["InvoiceNumber"];
            }
            return invoiceNumber;
        }

        private void sendAdminEmail()
        {
            int cartID = -1;
            var reader = DbConn.dBRead("CreateShoppingCart " + Session["ID"]);
            if (reader.Read())
            {
                cartID = Convert.ToInt32(reader["Result"]);
            }
                string email = "<table border = 2 width = 500>";
            email += getProducts("" + Session["ID"], 5, true);
            email += getProducts("" + Session["ID"], 3, true);
            email += getProducts("" + Session["ID"], 4, true);
            email += getTotal(cartID);
            email += getPropertyInfo(cartID);
            
            DbConn.dBWrite("EXEC sendAdminPurchaseEmail 'New Customer Order: " + logInvoice() + "','" +  email + "'");
            //Response.Write(email);
        }

        private void sendCustomerEmail()
        {
            int cartID = -1;
            var reader = DbConn.dBRead("CreateShoppingCart " + Session["ID"]);
            if (reader.Read())
            {
                cartID = Convert.ToInt32(reader["Result"]);
            }
            //string email = "<table border = 2 width = 500>";
            string email = "<h4>Thank you for placing an order with James Bruce Photography. Below is a summary of your order and contact information. If any of this needs to be changed, please contact support@JamesBrucePhotography.com </h4> <BR/>";
            email += "<table border = 2 width = 500>";
            email += getProducts("" + Session["ID"], 5, false);
            email += getProducts("" + Session["ID"], 3, false);
            email += getProducts("" + Session["ID"], 4, false);
            email += getTotal(cartID);
            email += getPropertyInfo(cartID);

            DbConn.dBWrite("EXEC sendAdminPurchaseEmail 'New Customer Order: " + logInvoice() + "','" + email + "'");
            //Response.Write(email);
        }

        private string getProducts(string ID, int PID, bool isAdmin)
        {
            //Create html table for email
            string email = "";

            string cartID2 = "";
            var cartreader = DbConn.dBRead("EXEC CreateShoppingCart " + Session["ID"]);
            if (cartreader.Read())
            {
                cartID2 = "" + cartreader["Result"];
            }

            var reader = DbConn.dBRead("Exec getCartItemsForPayment " + ID + ", " + PID + ", " + cartID2);
            var reader2 = DbConn.dBRead("Exec getCartItemsForPayment " + ID + ", " + PID + ", " + cartID2);

            if (reader2.Read())
            {
                TableRow row = new TableRow();
                TableCell cell = new TableCell();
                Label label = new Label();
                email += "<tr bgcolor=#a9a9a9><td>";
                email += "<b>" + reader2["MainProduct"] + "</b>";
                email += "</td></tr>";
            }

            while (reader.Read())
            {
                email += "<tr><td>";
                email += "" + reader["ProductDisplayName"];
                email += "</td>";

                email += "<td>";
                TableCell Pricecell = new TableCell();
                Label Pricelabel = new Label();
                decimal price = decimal.Round(Convert.ToDecimal(reader["Price"]), 2);

                email += price.ToString();
                email += "</tr>";
            }

            if (PID == 5)
            {
                var creader = DbConn.dBRead("EXEC CreateShoppingCart " + Session["ID"]);
                if (creader.Read())
                {
                    int cartID = Convert.ToInt32(creader["Result"]);
                    if (isAdmin == true)
                    {
                        email += getPropertyProducts(cartID);
                    }
                }
            }

            return email;
        }

        private string getPropertyProducts(int cartID)
        {
            string email = "";
            var reader = DbConn.dBRead("EXEC getPropertyProduct " + cartID);
            while (reader.Read())
            {
                email += "<tr><td>";
                email += "" + reader["ProductName"];
                email += "</td>";

                email += "<td>";
                email += "" + decimal.Round(Convert.ToDecimal(reader["Price"]), 2);
                email += "</td></tr>";
            }

            return email;
        }

        private string getTotal(int ID)
        {
            string email = "";
            email += "<tr><td><b>Total: </b></td><td><b>";
            var reader = DbConn.dBRead("EXEC getCartTotal " + ID);

            if (reader.Read())
            {
                decimal total = decimal.Round(Convert.ToDecimal(reader["Total"]), 2);
                email += "" + total;
            }

            email += "</b></td></tr></table>";
            return email;
        }

        ////////////////////////////////
        //Property Info/////////////////

        private string getPropertyInfo(int cartID)
        {
            string email = "<table border = 2>";

            var sReader = DbConn.dBRead("EXEC GetSchedule " + cartID);
            if (sReader.Read())
            {
                email += "<tr><td>";
                email += "<b>Date Scheduled: </b></td>";
                DateTime dateAndTime = Convert.ToDateTime(sReader["Date"]);
                email += "<td>" + dateAndTime.ToString("MM/dd/yyyy") + "</td></tr>";
            }

            List<Label> labelList = new List<Label>();

            var reader = DbConn.dBRead("EXEC GetPropertyInfo " + cartID);
            if (reader.Read())
            {
                email += "<tr><td><b>House Size:</b></td><td> " + reader["HouseSize"] + "</td></tr>";

                email += "<tr><td><b>Lot Size:</b></td><td> " + reader["LotSize"] + "</td></tr>";

                email += "<tr><td><b>Listing Price:</b></td><td> " + reader["ListingPrice"] + "</td></tr>";

                email += "<tr><td><b>House Address:</b></td><td> " + reader["HouseAddress"] + "</td></tr>";

                email += "<tr><td><b>How To Access:</b></td><td> " + reader["HowTo"] + "</td></tr>";

                email += "<tr><td><b>Realtor Name:</b></td><td> " + reader["RealtorName"] + "</td></tr>";

                email += "<tr><td><b>Realtor Phone:</b></td><td> " + reader["RealtorPhone"] + "</td></tr>";

                email += "<tr><td><b>Realtor Company:</b></td><td> " + reader["RealtorCompany"] + "</td></tr>";

                email += "<tr><td><b>Owner Name:</b></td><td> " + reader["OwnerName"] + "</td></tr>";

                email += "<tr><td><b>Owner Phone:</b></td><td> " + reader["OwnerPhone"] + "</td></tr>";

                email += "<tr><td><b>Notes:</b></td><td> " + reader["Notes"] + "</td></tr></table>";
            }
            return email;
        }
    }
}