//-----------------------------------------------------------------------
// <copyright file= "BunkInfo.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-02-19 20:43:40
// Modified by:
// Description: 新生寝室选择信息表
//-----------------------------------------------------------------------

using System;
using PSU.Utility.System;
using System.ComponentModel.DataAnnotations;

namespace PSU.Entity.SignUp
{
    public class BunkInfo
    {
        #region Attribute

        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public string BunkInfoOID { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        [Required]
        public long Id { get; set; } = TimeUtility.GetTimespans();

        /// <summary>
        /// 学生姓名
        /// 张三|李四...
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string StudentName { get; set; }

        /// <summary>
        /// 学生学号
        /// 20171222104569|20180214053521
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string StudentId { get; set; }

        /// <summary>
        /// 可容纳人数
        /// </summary>
        [Required]
        public int Count { get; set; }

        /// <summary>
        /// 已选择人数
        /// </summary>
        [Required]
        public int Chosen { get; set; }

        /// <summary>
        /// 寝室楼Id
        /// </summary>
        [Required]
        public long BuildingId { get; set; }

        /// <summary>
        /// 寝室楼名称
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string BuildingName { get; set; }

        /// <summary>
        /// 寝室所在楼层数
        /// </summary>
        [Required]
        public int Floor { get; set; }

        /// <summary>
        /// 寝室Id
        /// </summary>
        [Required]
        public long DormId { get; set; }

        /// <summary>
        /// 寝室名称
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string DormName { get; set; }
        
        /// <summary>
        /// 完成选择时间
        /// </summary>
        public DateTime DateTime { get; set; }

        #endregion
    }
}
