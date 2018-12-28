using Newtonsoft.Json;

namespace Shef.Model.Responses
{
    public class Command : IShefResponse
    {
        public bool command { get; set; }
        public bool param { get; set; }
        public bool prefix { get; set; }
        [JsonProperty("return")]
        public Return returnValue { get; set; }
        public Status status { get; set; }

    }
}
