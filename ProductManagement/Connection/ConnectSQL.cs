using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace ProductManagement.Connection
{
    public class ConnectSQL: IConnectSQL
    {
        private readonly IConfiguration _configuration;
        public ConnectSQL(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public string GetConnectionString()
        {
            string ConString = ConfigurationExtensions.GetConnectionString(_configuration, "MyConnection");
            return ConString;
        }
    }
}
