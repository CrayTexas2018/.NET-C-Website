using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JBPhotography.App_Code;

namespace JBPhotography
{
    public partial class Admin_Orders : System.Web.UI.Page
    {
        bool twilight = false;
        protected void Page_Load(object sender, EventArgs e)
        {
            checkBlank();
        }

        private void checkBlank()
        {
            if (startTextBox.Text == "")
            {
                startTextBox.Text = "" + DateTime.Now.Date.ToString("MM/dd/yyyy");
            }
            if (endTextBox.Text == "")
            {
                endTextBox.Text = "" + DateTime.Now.Date.ToString("MM/dd/yyyy");
            }
        }

        protected void startDateCalendar_SelectionChanged(object sender, EventArgs e)
        {
            startTextBox.Text = "" + startDateCalendar.SelectedDate.Date.ToString("MM/dd/yyyy");
        }

        protected void endDateCalendar_SelectionChanged(object sender, EventArgs e)
        {
            endTextBox.Text = "" + endDateCalendar.SelectedDate.Date.ToString("MM/dd/yyyy");
        }

        private void getOrders()
        {
            

            var reader = DbConn.dBRead("EXEC getOrders '" + startTextBox.Text + "', '" + endTextBox.Text + "'");
            int i = 0;

            TableHeaderRow headRow = new TableHeaderRow();

            TableHeaderCell headInvoice = new TableHeaderCell();
            headInvoice.Text = "Invoice";
            headRow.Controls.Add(headInvoice);

            TableHeaderCell headName = new TableHeaderCell();
            headName.Text = "Name";
            headRow.Controls.Add(headName);

            TableHeaderCell headEmail = new TableHeaderCell();
            headEmail.Text = "Email";
            headRow.Controls.Add(headEmail);

            TableHeaderCell headPhone = new TableHeaderCell();
            headPhone.Text = "Phone Number";
            headRow.Controls.Add(headPhone);

            TableHeaderCell headComnpany = new TableHeaderCell();
            headComnpany.Text = "Company Name";
            headRow.Controls.Add(headComnpany);

            TableHeaderCell headTotal = new TableHeaderCell();
            headTotal.Text = "Order Total";
            headRow.Controls.Add(headTotal);

            TableHeaderCell headCreated = new TableHeaderCell();
            headCreated.Text = "Schedule Date";
            headRow.Controls.Add(headCreated);

            OrderTable.Controls.Add(headRow);

            while (reader.Read())
            {               
  
                TableRow row = new TableRow();
                if (i % 2 == 0)
                {
                    row.BackColor = System.Drawing.Color.LightGray;
                }

                i++;

                TableCell InvoiceCell = new TableCell();
                HyperLink link = new HyperLink();
                link.NavigateUrl = "admin_orderdetails.aspx?I=" + reader["InvoiceNumber"];
                link.Text = "" + reader["InvoiceNumber"];
                link.ForeColor = System.Drawing.Color.Blue;
                InvoiceCell.Controls.Add(link);
                row.Controls.Add(InvoiceCell);

                TableCell NameCell = new TableCell();
                NameCell.Text = "" + reader["RealtorName"];
                row.Controls.Add(NameCell);

                TableCell EmailCell = new TableCell();
                EmailCell.Text = "" + reader["RealtorEmail"];
                row.Controls.Add(EmailCell);

                TableCell PhoneCell = new TableCell();
                PhoneCell.Text = "" + reader["RealtorPhone"];
                row.Controls.Add(PhoneCell);

                TableCell CompanyCell = new TableCell();
                CompanyCell.Text = "" + reader["RealtorCompany"];
                row.Controls.Add(CompanyCell);

                TableCell TotalCell = new TableCell();
                TotalCell.Text = "" + Math.Round(Convert.ToDecimal(reader["Total"]), 2);
                row.Controls.Add(TotalCell);

                TableCell CreatedCell = new TableCell();
                DateTime date = (DateTime)reader["Date"];
                CreatedCell.Text = date.Date.ToString("MM/dd/yyyy");
                row.Controls.Add(CreatedCell);

                OrderTable.Controls.Add(row);
            }
        }

        protected void FindOrdersButton_Click(object sender, EventArgs e)
        {
            getOrders();
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

        protected void endDateCalendar_DayRender(object sender, DayRenderEventArgs e)
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
                                   // e.Day.IsSelectable = false;
                                }
                            }
                            else
                            {
                                //e.Day.IsSelectable = false;
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
                                    //e.Day.IsSelectable = false;
                                }
                            }
                            else
                            {
                                //e.Day.IsSelectable = false;
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

        protected void TwilightCheckbox_CheckedChanged(object sender, EventArgs e)
        {
        }
    }
}