using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentInfo.API.Models
{
    public class Contact : Table
    {
        public string Id { get; set; }

        public string StudentId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Relationship { get; set; }

        public string Email { get; set; }

        public string Mobile { get; set; }

        public string Address { get; set; }

        public string City { get; set; }

        public string State { get; set; }

        public string Zip { get; set; }

    }
}
