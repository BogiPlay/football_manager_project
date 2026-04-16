using System;
using System.Configuration;
using System.Data;
using MySql.Data.MySqlClient;

namespace FootballManager.DataAccess
{
    public class Db
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        public static IDbConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
    }
}