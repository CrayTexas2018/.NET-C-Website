using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JBPhotography.App_Code;

namespace JBPhotography
{
    public partial class RecoverPassword : System.Web.UI.Page
    {
        string code;
        string error;
        public bool isValid = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["ID"] == null)
            {
                //Response.Redirect("~/default.aspx");
            }

            code = Request.QueryString["c"];
            if (!checkCode(code))
            {
                error = "Link has expired";
                ErrorLabel.Text = error;
                //isValid = false;
            }
        }

        private bool checkCode(string code)
        {
            try {
                var reader = DbConn.dBRead("EXEC checkcode '" + code + "'");
                if (reader.Read())
                {
                    if (Convert.ToString(reader["Result"]) == "True")
                    {
                        return true;
                    }
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        private bool checkEmail(string code, string email)
        {
            try
            {
                var reader = DbConn.dBRead("Exec CheckPasswordCode '" + code + "', '" + email + "'");

                if (reader.Read())
                {
                    if (Convert.ToString(reader["Result"]) == "True")
                    {
                        return true;
                    }
                        return false;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        protected void ChangeButton_Click(object sender, EventArgs e)
        {
            if (Passwords.checkPassword(PasswordTextBox1.Text, PasswordTextBox2.Text) == 3)
            {
                changePassword(PasswordTextBox1.Text, EmailAddressTextBox.Text, code);
                Response.Redirect("/Login.aspx");
            }
            else if (Passwords.checkPassword(PasswordTextBox1.Text, PasswordTextBox2.Text) == 0 || Passwords.checkPassword(PasswordTextBox1.Text, PasswordTextBox2.Text) == 1)
            {
                ErrorLabel.Text = "Please enter valid passwords are not blank";
            }
            else if (Passwords.checkPassword(PasswordTextBox1.Text, PasswordTextBox2.Text) == 2)
            {
                ErrorLabel.Text = "Please make sure passwords match";
            }
        }

        private void changePassword(string password, string email, string code)
        {
            DbConn.dBWrite("EXEC ChangePassword '" + password + "', '" + email + "'");
            DbConn.dBWrite("EXEC CodeUsed '" + code + "'");
        }
    }
}