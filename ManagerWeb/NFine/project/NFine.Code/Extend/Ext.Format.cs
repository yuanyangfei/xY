/*******************************************************************************
 
 *
 *
 *
*********************************************************************************/
namespace NFine.Code
{
    public static partial class Ext
    {
        public static string Description(this bool value)
        {
            return value ? "1" : "0";
        }
        public static string Description(this bool? value)
        {
            return value == null ? "" : Description(value.Value);
        }
        public static string Format(this int number, string defaultValue = "")
        {
            if (number == 0)
                return defaultValue;
            return number.ToString();
        }
        public static string Format(this int? number, string defaultValue = "")
        {
            return Format(number.SafeValue(), defaultValue);
        }
        public static string Format(this decimal number, string defaultValue = "")
        {
            if (number == 0)
                return defaultValue;
            return string.Format("{0:0.##}", number);
        }
        public static string Format(this decimal? number, string defaultValue = "")
        {
            return Format(number.SafeValue(), defaultValue);
        }
        public static string Format(this double number, string defaultValue = "")
        {
            if (number == 0)
                return defaultValue;
            return string.Format("{0:0.##}", number);
        }
        public static string Format(this double? number, string defaultValue = "")
        {
            return Format(number.SafeValue(), defaultValue);
        }
        public static string FormatRmb(this decimal number)
        {
            if (number == 0)
                return "￥0";
            return string.Format("￥{0:0.##}", number);
        }
        public static string FormatRmb(this decimal? number)
        {
            return FormatRmb(number.SafeValue());
        }
        public static string FormatPercent(this decimal number)
        {
            if (number == 0)
                return string.Empty;
            return string.Format("{0:0.##}%", number);
        }
        public static string FormatPercent(this decimal? number)
        {
            return FormatPercent(number.SafeValue());
        }
        public static string FormatPercent(this double number)
        {
            if (number == 0)
                return string.Empty;
            return string.Format("{0:0.##}%", number);
        }
        public static string FormatPercent(this double? number)
        {
            return FormatPercent(number.SafeValue());
        }
    }
}
