using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shef.Model.Responses
{
    public class SerialNumber : IShefResponse
    {
        /// <summary>
        ///  Serial number
        /// </summary>
        public string serialNum { get; set; }

        /// <summary>
        /// The status of the request.
        /// </summary>
        public Status status { get; set; }
    }
}
