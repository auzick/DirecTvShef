using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shef.Model.ShefResponses;

namespace Shef.Model.SerialResponses
{
    public class CurrentChannel : SerialResponse
    {
        public int MajorChannel => ShefResponse.returnValue.data.Substring(0, 4).HexToInt();
        public int MinorChannel => ShefResponse.returnValue.data.Substring(4, 4).HexToInt();

        public CurrentChannel(Command shefResponse) : base(shefResponse)
        {
        }
    }
}
