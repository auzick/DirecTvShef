using System.ComponentModel;

namespace Shef.Model.ShefResponses
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
        /// <summary>
        /// Mode.
        /// </summary>
        public StbMode mode { get; set; }

        /// <summary>
        /// The status of the request.
        /// </summary>
        public Status status { get; set; }
    }
}
