using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using JBPhotography.App_Code;

namespace JBPhotography.App_Code
{
    public class User : System.Web.UI.Page
    {
        public static bool isLoggedIn()
        {
            if (HttpContext.Current.Session["ID"] == null || (string) HttpContext.Current.Session["ID"] == "")
            {
                return false;                
            }
            return true;
        }
    }
}