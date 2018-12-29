using Shef.Model.ShefResponses;

namespace Shef.Model.SerialResponses
{
    public class SignalQuality : SerialResponse
    {
        public int Value => ShefResponse.returnValue.data.HexToInt();

        public SignalQuality(Command shefResponse) : base(shefResponse)
        {
        }
    }
}
