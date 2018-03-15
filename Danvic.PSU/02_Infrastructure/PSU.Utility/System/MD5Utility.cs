//-----------------------------------------------------------------------
// <copyright file= "MD5Utility.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/12 星期一 11:27:59
// Modified by:
// Description: MD5
//-----------------------------------------------------------------------

using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace PSU.Utility.System
{
    public class MD5Utility
    {
        #region Service

        /// <summary>
        /// 创建SALT加密字符串
        /// </summary>
        /// <param name="item">需要加密的字符串</param>
        /// <param name="salt">加密的参数</param>
        /// <returns></returns>
        public static string Sign(string item, string salt = "")
        {
            var md5 = new MD5CryptoServiceProvider();

            if (!string.IsNullOrEmpty(salt))
                item = item + "{" + salt.Trim() + "}";

            var bt = Encoding.Default.GetBytes(item);
            var b = md5.ComputeHash(bt);

            return b.Aggregate("", (current, t) => current + t.ToString("X").PadLeft(2, '0'));
        }

        /// <summary>
        /// 验证签名
        /// </summary>
        /// <param name="prestr">需要签名的字符串</param>
        /// <param name="sign">签名结果</param>
        /// <param name="key">密钥</param>
        /// <returns>验证结果</returns>
        public static bool Verify(string prestr, string sign, string key)
        {
            var mysign = Sign(prestr, key);
            return mysign == sign ? true : false;
        }

        #endregion
    }
}
