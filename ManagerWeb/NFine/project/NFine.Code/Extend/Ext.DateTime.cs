/*******************************************************************************
 
 *
 *
 *
*********************************************************************************/
using System;
using System.Text;

namespace NFine.Code
{
    public static partial class Ext
    {
        public static string ToDateTimeString(this DateTime dateTime, bool isRemoveSecond = false)
        {
            if (isRemoveSecond)
                return dateTime.ToString("yyyy-MM-dd HH:mm");
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss");
        }
        
        public static string ToDateTimeString(this DateTime? dateTime, bool isRemoveSecond = false)
        {
            if (dateTime == null)
                return string.Empty;
            return ToDateTimeString(dateTime.Value, isRemoveSecond);
        }
        
        public static string ToDateString(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd");
        }
        public static string ToDateString()
        {
            return DateTime.Now.ToString("yyyy-MM-dd");
        }
        
        public static string ToDateString(this DateTime? dateTime)
        {
            if (dateTime == null)
                return string.Empty;
            return ToDateString(dateTime.Value);
        }
        
        public static string ToTimeString(this DateTime dateTime)
        {
            return dateTime.ToString("HH:mm:ss");
        }
        
        public static string ToTimeString(this DateTime? dateTime)
        {
            if (dateTime == null)
                return string.Empty;
            return ToTimeString(dateTime.Value);
        }
        
        public static string ToMillisecondString(this DateTime dateTime)
        {
            return dateTime.ToString("yyyy-MM-dd HH:mm:ss.fff");
        }
        
        public static string ToMillisecondString(this DateTime? dateTime)
        {
            if (dateTime == null)
                return string.Empty;
            return ToMillisecondString(dateTime.Value);
        }
        
        public static string ToChineseDateString(this DateTime dateTime)
        {
            return string.Format("{0}年{1}月{2}日", dateTime.Year, dateTime.Month, dateTime.Day);
        }
        
        public static string ToChineseDateString(this DateTime? dateTime)
        {
            if (dateTime == null)
                return string.Empty;
            return ToChineseDateString(dateTime.SafeValue());
        }
        
        public static string ToChineseDateTimeString(this DateTime dateTime, bool isRemoveSecond = false)
        {
            StringBuilder result = new StringBuilder();
            result.AppendFormat("{0}年{1}月{2}日", dateTime.Year, dateTime.Month, dateTime.Day);
            result.AppendFormat(" {0}时{1}分", dateTime.Hour, dateTime.Minute);
            if (isRemoveSecond == false)
                result.AppendFormat("{0}秒", dateTime.Second);
            return result.ToString();
        }
        
        public static string ToChineseDateTimeString(this DateTime? dateTime, bool isRemoveSecond = false)
        {
            if (dateTime == null)
                return string.Empty;
            return ToChineseDateTimeString(dateTime.Value);
        }
    }
}
