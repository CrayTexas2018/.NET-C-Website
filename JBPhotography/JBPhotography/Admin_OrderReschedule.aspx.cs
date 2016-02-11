using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JBPhotography.App_Code;

namespace JBPhotography
{
    public partial class Admin_OrderReschedule : System.Web.UI.Page
    {
        string invoiceNumber;
        protected void Page_Load(object sender, EventArgs e)
        {
            invoiceNumber = Request.QueryString["i"];
        }

        private void changeDate()
        {

        }

        protected void startDateCalendar_DayRender(object sender, DayRenderEventArgs e)
        {
            //if the day is full make it red
            //if james is already working, make it yellow

            if (TwilightCheckbox.Checked)
            {
                float date1 = (e.Day.Date - DateTime.Today.Date).Days;
                date1 -= .41f;
                if (e.Day.Date < DateTime.Today.Date)
                {
                    //e.Day.IsSelectable = false;
                    e.Cell.BackColor = System.Drawing.Color.DarkGray;
                }
                else
                {

                    if (e.Day.Date == DateTime.Today.Date)
                    {
                        //e.Day.IsSelectable = false;
                        e.Cell.Font.Underline = true;
                        e.Cell.Font.Bold = true;
                        //e.Cell.Font.Italic = true;
                    }
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
            else
            {
                float date1 = (e.Day.Date - DateTime.Today.Date).Days;
                date1 -= .41f;
                if (e.Day.Date < DateTime.Today.Date)
                {
                    //e.Day.IsSelectable = false;
                    e.Cell.BackColor = System.Drawing.Color.DarkGray;
                }
                else
                {

                    if (e.Day.Date == DateTime.Today.Date)
                    {
                        //e.Day.IsSelectable = false;
                        e.Cell.Font.Underline = true;
                        e.Cell.Font.Bold = true;
                        //e.Cell.Font.Italic = true;
                    }

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
        }
    }
}