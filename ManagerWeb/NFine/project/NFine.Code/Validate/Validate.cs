﻿/*******************************************************************************
 
 *
 *
 *
*********************************************************************************/
using System.Text;
using System.Text.RegularExpressions;

namespace NFine.Code
{
    public class Validate
    {
        private static Regex RegNumber = new Regex("^[0-9]+$");
        private static Regex RegNumberSign = new Regex("^[+-]?[0-9]+$");
        private static Regex RegDecimal = new Regex("^[0-9]+[.]?[0-9]+$");
        private static Regex RegDecimalSign = new Regex("^[+-]?[0-9]+[.]?[0-9]+$");
        private static Regex RegEmail = new Regex(@"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$");
        private static Regex RegCHZN = new Regex("[\u4e00-\u9fa5]");

        public static int GetStringLength(string stringValue)
        {
            return Encoding.Default.GetBytes(stringValue).Length;
        }

        public static bool IsValidUserName(string userName)
        {
            int userNameLength = GetStringLength(userName);
            if (userNameLength >= 4 && userNameLength <= 20 && Regex.IsMatch(userName, @"^([\u4e00-\u9fa5A-Za-z_0-9]{0,})$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool IsValidPassword(string password)
        {
            return Regex.IsMatch(password, @"^[A-Za-z_0-9]{6,16}$");
        }


        static public bool IsValidInt(string val)
        {
            return Regex.IsMatch(val, @"^[1-9]\d*\.?[0]*$");
        }

        public static bool IsNumber(string inputData)
        {
            Match m = RegNumber.Match(inputData);
            return m.Success;
        }

        public static bool IsNumberSign(string inputData)
        {
            Match m = RegNumberSign.Match(inputData);
            return m.Success;
        }

        public static bool IsDecimal(string inputData)
        {
            Match m = RegDecimal.Match(inputData);
            return m.Success;
        }
        public static bool IsDecimalSign(string inputData)
        {
            Match m = RegDecimalSign.Match(inputData);
            return m.Success;
        }


        public static bool IsHasCHZN(string inputData)
        {
            Match m = RegCHZN.Match(inputData);
            return m.Success;
        }

        public static int GetCHZNLength(string inputData)
        {
            System.Text.ASCIIEncoding n = new System.Text.ASCIIEncoding();
            byte[] bytes = n.GetBytes(inputData);

            int length = 0; //
            for (int i = 0; i <= bytes.Length - 1; i++)
            {
                if (bytes[i] == 63) //
                {
                    length++;
                }
                length++;
            }
            return length;

        }


        public static bool IsIdCard(string idCard)
        {
            if (string.IsNullOrEmpty(idCard))
            {
                return false;
            }

            if (idCard.Length == 15)
            {
                return Regex.IsMatch(idCard, @"^[1-9]\d{7}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])\d{3}$");
            }
            else if (idCard.Length == 18)
            {
                return Regex.IsMatch(idCard, @"^[1-9]\d{5}[1-9]\d{3}((0\d)|(1[0-2]))(([0|1|2]\d)|3[0-1])((\d{4})|\d{3}[A-Z])$", RegexOptions.IgnoreCase);
            }
            else
            {
                return false;
            }
        }

        public static bool IsEmail(string inputData)
        {
            Match m = RegEmail.Match(inputData);
            return m.Success;
        }

        public static bool IsValidZip(string zip)
        {
            Regex rx = new Regex(@"^\d{6}$", RegexOptions.None);
            Match m = rx.Match(zip);
            return m.Success;
        }

        public static bool IsValidPhone(string phone)
        {
            Regex rx = new Regex(@"^(\(\d{3,4}\)|\d{3,4}-)?\d{7,8}$", RegexOptions.None);
            Match m = rx.Match(phone);
            return m.Success;
        }

        public static bool IsValidMobile(string mobile)
        {
            Regex rx = new Regex(@"^(13|15|17|18|19)\d{9}$", RegexOptions.None);
            Match m = rx.Match(mobile);
            return m.Success;
        }

        public static bool IsValidPhoneAndMobile(string number)
        {
            Regex rx = new Regex(@"^(\(\d{3,4}\)|\d{3,4}-)?\d{7,8}$|^(13|15)\d{9}$", RegexOptions.None);
            Match m = rx.Match(number);
            return m.Success;
        }

        static public bool IsValidURL(string url)
        {
            return Regex.IsMatch(url, @"^(http|https|ftp)\://[a-zA-Z0-9\-\.]+\.[a-zA-Z]{2,3}(:[a-zA-Z0-9]*)?/?([a-zA-Z0-9\-\._\?\,\'/\\\+&%\$#\=~])*[^\.\,\)\(\s]$");
        }

        public static bool IsValidIP(string ip)
        {
            return Regex.IsMatch(ip, @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }

        public static bool IsValidDomain(string host)
        {
            Regex r = new Regex(@"^\d+$");
            if (host.IndexOf(".") == -1)
            {
                return false;
            }
            return r.IsMatch(host.Replace(".", string.Empty)) ? false : true;
        }

        public static bool IsBase64String(string str)
        {
            return Regex.IsMatch(str, @"[A-Za-z0-9\+\/\=]");
        }

        public static bool IsGuid(string guid)
        {
            if (string.IsNullOrEmpty(guid))
                return false;

            return Regex.IsMatch(guid, "[A-F0-9]{8}(-[A-F0-9]{4}){3}-[A-F0-9]{12}|[A-F0-9]{32}", RegexOptions.IgnoreCase);
        }


        public static bool IsDate(string strValue)
        {
            return Regex.IsMatch(strValue, @"^((\d{2}(([02468][048])|([13579][26]))[\-\/\s]?((((0?[13578])|(1[02]))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(3[01])))|(((0?[469])|(11))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(30)))|(0?2[\-\/\s]?((0?[1-9])|([1-2][0-9])))))|(\d{2}(([02468][1235679])|([13579][01345789]))[\-\/\s]?((((0?[13578])|(1[02]))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(3[01])))|(((0?[469])|(11))[\-\/\s]?((0?[1-9])|([1-2][0-9])|(30)))|(0?2[\-\/\s]?((0?[1-9])|(1[0-9])|(2[0-8]))))))");
        }


        public static bool IsDateHourMinute(string strValue)
        {
            return Regex.IsMatch(strValue, @"^(19[0-9]{2}|[2-9][0-9]{3})-((0(1|3|5|7|8)|10|12)-(0[1-9]|1[0-9]|2[0-9]|3[0-1])|(0(4|6|9)|11)-(0[1-9]|1[0-9]|2[0-9]|30)|(02)-(0[1-9]|1[0-9]|2[0-9]))\x20(0[0-9]|1[0-9]|2[0-3])(:[0-5][0-9]){1}$");
        }

        public static string CheckMathLength(string inputData, int maxLength)
        {
            if (inputData != null && inputData != string.Empty)
            {
                inputData = inputData.Trim();
                if (inputData.Length > maxLength)//
                {
                    inputData = inputData.Substring(0, maxLength);
                }
            }
            return inputData;
        }

        public static string Encode(string str)
        {
            str = str.Replace("&", "&amp;");
            str = str.Replace("'", "''");
            str = str.Replace("\"", "&quot;");
            str = str.Replace(" ", "&nbsp;");
            str = str.Replace("<", "&lt;");
            str = str.Replace(">", "&gt;");
            str = str.Replace("\n", "<br>");
            return str;
        }
        public static string Decode(string str)
        {
            str = str.Replace("<br>", "\n");
            str = str.Replace("&gt;", ">");
            str = str.Replace("&lt;", "<");
            str = str.Replace("&nbsp;", " ");
            str = str.Replace("&quot;", "\"");
            return str;
        }
    }
}
