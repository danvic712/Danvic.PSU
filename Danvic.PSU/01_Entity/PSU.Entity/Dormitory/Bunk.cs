//-----------------------------------------------------------------------
// <copyright file= "Bunk.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-02-19 20:40:58
// Modified by:
// Description: 寝室类型表
//-----------------------------------------------------------------------
using PSU.Utility.System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PSU.Entity.Dormitory
{
    public class Bunk : SysField
    {
        #region Attribute

        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public string BunkOID { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        [Required]
        public long Id { get; set; } = TimeUtility.GetTimespans();

        /// <summary>
        /// 寝室类型名称
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        /// <summary>
        /// 可容纳人数
        /// </summary>
        [Required]
        [MaxLength(10)]
        public string Number { get; set; }

        /// <summary>
        /// 朝向
        /// </summary>
        [Required]
        [MaxLength(20)]
        public string Toward { get; set; }

        /// <summary>
        /// 类型示意图地址
        /// </summary>
        [MaxLength(500)]
        public string ImageSrc { get; set; }

        /// <summary>
        /// 类型示意图二进制流
        /// </summary>
        public byte Image { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnabled { get; set; }

        #endregion
    }
}
