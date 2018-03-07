using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zysoft.FrameWork
{
    public static class DateTimeExtension
    {
        /// <summary>
        /// DateTime转换成日期格式字符串
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToDateString(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// DateTime转换成日期格式字符串
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static string ToTimeString(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }

        public static DateTime ToDateTime(this string value)
        {
            return Convert.ToDateTime(value);
        }
    }
}
