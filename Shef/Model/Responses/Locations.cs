using System.Collections.Generic;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Shef.Model.Responses
{
    public enum LocationType
    {
        [Description("0")]
        server,
        [Description("1")]
        client
    }

    public class Locations : IShefResponse
    {
        public IEnumerable<Location> locations { get; set; }
        public Status status { get; set; }
    }

    public class Location
    {
        public string clientAddr { get; set; }
        public string locationName { get; set; }
        public string status { get; set; }
        public bool tunerBond { get; set; }

        [JsonIgnore]
        public bool IsServer => clientAddr == "0";
    }
}
