using System.ComponentModel;

namespace Shef.Model.SerialResponses
{
    public enum PrimaryType
    {
        [Description("11")] Data,
        [Description("12")] Audio,
        [Description("14")] Retired,
        [Description("15")] VideoTV,
        [Description("16")] VideoHDTV,
        [Description("255")] None,
    }

    public enum AudioType
    {
        [Description("0")] MPEG_In_PCM_Out,
        [Description("9")] AC3_In_AC3_Out,
        [Description("255")] None,
    }

    public enum DataType
    {
        [Description("11")] Retired1,
        [Description("13")] Retired2,
        [Description("12")] Retired3,
        [Description("255")] None,
    }

}
