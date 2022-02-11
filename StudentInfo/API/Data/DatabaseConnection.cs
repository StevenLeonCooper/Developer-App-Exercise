using System;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInfo.API.Data
{
    public class DatabaseConnection
    {
        public static string Default(IConfiguration config)
        {
            string DefConn = config.GetValue<string>("DefaultConnection");

           return config.GetConnectionString(DefConn);
        }

    }
}
