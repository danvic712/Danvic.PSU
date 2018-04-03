//-----------------------------------------------------------------------
// <copyright file= "GoodsViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-04-02 21:45:41
// Modified by:
// Description: Administrator-Statistics-物品预定列表页面 View Model
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;

namespace PSU.Model.Areas.Administrator.Statistics
{
    public class GoodsViewModel : PagingViewModel
    {
        #region Search

        /// <summary>
        /// 学生姓名
        /// </summary>
        public string SName { get; set; }

        /// <summary>
        /// 物品名称
        /// </summary>
        public string SGoodsName { get; set; }

        /// <summary>
        /// 选择时间
        /// </summary>
        public string SDate { get; set; }

        #endregion

        #region Result

        /// <summary>
        /// 学生选择物品列表
        /// </summary>
        public List<GoodsData> GoodsList { get; set; }

        #endregion
    }

    /// <summary>
    /// 学生物品选择信息
    /// </summary>
    public class GoodsData
    {
        #region Table

        /// <summary>
        /// 学号
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 学生姓名
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 物品编号
        /// </summary>
        public string GoodsId { get; set; }

        /// <summary>
        /// 物品名称
        /// </summary>
        public string GoodsName { get; set; }

        /// <summary>
        /// 物品尺寸
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// 选择时间
        /// </summary>
        public DateTime DateTime { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string Remark { get; set; }

        #endregion
    }
}
