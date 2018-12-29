namespace Shef.Model.Responses
{
    public class Version : IShefResponse
    {
        /// <summary>
        /// Access card ID (xxxx-xxxx-xxxx)
        /// </summary>
        public string accessCardId { get; set; }

        /// <summary>
        /// Receiver ID (xxxx xxxx xxxx)
        /// </summary>
        public string receiverId { get; set; }

        /// <summary>
        /// Current STB software version in hex string
        /// </summary>
        public string stbSoftwareVersion { get; set; }

        /// <summary>
        /// System time in secs in UTC
        /// </summary>
        public int systemTime { get; set; }

        /// <summary>
        /// Version of current implementation
        /// </summary>
        public string version { get; set; }
        /// <summary>
        /// The status of the request.
        /// </summary>
        public Status status { get; set; }

    }
}
