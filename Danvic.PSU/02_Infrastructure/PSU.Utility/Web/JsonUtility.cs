//-----------------------------------------------------------------------
// <copyright file= "JsonUtility.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/12 星期一 11:20:54
// Modified by:
// Description: Json帮助类
//-----------------------------------------------------------------------
using Newtonsoft.Json;

namespace PSU.Utility.Web
{
    public class JsonUtility
    {
        #region Service

        /// <summary>
        /// 将T对象序列化成Json
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public static string ToJson<T>(T model)
        {
            return JsonConvert.SerializeObject(model);
        }

        /// <summary>
        /// 将Json字符串反序列化成T对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="json"></param>
        /// <returns></returns>
        public static T ToObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }

        #endregion
    }
}
