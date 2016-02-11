using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JBPhotography.App_Code;
using Stripe;

namespace JBPhotography
{
    public partial class Checkout_StripePayment : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (hasToken())
                {
                    if (!customerExists())
                    {
                        //create the new customer
                        createCustomer();
                    }
                    chargeCustomer();
                    Response.Redirect("/Checkout_PaymentSuccess.aspx");
                }
            }
            catch
            {
                Response.Write("<Br/><Br/><Br/><Br/><Br/><Br/><Br/><Br/><Br/><Br/><Br/><h1>ERROR! Please try again. If this error persists, please contact James Bruce at support@jamesbrucephotography.com</h1>");
            }
        }

        private bool hasToken()
        {
            string token = "";
            token = "" + Request.Form["stripeToken"];
            if (token!= "")
            {
                return true;
            }
            return false;
        }

        private bool customerExists()
        {
            if (getCustomerID() == "" || getCustomerID() == "Error")
            {
                return false;
            }
            return true;
        }

        private void createCustomer()
        {
            string token = "" + Request.Form["stripeToken"];
            var myCustomer = new StripeCustomerCreateOptions();

            myCustomer.Email = "";
            myCustomer.Description = "";

            //Setting up card
            myCustomer.Source = new StripeSourceOptions()
            {
                TokenId = token
            };

            var customerService = new StripeCustomerService();
            StripeCustomer stripeCustomer = customerService.Create(myCustomer);


            //Add to DB
            DbConn.dBWrite("EXEC CreateStripeID '" + stripeCustomer.Id + "', " + Session["ID"]);
        }

        private string getCustomerID()
        {
            //Get Customer ID
            var reader = DbConn.dBRead("EXEC GetStripeUserID " + Session["ID"]);
            if (reader.Read())
            {
                string id = "";
                id = "" + reader["StripeID"];
                return id;
            }
            return "Error";
        }

        private int getChargeAmount()
        {
            //Make sure to get the real charge
            string total = (string)Session["ChargeTotal"];
            int centTotal = Convert.ToInt32(Convert.ToDecimal(total) * 100);
            return centTotal;
        }

        private void chargeCustomer()
        {
            var myCharge = new StripeChargeCreateOptions();

            //Make sure these have values
            myCharge.Amount = getChargeAmount();
            myCharge.Currency = "usd";

            myCharge.Description = "Need to put invoice number here";

            //Setting up card
            myCharge.Source = new StripeSourceOptions();

            myCharge.CustomerId = getCustomerID();

            var chargeService = new StripeChargeService();
            StripeCharge stripeCharge = chargeService.Create(myCharge);
        }
    }
}