using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentInfo.API.Models;
using StudentInfo.API.Data;
using StudentInfo.API.Data.DataAccess;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentInfo.API.Controllers
{
    [Route("api/student")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // GET: api/<StudentController>
        [HttpGet]
        public List<Student> Get()
        {
            string conn = DatabaseConnection.DefaultConnection;

            object[] SqlParams = Array.Empty<object>();

            SqlDataReader Reader = null;

            Reader = SqlHelper.ExecuteReader(conn, "Get_Student_List", SqlParams);

            var result = ReaderTo<Student>.Convert(Reader);

            return result.ToList<Student>();
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            //Student Output = new Student() { Id = "123", FirstName = "bob", LastName = "test", SchoolCode = "999" };
            Student Output = new Student();
            return Output;
        }

        // POST api/<StudentController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<StudentController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
