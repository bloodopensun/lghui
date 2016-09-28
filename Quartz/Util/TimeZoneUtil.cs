using System;

namespace Quartz.Util
{
    public static class TimeZoneUtil
    {
        /// <summary>
        /// TimeZoneInfo.ConvertTime is not supported under mono
        /// </summary>
        /// <param name="dateTimeOffset"></param>
        /// <param name="timeZoneInfo"></param>
        /// <returns></returns>
        public static DateTimeOffset ConvertTime(DateTimeOffset dateTimeOffset, TimeZoneInfo timeZoneInfo)
        {
            if (QuartzEnvironment.IsRunningOnMono)
            {
                return TimeZoneInfo.ConvertTimeFromUtc(dateTimeOffset.UtcDateTime, timeZoneInfo);
            }

            return TimeZoneInfo.ConvertTime(dateTimeOffset, timeZoneInfo);
        }

        /// <summary>
        /// TimeZoneInfo.GetUtcOffset(DateTimeOffset) is not supported under mono
        /// </summary>
        /// <param name="dateTimeOffset"></param>
        /// <param name="timeZoneInfo"></param>
        /// <returns></returns>
        public static TimeSpan GetUtcOffset(DateTimeOffset dateTimeOffset, TimeZoneInfo timeZoneInfo)
        {
            if (QuartzEnvironment.IsRunningOnMono)
            {
                return timeZoneInfo.GetUtcOffset(dateTimeOffset.UtcDateTime);
            }

            return timeZoneInfo.GetUtcOffset(dateTimeOffset);
        }

        /// <summary>
        /// Tries to find time zone with given id, has ability do some fallbacks when necessary.
        /// </summary>
        /// <param name="id">System id of the time zone.</param>
        /// <returns></returns>
        public static TimeZoneInfo FindTimeZoneById(string id)
        {
            var info = TimeZoneInfo.FromSerializedString(id);

            return info;
        }
    }
}