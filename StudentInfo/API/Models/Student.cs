using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInfo.API.Models
{
    public class Student: Table
    {
        public string StudentId { get; set; }

        public string Id { get; set; }

        public string SchoolCode { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
    }
}
