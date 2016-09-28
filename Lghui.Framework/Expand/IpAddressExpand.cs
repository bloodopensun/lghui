using System.Net;

namespace Lghui.Framework.Expand
{
    /// <summary>
    /// IPAddress扩展
    /// </summary>
    public static class IpAddressExpand
    {
        /// <summary>
        /// IPAddress转换为long
        /// </summary>
        /// <param name="ipAddress">ipAddress</param>
        /// <returns>int</returns>
        public static long ToLong(this IPAddress ipAddress)
        {
            var bytes = ipAddress.GetAddressBytes();
            return (long)bytes[0] << 24 | (long)bytes[1] << 16 | (long)bytes[2] << 8 | bytes[3];
        }

        /// <summary>
        /// long转换为IPAddress
        /// </summary>
        /// <param name="ipLong">待转换的long</param>
        /// <returns>IPAddress</returns>
        public static IPAddress ToIpAddress(this long ipLong)
        {
            ipLong = (uint)IPAddress.HostToNetworkOrder((int)ipLong);
            return new IPAddress(ipLong);
        }
    }
}
