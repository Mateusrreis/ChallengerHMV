using MySql.Data.MySqlClient;
using Npgsql;
using System.Threading.Tasks;

namespace Challenger.Repository.Database
{
    public static class ConfigurationDatabase
    {
        static string ConnectionString = "Server=ls-55644b4305aece7da22229120122e652bb78e1c3.cxyr7cur3cov.us-east-1.rds.amazonaws.com;Ports=5432;Database=challengerdb;User=challengerAdmin; Pwd=*fa7$:oLI$2j+cgpOOvG!S&).U(Wwrk*";
        public static MySqlConnection OpenDatabase()
        {
            var connection = new MySqlConnection(ConnectionString);
            connection.Open();
            return connection;
        }

        public static void CloseDatabase(NpgsqlConnection connection) => connection.Close();
    }
}
