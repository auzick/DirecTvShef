using Shef.Model.ShefResponses;

namespace Shef.Model.SerialResponses
{
    public class CommandVersion : SerialResponse
    {
        private byte[] Data { get; }

        public int MajorVersion => Data[0];
        public int MinorVersion => Data[1];
        public int Reserved1 => Data[2];
        public int Reserved2 => Data[3];


        public CommandVersion(Command shefResponse) : base(shefResponse)
        {
            Data = ShefResponse.returnValue.data.HexToByteArray();
        }
    }
}
