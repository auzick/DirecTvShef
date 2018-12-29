using Shef.Model.ShefResponses;

namespace Shef.Model.SerialResponses
{
    public class SerialResponse
    {
        public Command ShefResponse { get; set; }

        public SerialResponse(Command shefResponse)
        {
            ShefResponse = shefResponse;
        }

    }
}
