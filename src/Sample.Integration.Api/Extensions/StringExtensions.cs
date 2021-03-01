using System;

namespace Sample.Integration.Api.Extensions
{
    public static class StringExtensions
    {
        /// <summary>
        /// Parse Oracle Raw(16) To DotNet Guid
        /// </summary>        
        /// <param name="text">String to convert</param>
        /// <returns>string</returns>
        public static byte[] ToByte(this string text)
        {
            byte[] ret = new byte[text.Length / 2];
            for (int i = 0; i < ret.Length; i++)
            {
                ret[i] = Convert.ToByte(text.Substring(i * 2, 2), 16);
            }
            return ret;
        }
    }
}
