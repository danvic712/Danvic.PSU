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
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PSU.Entity.SignUp
{
    public class SuitInfo
    {
        #region Constructed Function

        public SuitInfo()
        {
            SuitInfoOID = Guid.NewGuid();
            Id = TimeUtility.GetTimespans();
        }

        #endregion

        #region Attribute

        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public Guid SuitInfoOID { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        [Required]
        public int Id { get; set; }

        /// <summary>
        /// 选择学生姓名
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string SName { get; set; }

        /// <summary>
        /// 选择学生学号
        /// </summary>
        [Required]
        public int SId { get; set; }

        /// <summary>
        /// 支付类型名称
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string SuName { get; set; }

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
