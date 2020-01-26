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

            string isProduction = _configuration.GetSection("Databases:0").GetSection("isProduction").Value;
            string connection;

            if (isProduction == "True")
            {
                connection = _configuration.GetSection("Databases:0").GetSection("productionConnectionString").Value;
            }
            else
            {
                connection = _configuration.GetSection("Databases:0").GetSection("developmentConnectionString").Value;
            }

            return connection;
        }
    }
}