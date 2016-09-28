using System;

namespace Lghui.Framework.Expand
{
    /// <summary>
    /// DateTime扩展
    /// </summary>
    public static class DateTimeExpand
    {
        /// <summary>
        /// 转换为时间戳
        /// </summary>
        /// <param name="time">待转换DateTime</param>
        /// <returns>时间戳</returns>
        public static double ToTimeStamp(this DateTime time)
        {
            var startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            return (time - startTime).TotalMilliseconds;
        }

        /// <summary>
        /// 转换为DateTime
        /// </summary>
        /// <param name="timeStamp">待转换时间戳</param>
        /// <returns>DateTime</returns>
        public static DateTime ToDateTime(this double timeStamp)
        {
            var startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            return startTime.AddMilliseconds(timeStamp);
        }
    }
}
