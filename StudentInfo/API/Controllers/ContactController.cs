using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentInfo.API.Models;
using StudentInfo.API.Data;
using StudentInfo.API.Data.DataAccess;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentInfo.API.Controllers
{
    [Route("api/contact")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly string connection;

        public ContactController(IConfiguration config)
        {
            this.connection = DatabaseConnection.Default(config);
        }

        // GET api/<ContactController>/5
        [HttpGet("sid/{id}")]
        public List<Contact> Get(int id)
        {
            // Code will get list of contacts arelated to student ID

            string conn = this.connection;

            object[] SqlParams = { id };

            SqlDataReader Reader = null;

            Reader = SqlHelper.ExecuteReader(conn, "Get_Student_Contacts", SqlParams);

            var result = ReaderTo<Contact>.Convert(Reader);

            return result.ToList<Contact>();

            
        }

        // POST api/<ContactController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ContactController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ContactController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
