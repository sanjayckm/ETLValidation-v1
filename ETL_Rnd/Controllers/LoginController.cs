using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ETL_Rnd.Controllers
{
    public static class LoginController
    {
        public static string UserID { set; get; }
        public static string Password { set; get; }

        public static void verifyCredentials()
        {
            if (HttpContext.Current.Session["isAuthenticated"] == null)
            {
                string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["ETL_ConnectionString"].ConnectionString;
                string query = "select [Password] from [tb_etl_valid_user] where [userName] = @userName";

                try
                {
                    using (SqlConnection con = new SqlConnection(connectionString))
                    {
                        con.Open();
                        SqlCommand cmd = new SqlCommand(query, con);
                        cmd.Parameters.AddWithValue("@userName", UserID);
                        string pswd = (string)cmd.ExecuteScalar();
                        if (pswd == Password)
                        {
                            HttpContext.Current.Session["isAuthenticated"] = true;
                        }
                        con.Close();
                    }
                }
                catch
                {
                    logout();
                }
            }
            else
            {
                if ((bool)HttpContext.Current.Session["isAuthenticated"] == false)
                    logout();
            }
        }

        public static void logout()
        {
            HttpContext.Current.Session["isAuthenticated"] = null;
            HttpContext.Current.Response.Redirect("/webapp/login.aspx",true);
        }
    }
}