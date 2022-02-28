using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Challenger.Repository.Database
{
    internal static class DatabaseCommand
    {
        public static bool InsertRowsDatabase(string query, IDbConnection connection)
        {
            var command = connection.CreateCommand();
            command.CommandText = query;
            var rows = command.ExecuteNonQuery();
            if (rows > 0)
                return true;
            return false;
        }

        public async static Task<IEnumerable<T>> GetDataRows<T>(string query, IDbConnection connection, DynamicParameters parameters) where T : class
        {
            var results = await connection.QueryAsync<T>(query, parameters);
            return results;
        }
    }
}
