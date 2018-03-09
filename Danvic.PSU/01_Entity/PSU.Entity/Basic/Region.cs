//-----------------------------------------------------------------------
// <copyright file= "Region.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-02-19 20:39:43
// Modified by:
// Description: 地区信息表
//-----------------------------------------------------------------------
using PSU.Utility.System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSU.Entity.Basic
{
    public class Region : SysField
    {
        #region Attribute

        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public string RegionOID { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        [Required]
        public long Id { get; set; } = TimeUtility.GetTimespans();

        /// <summary>
        /// 地区名称
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        /// <summary>
        /// 父级地区名称
        /// </summary>
        [Required]
        [MaxLength(50)]
        public string ParentName { get; set; }

        /// <summary>
        /// 地区级别
        /// </summary>
        public short Level { get; set; }

        #endregion

        #region Foreign Key

        /// <summary>
        /// 父级地区主键
        /// </summary>
        public string ParentFK { get; set; }

        [ForeignKey("ParentFK")]
        public virtual Region ParentRegion { get; set; }

        #endregion
    }
}
