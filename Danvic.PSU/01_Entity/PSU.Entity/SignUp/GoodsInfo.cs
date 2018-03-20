//-----------------------------------------------------------------------
// <copyright file= "GoodsInfo.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-02-19 20:43:22
// Modified by:
// Description: 新生选择物品信息表
//-----------------------------------------------------------------------
using PSU.Utility.System;
using System;
using System.ComponentModel.DataAnnotations;

namespace PSU.Entity.SignUp
{
    public class GoodsInfo
    {
        #region Attribute

        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public string GoodsInfoOID { get; set; }

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
        public long StudentId { get; set; }

        /// <summary>
        /// 选择物品Id
        /// </summary>
        [Required]
        public long BeddingId { get; set; }

        /// <summary>
        /// 卧具物品名称
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string BeddingName { get; set; }

        /// <summary>
        /// 物品尺寸
        /// </summary>
        [MaxLength(100)]
        public string Size { get; set; }

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
    }
}
