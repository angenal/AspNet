using System;

namespace Common.Utility
{
    /// <summary>
    /// 时间类型扩展
    /// </summary>
    public static class DateTimeExtensions
    {
        /// <summary>
        /// 获取以0点0分0秒开始的日期
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateTime GetStartTime(this DateTime d)
        {
            if (d.Hour != 0)
            {
                var year = d.Year;
                var month = d.Month;
                var day = d.Day;
                var hour = "0";
                var minute = "0";
                var second = "0";
                d = Convert.ToDateTime(string.Format("{0}-{1}-{2} {3}:{4}:{5}", year, month, day, hour, minute, second));
            }
            return d;
        }

        /// <summary>
        /// 获取以23点59分59秒结束的日期
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static DateTime GetEndTime(this DateTime d)
        {
            if (d.Hour != 23)
            {
                var year = d.Year;
                var month = d.Month;
                var day = d.Day;
                var hour = "23";
                var minute = "59";
                var second = "59";
                d = Convert.ToDateTime(string.Format("{0}-{1}-{2} {3}:{4}:{5}", year, month, day, hour, minute, second));
            }
            return d;
        }


        /// <summary>
        /// 时间戳 DateTime 转化十六进制
        /// </summary>
        public static string ToTimestampHex(this DateTime dateTime, bool toSeconds = true)
        {
            return ToTimestampHex(toSeconds ? ToTimestamp(dateTime) / 1000 : ToTimestamp(dateTime));
        }

        /// <summary>
        /// 时间戳 Seconds 转化十六进制
        /// </summary>
        public static string ToTimestampHex(this long t) => t.ToString("x8").ToUpper();

        /// <summary>
        /// 时间戳 Seconds 转化时间值
        /// </summary>
        public static DateTime ToDateTime(this long t, bool toSeconds = true)
        {
            return toSeconds ? _epoch_local.AddSeconds(t) : _epoch_local.AddMilliseconds(t);
        }

        /// <summary>
        /// 时间戳 Seconds 即自1970年1月1日UTC以来经过的秒数 (等价于ToTimestampSeconds)
        /// </summary>
        public static long Unix(this DateTime dateTime) => (long)(dateTime.ToUniversalTime() - _epoch_utc).TotalSeconds;

        /// <summary>
        /// 时间戳 Seconds 即自1970年1月1日UTC以来经过的秒数 (等价于Unix)
        /// </summary>
        public static long ToTimestampSeconds(this DateTime dateTime) => ToTimestamp(dateTime) / 1000;

        /// <summary>
        /// 时间戳 Milliseconds 即自1970年1月1日UTC以来经过的毫秒数
        /// </summary>
        public static long ToTimestamp(this DateTime dateTime)
        {
#if NS2 || NETSTANDARD2_0
            return (dateTime < _epoch_local ? DateTimeOffset.Now : new DateTimeOffset(dateTime)).ToUnixTimeMilliseconds();
#else
            return (long)Math.Round(((dateTime < _epoch_local ? DateTime.Now : dateTime) - _epoch_local).TotalMilliseconds, MidpointRounding.AwayFromZero);
#endif
        }

        /// <summary>
        /// 时间戳 Nanoseconds 即自1970年1月1日UTC以来经过的纳秒数
        /// </summary>
        public static long UnixNano(this DateTime dateTime) => (dateTime.ToUniversalTime() - _epoch_utc).Ticks * 100;

        /// <summary>
        /// 时间范围值
        /// </summary>
        public static string ToDurationString(this TimeSpan duration)
        {
            var a = duration.ToString().Split(':', '.');
            int h = int.Parse(a[0]), m = int.Parse(a[1]), s = int.Parse(a[2]), ms = int.Parse(a[3].Substring(0, 3));
            return $"{(h > 0 ? h + "h" : "")}{(m > 0 ? m + "m" : "")}{(s > 0 ? s + "s" : "")}{(ms > 0 ? ms + "ms" : "")}";
        }

        private static readonly DateTime _epoch_utc = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        private static readonly DateTime _epoch_local = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1, 0, 0, 0, 0));
    }
}
