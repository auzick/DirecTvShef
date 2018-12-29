using System.ComponentModel;
using Newtonsoft.Json;

namespace Shef.Model.Responses
{
    [JsonConverter(typeof(StringDescriptionEnumConverter))]
    public enum RemoteKeyAction
    {
        keyUp,
        keyDown,
        keyPress
    }

    [JsonConverter(typeof(StringDescriptionEnumConverter))]
    public enum RemoteKey
    {
        power,
        poweron,
        poweroff,
        format,
        pause,
        rew,
        replay,
        stop,
        advance,
        ffwd,
        record,
        play,
        guide,
        active,
        list,
        exit,
        back,
        menu,
        info,
        up,
        down,
        left,
        right,
        select,
        red,
        green,
        yellow,
        blue,
        chanup,
        chandown,
        prev,
        [Description("0")]
        number0,
        [Description("1")]
        number1,
        [Description("2")]
        number2,
        [Description("3")]
        number3,
        [Description("4")]
        number4,
        [Description("5")]
        number5,
        [Description("6")]
        number6,
        [Description("7")]
        number7,
        [Description("8")]
        number8,
        [Description("9")]
        number9,
        dash,
        enter
    }

    public class RemoteKeyPress : IShefResponse
    {

        /// <summary>
        /// Holding status of the simulated key
        /// </summary>
        public RemoteKeyAction hold { get; set; }

        /// <summary>
        /// Name of the simulated key
        /// </summary>
        public RemoteKey key { get; set; }

        /// <summary>
        /// Command status
        /// </summary>

        /// <summary>
        /// The status of the request.
        /// </summary>
        public Status status { get; set; }
    }

}
