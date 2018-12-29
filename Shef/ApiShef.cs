using System;
using RestSharp;
using Shef.Model.ShefResponses;
using Version = Shef.Model.ShefResponses.Version;

namespace Shef
{
    public partial class Api
    {
        /// <summary>
        /// Information about the currently viewed program. Warning: This command may change or be disabled in the future.
        /// </summary>
        /// <param name="videoWindow">Identifies the primary or secondary window.</param>
        /// <param name="clientAddress">Identifies the server or client. 0 for server and mac address(hexstring without colons) for clients</param>
        /// <param name="callback">Defaults to "jsonp"</param>
        /// <param name="wrapper"></param>
        /// <returns>Program</returns>
        public Program GetTuned(string videoWindow = null, string clientAddress = "0", string callback = null, string wrapper = null)
        {
            var req = new RestRequest("tv/getTuned");
            if (!string.IsNullOrWhiteSpace(videoWindow)) req.AddParameter("videoWindow", videoWindow);
            if (!string.IsNullOrWhiteSpace(clientAddress)) req.AddParameter("clientAddr", clientAddress);
            if (!string.IsNullOrWhiteSpace(callback)) req.AddParameter("callback", callback);
            if (!string.IsNullOrWhiteSpace(wrapper)) req.AddParameter("wrapper", wrapper);
            return Server.MakeRequest<Program>(req);
        }

        /// <summary>
        /// Current program information of specified channel. Warning: This command may change or be disabled in the future.
        /// </summary>
        /// <param name="major">Major number of channel.</param>
        /// <param name="minor">Minor number of channel. Note: 65535 is used for no minor number.</param>
        /// <param name="clientAddress">Identifies the server or client. 0 for server and mac address(hexstring without colons) for clients</param>
        /// <param name="callback">Defaults to "jsonp"</param>
        /// <param name="wrapper"></param>
        /// <returns>Program</returns>
        public Program GetProgramInfo(int major, int? minor = null, string clientAddress = "0", string callback = null, string wrapper = null)
        {
            return GetProgramInfo(major, minor, DateTime.Now);
        }

        /// <summary>
        /// Program information of specified channel at current or specific time. Warning: This command may change or be disabled in the future.
        /// </summary>
        /// <param name="major">Major number of channel.</param>
        /// <param name="minor">Minor number of channel. Note: 65535 is used for no minor number.</param>
        /// <param name="time">Time of the program to query.</param>
        /// <param name="clientAddress">Identifies the server or client. 0 for server and mac address(hexstring without colons) for clients</param>
        /// <param name="callback">Defaults to "jsonp"</param>
        /// <param name="wrapper"></param>
        /// <returns>Program</returns>
        public Program GetProgramInfo(int major, int? minor, DateTime time, string clientAddress = "0", string callback = null, string wrapper = null)
        {
            var req = new RestRequest("tv/getProgInfo");
            req.AddParameter("major", major.ToString());
            req.AddParameter("minor", (minor ?? 65535).ToString());
            req.AddParameter("time", time.ToUnixTime().ToString());
            if (!string.IsNullOrWhiteSpace(clientAddress)) req.AddParameter("clientAddr", clientAddress);
            if (!string.IsNullOrWhiteSpace(callback)) req.AddParameter("callback", callback);
            if (!string.IsNullOrWhiteSpace(wrapper)) req.AddParameter("wrapper", wrapper);
            return Server.MakeRequest<Program>(req);
        }

        /// <summary>
        /// Tune to a channel. Warning: This command may change or be disabled in the future.
        /// </summary>
        /// <param name="major">Major number of channel to tune to.</param>
        /// <param name="minor">Minor number of channel to tune to. 65535 is used for no minor number.</param>
        /// <param name="ccid"></param>
        /// <param name="clientAddress">Identifies the server or client. 0 for server and mac address(hexstring without colons) for clients</param>
        /// <param name="callback">Defaults to "jsonp"</param>
        /// <param name="wrapper"></param>
        /// <returns></returns>
        public Tune Tune(int major, int? minor = null, string ccid = null, string clientAddress = "0", string callback = null, string wrapper = null)
        {
            var req = new RestRequest("tv/tune");
            req.AddParameter("major", major.ToString());
            req.AddParameter("minor", (minor ?? 65535).ToString());
            if (!string.IsNullOrWhiteSpace(ccid)) req.AddParameter("ccid", ccid);
            if (!string.IsNullOrWhiteSpace(clientAddress)) req.AddParameter("clientAddr", clientAddress);
            if (!string.IsNullOrWhiteSpace(callback)) req.AddParameter("callback", callback);
            if (!string.IsNullOrWhiteSpace(wrapper)) req.AddParameter("wrapper", wrapper);
            return Server.MakeRequest<Tune>(req);
        }

        /// <summary>
        /// Process a key request from the remote control. Warning: This command may change or be disabled in the future.
        /// </summary>
        /// <param name="key">Name of the key to be simulated.</param>
        /// <param name="hold">Simulate key being pressed, released, or both.</param>
        /// <param name="clientAddress">Identifies the server or client. 0 for server and mac address(hexstring without colons) for clients</param>
        /// <param name="callback">Defaults to "jsonp"</param>
        /// <param name="wrapper"></param>
        /// <returns>RemoteKeyPress</returns>
        public RemoteKeyPress ProcessKey(RemoteKey key, RemoteKeyAction hold, string clientAddress = "0", string callback = null, string wrapper = null)
        {
            var req = new RestRequest("remote/processKey");
            req.AddParameter("key", key.GetDescription());
            req.AddParameter("hold", hold.GetDescription());
            if (!string.IsNullOrWhiteSpace(clientAddress)) req.AddParameter("clientAddr", clientAddress);
            if (!string.IsNullOrWhiteSpace(callback)) req.AddParameter("callback", callback);
            if (!string.IsNullOrWhiteSpace(wrapper)) req.AddParameter("wrapper", wrapper);
            return Server.MakeRequest<RemoteKeyPress>(req);
        }

