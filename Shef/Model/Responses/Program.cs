using System.ComponentModel;
using Newtonsoft.Json;

namespace Shef.Model.Responses
{
    [JsonConverter(typeof(StringDescriptionEnumConverter))]
    public enum ParentalControlLock
    {
        [Description("1")] Locked,
        [Description("2")] TemporarilyUnlocked,
        [Description("3")] Unlocked
    }

    [JsonConverter(typeof(StringDescriptionEnumConverter))]
    public enum RecordingType
    {
        [Description("1")] Manual,
        [Description("2")] FindBy,
        [Description("3")] Regular,
        [Description("4")] RecurringManual,
    }



    public class Program : IShefResponse
    {
        /// <summary>
        /// Call letter of a channel
        /// </summary>
        public string callsign { get; set; }

        /// <summary>
        /// Release year or first released date of the event for single event or first air date for series. Convert using DateTimeHelper.FromSortDate()
        /// </summary>
        public string date { get; set; }

        /// <summary>
        /// Duration in seconds of a live event or actual duration of a recording.
        /// </summary>
        public int duration { get; set; }

        /// <summary>
        /// Title of the episode
        /// </summary>
        public string episodeTitle { get; set; }

        /// <summary>
        /// Expiration day & time of the recording. Only available if the event is a recording.
        /// </summary>
        public string expiration { get; set; }

        /// <summary>
        /// Expiration day & time of the event in UTC seconds. Convert using DateTimeHelpers.FromUnixTime().
        /// </summary>
        public long expiryTime { get; set; }

        /// <summary>
        /// Words used to search recordings. Only available if the event is recorded based on search criteria.
        /// </summary>
        public string findByWord { get; set; }

        /// <summary>
        /// Whether the event is an ATSC event 
        /// </summary>
        public bool isOffAir { get; set; }

        /// <summary>
        /// Whether the parental control is enabled.
        /// </summary>
        public ParentalControlLock isPclocked { get; set; }

        /// <summary>
        /// Whether the event is a Pay-Per-View event 
        /// </summary>
        public bool isPpv { get; set; }

        /// <summary>
        /// Whether the event is partially recorded. Only available if the event is a recording.
        /// </summary>
        public bool isPartial { get; set; }

        /// <summary>
        /// Whether the event is purchased. Only available if isPpv returns true.
        /// </summary>
        public bool isPurchased { get; set; }

        /// <summary>
        /// Whether the event is currently being recorded.
        /// </summary>
        public bool isRecording { get; set; }

        /// <summary>
        /// Whether the event has been viewed. Only available if the event is a recording.
        /// </summary>
        public bool isViewed { get; set; }

        /// <summary>
        /// Whether the event is a Video-On-Demand event 
        /// </summary>
        public bool isVod { get; set; }

        /// <summary>
        /// Will the event will be deleted when the disk is full and more space is needed. Only available if the event is a recording.
        /// </summary>
        public bool keepUntilFull { get; set; }

        /// <summary>
        /// Major channel number.
        /// </summary>
        public int major { get; set; }

        /// <summary>
        /// Material ID. Only available for VOD and push titles.
        /// </summary>
        public string materialId { get; set; }

        /// <summary>
        /// Minor channel number.
        /// </summary>
        public int minor { get; set; }

        /// <summary>
        /// Music sound track information. Only available if the event is a music channel.
        /// </summary>
        public Music music { get; set; }

        /// <summary>
        /// Number of seconds from the scheduled start time of a recording or program start time of a live tv or live buffer
        /// </summary>
        public int offset { get; set; }

        /// <summary>
        /// Priority order of the event. Only available if the event is a recording.
        /// </summary>
        public string priority { get; set; }

        /// <summary>
        /// Program object id.
        /// </summary>
        public string programId { get; set; }

        /// <summary>
        /// Rating of the event 
        /// </summary>
        public string rating { get; set; }

        /// <summary>
        /// Recording Type. Only available if the event is a recording.
        /// </summary>
        public RecordingType recType { get; set; }

        /// <summary>
        /// Start time in seconds of a live event or when a recording happens in UTC time.
        /// </summary>
        public int startTime { get; set; }

        /// <summary>
        /// Unique identifier for the channel 
        /// </summary>
        public int stationId { get; set; }

        /// <summary>
        /// Title of the program.
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// The status of the request.
        /// </summary>
        public Status status { get; set; }

        /// <summary>
        /// Unique identifier of the event. Only available if the event is a recording.
        /// </summary>
        public string uniqueId { get; set; }

    }

}
