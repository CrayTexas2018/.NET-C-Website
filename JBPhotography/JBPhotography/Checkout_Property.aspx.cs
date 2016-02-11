using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JBPhotography.App_Code;

namespace JBPhotography
{
    public partial class Checkout_Property : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] == null)
            {
                Response.Redirect("Login.aspx?r=/Checkout_Property.aspx");
            }

            setInfo();
            getDescription();
        }

        private void getDescription()
        {
            var reader = DbConn.dBRead("EXEC getDescriptions 4");
            if (reader.Read())
            {
                TopLabel.Text = "" + reader["Description"];
            }
        }

        private void setInfo()
        {
                getRealtorInfo((int)Session["ID"]);
        }

        private void getRealtorInfo(int ID)
        {
            if ("" + Session["FirstName"] != "")
            {
                var reader = DbConn.dBRead("Exec getRealtor " + ID);

                if (reader.Read())
                {
                    //NAME
                    string firstName = (string)reader["FirstName"];
                    string lastName = (string)reader["LastName"];
                    RealtorNameTextBox.Text = firstName + " " + lastName;

                    //Phone
                    RealtorPhoneTextBox.Text = (string)reader["PhoneNumber"];

                    //Company
                    if (reader["Company"] != null)
                    {
                        RealtorCompanyTextBox.Text = (string)reader["Company"];
                    }
                }
            }

            if (!IsPostBack)
            {
                RealtorEmailTextBox.Text = "" + Session["Email"];
            }
        }

        protected void ContinueButton_Click(object sender, EventArgs e)
        {
            if (checkFields())
            {
                //Check to see if guest. If they are, update users to have this email, and set session to be this email.
                if ("" + Session["Email"] == "")
                {
                    Session["Email"] = RealtorEmailTextBox.Text;
                    //Dont want to do this because then they cannot make an account with this email address. Make a new column in table?
                    //DbConn.dBWrite("EXEC UpdateUserEmail " + Session["ID"] + ",'" + RealtorEmailTextBox.Text + "'");
                }

                var reader = DbConn.dBRead("EXEC CreateShoppingCart " + Session["ID"]);
                if (reader.Read())
                {
                    string CID = "" + reader["Result"];
                    DbConn.dBWrite("EXEC AddPropertyInfo " +  CID + ", " + HouseSizeTextBox.Text + ", "
                    + LotSizeTextBox.Text + ", " + ListingPriceTextBox.Text + ", '" + HouseAddressTextBox.Text
                    + "', '" + LockBoxCodeTextBox.Text + "', '" + RealtorNameTextBox.Text + "', '" + RealtorPhoneTextBox.Text
                    + "', '" + RealtorCompanyTextBox.Text + "', '" + HomeOwnerNameTextBox.Text + "', '" + HomeOwnerPhoneTextBox.Text 
                    + "', '" + NoteTextBox.Text + "', '" + RealtorEmailTextBox.Text + "'");
                    var cart = DbConn.dBRead("EXEC CreateShoppingCart " + Session["ID"]);
                    if (cart.Read())
                    {
                        decimal listingFee = 0;
                        var listFeeDb = DbConn.dBRead("Exec GetListingFee " + ListingPriceTextBox.Text);
                        if (listFeeDb.Read())
                        {
                            listingFee = decimal.Round(Convert.ToDecimal(listFeeDb["Price"]), 2);
                        }
                        DbConn.dBWrite("EXEC AddPropertyProduct " + cart["Result"] + ", 'Listing Fee'," + listingFee);

                        decimal sqftFee = 0;
                        var sqftFeeDb = DbConn.dBRead("EXEC getSqftFee " + HouseSizeTextBox.Text);
                        if (sqftFeeDb.Read())
                        {
                            sqftFee = decimal.Round(Convert.ToDecimal(sqftFeeDb["Price"]), 2);
                        }
                        DbConn.dBWrite("EXEC AddPropertyProduct " + cart["Result"] + ", 'Sqare Footage Fee'," + sqftFee);
                    }
                }
                Session["cartView"] = "True";
                DbConn.addGuestTime("" + Session["ID"]);
                Session["hasCart"] = "True";
                Response.Redirect("/Checkout_Payment.aspx");             
            }
        }

        private bool checkFields()
        {
            bool valid = true;
            if (HouseSizeTextBox.Text == "")
            {
                HouseSizeTextBox.BackColor = System.Drawing.Color.LightPink;
                valid = false;
            }

            if (LotSizeTextBox.Text == "")
            {
                LotSizeTextBox.BackColor = System.Drawing.Color.LightPink;
                valid = false;
            }

            if (ListingPriceTextBox.Text == "")
            {
                ListingPriceTextBox.BackColor = System.Drawing.Color.LightPink;
                valid = false;
            }

            if (HouseAddressTextBox.Text == "")
            {
                HouseAddressTextBox.BackColor = System.Drawing.Color.LightPink;
                valid = false;
            }

            if (RealtorNameTextBox.Text == "")
            {
                RealtorNameTextBox.BackColor = System.Drawing.Color.LightPink;
                valid = false;
            }

            if (RealtorPhoneTextBox.Text == "")
            {
                RealtorPhoneTextBox.BackColor = System.Drawing.Color.LightPink;
                valid = false;
            }

            if (RealtorEmailTextBox.Text == "")
            {
                RealtorEmailTextBox.BackColor = System.Drawing.Color.LightPink;
                valid = false;
            }

            if (valid == true)
            {
                return true;
            }
            else
            {
                ErrorLabel.Text = "Please correct the following fields:";
                return false;
            }
        }
    }
}