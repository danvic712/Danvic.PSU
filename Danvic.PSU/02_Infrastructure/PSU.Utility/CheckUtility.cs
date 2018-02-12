//-----------------------------------------------------------------------
// <copyright file= "CheckUtility.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/12 星期一 11:32:30
// Modified by:
// Description: 数据校验帮助类
//-----------------------------------------------------------------------
using System.Text.RegularExpressions;

namespace PSU.Utility
{
    public class CheckUtility
    {
        #region Service

        /// <summary>
        /// 判断Email地址是否合法
        /// </summary>
        /// <param name="address"></param>
        /// <returns></returns>
        public static bool IsEmail(string address)
        {
            return Regex.IsMatch(address, @"^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$");
        }

        /// <summary>
        /// 判断是否为Ip地址
        /// </summary>
        /// <param name="Ip"></param>
        /// <returns></returns>
        public static bool IsIpAddress(string Ip)
        {
            return !string.IsNullOrEmpty(Ip) && Regex.IsMatch(Ip.Replace(" ", ""), @"^((2[0-4]\d|25[0-5]|[01]?\d\d?)\.){1,3}(2[0-4]\d|25[0-5]|[01]?\d\d?)$");
        }

        /// <summary>
        /// 验证手机号格式是否合法
        /// </summary>
        /// <param name="phone"></param>
        /// <returns></returns>
        public static bool IsPhone(string phone)
        {
            return Regex.IsMatch(phone, @"^[1][3,5,7,9]\d{9}$");
        }

        #endregion
    }
}
