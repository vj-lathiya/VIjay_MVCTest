using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;
using Vitelytech.DB.DataAccess;

namespace Vijay_MVC.DB.DataAccess
{
    public class BaseDataProvider : IBaseDataProvider
    {
        private readonly IConfiguration _config;
        
        public BaseDataProvider(IConfiguration config)
        {
            _config = config;
        }
        
        public string ConnectionString()
        {
            string con = _config.GetSection("ConnectionStrings").GetSection("DefaultConnection").Value;
            return con;
        }

        public async Task<List<T>> GetData<T>(string SpName, object? Parameters = null)
        {
            using IDbConnection connection = new SqlConnection(ConnectionString());
            var result = await connection.QueryAsync<T>(SpName, Parameters, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public async Task<int> SaveData<T>(string SpName, T Parameters)
        {
            using IDbConnection connection = new SqlConnection(ConnectionString());
            return await connection.ExecuteAsync(SpName, Parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
