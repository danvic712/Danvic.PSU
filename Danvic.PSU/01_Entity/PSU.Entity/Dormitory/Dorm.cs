//-----------------------------------------------------------------------
// <copyright file= "Dorm.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-02-19 20:41:26
// Modified by:
// Description: 寝室信息表
//-----------------------------------------------------------------------
using PSU.Utility.System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSU.Entity.Dormitory
{
    public class Dorm : SysField
    {
        #region Attribute

        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public string DormOID { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        public long Id { get; set; } = TimeUtility.GetTimespans();

        /// <summary>
        /// 宿舍号
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// 寝室楼编号
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
        /// 楼层
        /// </summary>
        [Required]
        public short Floor { get; set; }

        /// <summary>
        /// 寝室类型编号
        /// </summary>
        [Required]
        public long BunkId { get; set; }

        /// <summary>
        /// 寝室类型名称
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string BunkName { get; set; }

        /// <summary>
        /// 可容纳人数
        /// </summary>
        [Required]
        public short Count { get; set; }

        /// <summary>
        /// 已选择人数
        /// </summary>
        public short SelectedCount { get; set; }

        /// <summary>
        /// 寝室楼类型
        /// 1:male;2:female;3:remix
        /// </summary>
        [Required]
        public short Type { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnabled { get; set; }

        #endregion

        #region Foreign Key

        /// <summary>
        /// 寝室楼主键
        /// </summary>
        public string BuildingFK { get; set; }

        /// <summary>
        /// 寝室类型主键
        /// </summary>
        public string BunkFK { get; set; }

        [ForeignKey("BuildingFK")]
        public virtual Building Building { get; set; }

        [ForeignKey("BunkFK")]
        public virtual Bunk Bunk { get; set; }

        #endregion
    }
}
