using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace CanteenCollegeAPI.Services
{
    public class BaseDAL
    {
        public string connStr = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("ConnectionStrings")["DefaultConnection"];
        public SqlConnection GetConnection()
        {
            return new SqlConnection(connStr);
        }
    }
}
