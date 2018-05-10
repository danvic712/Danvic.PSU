//-----------------------------------------------------------------------
// <copyright file= "GoodsViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-05-10 15:47:01
// Modified by:
// Description: Student-Register-物品选择页面 View Model 
//-----------------------------------------------------------------------
using System.Collections.Generic;

namespace PSU.Model.Areas.Student
{
    public class GoodsViewModel
    {
        /// <summary>
        /// 数据列表
        /// </summary>
        public List<GoodsData> GoodsList { get; set; }
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
        /// 是否选择
        /// </summary>
        public bool IsChosen { get; set; }

        #endregion
    }
}
