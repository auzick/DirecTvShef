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

        public static DateTime FromSortDate(string date)
        {
            var y = int.Parse(date.Substring(0, 4));
            var m = int.Parse(date.Substring(4, 2));
            var d = int.Parse(date.Substring(6, 2));
            return new DateTime(y, m, d);
        }
    }
}