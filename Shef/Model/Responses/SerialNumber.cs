using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shef.Model.Responses
{
    public class SerialNumber : IShefResponse
    {
        public string serialNum { get; set; }
        public Status status { get; set; }
    }
}
