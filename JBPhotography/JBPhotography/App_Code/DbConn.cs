using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace JBPhotography.App_Code
{
    public class DbConn
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;

        public static IDataReader dBRead(string sqlText)
        {
            try
            {
                using (var SqlConnection = new SqlConnection(connectionString))
                {
                    SqlConnection.Open();
                    SqlCommand command = new SqlCommand(sqlText);
                    command.Connection = SqlConnection;
                    SqlDataReader reader = command.ExecuteReader();
                    var dt = new DataTable();
                    dt.Load(reader);
                    return dt.CreateDataReader();
                }
            }
            catch
            {
                IDataReader dr = null;
                return dr;
            }
        }

        public IDataReader dBRead2(string sqlText)
        {
            try
            {
                using (var SqlConnection = new SqlConnection(connectionString))
                {
                    SqlConnection.Open();
                    SqlCommand command = new SqlCommand(sqlText);
                    command.Connection = SqlConnection;
                    SqlDataReader reader = command.ExecuteReader();
                    var dt = new DataTable();
                    dt.Load(reader);
                    return dt.CreateDataReader();
                }
            }
            catch
            {
                IDataReader dr = null;
                return dr;
            }
        }

        public static bool dBWrite(string sqlText)
        {
            try
            {
                using (var SqlConnection = new SqlConnection(connectionString))
                {
                    SqlConnection.Open();
                    SqlCommand command = new SqlCommand(sqlText);
                    command.Connection = SqlConnection;
                    SqlDataReader reader = command.ExecuteReader();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        private static  void addGuestTimeDaytime(string ID)
        {
            dBWrite("EXEC addGuestTime_Daytime " + ID);
        }

        private static void addGuestTimeTwilight(string ID)
        {
            dBWrite("EXEC addGuestTime_Twilight " + ID);
        }

        public static void addGuestTime(string ID)
        {
            if ("" + HttpContext.Current.Session["PhotoType"] == "7" && "" + HttpContext.Current.Session["Email"] == "")
            {
                addGuestTimeDaytime("" + HttpContext.Current.Session["ID"]);
            }
            else if ("" + HttpContext.Current.Session["PhotoType"] == "12" && "" + HttpContext.Current.Session["Email"] == "")
            {
                addGuestTimeTwilight("" + HttpContext.Current.Session["ID"]);
            }
        }


    }
}