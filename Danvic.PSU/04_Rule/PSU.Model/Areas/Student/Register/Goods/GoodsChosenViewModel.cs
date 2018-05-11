//-----------------------------------------------------------------------
// <copyright file= "GoodsChosenViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-05-10 22:45:18
// Modified by:
// Description: Student-Register-新生物品选择页面 View Model 
//-----------------------------------------------------------------------
using System;
using System.ComponentModel.DataAnnotations;

namespace PSU.Model.Areas.Student
{
    public class GoodsChosenViewModel
    {
        #region Attribute

        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 选择物品Id
        /// </summary>
        public string GoodsId { get; set; }

        /// <summary>
        /// 物品名称
        /// </summary>
        public string GoodsName { get; set; }

        /// <summary>
        /// 选择时间
        /// </summary>
        public DateTime ChosenTime { get; set; }

        /// <summary>
        /// 物品尺寸
        /// </summary>
        [StringLength(100, ErrorMessage = "物品尺寸字段不能超过100个字符长度")]
        public string Size { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        [StringLength(200, ErrorMessage = "备注字段不能超过200个字符长度")]
        public string Remark { get; set; }

        #endregion
    }
}
