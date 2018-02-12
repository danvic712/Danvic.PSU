//-----------------------------------------------------------------------
// <copyright file= "StringUtility.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/2/12 星期一 11:30:51
// Modified by:
// Description: String帮助类
//-----------------------------------------------------------------------
using System.Text;

namespace PSU.Utility.System
{
    public class StringUtility
    {
        #region Service

        /// <summary>
        /// 拆分主键集合
        /// </summary>
        /// <param name="oIds"></param>
        /// <returns></returns>
        public static string SeparateOIDs(string[] oIds)
        {
            StringBuilder builder = new StringBuilder();

            for (int i = 0; i < oIds.Length; i++)
            {
                if (i > 0)
                {
                    builder.Append(",");
                }
                builder.Append("'").Append(oIds[i]).Append("'");
            }

            return builder.ToString();
        }

        #endregion
    }
}
