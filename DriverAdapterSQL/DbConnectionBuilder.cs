

using DriverAdapterSQL.Gateway;
using Microsoft.Data.SqlClient;
using System.Data;

namespace DriverAdapterSQL
{
    public class DbConnectionBuilder : IDbConnectionBuilder
    {


        private readonly string _connectionString;

        public DbConnectionBuilder(string connectionString) =>

           _connectionString = connectionString ?? throw new ArgumentNullException(nameof(connectionString));


        public async Task<IDbConnection> CreateConnectionAsync()
        {
            var sqlConnection = new SqlConnection(_connectionString);
            await sqlConnection.OpenAsync();
            return sqlConnection;
        }
    }
}
