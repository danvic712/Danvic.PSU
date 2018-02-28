//-----------------------------------------------------------------------
// <copyright file= "ByteUtility.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/28 星期三 11:05:02
// Modified by:
// Description: Byte数组与对象转换
//-----------------------------------------------------------------------
using Newtonsoft.Json;
using System.Text;

namespace PSU.Utility.System
{
    public class ByteUtility
    {
        #region Service

        /// <summary>
        /// 将对象转换为byte数组
        /// </summary>
        /// <param name="obj">被转换对象</param>
        /// <returns>转换后byte数组</returns>
        public static byte[] Object2Bytes(object obj)
        {
            string json = JsonConvert.SerializeObject(obj);
            byte[] serializedResult = Encoding.UTF8.GetBytes(json);
            return serializedResult;
        }

        /// <summary>
        /// 将byte数组转换成对象
        /// </summary>
        /// <param name="buff">被转换byte数组</param>
        /// <returns>转换完成后的对象</returns>
        public static object Bytes2Object(byte[] buff)
        {
            string json = Encoding.UTF8.GetString(buff);
            return JsonConvert.DeserializeObject<object>(json);
        }

        /// <summary>
        /// 将byte数组转换成对象
        /// </summary>
        /// <param name="buff">被转换byte数组</param>
        /// <returns>转换完成后的对象</returns>
        public static T Bytes2Object<T>(byte[] buff)
        {
            string json = Encoding.UTF8.GetString(buff);
            return JsonConvert.DeserializeObject<T>(json);
        }

        #endregion
    }
}
