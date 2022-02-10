using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInfo.API.Data
{
    public class DatabaseConnection
    {
        /// <summary>
        /// Not how I would normally do this but I'm just trying to make this easy
        /// to use with GitHub. 
        /// </summary>
        public static string DefaultConnection
        {
            get
            {
                string conn = @"Data Source=(localdb)\ProjectsV13;Initial Catalog=StudentDB;";
                conn += @"Integrated Security=True;Pooling=False;Connect Timeout=30";
                return conn;
            }
        }

        public string Database { get; set; }

        public string Server { get; set; }

        public string UserId { get; set; }

        public string Password { get; set; }

        public string ConnectionString
        {
            get
            {
                string conn = "Server = {0}; Database = {1}; User Id = {2}; Password = {3};";

                conn = String.Format(conn, Server, Database, UserId, Password);

                return conn;
            }
        }

    }
}
