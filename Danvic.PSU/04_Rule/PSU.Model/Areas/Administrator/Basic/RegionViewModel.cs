//-----------------------------------------------------------------------
// <copyright file= "RegionViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018-03-31 22:11:47
// Modified by:
// Description: Administrator-Basic-地区信息列表页面 View Model
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace PSU.Model.Areas.Administrator.Basic
{
    public class RegionViewModel : PagingViewModel
    {
        #region Search

        /// <summary>
        /// 地区编号
        /// </summary>
        public string SId { get; set; }

        /// <summary>
        /// 地区名称
        /// </summary>
        public string SName { get; set; }

        /// <summary>
        /// 地区级别
        /// </summary>
        public short SLevel { get; set; }

        #endregion

        #region Result

        /// <summary>
        /// 地区数据列表
        /// </summary>
        public List<RegionData> RegionList { get; set; }

        #endregion
    }

    /// <summary>
    /// 地区数据
    /// </summary>
    public class RegionData
    {
        #region Table

        /// <summary>
        /// 编号
        /// </summary>
        public string Id { get; set; }

        #endregion
    }
}
