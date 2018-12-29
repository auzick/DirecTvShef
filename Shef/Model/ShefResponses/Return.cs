using System.Linq;

namespace Shef.Model.ShefResponses
{
    public class Return
    {
        public string data { get; set; }
        public int response { get; set; }
        public int value { get; set; }

        public Serial.Response ResponseInfo => Serial.Responses.FirstOrDefault(r => r.Code == response);

    }
}
