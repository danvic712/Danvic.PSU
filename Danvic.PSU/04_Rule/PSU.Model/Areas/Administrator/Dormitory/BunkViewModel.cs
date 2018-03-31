//-----------------------------------------------------------------------
// <copyright file= "BunkViewModel.cs">
//     Copyright (c) Danvic712. All rights reserved.
// </copyright>
// Author: Danvic712
// Date Created: 2018/3/28 星期三 11:15:20
// Modified by:
// Description: Administrator-Dormitory-宿舍类型信息页面 View Model
//-----------------------------------------------------------------------
using System.Collections.Generic;

namespace PSU.Model.Areas.Administrator.Dormitory
{
    public class BunkViewModel : PagingViewModel
    {
        #region Search

        /// <summary>
        /// 寝室类型名称
        /// </summary>
        public string SName { get; set; }

        /// <summary>
        /// 寝室朝向
        /// </summary>
        public string SDirection { get; set; }

        /// <summary>
        /// 是否启用
        /// </summary>
        public short SEnable { get; set; }

        #endregion

        #region Result

        /// <summary>
        /// 寝室类型列表
        /// </summary>
        public List<BunkData> BunkList { get; set; }

        #endregion
    }

    /// <summary>
    /// 数据列表展示
    /// </summary>
    public class BunkData
    {
        #region Table

        /// <summary>
        /// 宿舍类型编号
        /// 此处使用string传递防止进制转换
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// 宿舍类型名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 可容纳人数
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 朝向
        /// </summary>
        public string Toward { get; set; }

        /// <summary>
        /// 类型示意图地址
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
