//-----------------------------------------------------------------------
// <copyright file= "Goods.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-02-19 20:34:02
// Modified by:
// Description: 物品信息表
//-----------------------------------------------------------------------
using PSU.Utility.System;
using System.ComponentModel.DataAnnotations;

namespace PSU.Entity.Admission
{
    public class Goods : SysField
    {
        #region Attribute

        /// <summary>
        /// 主键
        /// </summary>
        [Key]
        public string GoodsOID { get; set; }

        /// <summary>
        /// 编号
        /// </summary>
        [Required]
        public long Id { get; set; } = TimeUtility.GetTimespans();

        /// <summary>
        /// 物品名称
        /// </summary>
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        /// <summary>
        /// 物品描述
        /// </summary>
        [MaxLength(200)]
        public string Description { get; set; }

        /// <summary>
        /// 物品尺寸
        /// </summary>
        [MaxLength(100)]
        public string Size { get; set; }

        /// <summary>
        /// 图片地址
        /// </summary>
        public string ImageSrc { get; set; }

        /// <summary>
        /// 图片二进制流
        /// </summary>
        public byte Image { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnabled { get; set; }

        #endregion
    }
}
