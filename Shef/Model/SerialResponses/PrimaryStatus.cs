using System;
using Shef.Model.ShefResponses;

namespace Shef.Model.SerialResponses
{
    public class PrimaryStatus : SerialResponse
    {
        public PrimaryStatusBytes HexData { get; }

        public int MajorChannel => HexData?.MajorChannel.HexToInt() ?? 0;
        public int MinorChannel => HexData?.MinorChannel.HexToInt() ?? 0;
        public PrimaryType PrimaryType => (PrimaryType)Enum.Parse(typeof(PrimaryType), HexData?.PrimaryType.HexToInt().ToString() ?? "");// EnumHelper.ParseValue<PrimaryType>(HexData?.PrimaryType.HexToInt() ?? 0);
        public AudioType AudioType => EnumHelper.ParseValue<AudioType>(HexData?.AudioType.HexToInt() ?? 0);
        public DataType DataType => EnumHelper.ParseValue<DataType>(HexData?.DataType.HexToInt() ?? 0);
        public int AudioScid => HexData?.AudioScid.HexToInt() ?? 0;
        public int DataScid => HexData?.DataScid.HexToInt() ?? 0;
        public int Network => HexData?.Network.HexToInt() ?? 0;
        public int Transponder => HexData?.Transponder.HexToInt() ?? 0; //(0 to 255, corresponding to transponders 1 to 256)
        public DateTime Date => ConvertDateTime();
        public int SignalQuality => HexData?.SignalQuality.HexToInt() ?? 0; // 0-100

        private DateTime ConvertDateTime()
        {
            if (HexData == null)
                return DateTime.MinValue;
            return new DateTime(
                HexData.Year.HexToInt(), HexData.Month.HexToInt(), HexData.Day.HexToInt(),
                HexData.Hour.HexToInt(), HexData.Minute.HexToInt(), HexData.Second.HexToInt()
            );
        }

        public PrimaryStatus(Command shefResponse) : base(shefResponse)
        {
            if (ShefResponse.status.code == 200)
            {
                HexData = new PrimaryStatusBytes(ShefResponse.returnValue.data);
            }
        }

        public class PrimaryStatusBytes
        {
            public PrimaryStatusBytes(string hexString)
            {
                HexString = hexString;
            }

            public string HexString { get; }

            public string MajorChannel => HexString.Substring(0, 4);
            public string MinorChannel => HexString.Substring(4, 4);

            public string PrimaryType => HexString.Substring(8, 2);
            public string AudioType => HexString.Substring(10, 2);
            public string DataType => HexString.Substring(12, 2);

            public string PrimaryScid => HexString.Substring(14, 4);

            public string AudioScid => HexString.Substring(18, 4);

            public string DataScid => HexString.Substring(22, 4);

            public string Network => HexString.Substring(26, 4);

            public string Transponder => HexString.Substring(30, 2);

            public string Year => HexString.Substring(32, 2);
            public string Month => HexString.Substring(34, 2);
            public string Day => HexString.Substring(36, 2);
            public string Hour => HexString.Substring(38, 2);
            public string Minute => HexString.Substring(40, 2);
            public string Second => HexString.Substring(42, 2);
            public string DayOfWeek => HexString.Substring(44, 2);

            public string RomVer => HexString.Substring(46, 8);

            public string StsId => HexString.Substring(54, 8);
            public string StsVer => HexString.Substring(62, 2);

            public string CamId => HexString.Substring(64, 12);

            public string SignalQuality => HexString.Substring(76, 2);

            public string RxId => HexString.Substring(78, 12);
        }

    }
}
