using System;
using System.Text;

namespace EndpointWithDelayHelper
{
    public static class Encoder
    {
        public static string ToBase64(this string value)
        {
            byte[] toEncodeAsBytes = Encoding.ASCII.GetBytes(value);
            return Convert.ToBase64String(toEncodeAsBytes);
        }
    }
}
