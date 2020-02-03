using System;
using Microsoft.Extensions.Configuration;

namespace react.net.Repositories
{
    public class RepositoryConnector
    {
        public IConfiguration _configuration;
        public RepositoryConnector(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GetConnection()
        {
            bool isProduction = Convert.ToBoolean(_configuration["Databases:0:isProduction"]);

            return isProduction
            ? _configuration["Databases:0:productionConnectionString"]
            : _configuration["Databases:0:developmentConnectionString"];
        }
    }
}