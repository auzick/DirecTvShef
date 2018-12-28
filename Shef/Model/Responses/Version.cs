namespace Shef.Model.Responses
{
    public class Version : IShefResponse
    {
        public string accessCardId { get; set; }
        public string receiverId { get; set; }
        public string stbSoftwareVersion { get; set; }
        public int systemTime { get; set; }
        public string version { get; set; }
        public Status status { get; set; }

    }
}
