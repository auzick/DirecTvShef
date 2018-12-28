using System.ComponentModel;

namespace Shef.Model.Responses
{
    public enum StbMode
    {
        [Description("0")]
        active,
        [Description("1")]
        standby
    }
    public class Mode : IShefResponse
    {
        public StbMode mode { get; set; }
        public Status status { get; set; }
    }
}
