using System.Collections.Generic;

namespace Shef
{
    public static class Serial
    {
        public static class Commands
        {
            public static string Standby = "FA81";
            public static string Active = "FA82";
            public static string GetPrimaryStatus = "FA83";
            public static string GetCommandVersion = "FA84";
            public static string GetCurrentChannel = "FA87";
            public static string GetSignalQuality = "FA90";
            public static string GetCurrentTime = "FA91";
            public static string GetUserCommand = "FA92";
            public static string EnableUserEntry = "FA93";
            public static string DisableUserEntry = "FA94";
            public static string GetReturnValue = "FA95";
            public static string Reboot = "FA96";
            public static string SendUserCommand = "FAA5";
            public static string OpenUserChannel = "FAA6";
            public static string GetTuner = "FA9A";
            public static string GetPrimaryStatusMT = "FA8A";
            public static string GetCurrentChannelMT = "FA8B";
            public static string GetSignalQualityMT = "FA9D";
            public static string OpenUserChannelMT = "FA9F";
        }

        public static List<Response> Responses;

        static Serial()
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
