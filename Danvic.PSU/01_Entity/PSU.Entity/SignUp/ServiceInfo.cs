//-----------------------------------------------------------------------
// <copyright file= "ServiceInfo.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-02-19 20:44:20
// Modified by:
// Description: 新生车辆服务预定表
//-----------------------------------------------------------------------
using PSU.Utility.System;
using System;
using System.ComponentModel.DataAnnotations;

namespace PSU.Entity.SignUp
{
    public class ServiceInfo
    {
        #region Attribute

        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public string ServiceInfoOID { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        [Required]
        public long Id { get; set; } = TimeUtility.GetTimespans();

        /// <summary>
        /// 预订人姓名
        /// </summary>
        [MaxLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// 联系方式
        /// </summary>
        public int Tel { get; set; }

        /// <summary>
        /// 人数
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 预定时间
        /// </summary>
        public DateTime ScheduledTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 预计出发时间
        /// </summary>
        public DateTime DepartureTime { get; set; }

        /// <summary>
        /// 出发地点
        /// </summary>
        [MaxLength(20)]
        public string Place { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        /// <summary>
        /// 是否取消
        /// </summary>
        public bool IsCancel { get; set; }

        #endregion
    }
}
