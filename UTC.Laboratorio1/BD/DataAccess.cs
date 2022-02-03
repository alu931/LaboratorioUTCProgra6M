using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD
{
    public class DataAccess
    {
        private readonly IConfiguration config;

        public DataAccess(IConfiguration _Config)
        {
            config = _Config;
        }

        public SqlConnection DbConnection => new SqlConnection(
             new SqlConnectionStringBuilder(config.GetConnectionString("Conn")).ConnectionString
            
            );

        //Representación de retorno de una lista
        public async Task<IEnumerable<T>> QueryAsync<T>(string sp, object Param= null, int? Timeout= null)
        {
            try
            {
                using (var exec= DbConnection)
                {
                    await exec.OpenAsync();

                    var result = exec.QueryAsync<T>(sql: sp, param: Param, commandType: System.Data.CommandType.StoredProcedure, commandTimeout: Timeout);

                    return await result;

                }

            }
            catch (Exception)
            {

                throw;
            }           
        
        }
    }





}
