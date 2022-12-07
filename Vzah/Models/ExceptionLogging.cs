using ModelPortal.Db_Connection;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Vzah.Models
{
    public static class ExceptionLogging
    {
        private static String exepurl;
        static SqlConnection con;
        private static void connecttion()
        {
            SqlConnection com = new SqlConnection(DBConnection.GetConnectionString);
            com.Open();
        }
        public static void SendExcepToDB(Exception exdb, string row_string)
        {

            con = new SqlConnection(DBConnection.GetConnectionString); con.Open();
            exepurl = HttpContext.Current.Request.Url.ToString();
            SqlCommand com = new SqlCommand("Sp_Exception", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ExceptionMsg", exdb.Message.ToString());
            com.Parameters.AddWithValue("@ExceptionType", exdb.GetType().Name.ToString());
            com.Parameters.AddWithValue("@ExceptionURL", exepurl);
            com.Parameters.AddWithValue("@row_string", row_string);
            com.Parameters.AddWithValue("@ExceptionSource", exdb.StackTrace.ToString());
            com.ExecuteNonQuery();
        }
        public static void SendExcepToDBWEB(Exception exdb, string row_string)
        {
            con = new SqlConnection(DBConnection.GetConnectionString); con.Open();
            exepurl = HttpContext.Current.Request.Url.ToString();
            SqlCommand com = new SqlCommand("Sp_ExceptionWEB", con);
            com.CommandType = CommandType.StoredProcedure;
            com.Parameters.AddWithValue("@ExceptionMsg", exdb.Message.ToString());
            com.Parameters.AddWithValue("@ExceptionType", exdb.GetType().Name.ToString());
            com.Parameters.AddWithValue("@ExceptionURL", exepurl);
            com.Parameters.AddWithValue("@row_string", row_string);
            com.Parameters.AddWithValue("@UserId", (int)System.Web.HttpContext.Current.Session["UserId"]);
            com.Parameters.AddWithValue("@ExceptionSource", exdb.StackTrace.ToString());
            com.ExecuteNonQuery();
        }
    }
}