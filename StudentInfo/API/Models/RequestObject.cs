using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfo.API.Models
{
    public class RequestObject : Table
    {
        public object Result { get; set; }

        public string Id { get; set; }

        public DateTime Created { get; set; }
    }
}
