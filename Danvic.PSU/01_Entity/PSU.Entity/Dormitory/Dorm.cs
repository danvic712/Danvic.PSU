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
        /// 寝室名
        /// </summary>
        [Required]
        public string Name { get; set; }

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
        public int Floor { get; set; }

        /// <summary>
        /// 寝室类型
        /// 1:4人间;2:6人间;3:8人间;4:套房;5:其它
        /// </summary>
        public short Type { get; set; }

        /// <summary>
        /// 可容纳人数
        /// </summary>
        [Required]
        public int Count { get; set; }

        /// <summary>
        /// 已选择人数
        /// </summary>
        public int SelectedCount { get; set; }

        /// <summary>
        /// 寝室是否人数已满
        /// </summary>
        public bool IsSelectedAll { get; set; }

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

        [ForeignKey("BuildingFK")]
        public virtual Building Building { get; set; }

        #endregion
    }
}
