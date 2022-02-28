using Dapper;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;

namespace Challenger.Repository.Database
{
    internal static class DatabaseCommand
    {
        public async static Task<int> InsertRowsDatabase(string query, IDbConnection connection, DynamicParameters parameters) => await connection.ExecuteAsync(query, parameters);

        public async static Task<IEnumerable<T>> GetDataRows<T>(string query, IDbConnection connection, DynamicParameters parameters) where T : class
        {
            var results = await connection.QueryAsync<T>(query, parameters);
            return results;
        }
    }
}
