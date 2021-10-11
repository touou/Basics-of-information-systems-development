using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.AccessControl;
using System.Threading.Tasks;
using System.Text;

namespace databasePrac.DataBase
{
    //Launcher Done
    public static class DataBaseLauncher
    {
        private static string datasource = @"LAPTOP-IJIRPH0O";//your server
        private static string database = "UsersAndCarsDB"; //your database name
        private static string username = "user1"; //username of server to connect
        private static string password = "sasa"; //password
        private static SqlConnection connection = new SqlConnection(@"Data Source=" + datasource + ";Initial Catalog="
                                                                   + database + ";Persist Security Info=True;User ID="
                                                                   + username + ";Password=" + password);

        public  static SqlConnection ConnectionReturn()
        {
            return connection;
        }
        
        public static void ConnectToDB()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open(); 
            }
        }

        public static void CloseDB()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}