using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;

namespace JBPhotography.App_Code
{

    public static class AdminInfo
    {
        public static bool checkCredentials(string userID)
        {
            try
            {
                var reader = DbConn.dBRead("Select * from users where id = " + HttpContext.Current.Session["ID"]);
                if (reader.Read())
                {
                    if ((bool)reader["isAdmin"] == true)
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
    }
}
