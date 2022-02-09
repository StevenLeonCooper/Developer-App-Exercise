using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentInfo.API.Models;

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
            List<Student> Output = new List<Student>();

            int i;
            int max = 5;
            Random rand = new Random();
            for(i = 0; i < max; i++)
            {
                Output.Add(new Student()
                {
                    Id = rand.Next(1000, 9999).ToString(),
                    FirstName = rand.Next(0, 99999).ToString(),
                    LastName = rand.Next(0, 99999).ToString(),
                    SchoolCode = rand.Next(10000, 99999).ToString()
                });
            }

            return Output;
        }

        // GET api/<StudentController>/5
        [HttpGet("{id}")]
        public Student Get(int id)
        {
            Student Output = new Student() { Id = "123", FirstName = "bob", LastName = "test", SchoolCode = "999" };
            
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
