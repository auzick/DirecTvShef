using System;
using System.Linq;

namespace Shef
{
    public static class StringHelpers
    {
        public static byte[] HexToByteArray(this string hex)
        {
            return Enumerable.Range(0, hex.Length)
                .Where(x => x % 2 == 0)
                .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                .ToArray();
        }

        //public static decimal HexToDecimal(this string hex)
        //{
        //    return Convert.ToInt32(hex, 16);

        //    // https://theburningmonk.com/2010/02/converting-hex-to-int-in-csharp/
        //    //return int.Parse(hex, System.Globalization.NumberStyles.HexNumber);

        //}

        public static int HexToInt(this string hex)
        {
            return Convert.ToInt32(hex, 16);
        }

    }
}
