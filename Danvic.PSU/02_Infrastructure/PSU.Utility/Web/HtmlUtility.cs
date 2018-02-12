//-----------------------------------------------------------------------
// <copyright file= "HtmlUtility.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/12 星期一 11:29:05
// Modified by:
// Description: Html帮助类
//-----------------------------------------------------------------------
using System.Web;

namespace PSU.Utility.Web
{
    public class HtmlUtility
    {
        #region Service

        /// <summary>
        /// 去除用户输入隐患
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string InputText(string str)
        {
            string returnVal = str;
            returnVal = ConvertStr(returnVal);
            returnVal.Replace("[url]", "");
            returnVal.Replace("[/url]", "");
            return returnVal;
        }

        /// <summary>
        /// 将存储的html代码展示在网页上
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static string OutputText(string str)
        {
            string returnVal = HttpUtility.HtmlDecode(str);
            returnVal = returnVal.Replace("<br>", "");
            returnVal = returnVal.Replace("&amp", "&;");
            returnVal = returnVal.Replace("&quot;", "\"");
            returnVal = returnVal.Replace("&lt;", "<");
            returnVal = returnVal.Replace("&gt;", ">");
            returnVal = returnVal.Replace("&nbsp;", " ");
            returnVal = returnVal.Replace("&nbsp;&nbsp;", "  ");
            return returnVal;
        }

        /// <summary>
        /// 将用户输入的字符串转换为可换行、替换Html编码、无危害数据库特殊字符、去掉首尾空白、的安全方便代码
        /// </summary>
        /// <param name="str">用户输入字符串</param>
        /// <returns></returns>
        private static string ConvertStr(string str)
        {
            string returnVal = str;
            returnVal = returnVal.Replace("\"", "&quot;");
            returnVal = returnVal.Replace("<", "&lt;");
            returnVal = returnVal.Replace(">", "&gt;");
            returnVal = returnVal.Replace(" ", "&nbsp;");
            returnVal = returnVal.Replace("  ", "&nbsp;&nbsp;");
            returnVal = returnVal.Replace("\t", "&nbsp;&nbsp;");
            returnVal = returnVal.Replace("\r", "<br>");
            return returnVal;
        }

        #endregion
    }
}
