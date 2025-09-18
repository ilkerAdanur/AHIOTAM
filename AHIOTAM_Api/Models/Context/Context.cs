using Microsoft.Data.SqlClient;
using System.Data;

namespace AHIOTAM_Api.Models.Context
{
    public class Context
    {
        private readonly IConfiguration _configuration;
        private readonly string _configurationString ;

        public Context(IConfiguration configuration)
        {
            _configuration = configuration;
            _configurationString = _configuration.GetConnectionString("connection");
        }
        public IDbConnection CreateConnection()
            => new SqlConnection(_configurationString);
    }
}
