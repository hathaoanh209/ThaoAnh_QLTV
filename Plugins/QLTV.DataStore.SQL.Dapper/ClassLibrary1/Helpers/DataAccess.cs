using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLTV.DataStore.SQL.Dapper.Helpers
{
    public  class DataAccess : IDataAccess

    {
        private readonly string connectionString;
        private string _connectionString;

        public DataAccess(string connectionString)
        {
            this.connectionString = connectionString;
        }
        public T QuerySingle<T, U>(string sql, U parameters)
        {
            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                return conn.QuerySingle<T>(sql, parameters);
            }
        }

        public T QueryFirst<T, U>(string sql, U parameters)
        {
            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                return conn.QueryFirst<T>(sql, parameters);
            }
        }


        public List<T> Query<T, U>(string sql, U parameters)
        {
            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                return conn.Query<T>(sql, parameters).ToList();
            }
        }

        public void ExecuteCommand<U>(string sql, U parameters)
        {
            using (IDbConnection conn = new SqlConnection(connectionString))
            {
                conn.Execute(sql, parameters);
            }
        }

        
        public async Task<IEnumerable<T>> QueryAsync<T, U>(string sql, U parameters)
        {
                using (IDbConnection connection = new SqlConnection(_connectionString))
                {
                    return await connection.QueryAsync<T>(sql, parameters);
                }
            
        }
    }
}
