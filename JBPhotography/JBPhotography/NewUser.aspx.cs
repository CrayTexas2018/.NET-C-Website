using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JBPhotography.App_Code;

namespace JBPhotography
{
    public partial class NewUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CreateAccountButton_Click(object sender, EventArgs e)
        {
            resetColors();
            checkPasswords(PasswordTextBox1.Text, PasswordTextBox2.Text);
            checkEmail(EmailTextBox.Text);
            checkFirstName(FirstNameTextBox.Text);
            checkLastName(LastNameTextBox.Text);
            checkPhone(PhoneNumberTextBox.Text);
            checkCompany(CompanyTextBox.Text);

            if (checkPasswords(PasswordTextBox1.Text, PasswordTextBox2.Text) && checkEmail(EmailTextBox.Text) 
                && checkFirstName(FirstNameTextBox.Text) && checkLastName(LastNameTextBox.Text) && checkPhone(PhoneNumberTextBox.Text) && checkCompany(CompanyTextBox.Text))
            {
                var reader = DbConn.dBRead("Exec AddUser '" + EmailTextBox.Text + "', '" + PasswordTextBox1.Text + "', '" + FirstNameTextBox.Text + "', '" + LastNameTextBox.Text + "', '" + PhoneNumberTextBox.Text + "', 0, '" + CompanyTextBox.Text + "'");

                if (reader.Read())
                {
                    if (Convert.ToBoolean(reader["Result"]) == true)
                    {
                        Response.Redirect("/Default.aspx");
                    }
                    else
                    {
                        ErrorLabel.Text = "Error: That email has already been registered. Please use a different email.";
                        EmailTextBox.BackColor = System.Drawing.Color.LightPink;
                    }
                }
            }  
        }

        private bool checkPasswords(string password1, string password2)
        {
            if (password1 == password2 && password1 != "")
            {
                return true;
            }
            else
            {
                ErrorLabel.Text = "Please make sure your passwords match.";
                PasswordTextBox1.BackColor = System.Drawing.Color.LightPink;
                PasswordTextBox2.BackColor = System.Drawing.Color.LightPink;
                return false;
            }
        }

        private bool checkEmail(string email)
        {
            if (email != "")
            {
                return true;
            }
            else
            {
                ErrorLabel.Text = "Please enter an email address into the email address box.";
                EmailTextBox.BackColor = System.Drawing.Color.LightPink;
                return false;
            }
        }

        private bool checkPhone(string phone)
        {
            if (phone != "")
            {
                return true;
            }
            else
            {
                ErrorLabel.Text = "Please enter a phone number into the phone number box";
                PhoneNumberTextBox.BackColor = System.Drawing.Color.LightPink;
                return false;
            }
        }

        private bool checkFirstName(string firstName)
        {
            if (firstName != "")
            {
                return true;
            }
            else
            {
                ErrorLabel.Text = "Please enter your first name into the first name box.";
                FirstNameTextBox.BackColor = System.Drawing.Color.LightPink;
                return false;
            }
        }

        private bool checkLastName(string lastName)
        {
            if (lastName != "")
            {
                return true;
            }
            else
            {
                ErrorLabel.Text = "Please enter your lastname into the lastname box.";
                LastNameTextBox.BackColor = System.Drawing.Color.LightPink;
                return false;
            }
        }

        private bool checkCompany(string companyName)
        {
            if (companyName != "")
            {
                return true;
            }
            else
            {
                ErrorLabel.Text = "Please enter your company name into the company name box.";
                CompanyTextBox.BackColor = System.Drawing.Color.LightPink;
                return false;
            }
        }

        private void resetColors()
        {
            PasswordTextBox1.BackColor = System.Drawing.Color.White;
            PasswordTextBox2.BackColor = System.Drawing.Color.White;
            EmailTextBox.BackColor = System.Drawing.Color.White;
            PhoneNumberTextBox.BackColor = System.Drawing.Color.White;
            FirstNameTextBox.BackColor = System.Drawing.Color.White;
            LastNameTextBox.BackColor = System.Drawing.Color.White;
            CompanyTextBox.BackColor = System.Drawing.Color.White;
        }
    }
}