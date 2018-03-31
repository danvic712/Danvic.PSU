//-----------------------------------------------------------------------
// <copyright file= "GoodsViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-03-31 20:53:21
// Modified by:
// Description: Administrator-Admission-物品列表页面 View Model
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace PSU.Model.Areas.Administrator.Admission
{
    public class GoodsViewModel : PagingViewModel
    {
        #region Search

        /// <summary>
        /// 物品名称
        /// </summary>
        public string SName { get; set; }

        /// <summary>
        /// 物品编号
        /// </summary>
        public string SId { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public short SEnable { get; set; }

        #endregion

        #region Result

        /// <summary>
        /// 数据列表
        /// </summary>
        public List<GoodsData> GoodsList { get; set; }

        #endregion
    }

    /// <summary>
    /// 物品列表数据
    /// </summary>
    public class GoodsData
    {
        #region Table

        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 物品名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 物品描述
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// 物品尺寸
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// 图片地址
        /// </summary>
        public string ImageSrc { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnabled { get; set; }

        public string IsEnabledStr => IsEnabled ? "启用" : "未启用";

        #endregion
    }
}
