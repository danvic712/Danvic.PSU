//-----------------------------------------------------------------------
// <copyright file= "ServiceInfo.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-02-19 20:44:20
// Modified by:
// Description: 新生服务预定表
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
        /// 学生学号
        /// </summary>
        [Required]
        public long StudentId { get; set; }

        /// <summary>
        /// 学生姓名
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// 联系方式
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Tel { get; set; }

        /// <summary>
        /// 人数
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// 预定时间
        /// </summary>
        public DateTime ScheduledTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 服务编号
        /// </summary>
        [Required]
        public long ServiceId { get; set; }

        /// <summary>
        /// 服务名称
        /// </summary>
        [Required]
        [MaxLength(30)]
        public string ServiceName { get; set; }

        /// <summary>
        /// 服务时间
        /// </summary>
        public DateTime DepartureTime { get; set; }

        /// <summary>
        /// 服务地点
        /// </summary>
        [MaxLength(20)]
        public string Place { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(200)]
        public string Remark { get; set; }

        /// <summary>
        /// 是否取消
        /// </summary>
        public bool IsCancel { get; set; }

        #endregion
    }
}
