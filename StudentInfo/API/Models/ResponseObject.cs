using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentInfo.API.Models
{
    public class ResponseObject : Table
    {
        public object Result { get; set; }

        public string Id { get; set; }

        public DateTime Created { get; set; }

        public string CreatedSort
        {
            get

            {
                var time = this.Created.Year + ""
                    + this.Created.Month + ""
                    + this.Created.Day + ""
                    + this.Created.Hour + ""
                    + this.Created.Minute + ""
                    + this.Created.Second;

                return time;
            }
        }

        public bool success { get; set; }
    }
}
