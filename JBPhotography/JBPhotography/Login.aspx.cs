using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JBPhotography.App_Code;

namespace JBPhotography
{
    public partial class Login : System.Web.UI.Page
    {
        private string returnURL;
        protected void Page_Load(object sender, EventArgs e)
        {
                returnURL = Request.QueryString["R"];
                returnURL = Request.QueryString["r"];
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            if (checkFields())
            {
                var reader = DbConn.dBRead("Exec checkLogin '" + EmailTextBox.Text + "', '" + PasswordTextBox.Text + "'");
                try
                {
                    if (reader.Read())
                    {
                        //Set Session Variables When Logged In
                        HttpContext.Current.Session["Email"] = reader["Email"];
                        HttpContext.Current.Session["ID"] = reader["ID"];
                        HttpContext.Current.Session["IsAdmin"] = reader["IsAdmin"];
                        HttpContext.Current.Session["PhoneNumber"] = reader["PhoneNumber"];
                        HttpContext.Current.Session["FirstName"] = reader["FirstName"];
                        HttpContext.Current.Session["LastName"] = reader["LastName"];
                        Session["cartView"] = "True";

                        if (returnURL != null)
                        {
                            Response.Redirect(returnURL);
                        }
                        else
                        {
                            Response.Redirect("~/Default.aspx");
                        }
                    }
                }
                catch
                {
                    System.Diagnostics.Debug.WriteLine("Error Loggin In");
                }
            }
        }

        protected void CreateAccountButton_Click(object sender, EventArgs e)
        {
            Response.Redirect("NewUser.aspx");
        }

        private bool checkFields()
        {
            string error = "";
            if (EmailTextBox.Text != "" && PasswordTextBox.Text != "")
            {
                return true;
            }
            if (EmailTextBox.Text == "")
            {
                error = "Error: Please enter your email address. \n";
                EmailTextBox.BackColor = System.Drawing.Color.LightPink;
            }

            if (PasswordTextBox.Text == "")
            {
                error += "Error: Please enter your password";
                PasswordTextBox.BackColor = System.Drawing.Color.LightPink;
            }

            ErrorLabel.Text = error;

            return false;
        }

        protected void GuestButton_Click(object sender, EventArgs e)
        {
            var reader = DbConn.dBRead("EXEC AddUser 'Guest'");
            try
            {
                if (reader.Read())
                {
                    //Set Session Variables When Logged In
                    HttpContext.Current.Session["Email"] = "";
                    HttpContext.Current.Session["ID"] = reader["Result"];
                    HttpContext.Current.Session["IsAdmin"] = "0";
                    HttpContext.Current.Session["PhoneNumber"] = "";
                    HttpContext.Current.Session["FirstName"] = "";
                    HttpContext.Current.Session["LastName"] = "";
                    Session["cartView"] = "False";
                    if (returnURL != null)
                    {
                        Response.Redirect(returnURL);
                    }
                    else
                    {
                        Response.Redirect("~/Default.aspx");
                    }
                }
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("Error Loggin In");
            }
        }
    }
}