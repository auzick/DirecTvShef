using System;

namespace Shef
{
    public static class DateTimeHelpers
    {
        private static readonly DateTime UnixEpoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        public static long ToUnixTime(this DateTime date)
        {
            return Convert.ToInt64((date.ToUniversalTime() - UnixEpoch).TotalSeconds);
        }

        public static DateTime FromUnixTime(this double unixTime)
        {
            return UnixEpoch.AddSeconds(unixTime);
        }
        public static DateTime FromUnixTime(this long unixTime)
        {
            return UnixEpoch.AddSeconds(unixTime);
        }
    }
}