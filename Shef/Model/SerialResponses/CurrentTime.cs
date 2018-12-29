using System;
using Shef.Model.ShefResponses;

namespace Shef.Model.SerialResponses
{
    public class CurrentTime : SerialResponse
    {
        private byte[] Data { get; }

        public DateTime Time => new DateTime(Data[0] + 1993, Data[1], Data[2], Data[3], Data[4], Data[5]);

        public CurrentTime(Command shefResponse) : base(shefResponse)
        {
            Data = ShefResponse.returnValue.data.HexToByteArray();
        }

    }
}
