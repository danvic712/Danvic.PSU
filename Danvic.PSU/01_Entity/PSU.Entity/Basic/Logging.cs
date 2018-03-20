//-----------------------------------------------------------------------
// <copyright file= "Logging.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/3/1 星期四 14:49:33
// Modified by:
// Description: 登录日志记录
//-----------------------------------------------------------------------
using PSU.Utility.System;
using System;
using System.ComponentModel.DataAnnotations;

namespace PSU.Entity.Basic
{
    public class Logging
    {
        #region Attribute

        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public string LoggingOID { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        [Required]
        public long Id { get; set; } = TimeUtility.GetTimespans();

        /// <summary>
        /// 用户编号
        /// </summary>
        [Required]
        public long UserId { get; set; }

        /// <summary>
        /// 用户姓名
        /// </summary>
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// 用户Ip地址
        /// </summary>
        public string IpAddress { get; set; }

        /// <summary>
        /// 用户登录时间
        /// </summary>
        public DateTime DateTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 浏览器信息
        /// </summary>
        public string Browser { get; set; }

        /// <summary>
        /// 操作系统版本
        /// </summary>
        public string System { get; set; }

        /// <summary>
        /// 屏幕分辨率
        /// </summary>
        public string Screen { get; set; }

        #endregion
    }
}
