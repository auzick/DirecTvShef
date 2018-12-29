using Shef.Model.SerialResponses;

namespace Shef
{
    public partial class Api
    {
        /// <summary>
        /// Places the STB in the "low power" mode where the audio and video processing is disabled.
        /// This command has the same effect as turning the box "off" by pressing the front panel power button.
        /// </summary>
        /// <returns></returns>
        public SerialResponse Standby()
        {
            var result = ProcessCommand(Serial.Commands.Standby);
            return new SerialResponse(result);
        }

        /// <summary>
        /// The STB executes this command by placing the STB in the operational mode.
        /// This command has the same effect as turning the box "on" by pressing the front panel power button.
        /// </summary>
        /// <returns></returns>
        public SerialResponse Active()
        {
            var result = ProcessCommand(Serial.Commands.Active);
            return new SerialResponse(result);
        }

        /// <summary>
        /// Get the STB’s health and status as defined by the Return Data Stream parameters.
        /// </summary>
        /// <returns>PrimaryStatus</returns>
        public PrimaryStatus PrimaryStatus()
        {
            var result = ProcessCommand(Serial.Commands.GetPrimaryStatus);
            return new PrimaryStatus(result);
        }

        /// <summary>
        /// This command displays the version of the Data Port specification the STB software was coded to.
        /// </summary>
        /// <returns>CommandVersion</returns>
        public CommandVersion GetCommandVersion()
        {
            var result = ProcessCommand(Serial.Commands.GetCommandVersion);
            return new CommandVersion(result);
        }

        /// <summary>
        /// Provides the major and minor channel number (i.e., for the DIRECTV system channel the STB is tuned to)
        /// </summary>
        /// <returns></returns>
        public CurrentChannel GetCurrentChannel()
        {
            var result = ProcessCommand(Serial.Commands.GetCurrentChannel);
            return new CurrentChannel(result);
        }

        /// <summary>
        /// Provides the signal quality
        /// </summary>
        /// <returns></returns>
        public SignalQuality GetSignalQuality()
        {
            var result = ProcessCommand(Serial.Commands.GetSignalQuality);
            return new SignalQuality(result);
        }

        /// <summary>
        /// Get the current time in Universal Time Coordinate(UTC) conditioned by time zone and daylight savings settings.
        /// </summary>
        /// <returns>CurrentTime</returns>
        public CurrentTime GetCurrentTime()
        {
            var result = ProcessCommand(Serial.Commands.GetCurrentTime);
            return new CurrentTime(result);
        }

        // TODO: Left off at 5.8 (GetUserCommand) in "DTV-MD-0058-DIRECTV Installer V2.2-3.pdf"


    }
}
