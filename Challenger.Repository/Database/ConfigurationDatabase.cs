using MySql.Data.MySqlClient;
using System;
using System.Data;

namespace Challenger.Repository.Database
{
    public static class ConfigurationDatabase
    {
        static string ConnectionString = @$"Server={Environment.GetEnvironmentVariable("Server")};Database={Environment.GetEnvironmentVariable("Database")};Port=3306;User={Environment.GetEnvironmentVariable("UserDatabaseChallenger")};Password={Environment.GetEnvironmentVariable("Password")}";
        public static MySqlConnection OpenDatabase()
        {
            var connection = new MySqlConnection(ConnectionString);
            if (connection.State != ConnectionState.Open)
                connection.Open();
            return connection;
        }

        public static void CloseDatabase(MySqlConnection connection) => connection.Close();
    }
}
