//-----------------------------------------------------------------------
// <copyright file= "GoodsEditViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-03-31 20:58:07
// Modified by:
// Description: Administrator-Admission-物品编辑页面 View Model
//-----------------------------------------------------------------------
using System.ComponentModel.DataAnnotations;
using static PSU.Model.Areas.EnumType;

namespace PSU.Model.Areas.Administrator.Admission
{
    public class GoodsEditViewModel
    {
        #region Attribute

        /// <summary>
        /// 物品编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 物品名称
        /// </summary>
        [Required(ErrorMessage = "物品名称不能为空")]
        public string Name { get; set; }

        /// <summary>
        /// 物品描述
        /// </summary>
        [StringLength(200, ErrorMessage = "物品描述不能超过200个字符长度")]
        public string Description { get; set; }

        /// <summary>
        /// 物品尺寸
        /// </summary>
        [StringLength(60, ErrorMessage = "物品尺寸不能超过60个字符长度")]
        public string Size { get; set; }

        /// <summary>
        /// 图片地址
        /// </summary>
        public string ImageSrc { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public Enable IsEnabled { get; set; }

        #endregion
    }
}
