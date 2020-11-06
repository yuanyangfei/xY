/*******************************************************************************
 
 *
 *
 *
*********************************************************************************/
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace NFine.Code
{
   
    public class Common
    {
    
        public static Stopwatch TimerStart()
        {
            Stopwatch watch = new Stopwatch();
            watch.Reset();
            watch.Start();
            return watch;
        }
       
        public static string TimerEnd(Stopwatch watch)
        {
            watch.Stop();
            double costtime = watch.ElapsedMilliseconds;
            return costtime.ToString();
        }
     
        public static string[] RemoveDup(string[] values)
        {
            List<string> list = new List<string>();
            for (int i = 0; i < values.Length; i++)
            {
                if (!list.Contains(values[i]))
                {
                    list.Add(values[i]);
                };
            }
            return list.ToArray();
        }
    
        public static string GuId()
        {
            return Guid.NewGuid().ToString();
        }
        public static string CreateNo()
        {
            Random random = new Random();
            string strRandom = random.Next(1000, 10000).ToString(); 
            string code = DateTime.Now.ToString("yyyyMMddHHmmss") + strRandom;
            return code;
        }

   
        public static string RndNum(int codeNum)
        {
            StringBuilder sb = new StringBuilder(codeNum);
            Random rand = new Random();
            for (int i = 1; i < codeNum + 1; i++)
            {
                int t = rand.Next(9);
                sb.AppendFormat("{0}", t);
            }
            return sb.ToString();

        }
      
        public static string DelLastComma(string str)
        {
            return str.Substring(0, str.LastIndexOf(","));
        }
      
        public static string DelLastChar(string str, string strchar)
        {
            return str.Substring(0, str.LastIndexOf(strchar));
        }
      
        public static string DelLastLength(string str, int Length)
        {
            if (string.IsNullOrEmpty(str))
                return "";
            str = str.Substring(0, str.Length - Length);
            return str;
        }
    }
}
