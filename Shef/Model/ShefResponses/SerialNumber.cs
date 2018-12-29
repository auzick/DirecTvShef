namespace Shef.Model.ShefResponses
{
    public class SerialNumber : IShefResponse
    {
        /// <summary>
        ///  Serial number
        /// </summary>
        public string serialNum { get; set; }

        /// <summary>
        /// The status of the request.
        /// </summary>
        public Status status { get; set; }
    }
}
