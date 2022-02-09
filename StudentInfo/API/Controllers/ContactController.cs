using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using StudentInfo.API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace StudentInfo.API.Controllers
{
    [Route("api/contact")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        // GET: api/<ContactController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ContactController>/5
        [HttpGet("sid/{id}")]
        public List<Contact> Get(int id)
        {
            // Code will get list of contacts arelated to student ID

            List<Contact> Output = new List<Contact>();

            int max = 5;
            int i;
            Random rand = new Random();

            for(i = 0; i < max; i++)
            {
                Output.Add(new Contact()
                {
                    Id = rand.Next(0, 1000).ToString(),
                    FirstName = rand.Next(0, 1000).ToString(),
                    LastName = rand.Next(0, 1000).ToString(),
                    StudentId = id.ToString(),
                    Relationship = "Relative"
                });
            }

            return Output;
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
