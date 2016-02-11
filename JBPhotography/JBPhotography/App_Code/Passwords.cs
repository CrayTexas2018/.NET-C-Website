using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace JBPhotography.App_Code
{
    public class Passwords
    {
        public static int checkPassword(string password1, string password2 = null)
        {
            if (password1 == "")
            {
                return 0;
            }
            else if (password2 == "")
            {
                return 1;
            }
            else if (password1 != password2)
            {
                return 2;
            }
            return 3;
        }
    }
}