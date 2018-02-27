//-----------------------------------------------------------------------
// <copyright file= "BunkInfo.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-02-19 20:43:40
// Modified by:
// Description: 新生选择床铺信息表
//-----------------------------------------------------------------------
using PSU.Utility.System;
using System;
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
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string StudentName { get; set; }

        /// <summary>
        /// 学生学号
        /// </summary>
        [Required]
        public long StudentId { get; set; }

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
        /// 床铺Id
        /// </summary>
        [Required]
        public long BunkId { get; set; }

        /// <summary>
        /// 床铺号
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string BunkNumber { get; set; }

        /// <summary>
        /// 选择时间
        /// </summary>
        public DateTime ChosenTime { get; set; } = DateTime.Now;

        #endregion
    }
}
