using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JBPhotography.App_Code;

namespace JBPhotography
{
    public partial class ForgotPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ResetButton_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            DbConn.dBWrite("EXEC GenResetPassword '" + "Cray.jaeger1@gmail.com" + "', '" + GetRandomString(r, 25) + "'");
            Response.Redirect("/ConfirmPasswordSent.aspx");
        }

        public string GetRandomString(Random rnd, int length)
        {
            string charPool = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz1234567890";
            string rs = "";

            while (length > 0)
            {
                rs += charPool[(int)(rnd.NextDouble() * charPool.Length)];
                length--;
            }
            return rs;
        }

    }
}