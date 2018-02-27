//-----------------------------------------------------------------------
// <copyright file= "SuitInfo.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-02-19 20:44:34
// Modified by:
// Description: 新生选择制服信息表
//-----------------------------------------------------------------------
using PSU.Utility.System;
using System;
using System.ComponentModel.DataAnnotations;

namespace PSU.Entity.SignUp
{
    public class SuitInfo
    {
        #region Attribute

        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public string SuitInfoOID { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        [Required]
        public long Id { get; set; } = TimeUtility.GetTimespans();

        /// <summary>
        /// 选择学生姓名
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string StudentName { get; set; }

        /// <summary>
        /// 选择学生学号
        /// </summary>
        [Required]
        public int StudentId { get; set; }

        /// <summary>
        /// 制服Id
        /// </summary>
        [Required]
        public long SuitId { get; set; }

        /// <summary>
        /// 制服类型名称
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string SuitName { get; set; }

        /// <summary>
        /// 上衣尺寸
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string CoatSize { get; set; }

        /// <summary>
        /// 裤子尺寸
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string PantsSize { get; set; }

        /// <summary>
        /// 预定时间
        /// </summary>
        public DateTime ScheduledTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        #endregion
    }
}
