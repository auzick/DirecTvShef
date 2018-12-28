using System.Collections.Generic;

namespace Shef
{
    public static class DataPort
    {
        public static readonly Dictionary<string, string> Commands
            = new Dictionary<string, string>
            {
                { "Standby", "FA81" },
                { "Active", "FA82" },
                { "GetPrimaryStatus", "FA83" },
                { "GetCommandVersion", "FA84" },
                { "GetCurrentChannel", "FA87" },
                { "GetSignalQuality", "FA90" },
                { "GetCurrentTime", "FA91" },
                { "GetUserCommand", "FA92" },
                { "EnableUserEntry", "FA93" },
                { "DisableUserEntry", "FA94" },
                { "GetReturnValue", "FA95" },
                { "Reboot", "FA96" },
                { "SendUserCommand", "FAA5" },
                { "OpenUserChannel", "FAA6" },
                { "GetTuner", "FA9A" },
                { "GetPrimaryStatusMT", "FA8A" },
                { "GetCurrentChannelMT", "FA8B" },
                { "GetSignalQualityMT", "FA9D" },
                { "OpenUserChannelMT", "FA9F" }
            };

        public static List<Response> Responses;

        static DataPort()
        {
            Responses = new List<Response>
            {
                new Response(240, "ACK_CMD", "Command Acknowledge"),
                new Response(241, "NACK_CMD", "Command Unknown"),
                new Response(242, "ACK_PARAMS", "Parser received the correct number of parameters"),
                new Response(243, "NACK_PARAMS", "Parser timed out when receiving parameters"),
                new Response(244, "ACK_FCNOK", "Service command completed successfully"),
                new Response(245, "NACK_FCNOK", "Service command completed unsuccessfully"),
                new Response(246, "ACK_RESET", "Command parser reset - break condition detected"),
                new Response(247, "NACK_BUSY", "A previous service command is pending completion"),
                new Response(249, "NACK_INUSE", "Command parser in use by another device"),
                new Response(251, "NACK_PREFIX", "Expected Prefix, prefix not sent"),
                new Response(253, "DATA_ERROR", "Command parser reset – Communication data error"),
                new Response(255, "CMDBUF_OVFL", "Command parser reset – Command buffer")
            };
        }

        public class Response
        {
            public int Code { get; set; }
            public string Label { get; set; }
            public string Description { get; set; }
            public bool IsError => !Label.StartsWith("ACK");

            public Response(){}

            public Response(int code, string label, string description)
            {
                Code = code;
                Label = label;
                Description = description;
            }
        }

    }
}
