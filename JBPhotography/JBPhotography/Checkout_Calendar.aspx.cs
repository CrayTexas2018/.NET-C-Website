using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JBPhotography.App_Code;
using Stripe;
using DDay.iCal;
using DDay.iCal.Serialization;
using DDay.iCal.Serialization.iCalendar;

namespace JBPhotography
{
    public partial class Checkout_Calendar : System.Web.UI.Page
    {
        private int daysAdvance = 1;
        //private bool twilight;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] == null)
            {
                Response.Redirect("Login.aspx?r=/Checkout_Calendar.aspx");
            }
            getDescription();
        }

        private void getDescription()
        {
            var reader = DbConn.dBRead("EXEC getDescriptions 1");
            if (reader.Read())
            {
                TopLabel.Text = "" + reader["Description"];
            }
        }

        protected void DaytimeCalendar_DayRender(object sender, DayRenderEventArgs e)
        {
            float date1 = (e.Day.Date - DateTime.Today.Date).Days;
            date1 -= .41f;
            if (e.Day.Date < DateTime.Today.Date)
            {
                e.Day.IsSelectable = false;
                e.Cell.BackColor = System.Drawing.Color.DarkGray;
            }
            else if (date1 < daysAdvance)
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.DarkGray;
            }
            else
            {
                var reader = DbConn.dBRead("EXEC getDayDateInfo '" + e.Day.Date + "'");
                
                try
                {
                    if (reader.Read())
                    {
                        if ((bool)reader["isActive"] == true)
                        {
                            if ((int)reader["Openings"] > 0)
                            {
                                e.Cell.ForeColor = System.Drawing.Color.Green;
                            }
                            if ((bool)reader["IsJames"] == false)
                            {
                                e.Cell.ForeColor = System.Drawing.Color.Orange;
                            }
                            if ((int)reader["Openings"] <= 0)
                            {
                                e.Cell.ForeColor = System.Drawing.Color.Red;
                                e.Day.IsSelectable = false;
                            }                            
                        }
                        else
                        {
                            e.Day.IsSelectable = false;
                        }
                    }
                }
                catch
                {
                    //e.Cell.BackColor = System.Drawing.Color.Green;
                }
            }
        }

        protected void DaytimeCalendar_SelectionChanged(object sender, EventArgs e)
        {
            System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
            string monthName = mfi.GetMonthName(DaytimeCalendar.SelectedDate.Month).ToString();
            DaySelectedLabel.Text = "You Have Selected: " + DaytimeCalendar.SelectedDate.DayOfWeek.ToString() + ", " + monthName + " " + DaytimeCalendar.SelectedDate.Day.ToString() + ", for a daytime photography appointment.";
            Session["PhotoType"] = "7";
            ContinueButton.Enabled = true;
            //TwilightCalendar.SelectedDates.Clear();
        }

        protected void TwilightCalendar_DayRender(object sender, DayRenderEventArgs e)
        {
            if (e.Day.Date < DateTime.Today.Date)
            {
                e.Day.IsSelectable = false;
                e.Cell.BackColor = System.Drawing.Color.DarkGray;
            }
            else if ((e.Day.Date - DateTime.Today.Date).Days < daysAdvance)
            {
                e.Day.IsSelectable = false;
                e.Cell.ForeColor = System.Drawing.Color.DarkGray;
            }
            else
            {
                var reader = DbConn.dBRead("EXEC getTwilightDateInfo '" + e.Day.Date + "'");

                try
                {
                    if (reader.Read())
                    {
                        if ((bool)reader["isActive"] == true)
                        {
                            if ((int)reader["Openings"] > 0)
                            {
                                e.Cell.ForeColor = System.Drawing.Color.Green;
                            }
                            if ((int)reader["Openings"] <= 0)
                            {
                                e.Cell.ForeColor = System.Drawing.Color.Red;
                                e.Day.IsSelectable = false;
                            }
                        }
                        else
                        {
                            e.Day.IsSelectable = false;
                        }
                    }
                }
                catch
                {
                    //e.Cell.BackColor = System.Drawing.Color.Green;
                }
            }
        }

        protected void TwilightCalendar_SelectionChanged(object sender, EventArgs e)
        {
            System.Globalization.DateTimeFormatInfo mfi = new System.Globalization.DateTimeFormatInfo();
            string monthName = mfi.GetMonthName(TwilightCalendar.SelectedDate.Month).ToString();
            DaySelectedLabel.Text = "You Have Selected: " + TwilightCalendar.SelectedDate.DayOfWeek.ToString() + ", " + monthName + " " + TwilightCalendar.SelectedDate.Day.ToString() + ", for a twilight photography appointment.";
            Session["PhotoType"] = "12";
            ContinueButton.Enabled = true;
            //DaytimeCalendar.SelectedDates.Clear();
            //twilight = true;
        }

        protected void ContinueButton_Click(object sender, EventArgs e)
        {
            var reader = DbConn.dBRead("EXEC CreateShoppingCart " + Session["ID"] + ", 1");
            
            if (reader.Read())
            {
                DateTime date;
                if (DaytimeCalendar.SelectedDate.Date != null && "" + Session["PhotoType"] == "7")
                {
                    date = DaytimeCalendar.SelectedDate.Date;
                }
                else
                {
                    date = TwilightCalendar.SelectedDate.Date;
                }
                
                if (DaytimeCalendar.SelectedDate.Date != null && "" + Session["PhotoType"] == "7")
                {
                    DbConn.dBWrite("EXEC AddSchedule " + Session["ID"] + ", " + reader["Result"] + ", '" + date + "'");
                    if ("" + Session["Email"] != "")
                    {
                        DbConn.dBWrite("EXEC AddTempSchedule '" + DaytimeCalendar.SelectedDate.Date + "', 0, " + Session["ID"]);
                    }
                    else
                    {
                        DbConn.dBWrite("EXEC AddTempSchedule '" + DaytimeCalendar.SelectedDate.Date + "', 1, " + Session["ID"]);
                    }
                }
                else
                {
                    //Must be a twilight shoot
                    DbConn.dBWrite("EXEC AddSchedule " + Session["ID"] + ", " + reader["Result"] + ", '" + date + "', 1");
                    if ("" + Session["Email"] != "")
                    {
                        DbConn.dBWrite("EXEC AddTempScheduleTwilight '" + TwilightCalendar.SelectedDate.Date + "' 0, " + Session["ID"]);
                    }
                    else
                    {
                        DbConn.dBWrite("EXEC AddTempScheduleTwilight '" + TwilightCalendar.SelectedDate.Date + "', 1, " + Session["ID"]);
                    }
                }
                decimal price = 0;
                var reader2 = DbConn.dBRead("Select productprice from addonproducts where ID = " + Session["PhotoType"]);
                if (reader2.Read())
                {
                    price = decimal.Round(Convert.ToDecimal(reader2["ProductPrice"]),2);
                }
                DbConn.dBWrite("EXEC AddItemToCart " + reader["Result"] + "," + Session["PhotoType"] + ", " + price);
                Response.Redirect("/checkout_RealEstate.aspx");
            }
            
        }
    }
}