        // https://whitlockjc.github.io/directv-remote-api/js/docs/dtv.remote.api.html#commands
        // http://www.iamanedgecutter.com/resources/SHEF/DTV-MD-0058-DIRECTV%20Installer%20V2.2-3.pdf <- Section 4.1

        /// <summary>
        /// "Process a command request from remote control. Warning: This command may change or be disabled in the future."
        /// See http://www.iamanedgecutter.com/resources/SHEF/DTV-MD-0058-DIRECTV%20Installer%20V2.2-3.pdf section 4.1
        /// </summary>
        /// <param name="command">Hex string to send</param>
        /// <param name="callback">Defaults to "jsonp"</param>
        /// <param name="wrapper"></param>
        /// <returns>Command</returns>
        public Command ProcessCommand(string command, string callback = null, string wrapper = null)
        {
            var req = new RestRequest("serial/processCommand");
            req.AddParameter("cmd", command);
            if (!string.IsNullOrWhiteSpace(callback)) req.AddParameter("callback", callback);
            if (!string.IsNullOrWhiteSpace(wrapper)) req.AddParameter("wrapper", wrapper);
            return Server.MakeRequest<Command>(req);
        }

        /// <summary>
        /// Set-top-box and SHEF information. Warning: This command may change or be disabled in the future.
        /// </summary>
        /// <param name="callback">Defaults to "jsonp"</param>
        /// <param name="wrapper"></param>
        /// <returns>Version</returns>
        public Version GetVersion(string callback = null, string wrapper = null)
        {
            var req = new RestRequest("info/getVersion");
            if (!string.IsNullOrWhiteSpace(callback)) req.AddParameter("callback", callback);
            if (!string.IsNullOrWhiteSpace(wrapper)) req.AddParameter("wrapper", wrapper);
            return Server.MakeRequest<Version>(req);
        }

        /// <summary>
        /// Gets a list of available commands
        /// </summary>
        /// <returns>Raw json</returns>
        public string GetOptions()
        {
            return Server.MakeRawRequest("info/getOptions");
        }

        /// <summary>
        /// List of available client locations. Warning: This command may change or be disabled in the future.
        /// </summary>
        /// <param name="type">Server or client (DVR or remote box)</param>
        /// <param name="clientAddress">Identifies the server or client. 0 for server and mac address(hexstring without colons) for clients</param>
        /// <param name="callback">Defaults to "jsonp"</param>
        /// <param name="wrapper"></param>
        /// <returns>Locations</returns>
        public Locations GetLocations(LocationType type, string clientAddress = "0", string callback = null, string wrapper = null)
        {
            var req = new RestRequest("info/getLocations");
            req.AddParameter("type", type.GetDescription());
            if (!string.IsNullOrWhiteSpace(clientAddress)) req.AddParameter("clientAddr", clientAddress);
            if (!string.IsNullOrWhiteSpace(callback)) req.AddParameter("callback", callback);
            if (!string.IsNullOrWhiteSpace(wrapper)) req.AddParameter("wrapper", wrapper);
            return Server.MakeRequest<Locations>(req);
        }

        /// <summary>
        /// STB serial number. Warning: This command may change or be disabled in the future.
        /// </summary>
        /// <param name="clientAddress">Identifies the server or client. 0 for server and mac address(hexstring without colons) for clients</param>
        /// <param name="callback">Defaults to "jsonp"</param>
        /// <param name="wrapper"></param>
        /// <returns>SerialNumber</returns>
        public SerialNumber GetSerialNumber(string clientAddress = "0", string callback = null, string wrapper = null)
        {
            var req = new RestRequest("info/getSerialNum");
            req.AddParameter("clientAddr", clientAddress);
            if (!string.IsNullOrWhiteSpace(clientAddress)) req.AddParameter("clientAddr", clientAddress);
            if (!string.IsNullOrWhiteSpace(callback)) req.AddParameter("callback", callback);
            if (!string.IsNullOrWhiteSpace(wrapper)) req.AddParameter("wrapper", wrapper);
            return Server.MakeRequest<SerialNumber>(req);
        }

        /// <summary>
        /// Set-top-box mode. Warning: This command may change or be disabled in the future.
        /// </summary>
        /// <param name="clientAddress">Identifies the server or client. 0 for server and mac address(hexstring without colons) for clients</param>
        /// <param name="callback">Defaults to "jsonp"</param>
        /// <param name="wrapper"></param>
        /// <returns>Mode</returns>
        public Mode Mode(string clientAddress = "0", string callback = null, string wrapper = null)
        {
            var req = new RestRequest("info/mode");
            req.AddParameter("clientAddr", clientAddress);
            if (!string.IsNullOrWhiteSpace(clientAddress)) req.AddParameter("clientAddr", clientAddress);
            if (!string.IsNullOrWhiteSpace(callback)) req.AddParameter("callback", callback);
            if (!string.IsNullOrWhiteSpace(wrapper)) req.AddParameter("wrapper", wrapper);
            return Server.MakeRequest<Mode>(req);
        }

    }
}
