//-----------------------------------------------------------------------
// <copyright file= "BeddingInfo.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-02-19 20:43:22
// Modified by:
// Description: 新生选择卧具信息表
//-----------------------------------------------------------------------
using PSU.Entity.Admission;
using PSU.Entity.Basic;
using PSU.Utility.System;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSU.Entity.SignUp
{
    public class BeddingInfo
    {
        #region Attribute

        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public string BeddingInfoOID { get; set; }

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
        public string SName { get; set; }

        /// <summary>
        /// 选择学生学号
        /// </summary>
        [Required]
        public int SId { get; set; }

        /// <summary>
        /// 卧具类型名称
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string BName { get; set; }

        /// <summary>
        /// 卧具信息描述
        /// </summary>
        [MaxLength(200)]
        public string Description { get; set; }

        /// <summary>
        /// 选择时间
        /// </summary>
        public DateTime ChosenTime { get; set; } = DateTime.Now;

        /// <summary>
        /// 备注
        /// </summary>
        [MaxLength(200)]
        public string Remark { get; set; }

        #endregion

        #region Foreign Key

        /// <summary>
        /// 学生主键
        /// </summary>
        public string StudentFK { get; set; }

        /// <summary>
        /// 卧具信息主键
        /// </summary>
        public string BeddingFK { get; set; }

        [ForeignKey("StudentFK")]
        public virtual Student Student { get; set; }

        [ForeignKey("BeddingFK")]
        public virtual Bedding Bedding { get; set; }

        #endregion
    }
}
